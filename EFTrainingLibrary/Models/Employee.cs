using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Designation { get; set; }

    public string? EmpPhone { get; set; }

    public string? EmpEmail { get; set; }

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
