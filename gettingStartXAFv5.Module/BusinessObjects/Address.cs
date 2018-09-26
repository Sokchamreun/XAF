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
    [DefaultClassOptions, ImageName("BO_Address")]
    public class Address : XPObject
    {
        public Address(Session session) : base(session) { }
        int empId;
        public int EmpId
        {
            get { return empId; }
            protected set { SetPropertyValue("EmpId", ref empId, value); }
        }
        [Size(SizeAttribute.Unlimited)]
        string addr;
        public string Addr
        {
            get { return addr; }
            set { SetPropertyValue("Addr", ref addr, value); }
        }
        
        EmpContact empContact = null;
        public EmpContact EmpContact
        {
            get { return empContact; }
            set
            {
                if (empContact == value)
                    return;

                EmpContact prevEmpContact = empContact;
                empContact = value;

                if (IsLoading)
                    return;

                if (prevEmpContact != null && prevEmpContact.Address == this)
                    prevEmpContact.Address = null;

                if (empContact != null)
                    empContact.Address = this;

                OnChanged("EmpContact");
            }
        }
    }
}
