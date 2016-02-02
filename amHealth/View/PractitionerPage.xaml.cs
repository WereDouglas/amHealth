using amHealth.View.Appointments;
using amHealth.View.practitioner;
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
    /// Interaction logic for PractitionerPage.xaml
    /// </summary>
    public partial class PractitionerPage : Page
    {
        private Practitioner _practitioner;
        
        private ObservableCollection<Practitioner> _practitionerList = null;
        public PractitionerPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {

            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            dtGrid.ItemsSource = null;
            dtGrid.ItemsSource = _practitionerList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
            view.Filter = UserFilter;

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as System.Windows.Controls.Button;
            Practitioner user = button.DataContext as Practitioner;
            // EditPractitioner(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)
       
            EditPractitioner inputDialog = new EditPractitioner(user.Id, user.Name,user.Phone,user.Email,user.Practice,user.Image);
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
          
            Refresh();          

        }
        private void image_Click(object sender, RoutedEventArgs e)
        {

            //System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            //Practitioner practitioner = button.DataContext as Practitioner;
            //string PractitionerID = practitioner.Pid;


            //PractitionerWindow admin = new PractitionerWindow(PractitionerID, practitioner.Fname + " " + practitioner.Sname);
            //admin.Show();
            //Close();


            //  System.Windows.Forms.MessageBox.Show("" + id.ToString());

        }
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddPractitioner inputDialog = new AddPractitioner();
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
           // alert.Visibility = System.Windows.Visibility.Visible;
           Refresh();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Practitioner user = button.DataContext as Practitioner;

            if (MessageBox.Show("Are you sure you want to delete " + user.Name + " "+" ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
            }

        }
        private List<Practitioner> lstMyObject = new List<Practitioner>();

        private void UserGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            foreach (Practitioner item in e.RemovedItems)
            {
                lstMyObject.Remove(item);
            }

            foreach (Practitioner item in e.AddedItems)
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
            else if ((item as Practitioner).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Practitioner).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Practitioner).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Practitioner).Practice.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Practitioner).Email.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Practitioner).Email.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            if (MessageBox.Show("Are you sure you want to delete all these practitioners?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Practitioner u in dtGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                Refresh();
                lblName.Text = "practitioner deleted!";
                lblName.Visibility = System.Windows.Visibility.Visible;

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

        private void PractitionerlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\amHealth\practitioner.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show(" Exporting DataGrid data to Excel file created");
        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Practitioner user = button.DataContext as Practitioner;
      
            MessagePractitioner inputDialog = new MessagePractitioner(user.Id, user.Name,user.Phone, user.Email,user.Image);
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;

            Refresh();      

        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as System.Windows.Controls.Button;
            Practitioner user = button.DataContext as Practitioner;
            //MessageBox.Show(user.Name+user.Id);

            ManageAppointment inputDialog = new ManageAppointment(user.Id, user.Name);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
