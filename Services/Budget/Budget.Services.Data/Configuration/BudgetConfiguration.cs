namespace FinanceTracker.Services.Budget.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FinanceTracker.Infrastructure.Entities.Budget;

    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("budgets");
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(e => e.ActualBudget)
                .IsRequired()
                .HasColumnName("actual_budget");

            builder.Property(e => e.TargetSavings)
                .IsRequired()
                .HasColumnName("target_savings");

            builder.Property(e => e.TargetItem)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("target_items");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("category");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.DueDate)
                .IsRequired()
                .HasColumnName("due_date");

            builder.Property(e => e.AlertThreshold)
                .IsRequired()
                .HasDefaultValue(80)
                .HasColumnName("alert_threshold");

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnName("is_active");

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("created_by");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(256)
                .HasColumnName("updated_by");

            // Foreign key (without navigation - managed by GroupDbContext)
            builder.Property(e => e.GroupId)
                .IsRequired()
                .HasColumnName("group_id");

            // Indexes
            builder.HasIndex(e => e.GroupId)
                .HasDatabaseName("ix_budget_group_id");

            builder.HasIndex(e => e.Category)
                .HasDatabaseName("ix_budget_category");

            builder.HasIndex(e => new { e.GroupId, e.IsDeleted, e.IsActive })
                .HasDatabaseName("ix_budget_group_active");

            builder.HasIndex(e => e.DueDate)
                .HasDatabaseName("ix_budget_due_date");

            builder.HasIndex(e => e.CreatedAt)
                .HasDatabaseName("ix_budget_created_at");
        }
    }
}