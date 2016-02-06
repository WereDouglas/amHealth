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
    public partial class CalendarPage : Page
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private string selectedPrac = "";

        private Appointment _appointment;
        private ObservableCollection<Appointment> _appointmentList = null;

        public CalendarPage()
        {
            InitializeComponent();
            month.ItemsSource = months.ToList();
            year.Text = DateTime.Now.Date.Year.ToString();
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            practitioners.ItemsSource = null;
            practitioners.Items.Add("");
            foreach (Practitioner prac in _practitionerList)
            {
                practitioners.Items.Add(prac.Name);
            }
            view();
        }

        private void PractitionerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPract = _practitionerList.First(x => x.Name.Contains(practitioners.SelectedItem.ToString())).Id;

            if (selectedPract != null)
            {
                selectedPrac = selectedPract.ToString();
            }
        }


        public string IntToRoman(int num)
        {
            string[] thou = { "", "M", "MM", "MMM" };
            string[] hun = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] ten = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string roman = "";
            roman += thou[(int)(num / 1000) % 10];
            roman += hun[(int)(num / 100) % 10];
            roman += ten[(int)(num / 10) % 10];
            roman += ones[num % 10];

            return roman;
        }
        public void view() {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments);

            for (int r = 1; r < 32; r++)
            {


                Console.WriteLine(IntToRoman(r).ToString().ToLower());
                Label tvs = (Label)FindName(IntToRoman(r).ToString().ToLower()) as Label;
                tvs.Content = r.ToString();

            }


            foreach (Appointment T in _appointmentList.Where(i => Convert.ToDateTime(i.Dated).Date.Year.ToString() == year.Text && Convert.ToDateTime(i.Dated).Date.ToString("MMMM") == month.Text))
            {

                for (int r = 1; r < 32; r++)
                {


                    if (Convert.ToDateTime(T.Dated).Date.Day == r)
                    {

                        Label tvs = (Label)FindName(IntToRoman(r).ToString().ToLower()) as Label;
                        tvs.Content = tvs.Content + Environment.NewLine + T.Meet + "-" + T.EndTime + _patientList.First(x => x.Id.Equals(T.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(T.Patient)).Lname;

                    }



                }
            }
        
        
        }
        private void month_DropDownClosed(object sender, EventArgs e)
        {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments.Where(h => h.Practitioner == _practitionerList.First(x => x.Name.Equals(practitioners.Text)).Id));

            for (int r = 1; r < 32; r++)
            {
               

                Console.WriteLine( IntToRoman(r).ToString().ToLower());
                Label tvs = (Label)FindName(IntToRoman(r).ToString().ToLower()) as Label;
                tvs.Content = r.ToString();

            }


            foreach (Appointment T in _appointmentList.Where(i => Convert.ToDateTime(i.Dated).Date.Year.ToString() == year.Text && Convert.ToDateTime(i.Dated).Date.ToString("MMMM") == month.Text))
            {
              
                for (int r = 1; r < 32; r++)
                {
                   

                    if (Convert.ToDateTime(T.Dated).Date.Day == r) {

                        Label tvs = (Label)FindName(IntToRoman(r).ToString().ToLower()) as Label;
                        tvs.Content =  tvs.Content + Environment.NewLine + T.Meet + "-" + T.EndTime+ _patientList.First(x => x.Id.Equals(T.Patient)).Fname + " " + _patientList.First(x => x.Id.Equals(T.Patient)).Lname ;

                    }

                   

                }
            }
        }

        private void month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void practitioners_DropDownClosed(object sender, EventArgs e)
        {
            if (practitioners.Text == "")
            {
                view();

            }
            else
            {
                month_DropDownClosed(null, null);
            }
        }
    }
}
