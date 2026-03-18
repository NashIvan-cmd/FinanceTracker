# Architecture & Data Flow Diagram

## Dependency Injection Flow

```
┌─────────────────────────────────────────────────────────────────┐
│                      Program.cs (Startup)                       │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  1. Read Connection String from appsettings.Development.json   │
│     └─> "POSTGRESQL": "Host=localhost;..."                    │
│                                                                 │
│  2. Chain Extension Methods:                                    │
│     builder.Services                                            │
│       .AddGroupDbContext(connectionString)                     │
│       .AddUserDbContext(connectionString)                      │
│       .AddBudgetDbContext(connectionString)                    │
│       .AddTransactionDbContext(connectionString)               │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
           ↓ ↓ ↓ ↓
    ┌──────────────────────────────────────────┐
    │  Extensions/Injection/ Directory          │
    ├──────────────────────────────────────────┤
    │                                          │
    │  ┌─────────────────────────────────────┐│
    │  │ GroupDbContextServiceExtension      ││
    │  ├─────────────────────────────────────┤│
    │  │ .AddDbContext<GroupDbContext>(...)  ││
    │  │ │                                   ││
    │  │ └─> services.AddDbContext<>        ││
    │  └─────────────────────────────────────┘│
    │                                          │
    │  ┌─────────────────────────────────────┐│
    │  │ UserDbContextServiceExtension       ││
    │  ├─────────────────────────────────────┤│
    │  │ .AddDbContext<UserDbContext>(...)   ││
    │  │ │                                   ││
    │  │ └─> services.AddDbContext<>        ││
    │  └─────────────────────────────────────┘│
    │                                          │
    │  ┌─────────────────────────────────────┐│
    │  │ BudgetDbContextServiceExtension     ││
    │  ├─────────────────────────────────────┤│
    │  │ .AddDbContext<BudgetDbContext>(...) ││
    │  │ │                                   ││
    │  │ └─> services.AddDbContext<>        ││
    │  └─────────────────────────────────────┘│
    │                                          │
    │  ┌─────────────────────────────────────┐│
    │  │TransactionDbContextServiceExtension ││
    │  ├─────────────────────────────────────┤│
    │  │.AddDbContext<TransactionDbContext>()││
    │  │ │                                   ││
    │  │ └─> services.AddDbContext<>        ││
    │  └─────────────────────────────────────┘│
    │                                          │
    └──────────────────────────────────────────┘
           ↓ ↓ ↓ ↓
    ┌──────────────────────────────────────────┐
    │  Dependency Injection Container          │
    ├──────────────────────────────────────────┤
    │ • GroupDbContext (Registered)            │
    │ • UserDbContext (Registered)             │
    │ • BudgetDbContext (Registered)           │
    │ • TransactionDbContext (Registered)      │
    └──────────────────────────────────────────┘
           ↓ ↓ ↓ ↓
    ┌──────────────────────────────────────────┐
    │  Available for Injection                 │
    ├──────────────────────────────────────────┤
    │  public class MyService                  │
    │  {                                       │
    │    public MyService(                     │
    │      GroupDbContext groupDb,            │
    │      UserDbContext userDb)               │
    │    { ... }                               │
    │  }                                       │
    └──────────────────────────────────────────┘
```

## DbContext to Database Mapping

```
┌──────────────────────────────────────────────────────────────────┐
│                  Single PostgreSQL Instance                      │
│              Host: localhost, Port: 5432                         │
├──────────────────────────────────────────────────────────────────┤
│                                                                  │
│  Database: "financetrackerdb"                                   │
│  ├── Schema: public (default)                                   │
│  │   ├── Table: groups (from GroupDbContext)                    │
│  │   ├── Table: group_members (from GroupDbContext)             │
│  │   ├── Table: users (from UserDbContext)                      │
│  │   ├── Table: budgets (from BudgetDbContext)                  │
│  │   ├── Table: transactions (from TransactionDbContext)        │
│  │   └── ...other tables...                                     │
│  │                                                               │
│  └── Schema: (custom) - Optional for isolation                  │
│      └── Each DbContext could use its own schema                │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

## Migration Workflow

```
┌─────────────────────┐
│  Update Entity or   │
│  Configuration      │
│  (e.g., add prop)   │
└────────────┬────────┘
             ↓
┌─────────────────────────────────────────────┐
│ dotnet ef migrations add <MigrationName>    │
│   --project <DataProjectPath>               │
│   --startup-project FinanceTracker.Api      │
└────────────┬────────────────────────────────┘
             ↓
┌───────────────────────────────────────┐
│  Migration Files Created:             │
│  ├── <Timestamp>_<Name>.cs           │
│  ├── <Timestamp>_<Name>.Designer.cs  │
│  └── DbContextModelSnapshot.cs       │
└────────────┬────────────────────────┘
             ↓
┌─────────────────────────────┐
│ Review Migration (if needed)│
│ - Check Up() method         │
│ - Check Down() method       │
└────────────┬────────────────┘
             ↓
┌─────────────────────────────────────────┐
│ dotnet ef database update               │
│   --project <DataProjectPath>           │
│   --startup-project FinanceTracker.Api  │
└────────────┬────────────────────────────┘
             ↓
