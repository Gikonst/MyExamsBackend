using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyExamsBackend.Models.Configurations
{
    public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Exams).WithOne(x => x.ProgrammingLanguage).HasForeignKey(x => x.ProgrammingLanguageId);

            builder.ToTable("ProgrammingLanguages");

        }
    }
}
