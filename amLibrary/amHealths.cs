using amLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amLibrary
{
   public class amHealths:DBObject
    {
         public amHealths()
            : base(null)
        {
            _practitioners = new PractitionerCollection(this);
            _patients = new PatientCollection(this);
            _appointments = new AppointmentCollection(this);
            _groups = new GroupCollection(this);
            _members = new MemberCollection(this);
            _queues = new QueueCollection(this);
            _messages = new MessageCollection(this);


        }

        private PatientCollection _patients;

        public PatientCollection Patients
        {
            get
            {
                if (!_patients.IsLoaded)
                    _patients.Refresh();
                _patients.Load();
                return _patients;
            }
        }
        private GroupCollection _groups;

        public GroupCollection Groups
        {
            get
            {
                if (!_groups.IsLoaded)
                    _groups.Refresh();
                _groups.Load();
                return _groups;
            }
        }


        private PractitionerCollection _practitioners;

        public PractitionerCollection Practitioners
        {
            get
            {
                if (!_practitioners.IsLoaded)
                    _practitioners.Refresh();
                _practitioners.Load();
                return _practitioners;
            }
        }


        private AppointmentCollection _appointments;

        public AppointmentCollection Appointments
        {
            get
            {
                if (!_appointments.IsLoaded)
                    _appointments.Refresh();
                _appointments.Load();
                return _appointments;
            }
        }


        private MemberCollection _members;
        public MemberCollection Members
        {
            get
            {
                if (!_members.IsLoaded)
                    _members.Refresh();
                _members.Load();
                return _members;
            }
        }

        private QueueCollection _queues;
        public QueueCollection Queues
        {
            get
            {
                if (!_queues.IsLoaded)
                    _queues.Refresh();
                _queues.Load();
                return _queues;
            }
        }


        private MessageCollection _messages;
        public MessageCollection Messages
        {
            get
            {
                if (!_messages.IsLoaded)
                    _messages.Refresh();
                _messages.Load();
                return _messages;
            }
        }



    }
}
