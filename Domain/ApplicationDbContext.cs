using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Models;
using MyExamsBackend.Models.Configurations;

namespace MyExamsBackend.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextoptions) : 
            base(dbContextoptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> ProgrammingLanguages { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
