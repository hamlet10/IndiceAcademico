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


            // builder.HasData(
            //     new Professor { ID = 6, Name = "Francia", LastName = "Mejia" },
            //     new Professor { ID = 7, Name = "Fausto", LastName = "Richardson" },
            //     new Professor { ID = 8, Name = "Lidia", LastName = "Noelia" },
            //     new Professor { ID = 9, Name = "John", LastName = "Joseph" },
            //     new Professor { ID = 10, Name = "Grullon", LastName = "Humberto" },
            //     new Professor { ID = 11, Name = "Luciano", LastName = "Sbritz" },
            //     new Professor { ID = 12, Name = "Maria", LastName = "Gonzalez" },
            //     new Professor { ID = 13, Name = "Samuel", LastName = "Luciano" },
            //     new Professor { ID = 14, Name = "Ramon", LastName = "Ramirez" },
            //     new Professor { ID = 15, Name = "Carolina", LastName = "Perez" },
            //     new Professor { ID = 16, Name = "Casimiro", LastName = "Cordero" }
            //     );
        }
    }
}