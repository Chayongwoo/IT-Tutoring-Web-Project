namespace WebProject_ITTaling.Models
{
    public class Review
    {
        public int reviewID { get; set; }
        public string reviewContent { get; set; }
        public int reviewGrade { get; set; }
        public int lectureID { get; set; }
        public int memberID { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}