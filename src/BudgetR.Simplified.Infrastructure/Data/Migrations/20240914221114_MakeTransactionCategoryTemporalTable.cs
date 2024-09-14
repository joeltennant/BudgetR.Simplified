using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetR.Simplified.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeTransactionCategoryTemporalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "TransactionCategories")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TransactionCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BusinessTransactionActivityId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionCategoryId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TransactionCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "TransactionCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 14, 16, 11, 13, 752, DateTimeKind.Local).AddTicks(658));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TransactionCategories")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "TransactionCategories")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterTable(
                name: "TransactionCategories")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TransactionCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BusinessTransactionActivityId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionCategoryId",
                table: "TransactionCategories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 5, 7, 36, 44, 341, DateTimeKind.Local).AddTicks(4572));
        }
    }
}
