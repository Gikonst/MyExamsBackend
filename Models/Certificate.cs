namespace MyExamsBackend.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? Score { get; set; }
        public ExamStatusEnum Status { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
       
    }
    public enum ExamStatusEnum : ushort
    {
        Enrolled = 0,
        Failed = 1,
        BorderlineFailed = 2,
        Passed = 3,
        Excellent = 4
    }
}
