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
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        private Patient _patient;
        private ObservableCollection<Patient> _patientList = null;


        WebCam webcam;
        public AddPatient()
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);

        }
        public string Answer
        {
            get { return fname.Text + " " + lname.Text; }
        }

        private void bntStart_Click(object sender, RoutedEventArgs e)
        {
            webcam.Start();
        }

        private void bntStop_Click(object sender, RoutedEventArgs e)
        {
            webcam.Stop();
        }

        private void bntCapture_Click(object sender, RoutedEventArgs e)
        {
            imgCapture.Source = imgVideo.Source;
        }

        private void bntContinue_Click(object sender, RoutedEventArgs e)
        {
            webcam.Continue();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SavePatient();
                this.DialogResult = true;
            }
            catch 
            {

            }

        }
        private void SavePatient()
        {
            // string paths = @"c:\amHealth\images";
            string filePath = @"c:\amHealth\\images\" +fname.Text+"-"+lname.Text +".jpg";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgCapture.Source));

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);

            _patient = App.amApp.Patients.Add();
            _patient.Lname = lname.Text;
            _patient.Fname = fname.Text;
            _patient.Gender = gender.Text;
            _patient.Dob = dob.Text;
            _patient.Height = height.Text;
            _patient.Weight = weight.Text;
            _patient.Phone = phone.Text;
            _patient.Region = region.Text;
            _patient.Sync = "F";
            _patient.Email = email.Text;
            _patient.Org = "test";
            _patient.Image = fname.Text + "-" + lname.Text + ".jpg";


            _patient.Save();
            System.Windows.MessageBox.Show("Patient saved ");
            this.DialogResult = true;

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgCapture.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
