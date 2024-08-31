using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetR.Simplified.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                UserId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AuthenticationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserType = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:TemporalIsPeriodStartColumn", true),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:TemporalIsPeriodEndColumn", true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.UserId);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "BusinessTransactionActivities",
            columns: table => new
            {
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UserId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusinessTransactionActivities", x => x.BusinessTransactionActivityId);
                table.ForeignKey(
                    name: "FK_BusinessTransactionActivities_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId");
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "UserId", "AuthenticationId", "BusinessTransactionActivityId", "FirstName", "IsActive", "LastName", "UserType" },
            values: new object[] { 1L, "", 1L, "System", false, null, 0 });

        migrationBuilder.InsertData(
            table: "BusinessTransactionActivities",
            columns: new[] { "BusinessTransactionActivityId", "CreatedAt", "ProcessName", "UserId" },
            values: new object[] { 1L, new DateTime(2024, 8, 30, 12, 2, 15, 678, DateTimeKind.Local).AddTicks(2780), "Initial Seeding", 1L });

        migrationBuilder.CreateIndex(
            name: "IX_BusinessTransactionActivities_UserId",
            table: "BusinessTransactionActivities",
            column: "UserId",
            unique: true,
            filter: "[UserId] IS NOT NULL");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BusinessTransactionActivities");

        migrationBuilder.DropTable(
            name: "Users")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");
    }
}
