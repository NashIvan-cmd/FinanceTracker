# EF Core PostgreSQL Migrations Guide

## Overview
This guide walks you through creating and applying EF Core migrations for your PostgreSQL database using the FinanceTracker project structure.

## Prerequisites

### 1. Connection String
Your connection string is configured in `appsettings.Development.json`:
```json
"ConnectionStrings": {
  "POSTGRESQL": "Host=localhost;Port=5432;Database=financetrackerdb;Username=postgres;Password=yourpassword"
}
```

**Update this with your PostgreSQL credentials before running migrations.**

### 2. PostgreSQL Installation
Ensure you have PostgreSQL installed and running on your machine.

### 3. Restore NuGet Packages
```bash
dotnet restore
```

## Project Structure

Each DbContext has its own extension file in `Extensions/Injection/`:
- `GroupDbContextServiceExtension.cs` - Group service DbContext
- `UserDbContextServiceExtension.cs` - User service DbContext
- `BudgetDbContextServiceExtension.cs` - Budget service DbContext
- `TransactionDbContextServiceExtension.cs` - Transaction service DbContext

Each extension registers its corresponding DbContext with a single responsibility, making it easy to:
- Modify lifetime (Scoped, Singleton, Transient)
- Add DbContext-specific configurations
- Test individual contexts

## Creating Migrations

### Method 1: Using Package Manager Console (Visual Studio / Rider)

1. Open the Package Manager Console
2. Select the Data project containing your DbContext (e.g., `FinanceTracker.Services.Group.Data`)
3. Run:
   ```
   Add-Migration <MigrationName> -Project FinanceTracker.Services.Group.Data
   ```

Example for Group context:
```
Add-Migration InitialCreateGroupTables -Project FinanceTracker.Services.Group.Data
```

### Method 2: Using dotnet CLI (Recommended for cross-platform)

From the FinanceTracker project root:

```bash
# For Group DbContext
dotnet ef migrations add InitialCreateGroupTables --project Services/Group/FinanceTracker.Services.Group.Data/

# For User DbContext
dotnet ef migrations add InitialCreateUserTables --project Services/User/FinanceTracker.User.Services.Data/

# For Budget DbContext
dotnet ef migrations add InitialCreateBudgetTables --project Services/Budget/Budget.Services.Data/

# For Transaction DbContext
dotnet ef migrations add InitialCreateTransactionTables --project Services/Expense/Expense.Services.Data/
```

## Migrations Folder Structure

After creating a migration, you'll see a `Migrations` folder in each Data project:
```
Services/
  Group/
    FinanceTracker.Services.Group.Data/
      Migrations/
        20260318120000_InitialCreateGroupTables.cs
        20260318120001_InitialCreateGroupTables.Designer.cs
        GroupDbContextModelSnapshot.cs
```

## Applying Migrations to Database

### Method 1: Using Package Manager Console

```
Update-Database -Project FinanceTracker.Services.Group.Data
```

### Method 2: Using dotnet CLI

```bash
# For Group DbContext
dotnet ef database update --project Services/Group/FinanceTracker.Services.Group.Data/

# For User DbContext
dotnet ef database update --project Services/User/FinanceTracker.User.Services.Data/

# For Budget DbContext
dotnet ef database update --project Services/Budget/Budget.Services.Data/

# For Transaction DbContext
dotnet ef database update --project Services/Expense/Expense.Services.Data/
```

## Viewing Migration Status

To see which migrations have been applied:

```bash
dotnet ef migrations list --project Services/Group/FinanceTracker.Services.Group.Data/
```

## Reverting Migrations

To revert to a specific migration:

```bash
# Revert last migration
dotnet ef database update <PreviousMigrationName> --project Services/Group/FinanceTracker.Services.Group.Data/
```

## Common Migration Scenarios

### Adding a New Property to an Entity

1. Update your Entity class
2. Create a migration:
   ```bash
   dotnet ef migrations add AddPropertyNameToEntityName --project Services/Group/FinanceTracker.Services.Group.Data/
   ```
3. Review the generated migration file
4. Apply the migration:
   ```bash
   dotnet ef database update --project Services/Group/FinanceTracker.Services.Group.Data/
   ```

### Renaming a Column

1. Update your Entity and/or Configuration
2. Create a migration:
   ```bash
   dotnet ef migrations add RenameColumnName --project Services/Group/FinanceTracker.Services.Group.Data/
   ```
3. The migration might generate a drop/create. Consider manually editing it for better performance
4. Apply the migration

### Adding Indexes (Already Configured)

Your `GroupMemberConfiguration` already has indexes defined. These will be included in migrations automatically.

## Extension Files - Single Responsibility

Each DbContext extension follows this pattern:

```csharp
namespace FinanceTracker.Extensions.Injection
{
    using YourDbContext;
    using Microsoft.EntityFrameworkCore;

    public static class YourDbContextServiceExtension
    {
        public static IServiceCollection AddYourDbContext(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<YourDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
```

**Benefits:**
- Easy to modify lifetime (Scoped/Singleton/Transient) per context
- Easy to add DbContext-specific logging, retry policies, or configuration
- Clean separation of concerns
- Simple to test individual contexts

### Example: Modifying DbContext Lifetime

If you want `GroupDbContext` to be a Singleton instead of Scoped:

```csharp
public static IServiceCollection AddGroupDbContext(
    this IServiceCollection services,
    string connectionString)
{
    services.AddDbContext<GroupDbContext>(
        options => options.UseNpgsql(connectionString),
        ServiceLifetime.Singleton); // ← Change here

    return services;
}
```

### Example: Adding Retry Policy

```csharp
public static IServiceCollection AddGroupDbContext(
    this IServiceCollection services,
    string connectionString)
{
    services.AddDbContext<GroupDbContext>(options =>
        options.UseNpgsql(
            connectionString,
            npgsqlOptions => npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelaySeconds: 30,
                errorCodesToAdd: null)));

    return services;
}
```

## Program.cs Configuration

Your `Program.cs` now registers all DbContexts cleanly:

```csharp
var connectionString = builder.Configuration.GetConnectionString("POSTGRESQL")
    ?? throw new InvalidOperationException("PostgreSQL connection string not configured.");

builder.Services
    .AddGroupDbContext(connectionString)
    .AddUserDbContext(connectionString)
    .AddBudgetDbContext(connectionString)
    .AddTransactionDbContext(connectionString);
```

## Troubleshooting

### Issue: "No DbContext found"
- Ensure you're specifying the correct `--project` parameter
- Check that the Data project is built

### Issue: "Connection refused"
- Verify PostgreSQL is running
- Check connection string credentials
- Verify PostgreSQL port (default: 5432)

### Issue: "Migration already exists"
- Each DbContext should have migrations in its own project
- Don't mix migrations from different contexts in the same folder

## Next Steps

1. ✅ Update `appsettings.Development.json` with your PostgreSQL credentials
2. ✅ Run `dotnet restore` to restore packages
3. Create your first migration for each DbContext
4. Apply migrations to create tables
5. Run your API and test the database connectivity

## Useful Commands Summary

```bash
# Create migration
dotnet ef migrations add <MigrationName> --project <ProjectPath>

# Apply migrations
dotnet ef database update --project <ProjectPath>

# List migrations
dotnet ef migrations list --project <ProjectPath>

# Remove last migration
dotnet ef migrations remove --project <ProjectPath>

# Revert to specific migration
dotnet ef database update <MigrationName> --project <ProjectPath>
```

---

**Remember:** Each DbContext manages its own database tables. They can be in the same PostgreSQL database (as configured) or split into separate databases by modifying the connection strings.
