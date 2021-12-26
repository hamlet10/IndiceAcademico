using Microsoft.EntityFrameworkCore;

namespace IndiceAcademico.Models
{
    public class AcademicDBContext : DbContext
    {
        public AcademicDBContext(DbContextOptions<AcademicDBContext> options) : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }

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