using amLibrary;
using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amHealth
{
    public static class Reminder
    {
        private static BackgroundWorker bw = new BackgroundWorker();

        private static ObservableCollection<Appointment> _appointmentList = null;

        private static Appointment _appointment;
        private static ObservableCollection<Patient> _patientList = null;

        private static ObservableCollection<Practitioner> _practitionerList = null;

        public static void Remind()
        {
            string selectdate = DateTime.Now.Date.ToString();
            _appointmentList = new ObservableCollection<Appointment>(App.amApp.Appointments);

            _patientList = new ObservableCollection<Patient>(App.amApp.Patients);
            _practitionerList = new ObservableCollection<Practitioner>(App.amApp.Practitioners);

            foreach (Appointment T in _appointmentList)
            {
                if (T.Reminder == "false")
                {
                    if (Convert.ToDateTime(T.Dated).Date == Convert.ToDateTime(selectdate).Date)
                        Messenger.Send(App.amApp, "Reminder You are reminded of your appointment with a " + _practitionerList.First(x => x.Id == T.Practitioner).Practice + "  on:" + T.Dated + " at:" + T.Meet + "to " + T.EndTime + " ", _patientList.First(x => x.Id == T.Patient.ToString()).Phone);
                    _appointment = new Appointment(null);
                    _appointment.UpdateReminder(T.Id, "true");


                }
            }



        }
    }
}
