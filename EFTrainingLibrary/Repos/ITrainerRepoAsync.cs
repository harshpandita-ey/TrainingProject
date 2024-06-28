using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface ITrainerRepoAsync
    {
        Task InsertTrainerAsync(Trainer trainer);
        Task UpdateTrainerAsync(int trainerId, Trainer trainer);
        Task DeleteTrainerAsync(int trainerId);
        Task<List<Trainer>> GetAllTrainerAsync();
        Task<Trainer> GetTrainerAsync(int trainerId);
    }
}
