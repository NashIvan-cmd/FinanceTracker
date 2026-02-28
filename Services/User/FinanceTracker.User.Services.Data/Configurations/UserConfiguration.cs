namespace FinanceTracker.Services.User.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FinanceTracker.Infrastructure.Entities.User;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Username).HasMaxLength(10).HasColumnName("username").IsRequired();
            builder.Property(e => e.GroupMemberships).HasColumnName("group_membership");
        }
    } 
}


