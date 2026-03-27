using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Infrastructure.Entities.Budget
{
    using System.ComponentModel.DataAnnotations;
    using FinanceTracker.Infrastructure.Entities.User;
    [Table("budget_members")]
    public class BudgetMember
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [ForeignKey("BudgetId")]
        public Guid BudgetId {get; set; }     

        [NotMapped]
        public Budget? Budget { get; set; }  

        [NotMapped]
        public User? User { get; set; }
    }
}