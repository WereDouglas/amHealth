using amHealth.View;
using amHealth.View.Appointments;
using amHealth.View.queue;
using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
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
    /// Interaction logic for BlankPage.xaml
    /// </summary>
    public partial class QueuePage : Page
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;
        private Queue _queue;
        private ObservableCollection<Queue> _queueList = null;

        private Appointment _appointment;
        private ObservableCollection<Appointment> _appointmentList = null;
        public ObservableCollection<Queue> ListQueue = new ObservableCollection<Queue>();
        public ObservableCollection<Appointment> ListAppoint = new ObservableCollection<Appointment>();

        public QueuePage()
        {

           // DeleteQueue();

           
            InitializeComponent();
            selectdate.Text = DateTime.Now.Date.Date.ToString();
            Refresh();
        }
       

        private void Refresh()
        {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments);
            _queueList = new ObservableCollection<Queue>(App.amApp.Queues);
            appointmentcount.Content = "Appointments:" + _appointmentList.Where(k => k.Dated == selectdate.Text).Count().ToString();
            queuecount.Content = "People in queue :" + _queueList.Where(k => Convert.ToDateTime(k.Day).Date == Convert.ToDateTime(selectdate.Text).Date).Count().ToString();
            QueuelistView.ItemsSource = null;
            AppointmentlistView.ItemsSource = null;
            _appointment = new Appointment(null);

            ListQueue.Clear();
            ListAppoint.Clear();


            foreach (Queue Q in _queueList.Where(m => Convert.ToDateTime(m.Day).Date == Convert.ToDateTime(selectdate.Text).Date && m.Seen=="F"))
            {
                _queue = new Queue(null);
                _queue.Id = Q.Id;
                _queue.Org = Q.Org;
                _queue.Details = "PATIENT : \t" + _patientList.First(x => x.Id.Equals(Q.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(Q.Patient)).Lname + Environment.NewLine + "PRACTITIONER : \t" + _practitionerList.First(x => x.Id.Equals(Q.Practitioner)).Name + " " + Environment.NewLine + "TIME :" + Q.Checked + Environment.NewLine + "REASON: \t" + Q.Reason + " " + Environment.NewLine + "State:" + Q.Seen + " Amount paid:" + Q.Amount; ;
                _queue.Practitioner = Q.Practitioner;               
                _queue.Patient = Q.Patient;
                _queue.Patientimage = _patientList.First(x => x.Id.Equals(Q.Patient)).Image;
                _queue.Payment = Q.Payment;
                _queue.Amount = Q.Amount;
                _queue.Checked = Convert.ToDateTime(Q.Checked).ToString("T");
                _queue.Reason = Q.Reason;

                ListQueue.Add(_queue);
            }
            //apointment list view 
            QueuelistView.ItemsSource = ListQueue;


            foreach (Appointment T in _appointmentList.Where(i => i.Dated == selectdate.Text))
            {
                _appointment = new Appointment(null);
                _appointment.Id = T.Id;
                _appointment.Org = T.Org;
                _appointment.Details = "PATIENT : \t" + _patientList.First(x => x.Id.Equals(T.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(T.Patient)).Lname + Environment.NewLine + "PRACTITIONER : \t" + _practitionerList.First(x => x.Id.Equals(T.Practitioner)).Name + " " + Environment.NewLine + "PERIOD: \t \t " + T.Meet + "-" + T.EndTime +" "+ Environment.NewLine + " REASON : \t" + T.Reason;
                _appointment.Practitioner = T.Practitioner;
                _appointment.Patient = T.Patient;
                _appointment.Dated = T.Dated;
                _appointment.StartTime = T.StartTime;
                _appointment.EndTime = T.EndTime;
                _appointment.Patientimage = _patientList.First(x => x.Id.Equals(T.Patient)).Image;
                _appointment.Reason = T.Reason;
                ListAppoint.Add(_appointment);
            }

            AppointmentlistView.ItemsSource = ListAppoint;


        }

       

        private void selectdate_LostFocus(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            AddQueue inputDialog = new AddQueue();
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Appointment user = button.DataContext as Appointment;

            if (System.Windows.MessageBox.Show("Are you sure you want to cancel this appointment" + " " + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dialog = new MyDialog();
                if (dialog.ShowDialog() == true)
                {

                    if (dialog.notify == true)
                    {
                        Messenger.Send(App.amApp, "Your appointment with a " + _practitionerList.First(x => x.Id == user.Practitioner).Practice + " on:" + user.Dated + " at " + user.Meet + " to " + user.EndTime + " has been cancelled  because " + dialog.ResponseText, _patientList.First(x => x.Id == user.Patient.ToString()).Phone);
                    }
                    user.Delete(user.Id.ToString());
                    Refresh();
                }
            }
            else
            {

                return;
            }
        }

        private void image_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QueuelistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment inputDialog = new AddAppointment();
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void AppointlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void QueueButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Appointment user = button.DataContext as Appointment;

            if (System.Windows.MessageBox.Show("Are you sure you want queue this appointment" + " " + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _queue = App.amApp.Queues.Add();
                _queue.Patient = user.Patient.ToString();
                _queue.Practitioner = user.Practitioner;
                _queue.Payment = " ";
                _queue.Amount = " ";
                _queue.Checked = DateTime.Now.ToString("hh:mm:ss");
                _queue.Day = DateTime.Now.ToString();
                _queue.Reason = " ";
                _queue.Sync = "F";
                _queue.Org = "test";
                _queue.Seen = "F";
                _queue.Save();

                Refresh();

            }
            else
            {

                return;
            }
        }

        private void DeleteQueueButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Queue user = button.DataContext as Queue;

            if (MessageBox.Show("Are you sure you want to  remove from queue ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
            }
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Queue user = button.DataContext as Queue;

            var dialog = new CheckDialog(user.Id);
            if (dialog.ShowDialog() == true)
            {
                _queue.Update(dialog.QID, dialog.amount.ToString(), dialog.payment.ToString(), "T");
                Refresh();

            }

        }

        private void btnAppointment(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/CalendarPage.xaml", UriKind.Relative));
        }
    }
}
