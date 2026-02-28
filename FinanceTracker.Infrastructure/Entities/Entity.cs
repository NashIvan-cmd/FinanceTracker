namespace FinanceTracker.Infrastructure.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }
        
        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}