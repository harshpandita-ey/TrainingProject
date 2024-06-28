using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface ITraineeRepoAsync
    {
        Task InsertTraineeAsync(Trainee trainee);
        Task UpdateTraineeAsync(int trainingId, int empId,Trainee trainee);
        Task DeleteTraineeAsync(int trainingId, int empId);
        Task<List<Trainee>> GetAllTraineeAsync();
        Task<Trainee> GetTraineeAsync(int trainingId, int empId);
        Task<List<Trainee>> GetTraineeByEIdAsync(int empId);
        Task<List<Trainee>> GetTraineeByTrainingIdAsync(int trainingId);
    }
}
