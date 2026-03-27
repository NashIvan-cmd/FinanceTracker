namespace FinanceTracker.Services.Budget.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.Budget;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DefaultBudgetDistributionConfiguration : IEntityTypeConfiguration<DefaultBudgetDistribution>
    {
        public void Configure(EntityTypeBuilder<DefaultBudgetDistribution> builder)
        {
            builder.ToTable("default_budget_distributions");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("id");

            builder.Property(d => d.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(d => d.GroupId)
                .HasColumnName("group_id");

            builder.Property(d => d.Category)
                .HasColumnName("category")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Amount)
                .HasColumnName("amount")
                .IsRequired();

            builder.Property(d => d.Priority)
                .HasColumnName("priority")
                .HasDefaultValue(0);

            builder.Property(d => d.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(d => d.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(d => d.UpdatedAt)
                .HasColumnName("updated_at");

            // Indexes
            builder.HasIndex(d => d.UserId);
            builder.HasIndex(d => d.GroupId);
            builder.HasIndex(d => new { d.UserId, d.GroupId, d.Priority });
        }
    }
}
