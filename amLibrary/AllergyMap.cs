using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amLibrary.Helpers;
using System.Data.SqlServerCe;

namespace amLibrary
{
   public class AllergyMap : DBObject
    {
       public AllergyMap(DBObject parent)
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

       private string _patient;

       public string Patient
       {
           get { return _patient; }
           set { _patient = value; }
       }
      
       
       private string _allergy;

       public string Allergy
       {
           get { return _allergy; }
           set { _allergy = value; }
       }
   
       private string _sync;

       public string Sync
       {
           get { return _sync; }
           set { _sync = value; }
       }

       public override void Save()
       {
           if (Patient == "" )
           {
               throw new Exception("Empty fields");
           }

           else
           {
               SqlCeCommand cmd = con.CreateCommand();
               cmd.CommandText = "INSERT INTO [allergyMap](id,allergy,patient,sync)VALUES(@id,@allergy,@patient,@sync)";
               cmd.Parameters.AddWithValue("@id", Id);
               cmd.Parameters.AddWithValue("@allergy", Allergy);              
               cmd.Parameters.AddWithValue("@patient", Patient);             
               cmd.Parameters.AddWithValue("@sync", Sync);
               ExecuteNonQuery(cmd);
               //System.Diagnostics.Debug.WriteLine(cmd);

           }
       }
       // _allergyMap.Update(Id, fpatient.Text,lpatient.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text,"");
              
             public void Update(string id, string fpatient, string lpatient, string gender, string dob, string height,string weight,string phone,string email,string region)
        {

          
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [allergyMap] SET fpatient='" + fpatient + "',lpatient='" + lpatient + "',phone='" + phone + "',email='" + email + "',height='" + height + "',weight='" + weight + "',gender='" + gender + "',dob ='" + dob + "',region='" + region + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [allergyMap] WHERE id ='" + Id + "'";
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
            cmd.CommandText = "DELETE FROM [allergyMap]";
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
