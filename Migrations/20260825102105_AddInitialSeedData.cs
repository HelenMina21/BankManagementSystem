using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace G_NET_5_EF04.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "B001", "Cairo", "Main Branch", "01000000000" },
                    { "B002", "Nasr City", "Nasr City Branch", "01100000000" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerType", "DateOfBirth", "Email", "FullName", "NationalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Cairo", "Individual", new DateTime(1995, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed.ali@email.com", "Mohamed Ali", "29505201234567", "01033333333" },
                    { 2, "Giza", "Individual", new DateTime(1998, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.adel@email.com", "Mariam Adel", "29808121234567", "01044444444" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "Balance", "BranchCode", "OpeningDate" },
                values: new object[,]
                {
                    { "ACC001", "Savings", 15000.00m, "B001", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ACC002", "Current", 25000.00m, "B002", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "B001", "ahmed.hassan@bank.com", "Ahmed Hassan", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011111111" },
                    { 2, "B002", "sara.mohamed@bank.com", "Sara Mohamed", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01022222222" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAccount",
                columns: new[] { "AccountNumber", "CustomerId", "AccountStatus", "OwnershipStartDate", "OwnershipType" },
                values: new object[,]
                {
                    { "ACC001", 1, "Active", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { "ACC002", 1, "Active", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { "ACC002", 2, "Active", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CoHolder" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionNumber", "AccountNumber", "Amount", "Note", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, "ACC001", 5000.00m, "Initial deposit", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 2, "ACC002", 2000.00m, "ATM withdrawal", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal" },
                    { 3, "ACC002", 1000.00m, "Monthly payment", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerAccount",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "ACC001", 1 });

            migrationBuilder.DeleteData(
                table: "CustomerAccount",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "ACC002", 1 });

            migrationBuilder.DeleteData(
                table: "CustomerAccount",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "ACC002", 2 });

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "ACC001");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "ACC002");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "B001");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "B002");
        }
    }
}
