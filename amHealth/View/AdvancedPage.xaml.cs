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
    public partial class AdvancedPage : Page
    {
        private Chronic _chronic;
        private ObservableCollection<Chronic> _chronicList = null;

        private Allergy _allergy;
        private ObservableCollection<Allergy> _allergyList = null;

        public AdvancedPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void btnDelete_imports(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all data imports?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteImport();
            }
            else
            {
                return;
            }            


        }
        private void DeleteImport()
        {

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            if (Helper.TableExists(conn, "member"))
            {
                cmd.CommandText = "DROP TABLE member";
                cmd.ExecuteNonQuery();

            }
            else {
                MessageBox.Show("table doesnot exist");
            
            }
            conn.Close();
            MessageBox.Show("deleted table for imported members");

        }
        private void DeletePatients()
        {

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (Helper.TableExists(conn, "patient"))
            {
                cmd.CommandText = "DROP TABLE patient";
                cmd.ExecuteNonQuery();
               
            }


            conn.Close();

        }
        private void DeleteAppoint()
        {

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (Helper.TableExists(conn, "appointment"))
            {
                cmd.CommandText = "DROP TABLE appointment";
                cmd.ExecuteNonQuery();

            }


            conn.Close();

        }

        private void DeleteQueue()
        {

            string con;

            con = string.Format(@"Data Source=C:\amHealth\amHealth.sdf;Password=access; Persist Security Info=True;");

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            if (Helper.TableExists(conn, "queue"))
            {
                cmd.CommandText = "DROP TABLE queue";
                cmd.ExecuteNonQuery();

            }


            conn.Close();

        }


        private void Deletepatients_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all patients in your database?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeletePatients();
            }
            else
            {
                return;
            }        
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QueueDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all patients in your database?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteQueue();
            }
            else
            {
                return;
            }        
        }

        private void btnAdd_allergy(object sender, RoutedEventArgs e)
        {
            AddAllergy inputDialog = new AddAllergy(null);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void btnAdd_condition(object sender, RoutedEventArgs e)
        {
             AddChronic inputDialog = new AddChronic(null);
            if (inputDialog.ShowDialog() == true)
                Refresh();
        }

        private void Refresh()
        {

            _chronicList = new ObservableCollection<Chronic>(App.amApp.Chronics);
            dtGrid.ItemsSource = null;
            dtGrid.ItemsSource = _chronicList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
           // view.Filter = UserFilter;


             _allergyList = new ObservableCollection<Allergy>(App.amApp.Allergys);
            dtGrid_allergy.ItemsSource = null;
            dtGrid_allergy.ItemsSource = _allergyList;


        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dtGrid.ItemsSource).Refresh();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
