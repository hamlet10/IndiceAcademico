using IndiceAcademico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndiceAcademico.Persistense.Config
{
    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollments>
    {
        public void Configure(EntityTypeBuilder<Enrollments> builder)
        {
            builder.HasKey( e => new {e.SubjectId, e.StudentId});
            builder.HasOne(e => e.Subject).WithMany(s => s.Enrollments);
            builder.HasOne(e => e.Student).WithMany(s => s.Enrollments);

            //builder.HasData(
            //Hamlet
            // new Enrollments { ID = 3, StudentId = 1, SubjectId = 1, Score = Score.A }
            // new Enrollments { ID = 2, StudentId = 1, SubjectId = 2, Score = Score.B },
            // new Enrollments { ID = 3, StudentId = 1, SubjectId = 3, Score = Score.A },
            // new Enrollments { ID = 4, StudentId = 1, SubjectId = 4, Score = Score.A },
            // new Enrollments { ID = 5, StudentId = 1, SubjectId = 5, Score = Score.A },
            // new Enrollments { ID = 6, StudentId = 1, SubjectId = 6, Score = Score.B },
            // new Enrollments { ID = 7, StudentId = 1, SubjectId = 7, Score = Score.A }

            //Pablo
            // new Enrollments { ID = 8, StudentId = 2, SubjectId = 8, Score = Score.C },
            // new Enrollments { ID = 9, StudentId = 2, SubjectId = 9, Score = Score.A },
            // new Enrollments { ID = 10, StudentId = 2, SubjectId = 10, Score = Score.A },
            // new Enrollments { ID = 11, StudentId = 2, SubjectId = 11, Score = Score.B },
            // new Enrollments { ID = 12, StudentId = 2, SubjectId = 12, Score = Score.B },
            // new Enrollments { ID = 13, StudentId = 2, SubjectId = 13, Score = Score.A },
            // new Enrollments { ID = 14, StudentId = 2, SubjectId = 14, Score = Score.A },

            // //Enmanuel
            // new Enrollments { ID = 15, StudentId = 3, SubjectId = 15, Score = Score.A },
            // new Enrollments { ID = 16, StudentId = 3, SubjectId = 16, Score = Score.A },
            // new Enrollments { ID = 17, StudentId = 3, SubjectId = 17, Score = Score.B },
            // new Enrollments { ID = 18, StudentId = 3, SubjectId = 14, Score = Score.A },
            // new Enrollments { ID = 20, StudentId = 3, SubjectId = 18, Score = Score.B },
            // new Enrollments { ID = 21, StudentId = 3, SubjectId = 19, Score = Score.A },
            // new Enrollments { ID = 19, StudentId = 3, SubjectId = 20, Score = Score.A },

            // //GONZALO
            // new Enrollments { ID = 22, StudentId = 4, SubjectId = 21, Score = Score.A },
            // new Enrollments { ID = 23, StudentId = 4, SubjectId = 22, Score = Score.A },
            // new Enrollments { ID = 24, StudentId = 4, SubjectId = 23, Score = Score.B },
            // new Enrollments { ID = 25, StudentId = 4, SubjectId = 24, Score = Score.B },
            // new Enrollments { ID = 26, StudentId = 4, SubjectId = 25, Score = Score.A },
            // new Enrollments { ID = 28, StudentId = 4, SubjectId = 26, Score = Score.A },
            // new Enrollments { ID = 29, StudentId = 4, SubjectId = 27, Score = Score.A },


            // //Hector
            // new Enrollments { ID = 30, StudentId = 5, SubjectId = 7, Score = Score.B },
            // new Enrollments { ID = 31, StudentId = 5, SubjectId = 28, Score = Score.A },
            // new Enrollments { ID = 32, StudentId = 5, SubjectId = 29, Score = Score.B },
            // new Enrollments { ID = 33, StudentId = 5, SubjectId = 30, Score = Score.B },
            // new Enrollments { ID = 34, StudentId = 5, SubjectId = 31, Score = Score.B },
            // new Enrollments { ID = 35, StudentId = 5, SubjectId = 32, Score = Score.B },
            // new Enrollments { ID = 36, StudentId = 5, SubjectId = 33, Score = Score.B }
            //);
        }
    }
}