using amHealth.View;
using amLibrary;
using amLibrary.Helpers;
using AutoUpdaterDotNET;
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
            Loading inputDialog = new Loading();
            if (inputDialog.ShowDialog() == true)
                InitializeComponent();

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

           
              Timer timer = new Timer(1000*60*60);
              timer.Elapsed += timer_Elapsed;
              timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!bw.IsBusy)
                tasks();
                 Console.WriteLine("this is another call doug every minute");
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

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start(Sending.directoryUrl + "amHealth.xml");
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
            if (!bw.IsBusy)
                tasks();

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
                //this.tbProgress.Content = "Canceled!";
            }

            else if (!(e.Error == null))
            {
               // this.tbProgress.Content = ("Error: " + e.Error.Message);
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

            System.Threading.Thread.Sleep(5000);

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
                                        return;
                                    }
                                    if (t.Message.Contains("No data"))
                                    {
                                        MessageBox.Show(" i think you donot have enough credit to send messages");
                                        return;
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
                else {
                    
                    return;
                
                }

            }
            else
            {

            }
        }
    }
}
