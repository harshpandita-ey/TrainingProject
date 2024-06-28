using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        readonly ITrainerRepoAsync trainerRepo;
        public TrainerController(ITrainerRepoAsync trainerRepoAsync)
        {
            trainerRepo = trainerRepoAsync;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Trainer> trainers = await trainerRepo.GetAllTrainerAsync();
            return Ok(trainers);
        }
        [HttpGet("{trainerId}")]
        public async Task<ActionResult> GetOne(int trainerId)
        {
            try
            {
                Trainer trainer = await trainerRepo.GetTrainerAsync(trainerId);
                return Ok(trainer);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add(Trainer trainer)
        {
            try
            {

                await trainerRepo.InsertTrainerAsync(trainer);
                return Created($"api/Trainer/{trainer.TrainerId}", trainer);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{trainerId}")]
        public async Task<ActionResult> Update(int trainerId, Trainer trainer)
        {
            try
            {
                await trainerRepo.UpdateTrainerAsync(trainerId, trainer);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainerId}")]
        public async Task<ActionResult> Delete(int trainerId)
        {
            try
            {
                await trainerRepo.DeleteTrainerAsync(trainerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
