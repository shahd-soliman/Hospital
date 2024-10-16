using System.ComponentModel.DataAnnotations.Schema;

namespace P.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public string? F_Name { get; set; }
        public string? L_Name { get; set; }
        public int? Age { get; set; }
        public string? Message { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime Date { get; set; }
        public virtual Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        [ForeignKey("Doctor")]
        public int? DocId { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

    }
}
