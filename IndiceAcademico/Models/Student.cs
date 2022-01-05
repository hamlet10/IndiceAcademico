using System.Collections.Generic;

namespace IndiceAcademico.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ApplicationUserId { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
    }
}