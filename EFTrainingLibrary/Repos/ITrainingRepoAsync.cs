using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface ITrainingRepoAsync
    {
        Task InsertTrainingAsync(Training training);
        Task UpdateTrainingAsync(int trainingId, Training training);
        Task DeleteTrainingAsync(int trainingId);
        Task<List<Training>> GetAllTrainingsAsync();
        Task<Training> GetTrainingAsync(int trainingId);
        Task<List<Training>> GetTrainingByTechnologyIdAsync(int techId);
        Task<List<Training>> GetTrainingByTrainerIdAsync(int trainerId);
    }
}
