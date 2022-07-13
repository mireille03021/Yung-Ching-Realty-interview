using Microsoft.EntityFrameworkCore;

namespace interview.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) 
        { 
        }

        public virtual DbSet<Employees> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Employees>().ToTable("Employees");
        }
    }
}
