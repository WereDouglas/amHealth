using amLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace amHealth.View.patient
{
    /// <summary>
    /// Interaction logic for AddChronic.xaml
    /// </summary>
    public partial class AddChronic : Window
    {
        private Chronic _chronic;
        private ObservableCollection<Chronic> _chronicList = null;
        private string patient;

        WebCam webcam;
        public AddChronic(string id)
        {
            patient = id;
            InitializeComponent();
           

        }
        public string Answer
        {
            get { return name.Text + " "; }
        }      

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveChronic();
                this.DialogResult = true;
            }
            catch 
            {
               
            }
        }
        private void SaveChronic()
        {         

            _chronic = App.amApp.Chronics.Add();

            _chronic.Name = name.Text;           
            _chronic.Sync = "F";
            _chronic.Org = "TEST";      
            _chronic.Save();
            System.Windows.MessageBox.Show("Chronic saved ");
            this.DialogResult = true;

        }       

    }
}
