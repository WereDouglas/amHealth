using amHealth.View.patient;
using amLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
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
    public partial class MessagePage : Page
    {
        private Group _group;
        private ObservableCollection<Group> _groupList = null;
        public MessagePage()
        {
            InitializeComponent();           
           
            Refresh();
        }
       

       
        private void Refresh()
        {

            _groupList = new ObservableCollection<Group>(App.amApp.Groups);
            GroupListView.ItemsSource = null;
            GroupListView.ItemsSource = _groupList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(GroupListView.ItemsSource);
            foreach (Group gp in _groupList)
            {

                string[] filt = gp.Filters.Split('|');

             //   System.Diagnostics.Debug.WriteLine(filt[0]);
               // System.Diagnostics.Debug.WriteLine(filt[1]);


                foreach (string line in filt)
                {
                    // System.Diagnostics.Debug.WriteLine(line);
                    //  string[] filt2 = line.Split(':');
                    // System.Diagnostics.Debug.WriteLine("Gender:"+filt[0]);
                    //System.Diagnostics.Debug.WriteLine("Age:" + filt[1]);



                }

            }


        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            DynamicPatient inputDialog = new DynamicPatient();
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            Excel inputDialog = new Excel();
            if (inputDialog.ShowDialog() == true)
                Refresh();

        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            Groups inputDialog = new Groups();
            if (inputDialog.ShowDialog() == true)
                show = "";
            //   lblName.Text = inputDialog.Answer;
            // lblName.Visibility = System.Windows.Visibility.Visible;
            // alert.Visibility = System.Windows.Visibility.Visible;
            Refresh();
        }

        private void PatientlistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Group user = button.DataContext as Group;

            if (MessageBox.Show("Are you sure you want to delete " + user.Name + " " + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                user.Delete(user.Id.ToString());
                Refresh();
            }
            else
            {

                return;
            }
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Group user = button.DataContext as Group;
            // EditPatient(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)

            GroupPage inputDialog = new GroupPage(user.Id, user.Filters);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }
    }
}
