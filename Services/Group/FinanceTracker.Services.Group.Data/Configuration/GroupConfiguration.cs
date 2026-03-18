namespace FinanceTracker.Services.Group.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FinanceTracker.Infrastructure.Entities.Group;

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("groups");
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.GroupName)
                .IsRequired()
                .HasColumnName("groupname");

            // Navigation properties - no column mapping needed
            // Members, Transactions, and Budgets are handled by their inverse relationships
        }
    }
}


