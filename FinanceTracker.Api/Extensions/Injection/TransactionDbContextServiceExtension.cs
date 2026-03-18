namespace FinanceTracker.Extensions.Injection
{
    using FinanceTracker.Services.Transaction.Data;
    using Microsoft.EntityFrameworkCore;

    public static class TransactionDbContextServiceExtension
    {
        /// <summary>
        /// Registers the TransactionDbContext with PostgreSQL provider.
        /// </summary>
        public static IServiceCollection AddTransactionDbContext(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TransactionDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
