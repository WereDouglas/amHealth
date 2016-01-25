using amHealth.View.patient;
using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace amHealth.View.Appointments
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class ManageAppointment : Window
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
        string Id;
        string Name;

        public ManageAppointment(string id, string name)
        {
            InitializeComponent();
            selectdate.Text = DateTime.Now.Date.Date.ToString();
            Id = id;
            Name = name;
            prac.Content = Name;
            Refresh();

        }
        private void Refresh()
        {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments.Where(h => h.Practitioner == Id));
            _queueList = new ObservableCollection<Queue>(App.amApp.Queues);
            appointmentcount.Content = "Appointments:" + _appointmentList.Where(k => k.Dated == selectdate.Text).Count().ToString();

            AppointmentlistView.ItemsSource = null;
          

            ListQueue.Clear();
            ListAppoint.Clear();

            foreach (Appointment T in _appointmentList.Where(i => i.Dated == selectdate.Text))
            {
                _appointment = new Appointment(null);
                _appointment.Id = T.Id;
                _appointment.Org = T.Org;
                _appointment.Details = "PATIENT : \t" + _patientList.First(x => x.Id.Equals(T.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(T.Patient)).Lname + Environment.NewLine + "PRACTITIONER : \t" + _practitionerList.First(x => x.Id.Equals(T.Practitioner)).Name + " " + Environment.NewLine + "HOURS: \t " + T.StartTime + "-END" + T.EndTime + Environment.NewLine + "REASON : \t" + T.Reason + Environment.NewLine + "Notify : \t" + T.Reminder;
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
        public string Answer
        {
            get { return " "; }
        }


        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                this.DialogResult = true;
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message.ToString());
                return;

            }

        }





        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient inputDialog = new AddPatient();
            if (inputDialog.ShowDialog() == true)
                _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            System.Windows.MessageBox.Show("done");

        }

        private void selectdate_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

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
                        try
                        {
                            Messenger.Send(App.amApp, "Your appointment with" + _practitionerList.First(x => x.Id == user.Practitioner).Practice + "  on:" + user.Dated + " at" + user.Meet + " to " + user.EndTime + " because " + dialog.ResponseText, _patientList.First(x => x.Id == user.Patient.ToString()).Phone);
                               }
                        catch {
                           
                        }
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

        private void AppointlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Appointment user = button.DataContext as Appointment;

            System.Windows.MessageBox.Show(user.Practitioner);
        }



    }
}
