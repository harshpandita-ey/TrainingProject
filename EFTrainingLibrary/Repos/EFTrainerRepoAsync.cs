using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFTrainerRepoAsync : ITrainerRepoAsync
    {
        EYTrainingDB2Context ctx = new EYTrainingDB2Context();
        public async Task DeleteTrainerAsync(int trainerId)
        {
            Trainer trainer2del = await GetTrainerAsync(trainerId);
            ctx.Trainers.Remove(trainer2del);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Trainer>> GetAllTrainerAsync()
        {
            List<Trainer> trainers = await ctx.Trainers.ToListAsync();
            return trainers;
        }

        public async Task<Trainer> GetTrainerAsync(int trainerId)
        {
            try
            {
                Trainer trainer = await(from t in ctx.Trainers where t.TrainerId == trainerId select t).FirstAsync();
                return trainer;
            }
            catch
            {
                throw new TrainingException("No such Technology ID");
            }
        }

        public async Task InsertTrainerAsync(Trainer trainer)
        {
            await ctx.Trainers.AddAsync(trainer);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTrainerAsync(int trainerId, Trainer trainer)
        {
            Trainer trainer2edit = await GetTrainerAsync(trainerId);
            trainer2edit.TrainerName = trainer.TrainerName;
            trainer2edit.TrainerType = trainer.TrainerType;
            trainer2edit.TrainerPhone = trainer.TrainerPhone;
            trainer2edit.TrainerType = trainer.TrainerType;
            await ctx.SaveChangesAsync();
        }
    }
}
