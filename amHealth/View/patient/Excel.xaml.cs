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
    public partial class Excel : Window
    {

        private Member _member;

        private ObservableCollection<Group> _groupList = null;
        private ObservableCollection<Member> _memberList = null;
        List<Patient> ageList = new List<Patient>();

        public Excel()
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
            _memberList = new ObservableCollection<Member>(App.amApp.Members);
            dtGrid.ItemsSource = _memberList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtGrid.ItemsSource);
            view.Filter = UserFilter;

        }

        private List<Member> lstMyObject = new List<Member>();

        private void UserGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            foreach (Member item in e.RemovedItems)
            {
                lstMyObject.Remove(item);
            }

            foreach (Member item in e.AddedItems)
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
            else if ((item as Member).Contact.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Member).Contact.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if ((item as Member).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Member).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            else if ((item as Member).Uploadname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ((item as Member).Uploadname.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return false;

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myText = new TextRange(message.Document.ContentStart, message.Document.ContentEnd).Text;
                foreach (Member u in dtGrid.SelectedItems)
                {
                    Messenger.Send(App.amApp, myText, u.Contact);
                    //MessageBox.Show(u.Contact);

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
        string str;
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {

            if (groupname.Text != "")
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = ".xlsx";
                openfile.Filter = "(.xlsx)|*.xlsx";
                //openfile.ShowDialog();

                var browsefile = openfile.ShowDialog();

                if (browsefile == true)
                {
                    txtFilePath.Text = openfile.FileName;
                    if (MessageBox.Show("Are you sure you want to upload this list?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {

                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                        Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;
                        int rowCnt = 0;
                        int colCnt = 0;
                        for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                        {
                            for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                            {
                                str = Convert.ToString((excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2);


                                if (colCnt % 2 == 0)
                                {
                                    _member.Contact = str.ToString();
                                    _member.Save();
                                }
                                else
                                {
                                    _member = App.amApp.Members.Add();
                                    _member.Name = str.ToString();
                                    _member.Org = "Test";
                                    _member.Sync = "F";
                                    _member.Uploadname = groupname.Text;

                                }
                            }

                        }

                        excelBook.Close(true, null, null);
                        excelApp.Quit();

                        Refresh();

                    }
                    else
                    {
                        return;
                    }
                }
            }
            else {

                MessageBox.Show("Please input the category name!");
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
