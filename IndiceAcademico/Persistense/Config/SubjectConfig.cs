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

            builder.HasData(

                //Hamlet
                new Subject { Code = "CBM220", Name = "ESTADISTICA APLICADA A LA INGENIERIA", Cred = 4 },
                new Subject { Code = "CBM306", Name = "MATEMATICA DISCRETA II", Cred = 4 },
                new Subject { Code = "INI301", Name = "INGENIERIA ECONOMICA", Cred = 4 },
                new Subject { Code = "INS377", Name = "BASES DE DATOS I", Cred = 4 },
                new Subject { Code = "INS377L", Name = "LABORATORIO BASES DE DATOS I", Cred = 1 },
                new Subject { Code = "IDS325", Name = " ASEGURAMIENTO DE LA CALIDAD DEL SOFTWARE", Cred = 4 },
                new Subject { Code = "IDS325L", Name = "LABORATORIO ASEGURAMIENTO DE LA CALIDAD DEL SOFTWARE", Cred = 1 },


                //Enmanuel
                new Subject { Code = "IDS311", Name = "PROCESO DE SOFTWARE", Cred = 4 },
                new Subject { Code = "IDS329", Name = "INGENIERIA DE FACTORES HUMANOS", Cred = 4 },
                new Subject { Code = "IDS329L", Name = "LABORATORIO INGENIERIA DE FACTORES HUMANOS", Cred = 1 },
                new Subject { Code = "IDS336", Name = "FUNDAMENTOS DE CIBERSEGURIDAD", Cred = 4 },
                new Subject { Code = "ING211", Name = "FORMULACION DE PROYECTOS", Cred = 4 },
                new Subject { Code = "INS378", Name = "ESTRUCTURAS DE DATOS Y ALGORITMOS II", Cred = 4 },
                new Subject { Code = "INS378L", Name = "LABORATORIO ESTRUCTURA DE DATOS Y ALGORITMOS II", Cred = 1 },

                //Pablo
                new Subject { Code = "CBF210", Name = "FISICA MECANICA I", Cred = 4 },
                new Subject { Code = "CBF210L", Name = "LABORATORIO FISICA MECANICA I", Cred = 1 },
                new Subject { Code = "CBM208", Name = "ALGEBRA LINEAL", Cred = 4 },
                new Subject { Code = "INS215L", Name = "LABORATORIO PROGRAMACION III(OOP)", Cred = 1 },
                new Subject { Code = "INS215", Name = "PROGRAMACION III(OOP)", Cred = 4 },
                new Subject { Code = "CON213", Name = "FUNDAMENTOS DE CONTABILIDAD", Cred = 2 },
                new Subject { Code = "IDS336", Name = "FUNDAMENTOS DE CIBERSEGURIDAD", Cred = 2 },

                //GONZALO
                new Subject { Code = "IDS336", Name = "FUNDAMENTOS DE CIBERSEGURIDAD", Cred = 2 }
            );

        }
    }
}