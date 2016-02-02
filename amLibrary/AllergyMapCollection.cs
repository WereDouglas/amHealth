using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class AllergyMapCollection : DBObject, IEnumerable<AllergyMap>
    {
        #region AllergyMaps
        private List<AllergyMap> _allergyMaps;
        #endregion

        #region Properties
        public int Count
        { get { return _allergyMaps.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public AllergyMapCollection(DBObject parent)
            : base(parent)
        {
            _allergyMaps = new List<AllergyMap>();
            // _allergyMaps.Clear();
        }

        public AllergyMap Add()
        {
            AllergyMap u = new AllergyMap(this);
            _allergyMaps.Add(u);
            return u;
        }

        public IEnumerator<AllergyMap> GetEnumerator()
        {
            foreach (var item in _allergyMaps)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _allergyMaps.Clear();
            string sql = "select * from [allergyMap]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                AllergyMap u = Add();
                u.Id = row["id"].ToString();
                u.Patient = row["patient"].ToString();               
                u.Allergy = row["allergy"].ToString();                       
                u.Sync = row["sync"].ToString();
             
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _allergyMaps.Clear();
            Load();
        }
    }
}
