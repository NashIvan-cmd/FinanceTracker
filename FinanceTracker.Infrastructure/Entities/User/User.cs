namespace FinanceTracker.Infrastructure.Entities.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FinanceTracker.Infrastructure.Entities.Group;
    using FinanceTracker.Infrastructure.Entities.Transaction;

    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("username")]
        [StringLength(10, MinimumLength = 1)]
        public string Username { get; set; } = string.Empty;

        public List<GroupMember>? GroupMemberships { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}