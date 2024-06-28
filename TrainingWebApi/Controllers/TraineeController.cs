using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EFTrainingLibrary.Repos;
using EFTrainingLibrary.Models;
namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {

        readonly ITraineeRepoAsync traineeRepo;
        public TraineeController(ITraineeRepoAsync traineeRepoAsync)
        {
            traineeRepo = traineeRepoAsync;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Trainee> trainees = await traineeRepo.GetAllTraineeAsync();
            return Ok(trainees);
        }
        [HttpGet("{trainingId}/{eid}")]
        public async Task<ActionResult> GetOne(int trainingId, int eid)
        {
            try
            {
                Trainee trainee = await traineeRepo.GetTraineeAsync(trainingId, eid);
                return Ok(trainee);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add(Trainee trainee)
        {
            try
            {

                await traineeRepo.InsertTraineeAsync(trainee);
                return Created($"api/Trainer/{trainee.TrainingId}/{trainee.EmpId}", trainee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{trainingId}/{eid}")]
        public async Task<ActionResult> Update(int trainingId, int eid, Trainee trainee)
        {
            try
            {
                await traineeRepo.UpdateTraineeAsync(trainingId, eid, trainee);
                return Ok(trainee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainingId}/{eid}")]
        public async Task<ActionResult> Delete(int trainingId, int eid)
        {
            try
            {
                await traineeRepo.DeleteTraineeAsync(trainingId, eid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByEmpId/{eid}")]
        public async Task<ActionResult> GetTraineeByempId(int eid)
        {
            List<Trainee> trainees = await traineeRepo.GetTraineeByEIdAsync(eid);
            return Ok(trainees);
        }

        [HttpGet("ByTrainingId/{trainingId}")]
        public async Task<ActionResult> GetTraineeByTrainingId(int trainingId)
        {
            List<Trainee> trainees = await traineeRepo.GetTraineeByTrainingIdAsync(trainingId);
            return Ok(trainees);
        }
    }
}