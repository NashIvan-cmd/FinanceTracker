namespace FinanceTracker.Services.User.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.User;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("username");
        }
    }
}
