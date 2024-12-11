using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyExamsBackend.Models.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Certificates).WithOne(x => x.Exam).HasForeignKey(x => x.ExamId);

            builder.HasMany(x => x.Questions).WithMany(x => x.Exams).UsingEntity(x => x.ToTable("ExamQuestions"));

            builder.ToTable("Exams");
        }
    }
}
