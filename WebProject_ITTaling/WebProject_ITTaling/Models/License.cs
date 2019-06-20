using System;

namespace WebProject_ITTaling.Models
{
    public class License
    {
        public int licenseID { get; set; }
        public string licenseName { get; set; }
        public string licenseNumber { get; set; }
        public string licenseAgency { get; set; }
        public DateTime licenseAcqDate { get; set; }
        public int memberID { get; set; }

        public virtual Member Member { get; set; }
    }
}