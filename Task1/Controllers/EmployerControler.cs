using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using Task1.Data;
using Task1.Models;
using Microsoft.EntityFrameworkCore;
using Task1.Models.Domain;

namespace Task1.Controllers
{
    public class EmployerControler : Controller
    {
        private readonly MVCDemoContext mvcDemoDbContext;
        public EmployerControler(MVCDemoContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index1()
        {
            var employees = await mvcDemoDbContext.Employee1.ToListAsync();
            
            return View(employees);
        }

       

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee1()
            {
                    FirstName = addEmployeeRequest.FirstName,
                    LastName=  addEmployeeRequest.LastName,
                    Email= addEmployeeRequest.Email,
                Contact = addEmployeeRequest.Contact

            };
            await mvcDemoDbContext.Employee1.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
