using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface ITechnologyRepoAsync
    {
        Task InsertTechnologyAsync(Technology technology);
        Task UpdateTechnologyAsync(int techId, Technology technology);
        Task DeleteTechnologyAsync(int techId);
        Task<List<Technology>> GetAllTechnologyAsync();
        Task<Technology> GetTechnologyAsync(int techId);
    }
}
