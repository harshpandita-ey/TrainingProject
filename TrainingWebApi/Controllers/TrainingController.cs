using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        readonly ITrainingRepoAsync trainRepo;
        public TrainingController(ITrainingRepoAsync trainRepoAsync)
        {
            trainRepo = trainRepoAsync;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Training> trainings = await trainRepo.GetAllTrainingsAsync();
            return Ok(trainings);
        }
        [HttpGet("{trainingId}")]
        public async Task<ActionResult> GetOne(int trainingId)
        {
            try
            {
                Training training = await trainRepo.GetTrainingAsync(trainingId);
                return Ok(training);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByTechnologyId/{techId}")]
        public async Task<ActionResult> GetByTechId(int techId)
        {
            try
            {
                List<Training> trainings = await trainRepo.GetTrainingByTechnologyIdAsync(techId);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult> GetByTrainerId(int trainerId)
        {
            try
            {
                List<Training> trainings = await trainRepo.GetTrainingByTrainerIdAsync(trainerId);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add(Training training)
        {
            try
            {

                await trainRepo.InsertTrainingAsync(training);
                return Created($"api/Training/{training.TrainingId}", training);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{trainingId}")]
        public async Task<ActionResult> Update(int trainingId, Training training)
        {
            try
            {
                await trainRepo.UpdateTrainingAsync(trainingId, training);
                return Ok(training);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainingId}")]
        public async Task<ActionResult> Delete(int trainingId)
        {
            try
            {
                await trainRepo.DeleteTrainingAsync(trainingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
