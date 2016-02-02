
using amHealth.View.Appointments;
using amLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AppointmentPage : Page
    {
        private Appointment _appointment;
        private ObservableCollection<Appointment> _appointmentList = null;

        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;

        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Hours u;
        public ObservableCollection<Hours> ListAppoint = new ObservableCollection<Hours>();

        public AppointmentPage()
        {
            InitializeComponent();
            selectdate.Text = DateTime.Now.Date.Date.ToString();
            Refresh();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {

            AddAppointment inputDialog = new AddAppointment();
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }
        private void Refresh()
        {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments);
            AppointmentListView.ItemsSource = null;
            count.Content = "Appointment count:"+_appointmentList.Where(k => k.Dated == selectdate.Text).Count().ToString();
            ListAppoint.Clear();

            foreach (Practitioner prac in _practitionerList)
            {

                u = new Hours();

                u.Practitioner = prac.Name;
                u.PractitionerImage = prac.Image;

                foreach (Appointment point in _appointmentList.Where(m => m.Practitioner == prac.Id))
                {

                    u.Dated = point.Dated;
                    //string title = "   " + "\t\t Start"+"\t End" + Environment.NewLine;

                    if (point.Dated == selectdate.Text)
                    {
                       
                        if (point.StartTime.Contains("06"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Six +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t"+ point.EndTime + Environment.NewLine;


                        }
                        if (point.StartTime.Contains("07"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Seven +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t  " + point.StartTime + "-" + point.EndTime + Environment.NewLine;


                        }
                        if (point.StartTime.Contains("08"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Eight +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + " \t" + point.EndTime + Environment.NewLine;


                        }
                        if (point.StartTime.Contains("09"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Nine +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + " \t"  + point.EndTime + Environment.NewLine;


                        }
                        if (point.StartTime.Contains("10"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Ten +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + " \t " + point.EndTime + Environment.NewLine;
                           
                        }
                        if (point.StartTime.Contains("11"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Eleven =  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + " \t "  + point.EndTime + Environment.NewLine;
                           
                        }
                        if (point.StartTime.Contains("12"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twelve +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + " \t "  + point.EndTime + Environment.NewLine;
                           
                        }
                        if (point.StartTime.Contains("13"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Thirteen +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " +  Environment.NewLine;
                        }
                        if (point.StartTime.Contains("14"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Fourteen += _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " +  Environment.NewLine;

                        }
                        if (point.StartTime.Contains("15"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Fifteen += _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("16")||point.EndTime.Contains("16"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Sixteen +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("17"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Seventeen += _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("18") || point.EndTime.Contains("18"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Eighteen +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t "  + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("19") || point.EndTime.Contains("19"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Nineteen +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("20"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twenty+=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("21"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twentyone += _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t "  + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("22"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twentytwo +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t " + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("23"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twentythree +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t "  + Environment.NewLine;

                        }
                        if (point.StartTime.Contains("24"))
                        {
                            u.PatientImage = _patientList.First(x => x.Id.Equals(point.Patient)).Image;
                            u.Twentyfour +=  _patientList.First(x => x.Id.Equals(point.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(point.Patient)).Lname + "\t "+ Environment.NewLine;

                        }

                    }


                }
                ListAppoint.Add(u);
            }

            AppointmentListView.ItemsSource = ListAppoint;

        }
        public string interval (string start ,string stop){

            return ""; 
    
        }

        private void btnCalendar(object sender, RoutedEventArgs e)
        {
           MessagePage  m = new MessagePage();
         NavigationService.Navigate(new Uri("view/CalendarPage.xaml", UriKind.Relative));
          
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void image_Click(object sender, RoutedEventArgs e)
        {
            //Button button = sender as System.Windows.Controls.Button;
            //Hours user = button.DataContext as Hours;
            //MessageBox.Show(user.Practitioner + "  " + user.Start);
            AddAppointment inputDialog = new AddAppointment();
            if (inputDialog.ShowDialog() == true)
            Refresh();
        }

        private void selectdate_LostFocus(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void image_Click_edit(object sender, RoutedEventArgs e)
        {
            AddAppointment inputDialog = new AddAppointment();
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

       
    }


}
