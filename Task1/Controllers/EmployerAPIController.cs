using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;
using Task1.Models.Domain;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerAPIController : ControllerBase
    {
        private readonly MVCDemoContext mVCDemoContext;

        public EmployerAPIController(MVCDemoContext mVCDemoContext)
        {
            this.mVCDemoContext = mVCDemoContext;
        }

        [HttpGet]
       public async Task<IActionResult> GetAdd1() 
        { 
            var employee=await mVCDemoContext.Employee1.ToListAsync();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostAdd(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee1()
            {
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                Email = addEmployeeRequest.Email,
                Contact = addEmployeeRequest.Contact

            };
            await mVCDemoContext.Employee1.AddAsync(employee);
            await mVCDemoContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
