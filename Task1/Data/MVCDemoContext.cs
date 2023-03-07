using Microsoft.EntityFrameworkCore;
using Task1.Models.Domain;

namespace Task1.Data
{
    public class MVCDemoContext :DbContext
    {
        public MVCDemoContext(DbContextOptions options):base(options) 
        { 
        }

        public DbSet<Employee1> Employee1 { get; set; }
    }
}
