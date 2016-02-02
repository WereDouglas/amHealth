using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Family : DBObject
    {
       public Family(DBObject parent)
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
       private string _relationship;

       public string Relationship
       {
           get { return _relationship; }
           set { _relationship = value; }
       }
       private string _prefs;

       public string Prefs
       {
           get { return _prefs; }
           set { _prefs = value; }
       }

       private string _name;

       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }
       private string _patient;

       public string Patient
       {
           get { return _patient; }
           set { _patient = value; }
       }
       private string _lname;

     
       private string _phone;

       public string Phone
       {
           get { return _phone; }
           set { _phone = value; }
       }

       private string _email;

       public string Email
       {
           get { return _email; }
           set { _email = value; }
       }
       private string _notify;

       public string Notify
       {
           get { return _notify; }
           set { _notify = value; }
       }

       
       private string _image;

       public string Image
       {
           get { return _image; }
           set { _image = value; }
       }
       private string _sync;

       public string Sync
       {
           get { return _sync; }
           set { _sync = value; }
       }

       public override void Save()
       {
           if (Name == "" || Phone == "")
           {
               throw new Exception("Empty fields");
           }

           else
           {
               SqlCeCommand cmd = con.CreateCommand();
               cmd.CommandText = "INSERT INTO [family](id,patient,name,notify,phone,email,image,sync,relationship)VALUES(@id,@patient,@name,@notify,@phone,@email,@image,@sync,@relationship)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@patient", Patient);
               cmd.Parameters.AddWithValue("@name", Name);             
               cmd.Parameters.AddWithValue("@notify", Notify);              
               cmd.Parameters.AddWithValue("@phone", Phone);
               cmd.Parameters.AddWithValue("@relationship", Relationship);
               cmd.Parameters.AddWithValue("@email", Email);              
               cmd.Parameters.AddWithValue("@image", Image);             
               cmd.Parameters.AddWithValue("@sync", Sync);

               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _family.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

       public void Update(string id, string name, string phone, string email, string notify)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [family] SET name='" + name + "',phone='" + phone + "',email='" + email + "',notify='" + notify + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [family] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [family]";
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
