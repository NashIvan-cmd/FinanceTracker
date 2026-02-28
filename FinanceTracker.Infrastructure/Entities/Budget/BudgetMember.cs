using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Infrastructure.Entities.Budget
{
    using FinanceTracker.Infrastructure.Entities.User;
    public class BudgetMember
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [ForeignKey("BudgetId")]
        public Guid BudgetId {get; set; }     

        public Budget? Budget { get; set; }  

        public User? User { get; set; }
    }
}