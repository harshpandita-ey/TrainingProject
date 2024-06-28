using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFTrainingRepoAsync : ITrainingRepoAsync
    {
        EYTrainingDB2Context ctx = new EYTrainingDB2Context();
        public async Task DeleteTrainingAsync(int trainingId)
        {
            Training training2del = await GetTrainingAsync(trainingId);
            ctx.Training.Remove(training2del);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            List<Training> training = await ctx.Training.ToListAsync();
            return training;
        }

        public async Task<Training> GetTrainingAsync(int trainingId)
        {
            try
            {
                Training training = await (from t in ctx.Training where t.TrainingId == trainingId select t).FirstAsync();
                return training;
            }
            catch
            {
                throw new TrainingException("No such Training ID");
            }
        }

        public async Task<List<Training>> GetTrainingByTechnologyIdAsync(int techId)
        {
            var trainings = await (from t in ctx.Training
                                   where t.TechnologyId == techId
                                   select t).ToListAsync();

            if (trainings.Count == 0)
            {
                throw new TrainingException("No TechId with this training");
            }

            return trainings;
        }

        public async Task<List<Training>> GetTrainingByTrainerIdAsync(int trainerId)
        {
            var trainings = await (from t in ctx.Training
                                   where t.TrainerId == trainerId
                                   select t).ToListAsync();

            if (trainings.Count == 0)
            {
                throw new TrainingException("No TrainerId with this training");
            }

            return trainings;
        }

    public async Task InsertTrainingAsync(Training training)
    {
            await ctx.Training.AddAsync(training);
            await ctx.SaveChangesAsync();
        }

    public async Task UpdateTrainingAsync(int trainingId, Training training)
    {
            Training training2edit = await GetTrainingAsync(trainingId);
            training2edit.StartDate = training.StartDate;
            training2edit.EndDate = training.EndDate;
            training2edit.TechnologyId = training.TechnologyId;
            training2edit.TrainerId = training.TrainerId;
            await ctx.SaveChangesAsync();
        }
}
}

