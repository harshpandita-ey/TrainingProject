using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFTechnologyRepoAsync : ITechnologyRepoAsync
    {
         EYTrainingDB2Context ctx = new EYTrainingDB2Context();
        public async Task DeleteTechnologyAsync(int techId)
        {
            Technology tech2del = await GetTechnologyAsync(techId);
            ctx.Technologies.Remove(tech2del);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Technology>> GetAllTechnologyAsync()
        {
            List<Technology> techs = await ctx.Technologies.ToListAsync();
            return techs;

        }

        public async Task<Technology> GetTechnologyAsync(int techId)
        {
            try
            {
                Technology technology = await (from t in ctx.Technologies where t.TechnologyId == techId select t).FirstAsync();
                return technology;
            }
            catch
            {
                throw new TrainingException("No such Technology ID");
            }
        }

        public async Task InsertTechnologyAsync(Technology technology)
        {
            await ctx.Technologies.AddAsync(technology);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateTechnologyAsync(int techId, Technology technology)
        {
            Technology tech2edit = await GetTechnologyAsync(techId);
            tech2edit.TechnologyName = technology.TechnologyName;
            tech2edit.TechnologyType = technology.TechnologyType;
            await ctx.SaveChangesAsync();
        }
    }
}
