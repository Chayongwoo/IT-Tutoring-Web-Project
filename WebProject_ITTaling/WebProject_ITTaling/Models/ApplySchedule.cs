namespace WebProject_ITTaling.Models
{
    public class ApplySchedule
    {
        public int applyScheduleID { get; set; }
        public string applyDayofweek { get; set; }
        public string applyScheduleTime { get; set; }
        public int applicationID { get; set; }

        public virtual Application Application { get; set; }
    }
}