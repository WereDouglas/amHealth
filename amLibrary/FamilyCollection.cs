using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public class FamilyCollection : DBObject, IEnumerable<Family>
    {
        #region Members
        private List<Family> _familys;
        #endregion

        #region Properties
        public int Count
        { get { return _familys.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public FamilyCollection(DBObject parent)
            :base(parent)
        {          
            _familys = new List<Family>();
           // _familys.Clear();
        }

        public Family Add()
        {
            Family u = new Family(this);            
            _familys.Add(u);
            return u;
        }

        public IEnumerator<Family> GetEnumerator()
        {
            foreach (var item in _familys)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _familys.Clear();
            string sql = "select * from [family]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                    Family u=Add();
                    u.Id = row["id"].ToString();
                    u.Patient = row["patient"].ToString();
                    u.Name = row["name"].ToString();                  
                    u.Notify = row["notify"].ToString();                   
                    u.Phone = row["phone"].ToString();
                    u.Email = row["email"].ToString();                
                    u.Image = "C:\\amHealth\\images\\" + row["image"].ToString();
                    u.Sync = row["sync"].ToString();
                    u.Relationship = row["relationship"].ToString(); 
               //  _familys.Add(u);
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _familys.Clear();
            Load();
        }
    }
}
