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
using System.Windows.Shapes;

namespace amHealth.View.patient
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        private Patient _patient;
      
        private string Id;
        private string Fname;
        private string Lname;
        private string Gender;
        private string Dob;
        private string Height;
        private string Weight;
        private string Phone;
        private string Email;
        private string Region;
        private string Image;
        private string Sync;
        private ObservableCollection<Patient> _patientList = null;      
        private ObservableCollection<Family> _familyList = null;

        private Chronic _chronic;
        private ObservableCollection<Chronic> _chronicList = null;

        private Allergy _allergy;
        private ObservableCollection<Allergy> _allergyList = null;


        private AllergyMap _allergyMap;
        private ObservableCollection<AllergyMap> _allergyMapList = null;
        private ChronicMap _chronicMap;
        private ObservableCollection<ChronicMap> _chronicMapList = null;
        private Message _message;
        private ObservableCollection<Message> _messageList = null;
     
        public EditPatient(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)
        {
            InitializeComponent();
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            Id = id; Fname = fname; Lname = lname; Gender = gender; Dob = dob; Height = height; Phone = phone; Email = email; Region = region; Image = image;
            this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Id == Id) };
            Refresh();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _patient = App.amApp.Patients.Add();               
                _patient.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text);
                this.DialogResult = true;
            }
            catch 
            {
               
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {

            fname.Text = Fname; lname.Text = Lname; gender.Text = Gender; dob.Text = Dob; height.Text = Height; phone.Text = Phone; email.Text = Email; region.Text = Region; 
         
        }

        public string Answer
        {
            get { return "" + Name + " has been updated"; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddFamily inputDialog = new AddFamily(Id);
            if (inputDialog.ShowDialog() == true)                
                Refresh();
        }
        private void Refresh()
        {

            _familyList = new ObservableCollection<Family>(App.amApp.Familys);
            dtGrid.ItemsSource = null;
            dtGrid.ItemsSource = _familyList.Where(m=>m.Patient == Id);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
            view.Filter = UserFilter;


            _chronicMapList = new ObservableCollection<ChronicMap>(App.amApp.ChronicMaps);
            dtGrid_chronic.ItemsSource = null;
            dtGrid_chronic.ItemsSource = _chronicMapList.Where(m => m.Patient == Id);
          


            _allergyMapList = new ObservableCollection<AllergyMap>(App.amApp.AllergyMaps);
            dtGrid_allergy.ItemsSource = null;
            dtGrid_allergy.ItemsSource = _allergyMapList.Where(m => m.Patient == Id);

            _messageList = new ObservableCollection<Message>(App.amApp.Messages);

            info.Content = "No.SMS: " +_messageList.Where(k => k.Contact == Phone).Count().ToString();
            info.Content = info.Content + Environment.NewLine + "No.UNSENT SMS: " + _messageList.Where(k => k.Contact == Phone && k.Sent == "F").Count().ToString();
            info.Content = info.Content + Environment.NewLine + "No.Emails : " + _messageList.Where(k => k.Contact == Email).Count().ToString();
            info.Content = info.Content + Environment.NewLine + "No.Chronics : " + _chronicMapList.Where(k => k.Patient == Id).Count().ToString();
            info.Content = info.Content + Environment.NewLine + "No.Allergy : " + _allergyMapList.Where(k => k.Patient == Id).Count().ToString();
            info.Content = info.Content + Environment.NewLine + "No.Family Contacts : " + _familyList.Where(k => k.Patient == Id).Count().ToString();

       


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
            else if ((item as Family).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Family).Phone.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Family).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Family).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Family).Relationship.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Family).Relationship.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            if (MessageBox.Show("Are you sure you want to delete all these family members?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Family u in dtGrid.SelectedItems)
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddFamily inputDialog = new AddFamily(Id);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void image_Click(object sender, RoutedEventArgs e)
        {

        }
        string conditions;
        private void btnAdd_allergy(object sender, RoutedEventArgs e)
        {
            conditions = "allergy";
            AddCondition inputDialog = new AddCondition(Id,conditions);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void btnAdd_Chronic(object sender, RoutedEventArgs e)
        {
            conditions = "chronic";
            AddCondition inputDialog = new AddCondition(Id, conditions);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void RemoveChronicButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            ChronicMap user = button.DataContext as ChronicMap;

            if (MessageBox.Show("Are you sure you want to remove " + user.Chronic + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
            }

        }

        private void RemoveAllergyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            AllergyMap user = button.DataContext as AllergyMap;

            if (MessageBox.Show("Are you sure you want to remove " + user.Allergy + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
            }
        }

    }
}
