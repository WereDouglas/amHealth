using amLibrary;
using amLibrary.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Data;

namespace amHealth.View.patient
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class DynamicPatient : Window
    {

        private Member _member;
        private ObservableCollection<Group> _groupList = null;
        private ObservableCollection<Patient> _patientList = null;
        List<Patient> ageList = new List<Patient>();

        public DynamicPatient()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            dtGrid.ItemsSource = _patientList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
            view.Filter = UserFilter;

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
            else if ((item as Patient).Gender.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Gender.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Dob.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Dob.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Email.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Email.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Region.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Region.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Patient).Sync.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Patient).Sync.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return false;

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myText = new TextRange(message.Document.ContentStart, message.Document.ContentEnd).Text;
                foreach (Patient u in dtGrid.SelectedItems)
                {
                    // Messenger.Send(myText, u.Contact);
                    MessageBox.Show(u.Phone);

                }
                // MessageBox.Show("messages sent");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

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
                dtGrid.SelectAll();
            }
            else
            {
                dtGrid.UnselectAll();
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
      
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
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
            if (MessageBox.Show("Are you sure you want to delete the selected items?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Member u in dtGrid.SelectedItems)
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
    }
}