┌──────────────────────┐
│ Migration Applied    │
│ Database Updated     │
│ Ready for Use ✓      │
└──────────────────────┘
```

## Single Responsibility Pattern in Action

### Before (Monolithic)
```csharp
// ❌ All DbContexts mixed in one place
builder.Services.AddDbContext<GroupDbContext>(...);
builder.Services.AddDbContext<UserDbContext>(...);
builder.Services.AddDbContext<BudgetDbContext>(...);
builder.Services.AddDbContext<TransactionDbContext>(...);

// Hard to modify individual contexts
// Hard to test
// Violates SRP
```

### After (Single Responsibility) ✓
```csharp
// ✅ Each DbContext has its own extension
builder.Services
    .AddGroupDbContext(connectionString)      // GroupDbContextServiceExtension.cs
    .AddUserDbContext(connectionString)       // UserDbContextServiceExtension.cs
    .AddBudgetDbContext(connectionString)     // BudgetDbContextServiceExtension.cs
    .AddTransactionDbContext(connectionString);// TransactionDbContextServiceExtension.cs

// Easy to modify individual contexts
// Easy to test each extension separately
// Follows SRP
```

### Easy to Customize
```csharp
// GroupDbContextServiceExtension.cs
services.AddDbContext<GroupDbContext>(
    options => options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
            .EnableRetryOnFailure(maxRetryCount: 3)
            .CommandTimeout(30)),
    ServiceLifetime.Scoped); // ← Scoped
    
// UserDbContextServiceExtension.cs  
services.AddDbContext<UserDbContext>(
    options => options.UseNpgsql(connectionString),
    ServiceLifetime.Transient); // ← Different lifetime
    
// Each extension can be customized independently! ✓
```

## File Organization

```
FinanceTracker.Api/
│
├── Program.cs
│   └── Reads connection string
│   └── Calls extension methods
│
├── appsettings.Development.json
│   └── PostgreSQL connection string
│
└── Extensions/Injection/
    ├── GroupDbContextServiceExtension.cs
    │   └── .AddGroupDbContext(connString) method
    │
    ├── UserDbContextServiceExtension.cs
    │   └── .AddUserDbContext(connString) method
    │
    ├── BudgetDbContextServiceExtension.cs
    │   └── .AddBudgetDbContext(connString) method
    │
    └── TransactionDbContextServiceExtension.cs
        └── .AddTransactionDbContext(connString) method

Services/Group/FinanceTracker.Services.Group.Data/
├── GroupDbContext.cs
├── Configuration/
│   └── GroupMemberConfiguration.cs (← Fluent API config)
└── Migrations/
    ├── 20260318_InitialCreate.cs
    ├── 20260318_InitialCreate.Designer.cs
    └── GroupDbContextModelSnapshot.cs

Services/User/FinanceTracker.User.Services.Data/
├── UserDbContext.cs
├── Configuration/
└── Migrations/

Services/Budget/Budget.Services.Data/
├── BudgetDbContext.cs
├── Configuration/
└── Migrations/

Services/Expense/Expense.Services.Data/
├── TransactionDbContext.cs
├── Configuration/
└── Migrations/
```

## Configuration Class Pattern (Already in Place!)

Your `GroupMemberConfiguration.cs` demonstrates the pattern:

```csharp
public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
{
    public void Configure(EntityTypeBuilder<GroupMember> builder)
    {
        // Fluent API configuration
        builder.ToTable("group_members");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired().HasColumnName("user_id");
        builder.Property(e => e.GroupId).IsRequired().HasColumnName("group_id");
        
        // Relationships with delete cascade
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Group).WithMany().HasForeignKey(e => e.GroupId).OnDelete(DeleteBehavior.Cascade);
    }
}

// Applied automatically in DbContext
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupDbContext).Assembly);
    // ↑ Scans assembly and applies all IEntityTypeConfiguration<T> implementations
}
```

## Data Flow Example: Inserting a User

```
1. Controller receives request
   ↓
2. Service receives request
   ↓
3. Service receives injected UserDbContext
   ↓
4. UserDbContext has Users DbSet
   ↓
5. Service: dbContext.Users.Add(newUser)
   ↓
6. Service: dbContext.SaveChangesAsync()
   ↓
7. DbContext translates to SQL (Npgsql)
   ↓
8. Npgsql executes SQL against PostgreSQL
   ↓
9. PostgreSQL inserts into users table
   ↓
10. Returns success to caller
    ↓
11. Response sent to client
```

## Testing Benefits of Single Responsibility

```csharp
// Easy to mock individual DbContexts for testing

[TestClass]
public class GroupServiceTests
{
    [TestMethod]
    public void TestGroupCreation()
    {
        // Mock only GroupDbContext
        var mockGroupDb = new Mock<GroupDbContext>();
        
        // Don't need to mock other contexts
        var service = new GroupService(mockGroupDb.Object);
        
        var result = service.CreateGroup(...);
        
        Assert.IsTrue(result.Success);
    }
}

// ✓ Cleaner, more focused tests
// ✓ Easier to understand test intent
// ✓ Faster test execution
```

---

**Summary:** Your setup follows architectural best practices with clean separation of concerns, making it maintainable, testable, and easy to extend!
