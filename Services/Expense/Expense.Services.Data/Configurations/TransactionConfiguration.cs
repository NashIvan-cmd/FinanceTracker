namespace FinanceTracker.Services.Transaction.Data.Configurations
{
    using FinanceTracker.Infrastructure.Entities.Transaction;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasColumnName("amount");

            builder.Property(e => e.IsNecessity)
                .IsRequired()
                .HasColumnName("is_necessity");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("expense")
                .HasColumnName("type");

            builder.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.Notes)
                .HasColumnName("notes");

            builder.Property(e => e.TransactionDate)
                .IsRequired()
                .HasColumnName("transaction_date");

            // Foreign Keys
            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.GroupId)
                .HasColumnName("group_id");

            // Audit Fields
            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("updated_by");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at");

            // Relationships
            builder.HasOne(e => e.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Group)
                .WithMany(g => g.Transactions)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes (critical for AI queries)
            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("IX_transactions_user_id");

            builder.HasIndex(e => e.GroupId)
                .HasDatabaseName("IX_transactions_group_id");

            builder.HasIndex(e => e.TransactionDate)
                .HasDatabaseName("IX_transactions_date");

            builder.HasIndex(e => e.Type)
                .HasDatabaseName("IX_transactions_type");

            builder.HasIndex(e => e.Category)
                .HasDatabaseName("IX_transactions_category");

            builder.HasIndex(e => new { e.UserId, e.TransactionDate })
                .HasDatabaseName("IX_transactions_user_date");

            builder.HasIndex(e => new { e.UserId, e.Type, e.TransactionDate })
                .HasDatabaseName("IX_transactions_user_type_date");

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("IX_transactions_is_deleted");
        }
    }
}