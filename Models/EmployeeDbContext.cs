using Microsoft.EntityFrameworkCore;

namespace ApiMagazine.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }
        // Banco
        public DbSet<Employee> Employee { get; set; }
    }
}