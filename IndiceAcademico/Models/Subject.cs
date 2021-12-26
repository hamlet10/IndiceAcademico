using System.Collections.Generic;

namespace IndiceAcademico.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Cred { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }

    }
}