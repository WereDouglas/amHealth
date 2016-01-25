using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public class AppointmentCollection : DBObject, IEnumerable<Appointment>
    {
        #region Members
        private List<Appointment> _appointments;
        #endregion

        #region Properties
        public int Count
        { get { return _appointments.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public AppointmentCollection(DBObject parent)
            : base(parent)
        {
            _appointments = new List<Appointment>();
            // _appointments.Clear();
        }

        public Appointment Add()
        {
            Appointment u = new Appointment(this);
            _appointments.Add(u);
            return u;
        }

        public IEnumerator<Appointment> GetEnumerator()
        {
            foreach (var item in _appointments)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _appointments.Clear();
            string sql = "select * from [appointment]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Appointment u = Add();
                u.Id = row["id"].ToString();
                u.Org = row["org"].ToString();
                u.Patient = row["patient"].ToString();
                u.Practitioner = row["practitioner"].ToString();
                u.Dated = row["dated"].ToString();
                u.StartTime = row["startTime"].ToString();
                u.EndTime = row["endTime"].ToString();
                u.Reason = row["reason"].ToString();
                u.Sync = row["sync"].ToString();
                u.Meet = row["meet"].ToString();
                u.Reminder = row["reminder"].ToString();
                //  _appointments.Add(u);
            }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _appointments.Clear();
            Load();
        }
    }
}
