using Microsoft.EntityFrameworkCore;
using Task1.Models.Domain;

namespace Task1.Data
{
    public class MVCDemoContext :DbContext
    // Entity Framework which is used to connect to a database and perform CRUD (Create, Read, Update, Delete) operations on the data
    //The DbContext class provides various methods to query and manipulate data, including Add, Remove, Find, and SaveChanges.
    {
        public MVCDemoContext(DbContextOptions options):base(options) 
        { 
        }

        public DbSet<Employee1> Employee1 { get; set; }
        // DbSet is being used to manage a collection of employee records in a database. 
    }
}
