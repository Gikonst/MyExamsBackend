namespace MyExamsBackend.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ExamStatusEnum Status { get; set; }
        public DateTime IssuedDate { get; set; }
       
    }
    public enum ExamStatusEnum : ushort
    {
        NotPassed = 0,
        Passed = 1,
    }
}
