using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class Queue : DBObject
    {
       public Queue(DBObject parent)
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
       private string _day;

       public string Day
       {
           get { return _day; }
           set { _day = value; }
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
       private string _payment;

       public string Payment
       {
           get { return _payment; }
           set { _payment = value; }
       }
       private string _amount;

       public string Amount
       {
           get { return _amount; }
           set { _amount = value; }
       }
       private string _checked;

       public string Checked
       {
           get { return _checked; }
           set { _checked = value; }
       }
       private string _reason;

       public string Reason
       {
           get { return _reason; }
           set { _reason = value; }
       }
       private string _patientimage;

       public string Patientimage
       {
           get { return _patientimage; }
           set { _patientimage = value; }
       }
       private string _sync;

       public string Sync
       {
           get { return _sync; }
           set { _sync = value; }
       }
       private string _details;

       public string Details
       {
           get { return _details; }
           set { _details = value; }
       }

       private string _seen;

       public string Seen
       {
           get { return _seen; }
           set { _seen = value; }
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
               cmd.CommandText = "INSERT INTO [queue](id,org,patient,practitioner ,payment , amount ,checked,day,reason,sync,seen)VALUES(@id,@org,@patient,@practitioner,@payment,@amount,@checked,@day,@reason,@sync,@seen)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@org", Org);
               cmd.Parameters.AddWithValue("@patient", Patient);             
               cmd.Parameters.AddWithValue("@practitioner", Practitioner);              
               cmd.Parameters.AddWithValue("@payment", Payment);
               cmd.Parameters.AddWithValue("@amount", Amount);              
               cmd.Parameters.AddWithValue("@checked", Checked);
               cmd.Parameters.AddWithValue("@day", Day);
               cmd.Parameters.AddWithValue("@reason", Reason);
               cmd.Parameters.AddWithValue("@seen", Seen);
               cmd.Parameters.AddWithValue("@sync", Sync);

               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _queue.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");

       public void Update(string id, string amount, string payment, string seen)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [queue] SET amount='" + amount + "',payment='" + payment + "',seen='" + seen + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [queue] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [queue]";
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
