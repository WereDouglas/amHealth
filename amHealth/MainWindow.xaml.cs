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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amHealth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Patient> _patientList = null;
        private Patient p;
        private Message _message;
        private ObservableCollection<Message> _messageList = null;
        private BackgroundWorker bw = new BackgroundWorker();
        public MainWindow()
        {

            InitializeComponent();
            createDb();
            CreateDB2();

            _messageList = new ObservableCollection<Message>(App.amApp.Messages);
            _mainFrame.NavigationService.Navigate(new Uri("view/QueuePage.xaml", UriKind.Relative));

            if (Messenger.IsInternetAvailable())
            {
                internet.Content = "Internet connection active";
            }
            else
            {
                internet.Content = "No Internet connection";
            }

            tasks();
            Timer timer = new Timer(1000 * 60);
            timer.Elapsed += timer_Elapsed;
            timer.Start();

        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
            Console.WriteLine("this is another call doug every minute");
        }


        private void CreateDB2()
        {
            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (!Helper.TableExists(conn, "queue"))
            {
                cmd.CommandText = "CREATE TABLE queue (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL,payment nvarchar(255) NULL, amount nvarchar(255)  NULL,checked nvarchar(255) NULL,day nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL,seen nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
            }
            if (!Helper.TableExists(conn, "messages"))
            {
                cmd.CommandText = "CREATE TABLE messages (id nvarchar(255)  NULL, org nvarchar(255)  NULL, type nvarchar(255)  NULL,content nvarchar(255) NULL,contact nvarchar(255) NULL, sent nvarchar(255)  NULL,dor nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
            }

            if (!Helper.TableExists(conn, "appointment"))
            {
                cmd.CommandText = "CREATE TABLE appointment (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL, dated nvarchar(255) NULL, startTime nvarchar(255)  NULL,endTime nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL,meet nvarchar(255) NULL,reminder nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table appointments");
            }
            conn.Close();
        }

        public void tasks()
        {

            bw.RunWorkerAsync();
            bw.WorkerReportsProgress = true;
            //  bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }
        private void createDb()
        {

            string fileName = @"c:\amHealth\amHealth.sdf";
            if (!File.Exists(fileName))
            {
                CreateDB();
            }
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);

        }

        private void CreateDB()
        {
            // public static string conString = @"Data Source=C:\transporter\wimea.sdf;Password=wimea; Persist Security Info=True;";
            string path = @"c:\amHealth";
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.",
            Directory.GetCreationTime(path));




            string paths = @"c:\amHealth\images";
            if (Directory.Exists(paths))
            {
                Console.WriteLine("That path exists already.");
                return;
            }
            // Try to create the directory.
            DirectoryInfo dim = Directory.CreateDirectory(paths);
            Console.WriteLine("The directory was created successfully at {0}.",
            Directory.GetCreationTime(paths));

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");
            SqlCeEngine en = new SqlCeEngine(con);
            en.CreateDatabase();

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (!TableExists(conn, "patient"))
            {
                cmd.CommandText = "CREATE TABLE patient (id nvarchar(255)  NULL, org nvarchar(255)  NULL,fname nvarchar(255) NULL, lname nvarchar(255) NULL, gender nvarchar(255) NULL, dob nvarchar(255) NULL, height nvarchar(255)  NULL, weight nvarchar(255)  NULL, phone nvarchar(255)  NULL,email nvarchar(255) NULL,region nvarchar(255) NULL,image nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table users");
            }

            if (!TableExists(conn, "practitioner"))
            {
                cmd.CommandText = "CREATE TABLE practitioner (id nvarchar(255)  NULL, org nvarchar(255)  NULL,name nvarchar(255) NULL, practice nvarchar(255) NULL, phone nvarchar(255)  NULL,email nvarchar(255) NULL,image nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table practitioners");
            }

            if (!TableExists(conn, "appointment"))
            {
                cmd.CommandText = "CREATE TABLE appointment (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL, dated nvarchar(255) NULL, startTime nvarchar(255)  NULL,endTime nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL,meet nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table appointments");
            }

            conn.Close();

        }

        public bool TableExists(SqlCeConnection connection, string tableName)
        {
            using (var command = new SqlCeCommand())
            {
                command.Connection = connection;
                var sql = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{0}'", tableName);
                command.CommandText = sql;
                var count = Convert.ToInt32(command.ExecuteScalar());
                return (count > 0);
            }
        }


        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/MessagePage.xaml", UriKind.Relative));
            _messageList = new ObservableCollection<Message>(App.amApp.Messages);
            modem.Content = (_messageList.Where(m => m.Sent == "F").Count()).ToString() + " unsent messages";
        }

        private void patient_click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/PatientPage.xaml", UriKind.Relative));

        }

        private void btnAppointment(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/AppointmentPage.xaml", UriKind.Relative));
        }

        private void Prac_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/PractitionerPage.xaml", UriKind.Relative));
        }

        private void Advanced_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/AdvancedPage.xaml", UriKind.Relative));

        }

        private void Modem_Click(object sender, RoutedEventArgs e)
        {
            modem.Content = "modem connecting....................";
            Messenger.connect();

            if (Messenger.connect() == "true")
            {
                modem.Content = "modem connected :" + (_messageList.Where(m => m.Sent == "F").Count()).ToString() + " unsent messages";

                tasks();
                modem.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                modem.Foreground = new SolidColorBrush(Colors.Red);
                modem.Content = "no modem connected!  :" + (_messageList.Where(m => m.Sent == "F").Count()).ToString() + " unsent messages";
            }

        }

        private void Queue_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/QueuePage.xaml", UriKind.Relative));
        }

        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/MessagesPage.xaml", UriKind.Relative));
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                // this.tbProgress.Content = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                ///this.tbProgress.Content = ("Error: " + e.Error.Message);
            }

            else
            {
                // this.tbProgress.Content = "All messages sent";
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress.Content = (e.ProgressPercentage.ToString() + "Count");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            send();

            System.Threading.Thread.Sleep(500);

        }

        public void send()
        {
            Messenger.connect();

            if (Messenger.connect() == "true")
            {
                Reminder.Remind();
                _messageList = new ObservableCollection<Message>(App.amApp.Messages);
                if (_messageList.Where(y => y.Sent == "F").Count() > 0)
                {
                    if (MessageBox.Show("would you like to send all unsent messages ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        foreach (Message u in _messageList)
                        {
                            if (u.Sent == "F")
                            {
                                try
                                {
                                    Messenger.SendUpdate(App.amApp, u.Id, u.Content, u.Contact);
                                }
                                catch (Exception t)
                                {

                                    if (t.Message.Contains("service error"))
                                    {
                                        MessageBox.Show("you do not have enough credits");
                                    }
                                    if (t.Message.Contains("No data"))
                                    {
                                        MessageBox.Show(" i think you donot have enough credit to send messages");
                                    }

                                }

                            }
                        }
                    }

                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                
            }
        }
    }
}
