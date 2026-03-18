namespace FinanceTracker.Services.User.Data
{
    using Microsoft.EntityFrameworkCore;
    using FinanceTracker.Infrastructure.Entities.User;

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
            
            // Explicitly ignore navigation properties that belong to other DbContexts
            modelBuilder.Entity<User>()
                .Ignore(u => u.GroupMemberships)
                .Ignore(u => u.Transactions);
        }
    }
}

