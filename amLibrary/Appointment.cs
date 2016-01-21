using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Appointment : DBObject
    {
       public Appointment(DBObject parent)
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
      

       private string _org;

       public string Org
       {
           get { return _org; }
           set { _org = value; }
       }
       private string _patient;

       public string Patient
       {
           get { return _patient; }
           set { _patient = value; }
       }
       private string _practitioner;

       public string Practitioner
       {
           get { return _practitioner; }
           set { _practitioner = value; }
       }
       private string _dated;

       public string Dated
       {
           get { return _dated; }
           set { _dated = value; }
       }
       private string _startTime;

       public string StartTime
       {
           get { return _startTime; }
           set { _startTime = value; }
       }
       private string _endTime;

       public string EndTime
       {
           get { return _endTime; }
           set { _endTime = value; }
       }
       private string _reason;

       public string Reason
       {
           get { return _reason; }
           set { _reason = value; }
       }
       private string _sync;

       public string Sync
       {
           get { return _sync; }
           set { _sync = value; }
       }

       public override void Save()
       {
           if (Practitioner == "" || Patient == "")
           {
               throw new Exception("Empty fields");
           }

           else
           {
               SqlCeCommand cmd = con.CreateCommand();
               cmd.CommandText = "INSERT INTO [appointment](id ,org, patient,practitioner ,dated , startTime ,endTime ,reason ,sync)VALUES(@id ,@org,@patient,@practitioner,@dated,@startTime,@endTime,@reason,@sync)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@org", Org);
               cmd.Parameters.AddWithValue("@patient", Patient);             
               cmd.Parameters.AddWithValue("@practitioner", Practitioner);              
               cmd.Parameters.AddWithValue("@dated", Dated);
               cmd.Parameters.AddWithValue("@startTime", StartTime);              
               cmd.Parameters.AddWithValue("@endTime", EndTime);
               cmd.Parameters.AddWithValue("@reason", Reason); 
               cmd.Parameters.AddWithValue("@sync", Sync);

               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _appointment.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

       public void Update(string id, string name, string phone, string email, string practice)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [appointment] SET fname='" + name + "',phone='" + phone + "',email='" + email + "',practice='" + practice + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [appointment] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [appointment]";
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
