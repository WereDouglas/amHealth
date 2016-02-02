using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Member : DBObject
    {
       public Member(DBObject parent)
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

       private string _uploadname;
       public string Uploadname
       {
           get { return _uploadname; }
           set { _uploadname = value; }
       }

       private string _name;

       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }
       private string _contact;

       public string Contact
       {
           get { return _contact; }
           set { _contact = value; }
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
           if (Name == "" || Contact == "")
           {
               throw new Exception("Empty fields");
           }

           else
           {
               SqlCeCommand cmd = con.CreateCommand();
               cmd.CommandText = "INSERT INTO [member](id,org,uploadname,name,contact,sync)VALUES(@id,@org,@uploadname,@name,@contact,@sync)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@org", Org);
               cmd.Parameters.AddWithValue("@uploadname", Uploadname);
               cmd.Parameters.AddWithValue("@name", Name);
               cmd.Parameters.AddWithValue("@contact", Contact);
               cmd.Parameters.AddWithValue("@sync", Sync);
               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _member.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");
              
             public void Update(string id, string fname, string lname, string gender, string dob, string height,string weight,string phone,string email,string region)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [member] SET fname='" + fname + "',lname='" + lname + "',phone='" + phone + "',email='" + email + "',height='" + height + "',weight='" + weight + "',gender='" + gender + "',dob ='" + dob + "',region='" + region + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [member] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [member]";
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
