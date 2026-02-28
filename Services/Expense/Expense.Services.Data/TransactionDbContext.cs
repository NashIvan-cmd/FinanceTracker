namespace FinanceTracker.Services.Transaction.Data
{
    using FinanceTracker.Infrastructure.Entities.Transaction;
    using FinanceTracker.Infrastructure.Entities.User;
    using FinanceTracker.Infrastructure.Entities.Group;
    using Microsoft.EntityFrameworkCore;

    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionDbContext).Assembly);
        }
    }
}