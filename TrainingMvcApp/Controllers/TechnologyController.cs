using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;
namespace TrainingMvcApp.Controllers
{
    public class TechnologyController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri(" http://localhost:5290/api/Technology/") };

        // GET: TechnologyController
        public async Task<ActionResult> Index()
        {
            List<Technology> tech = await client.GetFromJsonAsync<List<Technology>>("");
            return View(tech);
        }

        // GET: TechnologyController/Details/5
        public async Task<ActionResult> Details(int TechId)
        {
            Technology tech = await client.GetFromJsonAsync<Technology>("" + TechId);
            return View(tech);
        }

        // GET: TechnologyController/Create
        public async Task<ActionResult> Create()
        {
            Technology tech = new Technology();
            return View(tech);
        }

        // POST: TechnologyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Technology technology)
        {
            try
            {
                await client.PostAsJsonAsync<Technology>("", technology);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnologyController/Edit/5
        [Route("Technology/Edit/{TechId}")]
        public async Task<ActionResult> Edit(string TechId)
        {
            Technology technology = await client.GetFromJsonAsync<Technology>("" + TechId);
            return View(technology);
        }

        // POST: TechnologyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Technology/Edit/{TechId}")]
        public async Task<ActionResult> Edit(int TechId, Technology technology)
        {
            try
            {
                await client.PutAsJsonAsync("" + TechId, technology);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnologyController/Delete/5
        [Route("Technology/Delete/{TechId}")]
        public async Task<ActionResult> Delete(int TechId)
        {
            Technology tech = await client.GetFromJsonAsync<Technology>("" + TechId);

            return View(tech);
        }

        // POST: TechnologyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Technology/Delete/{TechId}")]
        public async Task<ActionResult> Delete(int TechId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + TechId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}