using System.Collections.Generic;

namespace WebProject_ITTaling.Models
{
    public class Application
    {
        public int applicationID { get; set; }
        public string applicationLevel { get; set; }
        public int lectureID { get; set; }
        public int memberID { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<ApplySchedule> ApplySchedules { get; set; }
    }
}