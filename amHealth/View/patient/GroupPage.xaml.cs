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
using System.Windows.Shapes;

namespace amHealth.View.patient
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class GroupPage : Window
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Group _group;
        private ObservableCollection<Group> _groupList = null;

        string Id;
        string Age = "";
        string Sex = "";

        string age1 = "";
        string age2 = "";
        List<Patient> ageList = new List<Patient>();
        public GroupPage(string id, string filters)
        {
            InitializeComponent();
            Id = id;
            Refresh();


        }


        public string Answer
        {
            get { return " "; }
        }
        private void Refresh()
        {
           
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _groupList = new ObservableCollection<Group>(App.amApp.Groups);
          
            foreach (Group gp in _groupList.Where(r => r.Id == Id))
            {
                name.Text = gp.Name;
                string[] filt = gp.Filters.Split('|');
                Sex = filt[0];
                Age = (filt[1]);
                string[] ages = Age.Split('-');
                age1 = ages[0];
                age2 = ages[1];
            }

            foreach (Patient pat in _patientList)
            {

                if ((Validator.IsBetween(Convert.ToInt32(pat.Age), Convert.ToInt32(age1), Convert.ToInt32(age2)) && pat.Gender == Sex))
                {
                    ageList.Add(pat);
               }

                PatientListView.ItemsSource = ageList;

            }


        }

        private List<Patient> lstMyObject = new List<Patient>();

        private void UserGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            foreach (Patient item in e.RemovedItems)
            {
                lstMyObject.Remove(item);
            }

            foreach (Patient item in e.AddedItems)
            {
                lstMyObject.Add(item);
            }
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(PatientListView.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else if ((item as Patient).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Fname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Fname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Lname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Lname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return false;

        }




        private void button8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ageto_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void gender_LostFocus(object sender, RoutedEventArgs e)
        {


        }

        private void gender_DropDownClosed(object sender, EventArgs e)
        {

        }


        private void Preview_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myText = new TextRange(message.Document.ContentStart, message.Document.ContentEnd).Text;
                foreach (Patient pt in ageList) {
                    Messenger.Send(myText, pt.Phone);
                 
                }
                MessageBox.Show("messages sent");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


    }
}
