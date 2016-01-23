using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amLibrary.Helpers
{
    public class Messenger
    {
        private static GsmCommMain comm;
        private delegate void SetTextCallback(string text);
        private static string cmbCOM;
        private static Message _message;
        private static string state;

        public static void Send(DBObject parent, string message, string number)
        {
            try
            {

                SmsSubmitPdu pdu;
                byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                pdu = new SmsSubmitPdu(message, Convert.ToString(number), dcs);
                int times = 1;
                for (int i = 0; i < times; i++)
                {
                    comm.SendMessage(pdu);
                }

                _message = new Message(parent);
                _message.Org = "test";
                _message.Type = "sms";
                _message.Content = message;
                _message.Contact = number;
                _message.Dor = DateTime.Now.ToString();
                _message.Sync = "F";
                _message.Sent = "T";

                _message.Save();

            }
            catch
            {
                _message = new Message(parent);
                _message.Org = "test";
                _message.Type = "sms";
                _message.Content = message;
                _message.Contact = number;
                _message.Dor = DateTime.Now.ToString();
                _message.Sync = "F";
                _message.Sent = "F";

                _message.Save();


            }
        }


        public static void SendUpdate(DBObject parent, string id, string message, string number)
        {
            try
            {

                SmsSubmitPdu pdu;
                byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                pdu = new SmsSubmitPdu(message, Convert.ToString(number), dcs);
                int times = 1;
                for (int i = 0; i < times; i++)
                {
                    comm.SendMessage(pdu);
                }
                // Update(string id,string sent)
                _message.Update(id, "T");


            }
            catch
            {

            }
        }
        static bool ports = false;
        public static string connect()
        {
            state = "false";
            int d = 0;
            do
            {
                d++;
                cmbCOM = "COM" + d.ToString();
                comm = new GsmCommMain(cmbCOM, 9600, 150);
                Console.WriteLine(cmbCOM);
                try
                {
                    comm.Open();
                    ports = true;
                    state = "true";
                }
                catch (Exception)
                {
                    ports = false;

                }

            }
            while (ports == false && d < 30);


            Console.WriteLine(cmbCOM);
            return state;

        }

    }
}
