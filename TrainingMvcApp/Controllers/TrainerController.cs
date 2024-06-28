using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TrainerController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5290/api/Trainer/") };
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            List<Trainer> trainers = await client.GetFromJsonAsync<List<Trainer>>("");
            return View(trainers);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int trainerId)
        {
            Trainer trainer = await client.GetFromJsonAsync<Trainer>("" + trainerId);
            return View(trainer);
        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            Trainer trainer = new Trainer();
            return View(trainer);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Trainer trainer)
        {
            try
            {
                await client.PostAsJsonAsync<Trainer>("", trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        [Route("Trainer/Edit/{trainerid}")]
        public async Task<ActionResult> Edit(int trainerid)
        {
            Trainer trainer = await client.GetFromJsonAsync<Trainer>("" + trainerid);
            return View(trainer);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainer/Edit/{trainerid}")]
        public async Task<ActionResult> Edit(int trainerid, Trainer trainer)
        {
            try
            {
                await client.PutAsJsonAsync("" + trainerid, trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [Route("Trainer/Delete/{trainerid}")]
        public async Task<ActionResult> Delete(int trainerid)
        {
            Trainer trainer = await client.GetFromJsonAsync<Trainer>("" + trainerid);
            return View(trainer);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainer/Delete/{trainerid}")]
        public async Task<ActionResult> Delete(int trainerid, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + trainerid);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
