namespace FinanceTracker.Services.Budget.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.Budget;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BudgetMemberConfiguration : IEntityTypeConfiguration<BudgetMember>
    {
        public void Configure (EntityTypeBuilder<BudgetMember> builder)
        {
            builder.ToTable("budget_members");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.BudgetId).IsRequired().HasColumnName("budget_id");
            builder.Property(e => e.UserId).IsRequired().HasColumnName("user_id");

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Budget)
                .WithMany()
                .HasForeignKey(e => e.BudgetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.BudgetId)
                .HasDatabaseName("ix_budget_members_budget_id");

            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("ix_budget_members_user_id");
        }
    }
}
