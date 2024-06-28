using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFTraineeRepoAsync : ITraineeRepoAsync
    {
        EYTrainingDB2Context ctx = new EYTrainingDB2Context();
        public async Task DeleteTraineeAsync(int trainingId, int empId)
        {
            Trainee trainee2del = await GetTraineeAsync(trainingId,empId);
            ctx.Trainees.Remove(trainee2del);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Trainee>> GetAllTraineeAsync()
        {
            List<Trainee> trainees = await ctx.Trainees.ToListAsync();
            return trainees;
        }

        public async Task<Trainee> GetTraineeAsync(int trainingId, int empId)
        {
            try
            {
                Trainee trainee = await (from t in ctx.Trainees where (t.TrainingId == trainingId && t.EmpId==empId) select t).FirstAsync();
                return trainee;
            }
            catch
            {
                throw new TrainingException("No such Trainee ID");
            }
        }

        public async Task<List<Trainee>> GetTraineeByEIdAsync(int empId)
        {
            var trainees = await(from t in ctx.Trainees
                                  where t.EmpId == empId
                                  select t).ToListAsync();

            if (trainees.Count == 0)
            {
                throw new TrainingException("No empId in this training");
            }

            return trainees;
        }

        public  async Task<List<Trainee>> GetTraineeByTrainingIdAsync(int trainingId)
        {
            var trainees = await (from t in ctx.Trainees
                                   where t.TrainingId == trainingId
                                   select t).ToListAsync();

            if (trainees.Count == 0)
            {
                throw new TrainingException("No trainingId in this training");
            }

            return trainees;
        }

        public async Task InsertTraineeAsync(Trainee trainee)
        {
            await ctx.Trainees.AddAsync(trainee);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTraineeAsync(int trainingId, int empId, Trainee trainee)
        {
            Trainee trainee2edit = await GetTraineeAsync(trainingId,empId);
            trainee2edit.Status = trainee.Status;
            await ctx.SaveChangesAsync();
        }
    }
}
