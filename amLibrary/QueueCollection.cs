using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public class QueueCollection : DBObject, IEnumerable<Queue>
    {
        #region Members
        private List<Queue> _queues;
        #endregion

        #region Properties
        public int Count
        { get { return _queues.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public QueueCollection(DBObject parent)
            :base(parent)
        {          
            _queues = new List<Queue>();
           // _queues.Clear();
        }

        public Queue Add()
        {
            Queue u = new Queue(this);            
            _queues.Add(u);
            return u;
        }

        public IEnumerator<Queue> GetEnumerator()
        {
            foreach (var item in _queues)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _queues.Clear();
            string sql = "select * from [queue]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                    Queue u=Add();
                    u.Id = row["id"].ToString();
                    u.Org = row["org"].ToString();
                    u.Patient = row["patient"].ToString();                  
                    u.Practitioner = row["practitioner"].ToString();                   
                    u.Payment = row["payment"].ToString();
                    u.Amount= row["amount"].ToString();
                    u.Checked = row["checked"].ToString();
                    u.Day = row["day"].ToString();
                    u.Reason = row["reason"].ToString();                   
                    u.Sync = row["sync"].ToString(); 
               //  _queues.Add(u);
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _queues.Clear();
            Load();
        }
    }
}
