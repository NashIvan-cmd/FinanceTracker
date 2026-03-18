namespace FinanceTracker.Extensions.Injection
{
    using FinanceTracker.Services.Budget.Data;
    using Microsoft.EntityFrameworkCore;

    public static class BudgetDbContextServiceExtension
    {
        /// <summary>
        /// Registers the BudgetDbContext with PostgreSQL provider.
        /// </summary>
        public static IServiceCollection AddBudgetDbContext(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<BudgetDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
