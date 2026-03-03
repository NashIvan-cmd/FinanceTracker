namespace FinanceTracker.Services.Budget.Data
{
    using System.Text.RegularExpressions;
    using FinanceTracker.Infrastructure.Entities.Budget;
    using FinanceTracker.Infrastructure.Entities.User;
    using Microsoft.EntityFrameworkCore;
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            : base (options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetDbContext).Assembly);
        }
    }   
}
