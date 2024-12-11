namespace MyExamsBackend.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<Question> Questions { get; set; }
        public Exam()
        {
            Certificates = new List<Certificate>();
            Questions = new List<Question>();
        }
    }
}
