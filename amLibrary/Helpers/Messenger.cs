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
        public static void Send(string message, string number)
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static bool ports = false;
        public static void connect()
        {

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
                }
                catch (Exception)
                {
                    ports = false;

                }

            }
            while (ports == false && d < 30);


            Console.WriteLine(cmbCOM);

        }

    }
}
