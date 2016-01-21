using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public class GroupCollection : DBObject, IEnumerable<Group>
    {
        #region Members
        private List<Group> _groups;
        #endregion

        #region Properties
        public int Count
        { get { return _groups.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public GroupCollection(DBObject parent)
            :base(parent)
        {          
            _groups = new List<Group>();
           // _groups.Clear();
        }

        public Group Add()
        {
            Group u = new Group(this);            
            _groups.Add(u);
            return u;
        }

        public IEnumerator<Group> GetEnumerator()
        {
            foreach (var item in _groups)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _groups.Clear();
            string sql = "select * from [groups]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                    Group u=Add();
                    u.Id = row["id"].ToString();
                    u.Org = row["org"].ToString();
                    u.Name = row["name"].ToString();
                    u.Filters = row["filters"].ToString();                  
                    u.Dor = row["dor"].ToString();                   
                    u.Sync = row["sync"].ToString(); 
                   
              
            }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _groups.Clear();
            Load();
        }
    }
}
