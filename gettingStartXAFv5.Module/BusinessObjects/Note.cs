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
    [DefaultClassOptions, ImageName("BO_Note")]
    public class Note : XPObject
    {
        public Note(Session session) : base(session) { }
        int noteId;
        public int NoteId
        {
            get { return noteId; }
            protected set { SetPropertyValue("NoteId", ref noteId, value); }
        }
        [Size(SizeAttribute.Unlimited)]
        string txtNote;
        public string TextNote
        {
            get { return txtNote; }
            set { SetPropertyValue("TextNote", ref txtNote, value); }
        }

        private EmpContact empContact;
        [Association("EmpContact-Note")]
        public EmpContact EmpContact
        {
            get { return empContact; }
            set { SetPropertyValue("EmpContact", ref empContact, value); }
        }

    }
}
