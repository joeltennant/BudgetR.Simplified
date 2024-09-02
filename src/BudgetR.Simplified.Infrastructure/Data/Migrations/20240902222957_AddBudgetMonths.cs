using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetR.Simplified.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddBudgetMonths : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "BudgetMonths",
            columns: table => new
            {
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MonthYearId = table.Column<long>(type: "bigint", nullable: false),
                Spent = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false),
                Earned = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:TemporalIsPeriodStartColumn", true),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:TemporalIsPeriodEndColumn", true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BudgetMonths", x => x.BudgetMonthId);
                table.ForeignKey(
                    name: "FK_BudgetMonths_MonthYears_MonthYearId",
                    column: x => x.MonthYearId,
                    principalTable: "MonthYears",
                    principalColumn: "MonthYearId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2024, 9, 2, 16, 29, 56, 991, DateTimeKind.Local).AddTicks(3756));

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_MonthYearId",
            table: "BudgetMonths",
            column: "MonthYearId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BudgetMonths")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2024, 9, 2, 16, 25, 7, 306, DateTimeKind.Local).AddTicks(7038));
    }
}
