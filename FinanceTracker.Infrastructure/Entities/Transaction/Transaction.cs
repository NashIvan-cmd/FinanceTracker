namespace FinanceTracker.Infrastructure.Entities.Transaction
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FinanceTracker.Infrastructure.Entities.User;
    using FinanceTracker.Infrastructure.Entities.Group;

    [Table("transactions")]
    public class Transaction : BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required]
        [Column("is_necessity")]
        public bool IsNecessity { get; set; }

        [Required]
        [Column("type")]
        public string Type { get; set; } = "expense"; // "expense", "income", "transfer"

        [Column("category")]
        public string? Category { get; set; } // "food", "transport", "utilities", etc.

        [Column("description")]
        public string? Description { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("transaction_date")]
        public DateTime TransactionDate { get; set; }

        // Relationships
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [NotMapped]
        public User User { get; set; } = null!;

        [ForeignKey("GroupId")]
        public Guid? GroupId { get; set; }
        [NotMapped]
        public Group? Group { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}