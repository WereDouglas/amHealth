using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
    public class Group : DBObject
    {
        public Group(DBObject parent)
            : base(parent)
        {
            Id = Guid.NewGuid().ToString();

        }
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _filters;

        public string Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }
        private string _dor;

        public string Dor
        {
            get { return _dor; }
            set { _dor = value; }
        }
        private int _counts;

        public int Counts
        {
            get { return _counts; }
            set { _counts = value; }
        }

        private string _org;

        public string Org
        {
            get { return _org; }
            set { _org = value; }
        }


        private string _sync;

        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }

        public override void Save()
        {
            if (Name == " " || Filters == " ")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [groups](id,org,name,filters,dor,sync)VALUES(@id,@org,@name,@filters,@dor,@sync)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@org", Org);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@filters", Filters);
                cmd.Parameters.AddWithValue("@dor", Dor);
                cmd.Parameters.AddWithValue("@sync", Sync);

                ExecuteNonQuery(cmd);
                //System.Diagnostics.Debug.WriteLine(cmd);

            }
        }
        // _group.Update(Id, fname.Text,lname.Text,dor.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

        public void Update(string id, string name, string filters)
        {
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [groups] SET name='" + name + "',filters='" + filters + "' WHERE id = '" + id + "'";


            ExecuteNonQuery(cmd);

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [groups] WHERE id ='" + Id + "'";
            try
            {

                ExecuteNonQuery(cmd);
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
            finally
            {

            }
            return true;

        }
        public bool Deleteall()
        {
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [group]";
            try
            {

                ExecuteNonQuery(cmd);
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
            finally
            {

            }
            return true;

        }



    }
}
