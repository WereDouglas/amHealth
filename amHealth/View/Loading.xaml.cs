using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace amHealth.View
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        private Timer timer;
       
        private BackgroundWorker bw = new BackgroundWorker();
       
        public Loading()
        {           
            InitializeComponent();
            status.Text = "Loading.....................";
            string fileName = @"c:\amHealth\amHealth.sdf";

            if (File.Exists(fileName))
            {
                 //Delete();
                CreateDB();
                Timer timer = new Timer(100);
                timer.Elapsed += timer_Elapsed;
                timer.Start();   
               
            }
            else
            {

                Timer timer = new Timer(400);
                timer.Elapsed += timer_Elapsed;
                timer.Start();

                CreateDirectories(); 
                CreateDB();
               
                
            }
                

                   

          }    
      
       

       
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
            {

                if (proggre.Value < 10)
                {
                    proggre.Value += 1;
                }
                else if (proggre.Value == 10)
                {
                    try
                    {
                       
                        this.DialogResult = true;
                        timer.Stop();
                    }
                    catch
                    {

                    }

                }
            }));



        }

        StringBuilder builder = new StringBuilder();
        private void CreateDirectories()
        {
            builder.Append(Environment.NewLine + "Creating directories.....");
            // public static string conString = @"Data Source=C:\transporter\wimea.sdf;Password=wimea; Persist Security Info=True;";
            string path = @"c:\amHealth";
            if (Directory.Exists(path))
            {
                builder.Append(Environment.NewLine + "That path exists already..........");
                return;
            }
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);

            builder.Append(Environment.NewLine + ("The directory was created successfully at " + Directory.GetCreationTime(path)));

            string paths = @"c:\amHealth\images";
            if (Directory.Exists(paths))
            {
                builder.Append(Environment.NewLine + ("image path exists already."));
                return;
            }
            // Try to create the directory.
            DirectoryInfo dim = Directory.CreateDirectory(paths);
            Console.WriteLine("The directory was created successfully at {0}.",
            Directory.GetCreationTime(paths));
            builder.Append(Environment.NewLine + "Image path created");

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");
            SqlCeEngine en = new SqlCeEngine(con);
            en.CreateDatabase();

            builder.Append(Environment.NewLine + "Database created");
        }

        private void CreateDB()
        {
            builder.Append(Environment.NewLine + "Creating database tables.....");
            string con;

            con = string.Format(@"Data Source=c:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            if (!Helper.TableExists(conn, "patient"))
            {
                cmd.CommandText = "CREATE TABLE patient (id nvarchar(255)  NULL, org nvarchar(255)  NULL,fname nvarchar(255) NULL, lname nvarchar(255) NULL, gender nvarchar(255) NULL, dob nvarchar(255) NULL, height nvarchar(255)  NULL, weight nvarchar(255)  NULL, phone nvarchar(255)  NULL,email nvarchar(255) NULL,region nvarchar(255) NULL,image nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table users");
            }
            if (!Helper.TableExists(conn, "queue"))
            {
                cmd.CommandText = "CREATE TABLE queue (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL,payment nvarchar(255) NULL, amount nvarchar(255)  NULL,checked nvarchar(255) NULL,day nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL,seen nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
            }
            if (!Helper.TableExists(conn, "message"))
            {
                cmd.CommandText = "CREATE TABLE message (id nvarchar(255)  NULL, org nvarchar(255)  NULL, type nvarchar(255)  NULL,content nvarchar(255) NULL,contact nvarchar(255) NULL, sent nvarchar(255)  NULL,dor nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
            }
            if (!Helper.TableExists(conn, "groups"))
            {
                cmd.CommandText = "CREATE TABLE groups (id nvarchar(255)  NULL, org nvarchar(255)  NULL,name nvarchar(255) NULL, filters nvarchar(255) NULL, dor nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table group");
            }
            if (!Helper.TableExists(conn, "member"))
            {
                cmd.CommandText = "CREATE TABLE member (id nvarchar(255)  NULL, org nvarchar(255)  NULL, uploadname nvarchar(255) NULL,name nvarchar(255) NULL, contact nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table member");
            }

            if (!Helper.TableExists(conn, "chronic"))
            {
                cmd.CommandText = "CREATE TABLE chronic (id nvarchar(255)  NULL, org nvarchar(255)  NULL,name nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table chronic");
            }

            if (!Helper.TableExists(conn, "allergy"))
            {
                cmd.CommandText = "CREATE TABLE allergy (id nvarchar(255)  NULL, org nvarchar(255)  NULL,name nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table allergy");
            }

            if (!Helper.TableExists(conn, "practitioner"))
            {
                cmd.CommandText = "CREATE TABLE practitioner (id nvarchar(255)  NULL, org nvarchar(255)  NULL,name nvarchar(255) NULL, practice nvarchar(255) NULL, phone nvarchar(255)  NULL,email nvarchar(255) NULL,image nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table practitioners");
            }
            if (!Helper.TableExists(conn, "family"))
            {
                cmd.CommandText = "CREATE TABLE family (id nvarchar(255)  NULL, patient nvarchar(255)  NULL,name nvarchar(255) NULL, notify nvarchar(255) NULL, phone nvarchar(255)  NULL,email nvarchar(255) NULL,image nvarchar(255) NULL,sync nvarchar(255) NULL,relationship nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table family");
            }

            if (!Helper.TableExists(conn, "appointment"))
            {
                cmd.CommandText = "CREATE TABLE appointment (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL, dated nvarchar(255) NULL, startTime nvarchar(255)  NULL,endTime nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL,meet nvarchar(255) NULL, reminder nvarchar(255)  NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table appointments");
            }


            if (!Helper.TableExists(conn, "chronicMap"))
            {
                cmd.CommandText = "CREATE TABLE chronicMap (id nvarchar(255)  NULL, patient nvarchar(255)  NULL,chronic nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table chronic");
            }

            if (!Helper.TableExists(conn, "allergyMap"))
            {
                cmd.CommandText = "CREATE TABLE allergyMap (id nvarchar(255)  NULL, patient nvarchar(255)  NULL,allergy nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table allergy");
            }
            

            conn.Close();
        }


       
        private void Delete()
        {

            string con;
            con = string.Format(@"Data Source=c:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");
            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (Helper.TableExists(conn, "appointment"))
            {
                cmd.CommandText = "DROP TABLE appointment";
                cmd.ExecuteNonQuery();

            }
            conn.Close();

        }


    }
}