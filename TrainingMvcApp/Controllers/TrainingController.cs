using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TrainingController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5290/api/Training/") };
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            List<Training> training = await client.GetFromJsonAsync<List<Training>>("");
            return View(training);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int trainingId)
        {
            Training training = await client.GetFromJsonAsync<Training>("" + trainingId);
            return View(training);
        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            Training training = new Training();
            return View(training);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Training training)
        {
            try
            {
                await client.PostAsJsonAsync<Training>("", training);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        [Route("Training/Edit/{trainingId}")]
        public async Task<ActionResult> Edit(int trainingId)
        {
            Training training = await client.GetFromJsonAsync<Training>("" + trainingId);
            return View(training);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Training/Edit/{trainingId}")]
        public async Task<ActionResult> Edit(int trainingId, Training training)
        {
            try
            {
                await client.PutAsJsonAsync("" + trainingId, training);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [Route("Training/Delete/{trainingId}")]
        public async Task<ActionResult> Delete(int trainingId)
        {
            Training training = await client.GetFromJsonAsync<Training>("" + trainingId);
            return View(training);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Training/Delete/{trainingId}")]
        public async Task<ActionResult> Delete(int trainingId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + trainingId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ByTrainerId(int trainerId)
        {
            List<Training> trainings = await client.GetFromJsonAsync<List<Training>>("ByTrainerId/" + trainerId);
            return View(trainings);
        }

        public async Task<ActionResult> ByTechnologyId(int techId)
        {
            List<Training> trainings = await client.GetFromJsonAsync<List<Training>>("ByTechnologyId/" + techId);
            return View(trainings);
        }
    }
}
