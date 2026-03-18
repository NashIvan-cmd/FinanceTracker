namespace FinanceTracker.Extensions.Injection
{
    using FinanceTracker.Services.Group.Data;
    using Microsoft.EntityFrameworkCore;

    public static class GroupDbContextServiceExtension
    {
        /// <summary>
        /// Registers the GroupDbContext with PostgreSQL provider.
        /// </summary>
        public static IServiceCollection AddGroupDbContext(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<GroupDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
