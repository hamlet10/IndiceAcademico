using IndiceAcademico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndiceAcademico.Persistense.Config
{
    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollments>
    {
        public void Configure(EntityTypeBuilder<Enrollments> builder)
        {
            builder.HasKey(e => new { e.SubjectId, e.StudentId });
            builder.HasOne(e => e.Subject).WithMany(s => s.Enrollments);
            builder.HasOne(e => e.Student).WithMany(s => s.Enrollments);


        }
    }
}