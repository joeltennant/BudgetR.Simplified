using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetR.Simplified.Server.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionMonth_TransactionYear",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTransactionActivities_UserId",
                table: "BusinessTransactionActivities");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionMonth",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionYear",
                table: "Transactions");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<long>(
                name: "TransactionCategoryId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<long>(
                name: "TransactionBatchId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<bool>(
                name: "PreventRecategorizing",
                table: "Transactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<long>(
                name: "BudgetMonthId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<long>(
                name: "MonthYearId",
                table: "Transactions",
                type: "bigint",
                maxLength: 2,
                nullable: false,
                defaultValue: 0L)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalanceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionBatches",
                columns: table => new
                {
                    TransactionBatchId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordCount = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionBatches", x => x.TransactionBatchId);
                });

            migrationBuilder.CreateTable(
                name: "UserParameters",
                columns: table => new
                {
                    UserParameterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterType = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParameters", x => x.UserParameterId);
                    table.ForeignKey(
                        name: "FK_UserParameters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    LongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    Balance = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    AccountTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                    BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.CheckConstraint("CK_Account_Balance", "[Balance] >= 0");
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_BusinessTransactionActivities_BusinessTransactionActivityId",
                        column: x => x.BusinessTransactionActivityId,
                        principalTable: "BusinessTransactionActivities",
                        principalColumn: "BusinessTransactionActivityId");
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "BalanceType", "Name" },
                values: new object[,]
                {
                    { 1L, 0, "Checking" },
                    { 2L, 0, "Savings" },
                    { 3L, 1, "Credit Card" },
                    { 4L, 0, "Cash" },
                    { 5L, 0, "Investment" },
                    { 6L, 1, "Loan" },
                    { 7L, 0, "Other" },
                    { 8L, 0, "Retirement" }
                });

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 10, 58, 58, 691, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MonthYearId",
                table: "Transactions",
                column: "MonthYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionBatchId",
                table: "Transactions",
                column: "TransactionBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTransactionActivities_UserId",
                table: "BusinessTransactionActivities",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BusinessTransactionActivityId",
                table: "Accounts",
                column: "BusinessTransactionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserParameters_UserId",
                table: "UserParameters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_MonthYears_MonthYearId",
                table: "Transactions",
                column: "MonthYearId",
                principalTable: "MonthYears",
                principalColumn: "MonthYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionBatches_TransactionBatchId",
                table: "Transactions",
                column: "TransactionBatchId",
                principalTable: "TransactionBatches",
                principalColumn: "TransactionBatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_MonthYears_MonthYearId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionBatches_TransactionBatchId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

            migrationBuilder.DropTable(
                name: "TransactionBatches");

            migrationBuilder.DropTable(
                name: "UserParameters");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MonthYearId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionBatchId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTransactionActivities_UserId",
                table: "BusinessTransactionActivities");

            migrationBuilder.DropColumn(
                name: "MonthYearId",
                table: "Transactions");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<long>(
                name: "TransactionCategoryId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<long>(
                name: "TransactionBatchId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<bool>(
                name: "PreventRecategorizing",
                table: "Transactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<long>(
                name: "BudgetMonthId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<int>(
                name: "TransactionMonth",
                table: "Transactions",
                type: "int",
                maxLength: 2,
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<int>(
                name: "TransactionYear",
                table: "Transactions",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 14, 17, 7, 31, 801, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionMonth_TransactionYear",
                table: "Transactions",
                columns: new[] { "TransactionMonth", "TransactionYear" });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTransactionActivities_UserId",
                table: "BusinessTransactionActivities",
                column: "UserId",
                filter: "[UserId] IS NOT NULL");
        }
    }
}
