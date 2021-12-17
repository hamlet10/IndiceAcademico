using IndiceAcademico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndiceAcademico.Persistense.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.ID).ValueGeneratedOnAdd();
            builder.Property(s => s.Code).IsRequired();
            builder.Property(s => s.Name).HasColumnType("nvarchar(80)")
            .IsRequired();
            builder.Property(s => s.LastName).HasColumnType("nvarchar(80)")
            .IsRequired();
            builder.HasMany(s => s.Enrollments).WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);

            builder.HasData(
                new Student { Code = 1059560, Name = "Hamlet", LastName = "Sánchez" },
                new Student { Code = 1096394, Name = "Pablo", LastName = "Díaz" },
                new Student { Code = 1095352, Name = "Enamuel", LastName = "Ureña" },
                new Student { Code = 1095352, Name = "Hector", LastName = "Soriano" }
            );

        }
    }
}