using System;
using System.Collections.Generic;
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

namespace amHealth.View
{
    /// <summary>
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class CheckDialog : Window
    {
        public CheckDialog(string qid)
        {
            InitializeComponent();
            QID = qid;
        }
        public string QID
        {
            get;
            set;
        }
        public string Amount
        {
            get { return amount.Text; }
            set { amount.Text = value; }
        }


        public string Payment
        {
            get { return payment.Text; }
            set { payment.Text = value; }
        }       

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void PractitionerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
