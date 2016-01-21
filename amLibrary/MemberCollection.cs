using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class MemberCollection : DBObject, IEnumerable<Member>
    {
        #region Members
        private List<Member> _members;
        #endregion

        #region Properties
        public int Count
        { get { return _members.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public MemberCollection(DBObject parent)
            : base(parent)
        {
            _members = new List<Member>();
            // _members.Clear();
        }

        public Member Add()
        {
            Member u = new Member(this);
            _members.Add(u);
            return u;
        }

        public IEnumerator<Member> GetEnumerator()
        {
            foreach (var item in _members)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _members.Clear();
            string sql = "select * from [member]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Member u = Add();
                u.Id = row["id"].ToString();
                u.Org = row["org"].ToString();
                u.Uploadname = row["uploadname"].ToString();
                u.Name = row["name"].ToString();
                u.Contact = row["contact"].ToString();                
                u.Sync = row["sync"].ToString();
             
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _members.Clear();
            Load();
        }
    }
}
