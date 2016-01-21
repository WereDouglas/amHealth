using amLibrary;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.Server;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amHealth.modem
{
    /// <summary>
    /// Interaction logic for BlankPage.xaml
    /// </summary>
    public partial class ModemPage : Page
    {
        private GsmCommMain comm;
        private delegate void SetTextCallback(string text);
      
          private Member _member;
          private ObservableCollection<Member> _memberList = null;
        public ModemPage()
        {
            InitializeComponent();    
              _memberList = new ObservableCollection<Member>(App.amApp.Members);
           
           
        }
      
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCOM.Text == "")
            {
                System.Windows.MessageBox.Show("Invalid Port Name");
                return;
            }
             comm = new GsmCommMain(cmbCOM.Text , 9600, 150);

             try
             {
                 comm.Open();
                 System.Windows.MessageBox.Show("Modem Connected Sucessfully");
             }
             catch (Exception)
             {
                 System.Windows.MessageBox.Show("no modem connected");
             }               

        }
        string message;
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Operation code = new Operation();
            try
            {
               
                foreach (Member  myrow in _memberList)
                {
                   
                  
                    message = "Desktop application testing standalone";
                    try
                    {
                        SmsSubmitPdu pdu;
                        byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                        pdu = new SmsSubmitPdu(message, Convert.ToString(myrow.Contact), dcs);
                        int times = 1;
                        for (int i = 0; i < times; i++)
                        {
                            comm.SendMessage(pdu);
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Modem is not available");
                     }
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("SMS not send");
            }
            System.Windows.MessageBox.Show("All messages sent to ");

        }

     
        }

       
}
