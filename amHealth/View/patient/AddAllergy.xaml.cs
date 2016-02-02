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
    /// Interaction logic for AddAllergy.xaml
    /// </summary>
    public partial class AddAllergy : Window
    {
        private Allergy _allergy;
        private ObservableCollection<Allergy> _allergyList = null;
        private string patient;

        WebCam webcam;
        public AddAllergy(string id)
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
                SaveAllergy();
                this.DialogResult = true;
            }
            catch {
                  return;
            }
        }
        private void SaveAllergy()
        {         

            _allergy = App.amApp.Allergys.Add();

            _allergy.Name = name.Text;           
            _allergy.Sync = "F";
            _allergy.Org = "TEST";   
            _allergy.Save();
            System.Windows.MessageBox.Show("Allergy saved ");
            this.DialogResult = true;

        }       

    }
}
