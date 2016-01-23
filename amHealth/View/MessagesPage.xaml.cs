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
    /// Interaction logic for BlankPage.xaml
    /// </summary>
    public partial class MessagesPage : Page
    {
        private Message _message;       
        private ObservableCollection<Message> _messageList = null;
      
        public MessagesPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            _messageList = new ObservableCollection<Message>(App.amApp.Messages);
            dtGrid.ItemsSource = _messageList;          

        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected items?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Message u in dtGrid.SelectedItems)
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

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
