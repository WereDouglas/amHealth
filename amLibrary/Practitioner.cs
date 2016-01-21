using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Practitioner : DBObject
    {
       public Practitioner(DBObject parent)
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
       private string _org;

       public string Org
       {
           get { return _org; }
           set { _org = value; }
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
       private string _practice;

       public string Practice
       {
           get { return _practice; }
           set { _practice = value; }
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
               cmd.CommandText = "INSERT INTO [practitioner](id,org,name,practice,phone,email,image,sync)VALUES(@id,@org,@name,@practice,@phone,@email,@image,@sync)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@org", Org);
               cmd.Parameters.AddWithValue("@name", Name);             
               cmd.Parameters.AddWithValue("@practice", Practice);              
               cmd.Parameters.AddWithValue("@phone", Phone);
               cmd.Parameters.AddWithValue("@email", Email);              
               cmd.Parameters.AddWithValue("@image", Image);             
               cmd.Parameters.AddWithValue("@sync", Sync);

               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _practitioner.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

       public void Update(string id, string name, string phone, string email, string practice)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [practitioner] SET name='" + name + "',phone='" + phone + "',email='" + email + "',practice='" + practice + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [practitioner] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [practitioner]";
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
