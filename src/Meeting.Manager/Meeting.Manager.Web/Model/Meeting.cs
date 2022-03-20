using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting.Manager.Web.Model
{
    public class Meeting
    {
        public string PersonObserved { get; set; }
        public string DateOfDiscussion { get; set; }
        public string Location { get; set; }
        public string Colleagues { get; set; }
        public string SubjectOfDiscussion { get; set; }
        public string Outcome { get; set; }
    }
}
