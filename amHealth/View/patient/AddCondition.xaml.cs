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
    /// Interaction logic for AddCondition.xaml
    /// </summary>
    public partial class AddCondition : Window
    {
        private Allergy _allergy;
        private ObservableCollection<Allergy> _allergyList = null;
        private Chronic _chronic;
        private ObservableCollection<Chronic> _chronicList = null;


        private AllergyMap _allergyMap;
        private ObservableCollection<AllergyMap> _allergyMapList = null;
        private ChronicMap _chronicMap;
        private ObservableCollection<ChronicMap> _chronicMapList = null;

       
        private string patient;
        private string type;

        WebCam webcam;
        public AddCondition(string id,string types)
        {
            type = types;
            patient = id;
            InitializeComponent();
            if(type=="chronic"){
                _chronicList = new ObservableCollection<Chronic>(App.amApp.Chronics);
            condition.ItemsSource = null;
            condition.ItemsSource = _chronicList.Select(l=>l.Name);
            }
            else if (type == "allergy") {

                _allergyList = new ObservableCollection<Allergy>(App.amApp.Allergys);
                condition.ItemsSource = null;
                condition.ItemsSource = _allergyList.Select(l=>l.Name);
            }
      
           

        }
        public string Answer
        {
            get { return condition.Text + " "; }
        }      

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveAllergy();
                this.DialogResult = true;
            }
            catch {

               
                 
            }
        }
        private void SaveAllergy()
        {

            if (type == "chronic")
            {
                _chronicMap = App.amApp.ChronicMaps.Add();
                _chronicMap.Patient = patient;
                _chronicMap.Chronic = condition.Text;
                _chronicMap.Sync = "F";
                _chronicMap.Save();
                System.Windows.MessageBox.Show("chronic added to patient");
                this.DialogResult = true;


               
            }
            else if (type == "allergy")
            {
                _allergyMap = App.amApp.AllergyMaps.Add();
                _allergyMap.Patient = patient;
                _allergyMap.Allergy = condition.Text;
                _allergyMap.Sync = "F";
                _allergyMap.Save();
                System.Windows.MessageBox.Show("Allergy added to patient");
                this.DialogResult = true;
               
            }
            
            
            
            

        }       

    }
}
