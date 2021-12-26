using System.Linq;
using IndiceAcademico.Models;

namespace IndiceAcademico.Persistense
{
    public static class DBInitializer
    {
        public static void Initialize(AcademicDBContext context)
        {
            if (context.Professors.Any())
            {
                return;
            }

            var Professor = new Professor[]{
                new Professor  {Name = "Francia", LastName = "Mejia" },
                 new Professor {Name = "Fausto", LastName = "Richardson" },
                 new Professor {Name = "Lidia", LastName = "Noelia" },
                 new Professor {Name = "John", LastName = "Joseph" },
                 new Professor {Name = "Grullon", LastName = "Humberto" },
                 new Professor {Name = "Luciano", LastName = "Sbritz" },
                 new Professor {Name = "Maria", LastName = "Gonzalez" },
                 new Professor {Name = "Samuel", LastName = "Luciano" },
                 new Professor {Name = "Ramon", LastName = "Ramirez" },
                 new Professor {Name = "Carolina", LastName = "Perez" },
                 new Professor {Name = "Casimiro", LastName = "Cordero" }
            };
            foreach (var p in Professor)
            {
                context.Professors.Add(p);

            }
            context.SaveChanges();

            var students = new Student[]{
                new Student {Code = 1059560, Name = "Hamlet", LastName = "Sánchez" }, //1
                 new Student {Code = 1096394, Name = "Pablo", LastName = "Díaz" },     //2
                 new Student {Code = 1095352, Name = "Enamuel", LastName = "Ureña" }, //3
                 new Student {Code = 1095352, Name = "Gonzalo", LastName = "Pina" },   //4
                 new Student {Code = 1088434, Name = "Hector", LastName = "Soriano" }//5
            };

            foreach (var s in students.Reverse())
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var subjects = new Subject[]{
                 new Subject {Code = "CBM220", Name = "ESTADISTICA APLICADA A LA INGENIERIA", Cred = 4, ProfessorId = 4 },
                 new Subject {Code = "CBM306", Name = "MATEMATICA DISCRETA II", Cred = 4, ProfessorId = 3 },
                 new Subject {Code = "INI301", Name = "INGENIERIA ECONOMICA", Cred = 4, ProfessorId = 5 },
                 new Subject {Code = "INS377", Name = "BASES DE DATOS I", Cred = 4, ProfessorId = 2 },
                 new Subject {Code = "INS377L", Name = "LABORATORIO BASES DE DATOS I", Cred = 1, ProfessorId = 2 },
                 new Subject {Code = "IDS325", Name = "ASEGURAMIENTO DE LA CALIDAD DEL SOFTWARE", Cred = 4, ProfessorId = 1 },
                 new Subject {Code = "IDS325L", Name = "LABORATORIO ASEGURAMIENTO DE LA CALIDAD DEL SOFTWARE", Cred = 1, ProfessorId = 1 },

            //     //Pablo
                 new Subject {Code = "CBF210", Name = "FISICA MECANICA I", Cred = 4, ProfessorId = 6 }, //7
                 new Subject {Code = "CBF210L", Name = "LABORATORIO FISICA MECANICA I", Cred = 1, ProfessorId = 6 }, //8
                 new Subject {Code = "CBM208", Name = "ALGEBRA LINEAL", Cred = 4, ProfessorId = 9 }, //9
                 new Subject {Code = "INS215L", Name = "LABORATORIO PROGRAMACION III(OOP)", Cred = 1, ProfessorId = 11 }, //10
                 new Subject {Code = "INS215", Name = "PROGRAMACION III(OOP)", Cred = 4, ProfessorId = 11, }, //11
                 new Subject {Code = "CON213", Name = "FUNDAMENTOS DE CONTABILIDAD", Cred = 2, ProfessorId = 7 }, //12
                 new Subject {Code = "IDS336", Name = "FUNDAMENTOS DE CIBERSEGURIDAD", Cred = 2, ProfessorId = 2 }, //13

            //     //Enmanuel
                 new Subject {Code = "S311", Name = "PROCESO DE SOFTWARE", Cred = 4, ProfessorId = 1 }, //14
                 new Subject {Code = "IDS329", Name = "INGENIERIA DE FACTORES HUMANOS", Cred = 4, ProfessorId = 8 }, //15
                 new Subject {Code = "IDS329L", Name = "LABORATORIO INGENIERIA DE FACTORES HUMANOS", Cred = 1, ProfessorId = 8 },//16
                 new Subject {Code = "ING211", Name = "FORMULACION DE PROYECTOS", Cred = 4, ProfessorId = 5 },//17
                 new Subject {Code = "INS378", Name = "ESTRUCTURAS DE DATOS Y ALGORITMOS II", Cred = 4, ProfessorId = 11 },//18
                 new Subject {Code = "INS378L", Name = "LABORATORIO ESTRUCTURA DE DATOS Y ALGORITMOS II", Cred = 1, ProfessorId = 11 },//19

            //     //GONZALO
                 new Subject {Code = "CBM203", Name = "ECUACIONES DIFEFENCIALES", Cred = 5, ProfessorId = 9 }, //20
                 new Subject {Code = "CSH105", Name = "PROYECTO INTEGRADOR ESTUDIOS GEN", Cred = 2, ProfessorId = 10 },//21
                 new Subject {Code = "CSH113", Name = "PENSAMIENTO CREATIVO", Cred = 2, ProfessorId = 10 },//22
                 new Subject {Code = "IDS202", Name = "TECNOLOGIA DE OBJETOS", Cred = 4, ProfessorId = 8 },//23
                 new Subject {Code = "IDS202L", Name = "LABORATORIO TECNOLOGIA DE OBJETOS", Cred = 1, ProfessorId = 8 },//24
                 new Subject {Code = "IDS323", Name = "TECNICAS FUNDAMENTALES ING. DE SOFTWARE", Cred = 4, ProfessorId = 1 },//25
                 new Subject {Code = "IDS323L", Name = "LAB. TECNICAS FUNDAMENTALES ING. DE SOFTWARE", Cred = 1, ProfessorId = 1 },//26

            //     //Hector

                 new Subject {Code = "CBM202", Name = "CALCULO VECTORIAL", Cred = 5, ProfessorId = 9 },//25
                 new Subject {Code = "CSG201", Name = "HISTORIA, CIVILIZACIONES Y CULTURA", Cred = 4, ProfessorId = 10 },//26
                 new Subject {Code = "CSH102", Name = "COMPROMISO SOCIAL Y CIVICO", Cred = 2, ProfessorId =10 },//27
                 new Subject {Code = "CSH103", Name = "INNOVACION Y EMPRENDIMIENTO", Cred = 2, ProfessorId = 10 },//28
                 new Subject {Code = "INS208", Name = "FUNDAMENTOS DE PROGRAMACION", Cred = 4, ProfessorId = 11 },//29
                 new Subject {Code = "INS208L", Name = "LAB FUNDAMENTOS DE PROGRAMACION", Cred = 1, ProfessorId = 11 }//30
            };

            foreach (var s in subjects)
            {
                context.Subjects.Add(s);
            }
            context.SaveChanges();
        }
    }
}