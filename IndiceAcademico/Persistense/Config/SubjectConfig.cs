using IndiceAcademico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndiceAcademico.Persistense.Config
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(s => s.ID).ValueGeneratedOnAdd();
            builder.Property(s => s.Code).HasColumnType("varchar(10)").IsRequired();
            builder.Property(s => s.Name).HasColumnType("nvarchar(80)").IsRequired();
            builder.Property(s => s.Cred).IsRequired();
            builder.HasMany(s => s.Enrollments).WithOne(e => e.Subject).HasForeignKey(e => e.SubjectId);

            // builder.HasData(

            //     //Hamlet

            // );

        }
    }
}