namespace FinanceTracker.Services.Group.Data
{
    using Microsoft.EntityFrameworkCore;
    using FinanceTracker.Infrastructure.Entities.Group;
    using FinanceTracker.Infrastructure.Entities.User;
    public class GroupDbContext : DbContext
    {
        public GroupDbContext(DbContextOptions<GroupDbContext> options)
            : base(options)
        {    
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupDbContext).Assembly);
            
            // Explicitly prevent discovery of other entities
            modelBuilder.Ignore<FinanceTracker.Infrastructure.Entities.Budget.Budget>();
            modelBuilder.Ignore<FinanceTracker.Infrastructure.Entities.Budget.BudgetMember>();
            modelBuilder.Ignore<FinanceTracker.Infrastructure.Entities.Transaction.Transaction>();
        }
    }
}