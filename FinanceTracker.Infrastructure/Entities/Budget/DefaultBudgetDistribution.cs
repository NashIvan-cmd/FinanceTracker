namespace FinanceTracker.Infrastructure.Entities.Budget
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("default_budget_distributions")]
    public class DefaultBudgetDistribution
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("group_id")]
        public Guid? GroupId { get; set; }

        [Required]
        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Column("amount")]
        public double Amount { get; set; }

        [Required]
        [Column("priority")]
        public int Priority { get; set; } = 0;

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
