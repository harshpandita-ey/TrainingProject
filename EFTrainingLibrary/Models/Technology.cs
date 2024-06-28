using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Technology
{
    public int TechnologyId { get; set; }

    public string? TechnologyName { get; set; }

    public string? TechnologyType { get; set; }

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
