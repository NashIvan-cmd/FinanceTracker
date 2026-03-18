namespace FinanceTracker.Services.Budget.Data
{
    using FinanceTracker.Infrastructure.Entities.Budget;
    using FinanceTracker.Infrastructure.Entities.User;
    using FinanceTracker.Infrastructure.Entities.Group;
    using FinanceTracker.Infrastructure.Entities.Transaction;
    using FinanceTracker.Services.Budget.Data.Configuration;
    using Microsoft.EntityFrameworkCore;
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            : base (options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetMember> BudgetMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Only apply Budget and BudgetMember configurations
            modelBuilder.ApplyConfiguration(new BudgetConfiguration());
            modelBuilder.ApplyConfiguration(new BudgetMemberConfiguration());
            
            // Explicitly prevent discovery of other entities
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Group>();
            modelBuilder.Ignore<GroupMember>();
            modelBuilder.Ignore<Transaction>();
        }
    }   
}
