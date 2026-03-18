using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Services.Budget.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateBudgetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "budget_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    budget_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budget_members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "budgets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("bc03e7d4-153f-4328-bd21-95707d1a2d09")),
                    actual_budget = table.Column<double>(type: "double precision", nullable: false),
                    target_savings = table.Column<double>(type: "double precision", nullable: false),
                    target_items = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    due_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    alert_threshold = table.Column<int>(type: "integer", nullable: false, defaultValue: 80),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budgets", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_budget_members_budget_id",
                table: "budget_members",
                column: "budget_id");

            migrationBuilder.CreateIndex(
                name: "ix_budget_members_user_id",
                table: "budget_members",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_budget_category",
                table: "budgets",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "ix_budget_created_at",
                table: "budgets",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_budget_due_date",
                table: "budgets",
                column: "due_date");

            migrationBuilder.CreateIndex(
                name: "ix_budget_group_active",
                table: "budgets",
                columns: new[] { "group_id", "is_deleted", "is_active" });

            migrationBuilder.CreateIndex(
                name: "ix_budget_group_id",
                table: "budgets",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budget_members");

            migrationBuilder.DropTable(
                name: "budgets");
        }
    }
}
