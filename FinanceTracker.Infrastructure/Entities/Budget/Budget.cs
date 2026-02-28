namespace FinanceTracker.Infrastructure.Entities.Budget
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using FinanceTracker.Infrastructure.Entities.User;
    using System.Runtime.CompilerServices;

    public class Budget : BaseEntity
    {
        [Required]
        [Column("actual_budget")]
        public double ActualBudget { get; set; }

        [Required]
        [Column("target_savings")]
        public double TargetSavings { get; set; }

        [Required]
        [Column("target_item")]
        public string TargetItem { get; set; } = string.Empty;

        [Required]
        [Column("category")]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("due_date")]
        public DateTime DueDate { get; set; }

        [Required]
        [Column("alert_threshold")]
        public int AlertThreshold { get; set; } = 80;

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("GroupId")]
        public Guid GroupId { get; set; }
    }
}