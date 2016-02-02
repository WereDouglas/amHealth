using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
    public class Message : DBObject
    {
        public Message(DBObject parent)
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
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _contact;

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
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
        private string _sent;

        public string Sent
        {
            get { return _sent; }
            set { _sent = value; }
        }

        public override void Save()
        {
            if (Type == " " || Content == " ")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [message](id,org,type,content,contact,dor,sync,sent)VALUES(@id,@org,@type,@content,@contact,@dor,@sync,@sent)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@org", Org);
                cmd.Parameters.AddWithValue("@type", Type);
                cmd.Parameters.AddWithValue("@content", Content);
                cmd.Parameters.AddWithValue("@contact", Contact);
                cmd.Parameters.AddWithValue("@dor", Dor);
                cmd.Parameters.AddWithValue("@sent", Sent);
                cmd.Parameters.AddWithValue("@sync", Sync);

                ExecuteNonQuery(cmd);
                //System.Diagnostics.Debug.WriteLine(cmd);

            }
        }
        // _message.Update(Id, ftype.Text,ltype.Text,dor.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

        public void Update(string id,string sent)
        {
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [message] SET sent='" + sent + "' WHERE id = '" + id + "'";
            
            ExecuteNonQuery(cmd);

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [message] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [message]";
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
