using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class EmployeeAddAPIController : Controller
    {
        public IActionResult AddAPI()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAPI(AddEmployeeViewModel request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7292/api/EmployerAPI");

                var postTask = client.PostAsJsonAsync<AddEmployeeViewModel>("EmployerAPI", request);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AddAPI");
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            return View(request);
        }
    }
}
