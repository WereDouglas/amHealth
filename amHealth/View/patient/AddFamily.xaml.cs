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
    /// Interaction logic for AddFamily.xaml
    /// </summary>
    public partial class AddFamily : Window
    {
        private Family _family;
        private ObservableCollection<Family> _familyList = null;
        private string patient;

        WebCam webcam;
        public AddFamily(string id)
        {
            patient = id;
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);

        }
        public string Answer
        {
            get { return name.Text + " "; }
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
                SaveFamily();
                this.DialogResult = true;
            }
            catch 
            {
               
            }
        }
        private void SaveFamily()
        {
            // string paths = @"c:\amHealth\images";
            string filePath = @"c:\amHealth\\images\" + name.Text + ".jpg";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgCapture.Source));

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);

            _family = App.amApp.Familys.Add();

            _family.Name = name.Text;
            _family.Phone = phone.Text;
            _family.Relationship = relationship.Text;
            _family.Sync = "F";
            if (chkNotify.IsChecked == true)
            {
                _family.Notify = "true";
            }
            else
            {

                _family.Notify = "false";
            }
            _family.Email = email.Text;
            _family.Patient = patient;
            _family.Image = name.Text + ".jpg";
            _family.Save();
            System.Windows.MessageBox.Show("Family saved ");
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
