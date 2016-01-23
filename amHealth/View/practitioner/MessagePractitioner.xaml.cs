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

namespace amHealth.View.practitioner
{
    /// <summary>
    /// Interaction logic for EditPractitioner.xaml
    /// </summary>
    public partial class MessagePractitioner : Window
    {
        private Practitioner _practitioner;

        private string Id;
        private string Name;
        private string Phone;
        private string Email;
        private string Image;
        private string Sync;
        private ObservableCollection<Practitioner> _practitionerList = null;

        //(user.Id, user.Fname, user.Lname,user.Phone, user.Email, user.Region, user.Image)
        public MessagePractitioner(string id, string name, string phone, string email, string image)
        {
            InitializeComponent();
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            Id = id; Name = name; Phone = phone; Email = email; Image = image;
            this.DataContext = new CollectionViewSource { Source = _practitionerList.Where(x => x.Id == Id) };
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            string myText = new TextRange(message.Document.ContentStart, message.Document.ContentEnd).Text;
            try
            {


                Messenger.Send(App.amApp, myText, phone.Text);
                
                MessageBox.Show("message sent");
            }
            catch 
            {
              
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {

            name.Text = Name; phone.Text = Phone; email.Text = Email;

        }

        public string Answer
        {
            get { return "" + Name + " has been updated"; }
        }
    }
}
