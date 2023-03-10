using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using Task1.Data;
using Task1.Models;
using Microsoft.EntityFrameworkCore;
using Task1.Models.Domain;
using System.Collections.Generic;

namespace Task1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDemoContext mvcDemoDbContext;



        public EmployeeController(MVCDemoContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index1()
        {
            var employees = await mvcDemoDbContext.Employee1.ToListAsync();//all the records from a given database table as a list.

            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        //IActionResult-write more maintainable and testable code that can be easily modified in the future. 
        //implementations such as "ViewResult", "JsonResult", "RedirectResult", "ContentResult" and "StatusCodeResult"
        {
            var employee = new Employee1()
            {
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                Email = addEmployeeRequest.Email,
                Contact = addEmployeeRequest.Contact

            };
            await mvcDemoDbContext.Employee1.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");//specify the target action method
        }

        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var employee = await mvcDemoDbContext.Employee1.FirstOrDefaultAsync(x => x.Id == Id);
            //FirstOrDefaultAsync=Entity Framework Core that retrieves the first record that matches a given condition,
            //or returns a default value if no records match.
            if (employee != null)
            {

                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Contact = employee.Contact
                };
               
                return await Task.Run(() => View("View",viewModel));
                //Task.Run" method is used to execute the rendering of the view on a separate thread, which can improve the responsiveness of the application.
                //the UI thread is free to handle user input and update the display while the rendering thread is responsible for generating the view content. This can result in a smoother and more responsive user experience.
            }
            return RedirectToAction("Index1");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {

            var employee = await mvcDemoDbContext.Employee1.FindAsync(model.Id);

            if (employee != null)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Email = model.Email;
                employee.Contact = model.Contact;

                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index1");

            }
            return RedirectToAction("Index1");

        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        { 
            var employee= await mvcDemoDbContext.Employee1.FindAsync(id);
            if (employee != null) 
            
            {   
                mvcDemoDbContext.Employee1.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index1");
            }
            return RedirectToAction("Index1");
        }
    }
}
