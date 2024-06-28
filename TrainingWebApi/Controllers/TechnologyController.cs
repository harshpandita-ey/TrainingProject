using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;

namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        readonly ITechnologyRepoAsync techRepo;
        public TechnologyController(ITechnologyRepoAsync techRepoAsync)
        {
            techRepo = techRepoAsync;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Technology> technologies = await techRepo.GetAllTechnologyAsync();
            return Ok(technologies);
        }
        [HttpGet("{techId}")]
        public async Task<ActionResult> GetOne(int techId)
        {
            try
            {
                Technology tech = await techRepo.GetTechnologyAsync(techId);
                return Ok(tech);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add(Technology technology)
        {
            try
            {

                await techRepo.InsertTechnologyAsync(technology);
                return Created($"api/Technology/{technology.TechnologyId}", technology);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{techId}")]
        public async Task<ActionResult> Update(int techId, Technology technology)
        {
            try
            {
                await techRepo.UpdateTechnologyAsync(techId, technology);
                return Ok(technology);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{techId}")]
        public async Task<ActionResult> Delete(int techId)
        {
            try
            {
                await techRepo.DeleteTechnologyAsync(techId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
