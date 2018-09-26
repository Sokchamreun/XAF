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
    public  class Task : XPObject
    {
        public Task(Session session) : base(session) { }
        int taskId;
        public int TaskId
        {
            get { return taskId; }
            protected set { SetPropertyValue("TaskId", ref taskId, value); }
        }
        string subject;
        public string Subject
        {
            get { return subject; }
            set { SetPropertyValue("Subject", ref subject, value); }
        }
        DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { SetPropertyValue("StartDate", ref startDate, value); }
        }

        [Association("EmpContact-Task")]
        public XPCollection<EmpContact> EmpCollection
        {
            get { return GetCollection < EmpContact >("EmpCollection"); }
        }
        
    }
}
