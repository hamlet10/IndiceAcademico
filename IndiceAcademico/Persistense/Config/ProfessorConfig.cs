using IndiceAcademico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndiceAcademico.Persistense.Config
{
    public class ProfessorConfig : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("nvarchar(80)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(80)").IsRequired();
            builder.HasMany(p => p.Subjects).WithOne(s => s.Professor).HasForeignKey(s => s.ProfessorId);


            builder.HasData(
                new Professor { Name = "Francia", LastName = "Mejia" },
                new Professor { Name = "Fausto", LastName = "Richardso" },
                new Professor { Name = "Lidia", LastName = "Noelia" },
                new Professor { Name = "John", LastName = "Joseph" }
                );
        }
    }
}