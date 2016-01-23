using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MainWindow()
        {
            InitializeComponent();
            createDb();
          
            _messageList = new ObservableCollection<Message>(App.amApp.Messages);
            _mainFrame.NavigationService.Navigate(new Uri("view/QueuePage.xaml", UriKind.Relative));

            Modem_Click(null, null);
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
                cmd.CommandText = "CREATE TABLE appointment (id nvarchar(255)  NULL, org nvarchar(255)  NULL, patient nvarchar(255)  NULL,practitioner nvarchar(255) NULL, dated nvarchar(255) NULL, startTime nvarchar(255)  NULL,endTime nvarchar(255) NULL,reason nvarchar(255) NULL,sync nvarchar(255) NULL);";
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
                modem.Content = "modem connected";

                if (MessageBox.Show("would you like to send all unsent messages ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (Message u in _messageList.Where(r=>r.Sent=="F"))
                    {
                        Messenger.SendUpdate(App.amApp,u.Id, u.Content, u.Contact);
           
                    }
                    

                }
                else
                {
                    return;
                } 
                modem.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                modem.Foreground = new SolidColorBrush(Colors.Red);
                modem.Content = "no modem connected!";
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
    }
}
