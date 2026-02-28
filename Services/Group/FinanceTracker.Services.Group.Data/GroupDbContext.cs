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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupDbContext).Assembly);
        }
    }
}