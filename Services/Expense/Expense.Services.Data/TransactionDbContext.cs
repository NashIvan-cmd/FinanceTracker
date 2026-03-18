namespace FinanceTracker.Services.Transaction.Data
{
    using FinanceTracker.Infrastructure.Entities.Transaction;
    using FinanceTracker.Infrastructure.Entities.User;
    using FinanceTracker.Infrastructure.Entities.Group;
    using FinanceTracker.Services.Transaction.Data.Configuration;
    using Microsoft.EntityFrameworkCore;

    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            
            // Explicitly prevent discovery of other entities
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Group>();
        }
    }
}