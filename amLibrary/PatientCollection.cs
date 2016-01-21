using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data;

namespace amLibrary
{
    public  class PatientCollection : DBObject, IEnumerable<Patient>
    {
        #region Members
        private List<Patient> _patients;
        #endregion

        #region Properties
        public int Count
        { get { return _patients.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public PatientCollection(DBObject parent)
            : base(parent)
        {
            _patients = new List<Patient>();
            // _patients.Clear();
        }

        public Patient Add()
        {
            Patient u = new Patient(this);
            _patients.Add(u);
            return u;
        }

        public IEnumerator<Patient> GetEnumerator()
        {
            foreach (var item in _patients)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _patients.Clear();
            string sql = "select * from [patient]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Patient u = Add();
                u.Id = row["id"].ToString();
                u.Org = row["org"].ToString();
                u.Fname = row["fname"].ToString();
                u.Lname = row["lname"].ToString();
                u.Gender = row["gender"].ToString();
                u.Dob = row["dob"].ToString();
                u.Height = row["height"].ToString();
                u.Weight = row["weight"].ToString();
                u.Phone = row["phone"].ToString();
                u.Email = row["email"].ToString();
                u.Region = row["region"].ToString();
                u.Image = "C:\\amHealth\\images\\" + row["image"].ToString();
                u.Sync = row["sync"].ToString();
                u.Age =  Validator.Aged(Convert.ToDateTime(row["dob"].ToString()), DateTime.Now).ToString();
                //  _patients.Add(u);
            }
            IsLoaded = true;
        }
   
        public void Refresh()
        {
            _patients.Clear();
            Load();
        }
    }
}
