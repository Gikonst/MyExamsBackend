namespace MyExamsBackend.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; } 

        //TODO Add a bigger description here.
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<Question> Questions { get; set; }
        public List<User> Users { get; set; }
        public Exam()
        {
            Certificates = new List<Certificate>();
            Questions = new List<Question>();
            Users = new List<User>();
        }
    }
}
