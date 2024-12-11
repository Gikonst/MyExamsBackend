using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyExamsBackend.Models.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Answers).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);

            builder.ToTable("Questions");
        }
    }
}
