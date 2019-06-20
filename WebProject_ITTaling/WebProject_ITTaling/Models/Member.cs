using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject_ITTaling.Models
{
    public class Member
    {
        public int memberID { get; set; }
        public string memberName { get; set; }
        public string memberEmail { get; set; }
        public string memberPassword { get; set; }
        public string memberType { get; set; }
        public string memberPhone { get; set; }
        public string tutorImage { get; set; }
        public string tutorPortfolio { get; set; }
        public string tutorGit { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<License> Licenses { get; set; }
    }
}