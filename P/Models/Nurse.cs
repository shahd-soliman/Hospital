using System;
using System.Collections.Generic;

namespace P.Models;

public partial class Nurse
{
    public int NId { get; set; }

    public string? TypeDegree { get; set; }

    public int? EmpId { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
