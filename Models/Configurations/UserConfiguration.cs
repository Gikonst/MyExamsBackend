using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyExamsBackend.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Certificates).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Exams).WithMany(x => x.Users).UsingEntity(x => x.ToTable("UserExams"));

            builder.ToTable("Users");
        }
    }
}
