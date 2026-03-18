namespace FinanceTracker.Services.Transaction.Data.Configuration
{
    using FinanceTracker.Infrastructure.Entities.Transaction;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnName("amount");

            builder.Property(e => e.IsNecessity)
                .IsRequired()
                .HasColumnName("is_necessity");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("type");

            builder.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");

            builder.Property(e => e.TransactionDate)
                .IsRequired()
                .HasColumnName("transaction_date");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.GroupId)
                .HasColumnName("group_id");

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

            // Relationships
            builder.HasOne(e => e.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Group)
                .WithMany(g => g.Transactions)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("ix_transactions_user_id");

            builder.HasIndex(e => e.GroupId)
                .HasDatabaseName("ix_transactions_group_id");

            builder.HasIndex(e => e.TransactionDate)
                .HasDatabaseName("ix_transactions_date");

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("ix_transactions_is_deleted");
        }
    }
}
