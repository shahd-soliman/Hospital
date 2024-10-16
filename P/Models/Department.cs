using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace P.Models;

public partial class Department
{
    [Key]
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public string? DeptLocation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
    
    public string? Logo { get; set; }
    public string? Img { get; set; }
    public string? Headline { get; set; }
    public string? Description { get; set; }
    public string? Web_Id { get; set; }

    //Attribute cost
    public int? Cost { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
}
