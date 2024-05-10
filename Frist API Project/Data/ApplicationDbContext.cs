using Frist_API_Project.Models;
using Frist_API_Project.Models.DatatTransfareObject;
using Microsoft.EntityFrameworkCore;

namespace Frist_API_Project.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Department>().HasData(
        //        new Department() { Name = "IT"},
        //        new Department() { Name = "Hr"},
        //        new Department() { Name = "CS"}
        //        );
        //}

        
        
    }
}
