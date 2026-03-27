using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Services.Budget.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultBudgetDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "budgets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("68fe8c06-5493-4e0a-90ab-fa80e7a4fe91"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("d2d51592-9c4e-4c6f-a370-bf3369712809"));

            migrationBuilder.CreateTable(
                name: "default_budget_distributions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: true),
                    category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_default_budget_distributions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_default_budget_distributions_group_id",
                table: "default_budget_distributions",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_default_budget_distributions_user_id",
                table: "default_budget_distributions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_default_budget_distributions_user_id_group_id_priority",
                table: "default_budget_distributions",
                columns: new[] { "user_id", "group_id", "priority" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "default_budget_distributions");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "budgets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("d2d51592-9c4e-4c6f-a370-bf3369712809"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("68fe8c06-5493-4e0a-90ab-fa80e7a4fe91"));
        }
    }
}
