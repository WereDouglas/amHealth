using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class ChronicCollection : DBObject, IEnumerable<Chronic>
    {
        #region Chronics
        private List<Chronic> _chronics;
        #endregion

        #region Properties
        public int Count
        { get { return _chronics.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public ChronicCollection(DBObject parent)
            : base(parent)
        {
            _chronics = new List<Chronic>();
            // _chronics.Clear();
        }

        public Chronic Add()
        {
            Chronic u = new Chronic(this);
            _chronics.Add(u);
            return u;
        }

        public IEnumerator<Chronic> GetEnumerator()
        {
            foreach (var item in _chronics)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _chronics.Clear();
            string sql = "select * from [chronic]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Chronic u = Add();
                u.Id = row["id"].ToString();
                u.Org = row["org"].ToString();               
                u.Name = row["name"].ToString();                       
                u.Sync = row["sync"].ToString();
             
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _chronics.Clear();
            Load();
        }
    }
}
