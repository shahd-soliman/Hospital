using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P.Models
{
    public class Patient
    {
        [Key]
        public int PId { get; set; }

        public string F_Name { get; set; } = null!;

        public string L_Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public string? Phone { get; set; }
        public virtual Nurse? Nurse { get; set; } = null!;
        [ForeignKey("Nurse")]
        public int? NId { get; set; }
        public virtual MedicalRecord? Record { get; set; }

        [ForeignKey("Record")]
        public int? RecordId { get; set; }
        public virtual Room? Room { get; set; } = null!;
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }
      
        public virtual ApplicationUser? User { get; set; }
        [ForeignKey("User")]
        public int? userId { get; set; }

    }
}
