using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetR.Simplified.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMonthYears : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthYears",
                columns: table => new
                {
                    MonthYearId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthYears", x => x.MonthYearId);
                    table.ForeignKey(
                        name: "FK_MonthYears_BusinessTransactionActivities_BusinessTransactionActivityId",
                        column: x => x.BusinessTransactionActivityId,
                        principalTable: "BusinessTransactionActivities",
                        principalColumn: "BusinessTransactionActivityId");
                });

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 2, 16, 25, 7, 306, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.InsertData(
                table: "MonthYears",
                columns: new[] { "MonthYearId", "BusinessTransactionActivityId", "IsActive", "Month", "NumberOfDays", "Year" },
                values: new object[,]
                {
                    { 1L, null, true, 1, 31, 2020 },
                    { 2L, null, true, 2, 29, 2020 },
                    { 3L, null, true, 3, 31, 2020 },
                    { 4L, null, true, 4, 30, 2020 },
                    { 5L, null, true, 5, 31, 2020 },
                    { 6L, null, true, 6, 30, 2020 },
                    { 7L, null, true, 7, 31, 2020 },
                    { 8L, null, true, 8, 31, 2020 },
                    { 9L, null, true, 9, 30, 2020 },
                    { 10L, null, true, 10, 31, 2020 },
                    { 11L, null, true, 11, 30, 2020 },
                    { 12L, null, true, 12, 31, 2020 },
                    { 13L, null, true, 1, 31, 2021 },
                    { 14L, null, true, 2, 28, 2021 },
                    { 15L, null, true, 3, 31, 2021 },
                    { 16L, null, true, 4, 30, 2021 },
                    { 17L, null, true, 5, 31, 2021 },
                    { 18L, null, true, 6, 30, 2021 },
                    { 19L, null, true, 7, 31, 2021 },
                    { 20L, null, true, 8, 31, 2021 },
                    { 21L, null, true, 9, 30, 2021 },
                    { 22L, null, true, 10, 31, 2021 },
                    { 23L, null, true, 11, 30, 2021 },
                    { 24L, null, true, 12, 31, 2021 },
                    { 25L, null, true, 1, 31, 2022 },
                    { 26L, null, true, 2, 28, 2022 },
                    { 27L, null, true, 3, 31, 2022 },
                    { 28L, null, true, 4, 30, 2022 },
                    { 29L, null, true, 5, 31, 2022 },
                    { 30L, null, true, 6, 30, 2022 },
                    { 31L, null, true, 7, 31, 2022 },
                    { 32L, null, true, 8, 31, 2022 },
                    { 33L, null, true, 9, 30, 2022 },
                    { 34L, null, true, 10, 31, 2022 },
                    { 35L, null, true, 11, 30, 2022 },
                    { 36L, null, true, 12, 31, 2022 },
                    { 37L, null, true, 1, 31, 2023 },
                    { 38L, null, true, 2, 28, 2023 },
                    { 39L, null, true, 3, 31, 2023 },
                    { 40L, null, true, 4, 30, 2023 },
                    { 41L, null, true, 5, 31, 2023 },
                    { 42L, null, true, 6, 30, 2023 },
                    { 43L, null, true, 7, 31, 2023 },
                    { 44L, null, true, 8, 31, 2023 },
                    { 45L, null, true, 9, 30, 2023 },
                    { 46L, null, true, 10, 31, 2023 },
                    { 47L, null, true, 11, 30, 2023 },
                    { 48L, null, true, 12, 31, 2023 },
                    { 49L, null, true, 1, 31, 2024 },
                    { 50L, null, true, 2, 29, 2024 },
                    { 51L, null, true, 3, 31, 2024 },
                    { 52L, null, true, 4, 30, 2024 },
                    { 53L, null, true, 5, 31, 2024 },
                    { 54L, null, true, 6, 30, 2024 },
                    { 55L, null, true, 7, 31, 2024 },
                    { 56L, null, true, 8, 31, 2024 },
                    { 57L, null, true, 9, 30, 2024 },
                    { 58L, null, true, 10, 31, 2024 },
                    { 59L, null, true, 11, 30, 2024 },
                    { 60L, null, true, 12, 31, 2024 },
                    { 61L, null, true, 1, 31, 2025 },
                    { 62L, null, true, 2, 28, 2025 },
                    { 63L, null, true, 3, 31, 2025 },
                    { 64L, null, true, 4, 30, 2025 },
                    { 65L, null, true, 5, 31, 2025 },
                    { 66L, null, true, 6, 30, 2025 },
                    { 67L, null, true, 7, 31, 2025 },
                    { 68L, null, true, 8, 31, 2025 },
                    { 69L, null, true, 9, 30, 2025 },
                    { 70L, null, true, 10, 31, 2025 },
                    { 71L, null, true, 11, 30, 2025 },
                    { 72L, null, true, 12, 31, 2025 },
                    { 73L, null, true, 1, 31, 2026 },
                    { 74L, null, true, 2, 28, 2026 },
                    { 75L, null, true, 3, 31, 2026 },
                    { 76L, null, true, 4, 30, 2026 },
                    { 77L, null, true, 5, 31, 2026 },
                    { 78L, null, true, 6, 30, 2026 },
                    { 79L, null, true, 7, 31, 2026 },
                    { 80L, null, true, 8, 31, 2026 },
                    { 81L, null, true, 9, 30, 2026 },
                    { 82L, null, true, 10, 31, 2026 },
                    { 83L, null, true, 11, 30, 2026 },
                    { 84L, null, true, 12, 31, 2026 },
                    { 85L, null, true, 1, 31, 2027 },
                    { 86L, null, true, 2, 28, 2027 },
                    { 87L, null, true, 3, 31, 2027 },
                    { 88L, null, true, 4, 30, 2027 },
                    { 89L, null, true, 5, 31, 2027 },
                    { 90L, null, true, 6, 30, 2027 },
                    { 91L, null, true, 7, 31, 2027 },
                    { 92L, null, true, 8, 31, 2027 },
                    { 93L, null, true, 9, 30, 2027 },
                    { 94L, null, true, 10, 31, 2027 },
                    { 95L, null, true, 11, 30, 2027 },
                    { 96L, null, true, 12, 31, 2027 },
                    { 97L, null, true, 1, 31, 2028 },
                    { 98L, null, true, 2, 29, 2028 },
                    { 99L, null, true, 3, 31, 2028 },
                    { 100L, null, true, 4, 30, 2028 },
                    { 101L, null, true, 5, 31, 2028 },
                    { 102L, null, true, 6, 30, 2028 },
                    { 103L, null, true, 7, 31, 2028 },
                    { 104L, null, true, 8, 31, 2028 },
                    { 105L, null, true, 9, 30, 2028 },
                    { 106L, null, true, 10, 31, 2028 },
                    { 107L, null, true, 11, 30, 2028 },
                    { 108L, null, true, 12, 31, 2028 },
                    { 109L, null, true, 1, 31, 2029 },
                    { 110L, null, true, 2, 28, 2029 },
                    { 111L, null, true, 3, 31, 2029 },
                    { 112L, null, true, 4, 30, 2029 },
                    { 113L, null, true, 5, 31, 2029 },
                    { 114L, null, true, 6, 30, 2029 },
                    { 115L, null, true, 7, 31, 2029 },
                    { 116L, null, true, 8, 31, 2029 },
                    { 117L, null, true, 9, 30, 2029 },
                    { 118L, null, true, 10, 31, 2029 },
                    { 119L, null, true, 11, 30, 2029 },
                    { 120L, null, true, 12, 31, 2029 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthYears_BusinessTransactionActivityId",
                table: "MonthYears",
                column: "BusinessTransactionActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthYears");

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 31, 16, 2, 42, 165, DateTimeKind.Local).AddTicks(7454));
        }
    }
}
