using Microsoft.EntityFrameworkCore;

namespace IndiceAcademico.Models
{
    public class AcademicDBContext : DbContext
    {
        public AcademicDBContext(DbContextOptions<AcademicDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Professor).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(Student).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(Subject).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(Enrollments).Assembly);
        }
        // public DbSet<Product> Products { get; set; }
    }
}