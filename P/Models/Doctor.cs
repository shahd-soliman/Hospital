using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P.Models;

public partial class Doctor
{
    [Key]
    public int? DId { get; set; }
    public string? F_Name { get; set; }

    public string? M_Name { get; set; }

    public string? L_Name { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Salary { get; set; }

    public DateOnly? Hire_Date { get; set; }

    public string? Gender { get; set; }

    public string? Shift_Type { get; set; }
    public string? ImgName { get; set; }
    public virtual Department? Dept { get; set; }
    [ForeignKey("Dept")]
    public int? DeptId { get; set; }
    [JsonIgnore]
    public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; } = new List<MedicalRecord>();
    public virtual ICollection<Appointment>? Appointments { get; set; }
}
