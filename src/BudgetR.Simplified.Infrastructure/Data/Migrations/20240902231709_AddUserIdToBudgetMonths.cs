using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetR.Simplified.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddUserIdToBudgetMonths : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<long>(
            name: "UserId",
            table: "BudgetMonths",
            type: "bigint",
            nullable: false,
            defaultValue: 0L)
            .Annotation("Relational:ColumnOrder", 4);

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2024, 9, 2, 17, 17, 9, 252, DateTimeKind.Local).AddTicks(3839));

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_UserId",
            table: "BudgetMonths",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_BudgetMonths_Users_UserId",
            table: "BudgetMonths",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "UserId",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BudgetMonths_Users_UserId",
            table: "BudgetMonths");

        migrationBuilder.DropIndex(
            name: "IX_BudgetMonths_UserId",
            table: "BudgetMonths");

        migrationBuilder.DropColumn(
            name: "UserId",
            table: "BudgetMonths");

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2024, 9, 2, 16, 29, 56, 991, DateTimeKind.Local).AddTicks(3756));
    }
}
