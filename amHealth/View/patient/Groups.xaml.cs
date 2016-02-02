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
    public partial class Groups : Window
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Group _group;
        private ObservableCollection<Group> _groupList = null;
        List<Patient> ageList = new List<Patient>();



        public Groups()
        {
            InitializeComponent();

            Refresh();


        }


        public string Answer
        {
            get { return " "; }
        }
        private void Refresh()
        {

            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            PatientlistView.ItemsSource = null;
           // PatientlistView.ItemsSource = _patientList;
          //  CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PatientlistView.ItemsSource);
           // view.Filter = UserFilter;
            _groupList = new ObservableCollection<Group>(App.amApp.Groups);

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
            CollectionViewSource.GetDefaultView(PatientlistView.ItemsSource).Refresh();
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

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveGroup();
                this.DialogResult = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return;

            }

        }
        private void SaveGroup()
        {
            string filt = ""+gender.Text+"|"+ " "+Agefrom.Text+"-"+Ageto.Text+"|";

            _group = App.amApp.Groups.Add();
            _group.Name = name.Text;
            _group.Filters = filt;
            _group.Dor = DateTime.Now.Date.ToString();
            _group.Sync = "F";
            _group.Org = "test";

            _group.Save();
            System.Windows.MessageBox.Show("Group created and saved ");
            this.DialogResult = true;

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

        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                PatientlistView.SelectAll();
            }
            else
            {
                PatientlistView.UnselectAll();
            }
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
        public bool InThere(string id)
        {

            if ((ageList.Where(t => t.Id == id)).Count() > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            //  IsBetween(this long value, long Min, long Max)             
            PatientlistView.ItemsSource = null;
            ageList.Clear();

            string selected = (gender.SelectionBoxItem.ToString());
            var isIF = "true ";


            if (gender.Text != "")
            {
                isIF += "&& pat.Gender == selected";
            }
            if (Ageto.Text != "0")
            {
                isIF += "&& (Validator.IsBetween(pat.Age, Convert.ToInt32(Agefrom.Text), Convert.ToInt32(Ageto.Text)) ";
            }

            foreach (Patient pat in _patientList)
            {
                if (!InThere(pat.Id))
                {

                    if ((Validator.IsBetween(Convert.ToInt32( pat.Age), Convert.ToInt32(Agefrom.Text), Convert.ToInt32(Ageto.Text)) && pat.Gender == selected))
                    {
                        ageList.Add(pat);
                    }
                }

            }



            PatientlistView.ItemsSource = ageList;
        }


    }
}
