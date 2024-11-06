using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeModel> employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=Employee;User=root;Password=gabriel2006drl1;Port=3306",
                    new MySqlServerVersion(new Version(8, 0, 23)));
            };
        }
    }
}
