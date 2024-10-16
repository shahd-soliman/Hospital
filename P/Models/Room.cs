using System;
using System.Collections.Generic;

namespace P.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public string? Location { get; set; }
    public string? RoomImg { get; set; }
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
