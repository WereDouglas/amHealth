using amLibrary;
using amLibrary.Helpers;
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
    public partial class MessagePatient : Window
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

        //(user.Id, user.Fname, user.Lname,user.Phone, user.Email, user.Region, user.Image)
        public MessagePatient(string id, string fname, string lname, string phone, string email, string region, string image)
        {
            InitializeComponent();
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            Id = id; Fname = fname; Lname = lname; Phone = phone; Email = email; Region = region; Image = image;
            this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Id == Id) };
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myText = new TextRange(message.Document.ContentStart, message.Document.ContentEnd).Text;

                Messenger.Send(myText, phone.Text);
                MessageBox.Show("message sent");
                MessagePatient page = new MessagePatient(null,null,null,null,null,null,null);
                page.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {

            fname.Text = Fname; lname.Text = Lname; phone.Text = Phone; email.Text = Email;

        }

        public string Answer
        {
            get { return "" + Name + " has been updated"; }
        }
    }
}
