namespace MyExamsBackend.Models
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
        public List<Exam> Exams { get; set; }
        public ProgrammingLanguage()
        {
            Exams = new List<Exam>();
        }
    }
}
