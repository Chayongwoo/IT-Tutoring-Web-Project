namespace WebProject_ITTaling.Models
{
    public class Schedule
    {
        public int scheduleID { get; set; }
        public string dayofweek { get; set; }
        public string scheduleTime { get; set; }
        public int lectureID { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}