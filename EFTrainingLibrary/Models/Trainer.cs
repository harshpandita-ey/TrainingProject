using System;
using System.Collections.Generic;

namespace EFTrainingLibrary.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string? TrainerName { get; set; }

    public string? TrainerType { get; set; }

    public string? TrainerPhone { get; set; }

    public string? TrainerEmail { get; set; }

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
