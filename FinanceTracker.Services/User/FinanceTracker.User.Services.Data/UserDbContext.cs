namespace FinanceTracker.Services.User.Data
{
    using Microsoft.EntityFrameworkCore;
    using FinanceTracker.Infrastructure.Entities.User;
    using FinanceTracker.Infrastructure.Entities.Group;
    using FinanceTracker.Infrastructure.Entities.Transaction;

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<GroupMember> GroupMembership { get; set; }
        public DbSet<Transaction> Transcations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}

