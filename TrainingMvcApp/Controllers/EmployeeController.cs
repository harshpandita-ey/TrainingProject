using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5290/api/Employee/") };
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            List<Employee> employees = await client.GetFromJsonAsync<List<Employee>>("");
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int eid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("" + eid);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            Employee emp = new Employee();
            return View(emp);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee emp)
        {
            try
            {
                await client.PostAsJsonAsync<Employee>("", emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        [Route("Employee/Edit/{eid}")]
        public async Task<ActionResult> Edit(int eid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("" + eid);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employee/Edit/{eid}")]
        public async Task<ActionResult> Edit(int eid, Employee emp)
        {
            try
            {
                await client.PutAsJsonAsync("" + eid, emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [Route("Employee/Delete/{eid}")]
        public async Task<ActionResult> Delete(int eid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("" + eid);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employee/Delete/{eid}")]
        public async Task<ActionResult> Delete(int eid, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + eid);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
