using amHealth.View.patient;
using amLibrary;
using amLibrary.Helpers;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace amHealth.View.queue
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddQueue : Window
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;
        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;

        private Queue _queue;
        private ObservableCollection<Queue> _queueList = null;
        private string selectedPrac = "";

        public AddQueue()
        {
            InitializeComponent();
        
            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);
            practitioners.ItemsSource = null;
            foreach (Practitioner prac in _practitionerList)
            {
                practitioners.Items.Add(prac.Name);
            }         

        }
        public string Answer
        {
            get { return " "; }
        }


        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveQueue();
                this.DialogResult = true;
            }
            catch 
            {

                return;

            }

        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            object value = "";
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                this.DataContext = null;
            }
            else if (!String.IsNullOrEmpty(txtFilter.Text))
            {
                this.DataContext = null;
                if (_patientList.Where(x => x.Phone.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Phone.Contains(txtFilter.Text)) };
                }

                else if (_patientList.Where(x => x.Fname.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Fname.Contains(txtFilter.Text)) };
                }
                else if (_patientList.Where(x => x.Lname.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Lname.Contains(txtFilter.Text)) };
                }
                else if (_patientList.Where(x => x.Email.Contains(txtFilter.Text)).Count() > 0)
                {
                    this.DataContext = new CollectionViewSource { Source = _patientList.Where(x => x.Email.Contains(txtFilter.Text)) };
                }

            }

        }
        private void SaveQueue()
        {
          
            _queue = App.amApp.Queues.Add();
            _queue.Patient = patient.Content.ToString();
            _queue.Practitioner = selectedPrac;
            _queue.Payment = payment.Text;
            _queue.Amount = amount.Text;
            _queue.Checked = DateTime.Now.TimeOfDay.ToString();
            _queue.Day = DateTime.Now.ToString();
            _queue.Reason = reason.Text;
            _queue.Sync = "F";
            _queue.Org = "test";
            _queue.Seen = "F";
            _queue.Save();

           // Messenger.Send("You have `scheduled an appointment with" + _practitionerList.First(x => x.Id == selectedPrac).Practice + "  on:" + startDate.Text + " at:" + endHour.Text + ":" + endMin.Text + "  ", _patientList.First(x => x.Id == patient.Content.ToString()).Phone);    
          


            System.Windows.MessageBox.Show("Queue created ");
            this.DialogResult = true;

        }

        private void PractitionerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedPract = _practitionerList.First(x => x.Name.Contains(practitioners.SelectedItem.ToString())).Id;

            if (selectedPract != null)
            {
                selectedPrac = selectedPract.ToString();
            }

        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient inputDialog = new AddPatient();
            if (inputDialog.ShowDialog() == true)
                _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
                System.Windows.MessageBox.Show("done");
            
          
        }



    }
}
