using System.ComponentModel.DataAnnotations;

namespace MyExamsBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
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