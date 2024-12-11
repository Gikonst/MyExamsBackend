namespace MyExamsBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public UserRoleType Role { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Certificate> Certificates { get; set; }
        public User()
        {
            Exams = new List<Exam>();
            Certificates = new List<Certificate>();
        }
    }

    public enum UserRoleType : ushort
    {
        User = 0,
        Admin = 1
    }
}