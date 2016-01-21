using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Patient : DBObject
    {
       public Patient(DBObject parent)
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
       private string _fname;

       public string Fname
       {
           get { return _fname; }
           set { _fname = value; }
       }
       private string _lname;

       public string Lname
       {
           get { return _lname; }
           set { _lname = value; }
       }
       private string _gender;

       public string Gender
       {
           get { return _gender; }
           set { _gender = value; }
       }
       private string _dob;

       public string Dob
       {
           get { return _dob; }
           set { _dob = value; }
       }
       private string _age;

       public string Age
       {
           get { return _age; }
           set { _age = value; }
       }
      

       private string _height;

       public string Height
       {
           get { return _height; }
           set { _height = value; }
       }
       private string _weight;

       public string Weight
       {
           get { return _weight; }
           set { _weight = value; }
       }
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
       private string _region;

       public string Region
       {
           get { return _region; }
           set { _region = value; }
       }
       private string _org;

       public string Org
       {
           get { return _org; }
           set { _org = value; }
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
           if (Fname == "" || Lname == "")
           {
               throw new Exception("Empty fields");
           }

           else
           {
               SqlCeCommand cmd = con.CreateCommand();
               cmd.CommandText = "INSERT INTO [patient](id,org,fname,lname,gender,dob,height,weight,phone,email,region,image,sync)VALUES(@id,@org,@fname,@lname,@gender,@dob,@height,@weight,@phone,@email,@region,@image,@sync)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@org", Org);
               cmd.Parameters.AddWithValue("@fname", Fname);
               cmd.Parameters.AddWithValue("@lname", Lname);
               cmd.Parameters.AddWithValue("@gender", Gender);
               cmd.Parameters.AddWithValue("@dob", Dob);
               cmd.Parameters.AddWithValue("@height", Height);
               cmd.Parameters.AddWithValue("@weight", Weight);
               cmd.Parameters.AddWithValue("@phone", Phone);
               cmd.Parameters.AddWithValue("@email", Email);
               cmd.Parameters.AddWithValue("@region", Region);
               cmd.Parameters.AddWithValue("@image", Image);             
               cmd.Parameters.AddWithValue("@sync", Sync);

               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _patient.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");
              
             public void Update(string id, string fname, string lname, string gender, string dob, string height,string weight,string phone,string email,string region)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [patient] SET fname='" + fname + "',lname='" + lname + "',phone='" + phone + "',email='" + email + "',height='" + height + "',weight='" + weight + "',gender='" + gender + "',dob ='" + dob + "',region='" + region + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [patient] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [patient]";
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
