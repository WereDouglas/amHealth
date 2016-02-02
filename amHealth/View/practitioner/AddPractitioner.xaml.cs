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

namespace amHealth.View.practitioner
{
    /// <summary>
    /// Interaction logic for AddPractitioner.xaml
    /// </summary>
    public partial class AddPractitioner : Window
    {
        private Practitioner _practitioner;
        private ObservableCollection<Practitioner> _practitionerList = null;


        WebCam webcam;
        public AddPractitioner()
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);

        }
        public string Answer
        {
            get { return name.Text + " " ; }
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
                SavePractitioner();
                this.DialogResult = true;
            }
            catch 
            {

               
            }

        }
        private void SavePractitioner()
        {
            // string paths = @"c:\amHealth\images";
            string filePath = @"c:\amHealth\\images\" +name.Text +".jpg";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgCapture.Source));

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);

            _practitioner = App.amApp.Practitioners.Add();

            _practitioner.Name = name.Text;
            _practitioner.Phone = phone.Text;
            _practitioner.Practice = practice.Text;    
            _practitioner.Sync = "F";
            _practitioner.Email = email.Text;
            _practitioner.Org = "test";
            _practitioner.Image = name.Text +".jpg";
            _practitioner.Save();
            System.Windows.MessageBox.Show("Practitioner saved ");
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

    }
}
