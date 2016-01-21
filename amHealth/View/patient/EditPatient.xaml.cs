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

     
        public EditPatient(string id,string fname,string lname,string gender,string dob,string height,string weight,string phone,string email,string region,string image)
        {
            InitializeComponent();
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            Id = id; Fname = fname; Lname = lname; Gender = gender; Dob = dob; Height = height; Phone = phone; Email = email; Region = region; Image = image;
            this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Id == Id) };
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _patient = App.amApp.Patients.Add();
               
                _patient.Update(Id, fname.Text,lname.Text,gender.Text,dob.Text, height.Text,weight.Text,phone.Text,email.Text,region.Text);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
    }
}
