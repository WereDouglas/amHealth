using amHealth.View.patient;
using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class AddAppointment : Window
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;

        private Appointment _appointment;
        private ObservableCollection<Appointment> _appointmentList = null;
        private string selectedPrac = "";

        

        public AddAppointment()
        {
            InitializeComponent();
            startDate.Text = DateTime.Now.Date.Date.ToString();
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);

            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            practitioners.ItemsSource = null;
            foreach (Practitioner prac in _practitionerList)
            {
                practitioners.Items.Add(prac.Name);
            }
            string fmt = "00";

            for (int d = 00; d < 24; d++)
            {
                startHour.Items.Add(d.ToString(fmt));
                endHour.Items.Add(d.ToString(fmt));
            }
            for (int d = 00; d < 60; d++)
            {
                startMin.Items.Add(d.ToString(fmt));
                endMin.Items.Add(d.ToString(fmt));
            }
           

        }
       

        public string Answer
        {
            get { return " "; }
        }


        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                SaveAppointment();
                 if (ChkNotify.IsChecked==true){
                Messenger.Send(App.amApp, "You have scheduled an appointment with a " + _practitionerList.First(x => x.Id == selectedPrac).Practice + "  on:" + startDate.Text + " at:"+ startHour.Text + ":" + startMin.Text +" to"+ endHour.Text + ":" + endMin.Text + "  ", _patientList.First(x => x.Id == patient.Content.ToString()).Phone);
                 }
                     this.DialogResult = true;
                

            }
            catch
            {
               
            }



        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            object value = "";
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                this.DataContext = null;
            }
            else if (!String.IsNullOrEmpty(txtFilter.Text))
            {
                this.DataContext = null;
                if (_patientList.Where(x => x.Phone.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Phone.Contains(txtFilter.Text)) };
                }

                else if (_patientList.Where(x => x.Fname.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Fname.Contains(txtFilter.Text)) };
                }
                else if (_patientList.Where(x => x.Lname.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Lname.Contains(txtFilter.Text)) };
                }
                else if (_patientList.Where(x => x.Email.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Email.Contains(txtFilter.Text)) };
                }

            }

        }
        private void SaveAppointment()
        {
            string fmt = "00";
            int period = Convert.ToInt32(endHour.Text) - Convert.ToInt32(startHour.Text);
            _appointment = App.amApp.Appointments.Add();
            string build = startHour.Text;
            for (int p = 0; p <= period; p++)
            {
                build += (Convert.ToInt32(startHour.Text) + p).ToString(fmt) + "  ";

            }

            if (ChkNotify.IsChecked == true)
            {
                _appointment.Reminder = "false";
            }
            else {
                _appointment.Reminder = "true";

            }

            _appointment.Patient = patient.Content.ToString();
            _appointment.Practitioner = selectedPrac;
            _appointment.Dated = startDate.Text;
            _appointment.StartTime = build;
            _appointment.Meet  = startHour.Text +":" + startMin.Text;
            _appointment.EndTime = endHour.Text + ":" + endMin.Text;
            _appointment.Reason = reason.Text;
            _appointment.Sync = "F";
            _appointment.Org = "test";



            _appointment.Save();


            System.Windows.MessageBox.Show("Appointment created ");
            this.DialogResult = true;

        }

        private void PractitionerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedPract = _practitionerList.First(x => x.Name.Contains(practitioners.SelectedItem.ToString())).Id;

            if (selectedPract != null)
            {
                selectedPrac = selectedPract.ToString();
            }

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient inputDialog = new AddPatient();
            if (inputDialog.ShowDialog() == true)
                _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            System.Windows.MessageBox.Show("done");

        }



    }
}
