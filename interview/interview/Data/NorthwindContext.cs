using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace interview.Data
{
    public class NorthwindContext : DbContext
    {
        private IConfiguration _configuration;
        
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) 
        { 
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this._configuration.GetConnectionString("NorthwindContext"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
