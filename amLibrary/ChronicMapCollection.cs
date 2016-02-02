using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class ChronicMapCollection : DBObject, IEnumerable<ChronicMap>
    {
        #region ChronicMaps
        private List<ChronicMap> _chronicMaps;
        #endregion

        #region Properties
        public int Count
        { get { return _chronicMaps.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public ChronicMapCollection(DBObject parent)
            : base(parent)
        {
            _chronicMaps = new List<ChronicMap>();
            // _chronicMaps.Clear();
        }

        public ChronicMap Add()
        {
            ChronicMap u = new ChronicMap(this);
            _chronicMaps.Add(u);
            return u;
        }

        public IEnumerator<ChronicMap> GetEnumerator()
        {
            foreach (var item in _chronicMaps)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _chronicMaps.Clear();
            string sql = "select * from [chronicMap]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                ChronicMap u = Add();
                u.Id = row["id"].ToString();
                u.Patient = row["patient"].ToString();               
                u.Chronic = row["chronic"].ToString();                       
                u.Sync = row["sync"].ToString();
             
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _chronicMaps.Clear();
            Load();
        }
    }
}
