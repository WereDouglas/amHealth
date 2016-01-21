using System;
using System.Collections.Generic;
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
        public AdvancedPage()
        {
            InitializeComponent();
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
    }
}
