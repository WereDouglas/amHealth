using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class AllergyCollection : DBObject, IEnumerable<Allergy>
    {
        #region Allergys
        private List<Allergy> _allergys;
        #endregion

        #region Properties
        public int Count
        { get { return _allergys.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public AllergyCollection(DBObject parent)
            : base(parent)
        {
            _allergys = new List<Allergy>();
            // _allergys.Clear();
        }

        public Allergy Add()
        {
            Allergy u = new Allergy(this);
            _allergys.Add(u);
            return u;
        }

        public IEnumerator<Allergy> GetEnumerator()
        {
            foreach (var item in _allergys)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _allergys.Clear();
            string sql = "select * from [allergy]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Allergy u = Add();
                u.Id = row["id"].ToString();
                u.Org = row["org"].ToString();               
                u.Name = row["name"].ToString();                       
                u.Sync = row["sync"].ToString();
             
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _allergys.Clear();
            Load();
        }
    }
}
