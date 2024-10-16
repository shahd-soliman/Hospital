using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P.Models;

public partial class MedicalRecord
{
    [Key]
    public int RecordId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string PatientMedicalHistory { get; set; } = null!;

    public string Medications { get; set; } = null!;

    public string Diagnosis { get; set; } = null!;

    public string TestResults { get; set; } = null!;

    public string ProgressNotes { get; set; } = null!;

    public string TreatmentPlans { get; set; } = null!;

    public string VitalSigns { get; set; } = null!;

    public string SurgicalReports { get; set; } = null!;

    public string DischargeSummaries { get; set; } = null!;

    public virtual Doctor? Doctor { get; set; }
    [ForeignKey("Doctor")]
    public int? Did { get; set; }
    [JsonIgnore]
    public virtual ICollection<Patient>? Patients { get; set; } = new List<Patient>();
}
