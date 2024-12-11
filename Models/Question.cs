namespace MyExamsBackend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();   
        }
    }
}
