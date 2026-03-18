namespace FinanceTracker.Services.Group.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.Group;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FinanceTracker.Infrastructure.Entities.User;

    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.ToTable("group_members");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.GroupId)
                .IsRequired()
                .HasColumnName("group_id");

            // User relationship
            builder.HasOne(e => e.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Group relationship
            builder.HasOne(e => e.Group)
                .WithMany(g => g.Members)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("ix_group_members_user_id");

            builder.HasIndex(e => e.GroupId)
                .HasDatabaseName("ix_group_members_group_id");

            builder.HasIndex(e => new { e.UserId, e.GroupId })
                .IsUnique()
                .HasDatabaseName("ix_group_members_user_group_unique");
        }
    }
}