namespace IndiceAcademico.Models
{
    public enum Score
    {
        F, D, C, B, A
    }
    public class Enrollments
    {
        // public int ID { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Score Score { get; set; }

    }
}