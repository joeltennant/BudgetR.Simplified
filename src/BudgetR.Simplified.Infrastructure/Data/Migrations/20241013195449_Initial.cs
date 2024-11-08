using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetR.Simplified.Server.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
            name: "Users",
            columns: table => new
            {
                UserId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                AuthenticationId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                UserType = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Started = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.UserId);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

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
                DisplayName = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true)
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
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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

        migrationBuilder.CreateTable(
            name: "TransactionCategories",
            columns: table => new
            {
                TransactionCategoryId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                UserId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Started = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TransactionCategories", x => x.TransactionCategoryId);
                table.ForeignKey(
                    name: "FK_TransactionCategories_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_TransactionCategories_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId");
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

        migrationBuilder.CreateTable(
            name: "BudgetMonths",
            columns: table => new
            {
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                MonthYearId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Spent = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Earned = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                UserId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Ended = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started"),
                Started = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started")
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
                table.ForeignKey(
                    name: "FK_BudgetMonths_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

        migrationBuilder.CreateTable(
            name: "Transactions",
            columns: table => new
            {
                TransactionId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TransactionType = table.Column<int>(type: "int", nullable: true),
                Amount = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false),
                TransactionDate = table.Column<DateOnly>(type: "date", nullable: true),
                MonthYearId = table.Column<long>(type: "bigint", maxLength: 2, nullable: false),
                TransactionCategoryId = table.Column<long>(type: "bigint", nullable: true),
                TransactionBatchId = table.Column<long>(type: "bigint", nullable: true),
                UserId = table.Column<long>(type: "bigint", nullable: false),
                PreventRecategorizing = table.Column<bool>(type: "bit", nullable: false),
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                table.ForeignKey(
                    name: "FK_Transactions_BudgetMonths_BudgetMonthId",
                    column: x => x.BudgetMonthId,
                    principalTable: "BudgetMonths",
                    principalColumn: "BudgetMonthId");
                table.ForeignKey(
                    name: "FK_Transactions_MonthYears_MonthYearId",
                    column: x => x.MonthYearId,
                    principalTable: "MonthYears",
                    principalColumn: "MonthYearId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Transactions_TransactionBatches_TransactionBatchId",
                    column: x => x.TransactionBatchId,
                    principalTable: "TransactionBatches",
                    principalColumn: "TransactionBatchId");
                table.ForeignKey(
                    name: "FK_Transactions_TransactionCategories_TransactionCategoryId",
                    column: x => x.TransactionCategoryId,
                    principalTable: "TransactionCategories",
                    principalColumn: "TransactionCategoryId");
                table.ForeignKey(
                    name: "FK_Transactions_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId",
                    onDelete: ReferentialAction.Restrict);
            });

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

        migrationBuilder.InsertData(
            table: "MonthYears",
            columns: new[] { "MonthYearId", "BusinessTransactionActivityId", "CreatedAt", "IsActive", "Month", "NumberOfDays", "Year" },
            values: new object[,]
            {
                { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2020 },
                { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 29, 2020 },
                { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2020 },
                { 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2020 },
                { 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2020 },
                { 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2020 },
                { 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2020 },
                { 8L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2020 },
                { 9L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2020 },
                { 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2020 },
                { 11L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2020 },
                { 12L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2020 },
                { 13L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2021 },
                { 14L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2021 },
                { 15L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2021 },
                { 16L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2021 },
                { 17L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2021 },
                { 18L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2021 },
                { 19L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2021 },
                { 20L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2021 },
                { 21L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2021 },
                { 22L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2021 },
                { 23L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2021 },
                { 24L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2021 },
                { 25L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2022 },
                { 26L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2022 },
                { 27L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2022 },
                { 28L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2022 },
                { 29L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2022 },
                { 30L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2022 },
                { 31L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2022 },
                { 32L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2022 },
                { 33L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2022 },
                { 34L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2022 },
                { 35L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2022 },
                { 36L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2022 },
                { 37L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2023 },
                { 38L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2023 },
                { 39L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2023 },
                { 40L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2023 },
                { 41L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2023 },
                { 42L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2023 },
                { 43L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2023 },
                { 44L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2023 },
                { 45L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2023 },
                { 46L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2023 },
                { 47L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2023 },
                { 48L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2023 },
                { 49L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2024 },
                { 50L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 29, 2024 },
                { 51L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2024 },
                { 52L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2024 },
                { 53L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2024 },
                { 54L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2024 },
                { 55L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2024 },
                { 56L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2024 },
                { 57L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2024 },
                { 58L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2024 },
                { 59L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2024 },
                { 60L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2024 },
                { 61L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2025 },
                { 62L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2025 },
                { 63L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2025 },
                { 64L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2025 },
                { 65L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2025 },
                { 66L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2025 },
                { 67L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2025 },
                { 68L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2025 },
                { 69L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2025 },
                { 70L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2025 },
                { 71L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2025 },
                { 72L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2025 },
                { 73L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2026 },
                { 74L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2026 },
                { 75L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2026 },
                { 76L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2026 },
                { 77L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2026 },
                { 78L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2026 },
                { 79L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2026 },
                { 80L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2026 },
                { 81L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2026 },
                { 82L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2026 },
                { 83L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2026 },
                { 84L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2026 },
                { 85L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2027 },
                { 86L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2027 },
                { 87L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2027 },
                { 88L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2027 },
                { 89L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2027 },
                { 90L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2027 },
                { 91L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2027 },
                { 92L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2027 },
                { 93L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2027 },
                { 94L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2027 },
                { 95L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2027 },
                { 96L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2027 },
                { 97L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2028 },
                { 98L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 29, 2028 },
                { 99L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2028 },
                { 100L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2028 },
                { 101L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2028 },
                { 102L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2028 },
                { 103L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2028 },
                { 104L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2028 },
                { 105L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2028 },
                { 106L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2028 },
                { 107L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2028 },
                { 108L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2028 },
                { 109L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 31, 2029 },
                { 110L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 28, 2029 },
                { 111L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 31, 2029 },
                { 112L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 30, 2029 },
                { 113L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 31, 2029 },
                { 114L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, 30, 2029 },
                { 115L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 31, 2029 },
                { 116L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, 31, 2029 },
                { 117L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 30, 2029 },
                { 118L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 31, 2029 },
                { 119L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11, 30, 2029 },
                { 120L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12, 31, 2029 }
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "UserId", "AuthenticationId", "BusinessTransactionActivityId", "Email", "FirstName", "IsActive", "LastName", "UserType" },
            values: new object[] { 1L, "", 1L, null, "System", false, null, 0 });

        migrationBuilder.InsertData(
            table: "BusinessTransactionActivities",
            columns: new[] { "BusinessTransactionActivityId", "CreatedAt", "ProcessName", "UserId" },
            values: new object[] { 1L, new DateTime(2024, 10, 13, 13, 54, 49, 12, DateTimeKind.Local).AddTicks(2100), "Initial Seeding", 1L });

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
            name: "IX_BudgetMonths_MonthYearId",
            table: "BudgetMonths",
            column: "MonthYearId");

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_UserId",
            table: "BudgetMonths",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_BusinessTransactionActivities_UserId",
            table: "BusinessTransactionActivities",
            column: "UserId",
            unique: false,
            filter: "[UserId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_MonthYears_BusinessTransactionActivityId",
            table: "MonthYears",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_TransactionCategories_BusinessTransactionActivityId",
            table: "TransactionCategories",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_TransactionCategories_UserId",
            table: "TransactionCategories",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_BudgetMonthId",
            table: "Transactions",
            column: "BudgetMonthId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_MonthYearId",
            table: "Transactions",
            column: "MonthYearId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionBatchId",
            table: "Transactions",
            column: "TransactionBatchId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionCategoryId",
            table: "Transactions",
            column: "TransactionCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_UserId",
            table: "Transactions",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_UserParameters_UserId",
            table: "UserParameters",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Accounts")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

        migrationBuilder.DropTable(
            name: "Transactions");

        migrationBuilder.DropTable(
            name: "UserParameters");

        migrationBuilder.DropTable(
            name: "AccountTypes");

        migrationBuilder.DropTable(
            name: "BudgetMonths")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

        migrationBuilder.DropTable(
            name: "TransactionBatches");

        migrationBuilder.DropTable(
            name: "TransactionCategories")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "TransactionCategoryHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");

        migrationBuilder.DropTable(
            name: "MonthYears");

        migrationBuilder.DropTable(
            name: "BusinessTransactionActivities");

        migrationBuilder.DropTable(
            name: "Users")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "Ended")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "Started");
    }
}
