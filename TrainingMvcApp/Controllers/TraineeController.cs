using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Security.Policy;
using TrainingMvcApp.Models;
namespace TrainingMvcApp.Controllers
{
    public class TraineeController : Controller
    {
        // GET: TraineeController
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5290/api/Trainee/") };

        public async Task<ActionResult> Index()
        {
            List<Trainee> traniees = await client.GetFromJsonAsync<List<Trainee>>("");
            return View(traniees);
        }

        // GET: TraineeController/Details/5
        public async Task<ActionResult> Details(int TrainingId, int EmpId)
        {

            Trainee trainee = await client.GetFromJsonAsync<Trainee>("" + TrainingId + "/" + EmpId);
            return View(trainee);
        }

        // GET: TraineeController/Create
        public async Task<ActionResult> Create()
        {

            Trainee trainee = new Trainee();
            return View(trainee);
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Trainee trainee)
        {
            try
            {
                await client.PostAsJsonAsync<Trainee>("", trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Edit/5]
        [Route("Trainee/Edit/{TrainingId}/{EmpId}")]
        public async Task<ActionResult> Edit(int TrainingId, int EmpId
            )
        {
            Trainee trainee = await client.GetFromJsonAsync<Trainee>("" + TrainingId + "/" + EmpId);

            return View();
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/Edit/{TrainingId}/{EmpId}")]
        public async Task<ActionResult> Edit(int TrainingId, int EmpId, Trainee trainee)
        {
            try
            {
                await client.PutAsJsonAsync("" + TrainingId + "/" + EmpId, trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Delete/5
        [Route("Trainee/Delete/{TrainingId}/{EmpId}")]
        public async Task<ActionResult> Delete(int TrainingId, int EmpId)
        {
            Trainee trainee = await client.GetFromJsonAsync<Trainee>("" + TrainingId + "/" + EmpId);

            return View();
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/Delete/{TrainingId}/{EmpId}")]
        public async Task<ActionResult> Delete(int TrainingId, int EmpId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + TrainingId + "/" + EmpId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ByTrainingId(int TrainingId)
        {
            List<Trainee> trainees = await client.GetFromJsonAsync<List<Trainee>>("ByTrainingId/" + TrainingId);
            return View(trainees);
        }

        public async Task<ActionResult> ByEmployeeId(int EmpId)
        {
            List<Trainee> trainees = await client.GetFromJsonAsync<List<Trainee>>("ByEmpId/" + EmpId);
            return View(trainees);
        }
    }
}
