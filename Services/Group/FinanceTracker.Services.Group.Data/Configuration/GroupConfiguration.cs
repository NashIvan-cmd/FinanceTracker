namespace FinanceTracker.Services.Group.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using FinanceTracker.Infrastructure.Entities.Group;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
        {
            public void Configure(EntityTypeBuilder<Group> builder)
            {
                builder.HasKey(e => e.Id);
                
                builder.Property(e => e.GroupName).IsRequired().HasColumnName("groupname");
                builder.Property(e => e.Transactions).HasColumnName("transactions");
                builder.Property(e => e.Members).IsRequired().HasColumnName("members");
            }
        } 
}


