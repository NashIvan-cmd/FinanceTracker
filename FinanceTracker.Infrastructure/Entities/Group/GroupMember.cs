namespace FinanceTracker.Infrastructure.Entities.Group
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.RegularExpressions;
    using FinanceTracker.Infrastructure.Entities.User;
    public class GroupMember
    {
        [Key]
        public Guid Id { get; set; }

        // Called as Navigation Properties
        // Will not exist on db as column
        public User User { get; set; } = null!;

        public Group Group { get; set; } = null!;
        
        [ForeignKey("Group")]
        public Guid GroupId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
    }
}