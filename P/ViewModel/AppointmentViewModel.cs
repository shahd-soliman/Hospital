using P.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace P.ViewModel
{
    public class AppointmentViewModel
    {
        [Required(ErrorMessage = "You must entre your first name")]
        [MaxLength(25, ErrorMessage = "Name Should be less than 25 letters")]

        public string? F_Name { get; set; }
        [Required(ErrorMessage = "You must entre your last name")]
        [MaxLength(25, ErrorMessage = "Name Should be less than 25 letters")]
        public string? L_Name { get; set; }
        [Required(ErrorMessage = "You must entre your age")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "You must entre your illness description")]
        [MaxLength(2500, ErrorMessage = "You reached to the maxmuim charcter ")]
        public string? Message { get; set; }
        [Required(ErrorMessage = "You must choose your gender")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "You must entre your phone")]
        [MaxLength(11, ErrorMessage = "You reached to the maxmuim chracter")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "You must entre your address")]
        [MaxLength(100, ErrorMessage = "You reached to the maxmuim chracter")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "You must entre your date")]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        [JsonIgnore]
        public virtual Doctor? Doctor { get; set; }
        [ForeignKey("Doctor")]
        public int? DocId { get; set; }
    }
}
