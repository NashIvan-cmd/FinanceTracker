namespace FinanceTracker.Extensions.Injection
{
    using FinanceTracker.Services.User.Data;
    using Microsoft.EntityFrameworkCore;

    public static class UserDbContextServiceExtension
    {
        /// <summary>
        /// Registers the UserDbContext with PostgreSQL provider.
        /// </summary>
        public static IServiceCollection AddUserDbContext(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
