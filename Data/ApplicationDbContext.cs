using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeManagementAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Employee> Employees {get;set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Employee>()
                .HasDiscriminator<string>("EmployeeType")
                .HasValue<Manager>("Manager")
                .HasValue<Contractor>("Contractor")
                .HasValue<Permanent>("Permanent")
                .HasValue<HR>("HR")
                .HasValue<Finance>("Finance");
        }
    }
}