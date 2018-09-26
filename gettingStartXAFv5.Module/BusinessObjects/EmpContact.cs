using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace gettingStartXAFv5.Module.BusinessObjects.User
{
    [NavigationItem("User")]
    [DefaultClassOptions, ImageName("BO_Customer")]
    public class EmpContact : XPObject
    {
        public EmpContact(Session session) : base(session) { }
        int id;
        public int EmpId
        {
            get { return id; }
            protected set { SetPropertyValue("Id", ref id, value); }
        }
        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetPropertyValue("FirstName", ref firstName, value); }
        }
        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue("LastName", ref lastName, value); }
        }

        private Department department;
        [Association("Department-EmpContact")]
        public Department Department
        {
            get { return department; }
            set { SetPropertyValue("Department", ref department, value); }
        }

        
        [Association("EmpContact-Note"), DevExpress.Xpo.Aggregated]
        public XPCollection<Note> NoteCollection
        {
            get { return GetCollection<Note>("NoteCollection"); }
        }

        [Association("EmpContact-Task")]
        public XPCollection<Task> TaskCollection
        {
            get { return GetCollection<Task>("TaskCollection"); }
        }

        [Aggregated]
        private Address address;
        public Address Address
        {
            get { return address; }
            set
            {
                if (address == value)
                    return;

                Address prevAddress = address;
                address = value;

                if (IsLoading)
                    return;
                if (prevAddress != null && prevAddress.EmpContact == this)
                    prevAddress.EmpContact = null;

                if (address != null)
                    address.EmpContact = this;

                OnChanged("Address");
            }

        }
    }
}
