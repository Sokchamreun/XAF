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
    [DefaultClassOptions, ImageName("BO_Task")]
    public class Department : XPObject
    {
        public Department(Session session) : base(session) { }
        int departmentId;
        public Int32 DepartmentId
        {
            get { return departmentId; }
            protected set { SetPropertyValue("DepartmentId", ref departmentId, value); }
        }
        string departmentName;
        public String DepartmentName
        {
            get { return departmentName; }
            set { SetPropertyValue("DepartmentName", ref departmentName, value); }
        }

        [Association("Department-EmpContact")]
        public XPCollection<EmpContact> EmpCollection
        {
            get { return GetCollection<EmpContact>("EmpCollection"); }
        }
       
    }
}
