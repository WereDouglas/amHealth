using amHealth.View.Appointments;
using amHealth.View.patient;
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
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        public PatientPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {

            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            dtGrid.ItemsSource = null;
            dtGrid.ItemsSource = _patientList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
            view.Filter = UserFilter;
           

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as System.Windows.Controls.Button;
            Patient user = button.DataContext as Patient;
            // EditPatient(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)

            EditPatient inputDialog = new EditPatient(user.Id, user.Fname, user.Lname, user.Gender, user.Dob, user.Height, user.Weight, user.Phone, user.Email, user.Region, user.Image);
            if (inputDialog.ShowDialog() == true)
             

            Refresh();

        }
        private void image_Click(object sender, RoutedEventArgs e)
        {

            //System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            //Patient patient = button.DataContext as Patient;
            //string PatientID = patient.Pid;


            //PatientWindow admin = new PatientWindow(PatientID, patient.Fname + " " + patient.Sname);
            //admin.Show();
            //Close();


            //  System.Windows.Forms.MessageBox.Show("" + id.ToString());

        }
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient inputDialog = new AddPatient();
            if (inputDialog.ShowDialog() == true)
               
            // alert.Visibility = System.Windows.Visibility.Visible;
            Refresh();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Patient user = button.DataContext as Patient;

            if (MessageBox.Show("Are you sure you want to delete " + user.Fname + " " + user.Lname + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
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
            CollectionViewSource.GetDefaultView(dtGrid.ItemsSource).Refresh();
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
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                dtGrid.SelectAll();
            }
            else
            {
                dtGrid.UnselectAll();
            }
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all these patients?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Patient u in dtGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                Refresh();
               

            }
            else
            {
                return;
            }

        }

        private void sync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            dtGrid.SelectAll();
           dtGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
           ApplicationCommands.Copy.Execute(null, dtGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtGrid.UnselectAll();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\amHealth\patient.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show(" Exporting DataGrid data to Excel file created");
        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Patient user = button.DataContext as Patient;
            // EditPatient(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)

            MessagePatient inputDialog = new MessagePatient(user.Id, user.Fname, user.Lname, user.Phone, user.Email, user.Region, user.Image);
            if (inputDialog.ShowDialog() == true)
               

            Refresh();
        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Patient user = button.DataContext as Patient;
            PatientAppointment inputDialog = new PatientAppointment(user.Id, user.Fname + " " + user.Lname);

            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}
