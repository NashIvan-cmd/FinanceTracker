namespace FinanceTracker.Services.Group.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.Group;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FinanceTracker.Infrastructure.Entities.User;
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(e => e.GroupId).IsRequired().HasColumnName("group_id");

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Group)
                .WithMany()
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}