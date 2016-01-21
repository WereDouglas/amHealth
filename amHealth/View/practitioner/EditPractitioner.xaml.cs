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

namespace amHealth.View.practitioner
{
    /// <summary>
    /// Interaction logic for EditPractitioner.xaml
    /// </summary>
    public partial class EditPractitioner : Window
    {
        private Practitioner _practitioner;
      
        private string Id;
        private string Name;        
        private string Practice;        
        private string Phone;
        private string Email;      
        private string Image;
        private string Sync;
        private ObservableCollection<Practitioner> _practitionerList = null;

     
        public EditPractitioner(string id,string name,string phone,string email,string practice,string image)
        {
            InitializeComponent();
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            Id = id; Name = name; Phone = phone; Email = email; Image = image; Practice = practice;
            this.DataContext = new CollectionViewSource { Source = _practitionerList.Where(x => x.Id == Id) };
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _practitioner = App.amApp.Practitioners.Add();
               
                _practitioner.Update(Id, name.Text,phone.Text,email.Text,practice.Text);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {

            name.Text = Name; phone.Text = Phone; email.Text = Email; practice.Text = Practice;  
         
        }

        public string Answer
        {
            get { return "" + Name + " has been updated"; }
        }
    }
}
