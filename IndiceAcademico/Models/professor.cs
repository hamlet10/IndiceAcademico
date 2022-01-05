using System.Collections.Generic;

namespace IndiceAcademico.Models
{
    public class Professor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ApplicationUserId { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}