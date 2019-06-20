using System.Collections.Generic;

namespace WebProject_ITTaling.Models
{
    public class Lecture
    {
        public int lectureID { get; set; }
        public string lectureTitle { get; set; }
        public string lectureLanguage { get; set; }
        public string lectureImage { get; set; }
        public string tutorIntroduce { get; set; }
        public string lectureIntroduce { get; set; }
        public string lecturePeople { get; set; }
        public string lecturePlan { get; set; }
        public int lectureCount { get; set; }
        public int lecturePrice { get; set; }
        public int lectureMaxperson { get; set; }
        public System.DateTime lectureApplyDeadline { get; set; }
        public string lectureLocation { get; set; }
        public string lecturePlace { get; set; }
        public int memberID { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}