using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Infrastructure.Entities.Budget
{
    using System.ComponentModel.DataAnnotations;
    using FinanceTracker.Infrastructure.Entities.User;
    public class BudgetMember
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [ForeignKey("BudgetId")]
        public Guid BudgetId {get; set; }     

        public Budget? Budget { get; set; }  

        public User? User { get; set; }
    }
}