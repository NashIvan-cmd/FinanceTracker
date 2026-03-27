namespace FinanceTracker.Infrastructure.Entities.Group
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using FinanceTracker.Infrastructure.Entities.Budget;
    using FinanceTracker.Infrastructure.Entities.Transaction;

    [Table("groups")]
    public class Group
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("groupname")]
        public string GroupName { get; set; } = string.Empty;

        public List<GroupMember> Members { get; set; } = new();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}