using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public class PractitionerCollection : DBObject, IEnumerable<Practitioner>
    {
        #region Members
        private List<Practitioner> _practitioners;
        #endregion

        #region Properties
        public int Count
        { get { return _practitioners.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public PractitionerCollection(DBObject parent)
            :base(parent)
        {          
            _practitioners = new List<Practitioner>();
           // _practitioners.Clear();
        }

        public Practitioner Add()
        {
            Practitioner u = new Practitioner(this);            
            _practitioners.Add(u);
            return u;
        }

        public IEnumerator<Practitioner> GetEnumerator()
        {
            foreach (var item in _practitioners)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _practitioners.Clear();
            string sql = "select * from [practitioner]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                    Practitioner u=Add();
                    u.Id = row["id"].ToString();
                    u.Org = row["org"].ToString();
                    u.Name = row["name"].ToString();                  
                    u.Practice = row["practice"].ToString();                   
                    u.Phone = row["phone"].ToString();
                    u.Email = row["email"].ToString();                
                    u.Image = "C:\\amHealth\\images\\" + row["image"].ToString();
                    u.Sync = row["sync"].ToString(); 
               //  _practitioners.Add(u);
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _practitioners.Clear();
            Load();
        }
    }
}
