using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSystemApi_v01.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Customers_CustormId",
                table: "TransactionHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionHistory",
                table: "TransactionHistory");

            migrationBuilder.RenameTable(
                name: "TransactionHistory",
                newName: "transactionHistories");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistory_CustormId",
                table: "transactionHistories",
                newName: "IX_transactionHistories_CustormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionHistories",
                table: "transactionHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactionHistories_Customers_CustormId",
                table: "transactionHistories",
                column: "CustormId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionHistories_Customers_CustormId",
                table: "transactionHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionHistories",
                table: "transactionHistories");

            migrationBuilder.RenameTable(
                name: "transactionHistories",
                newName: "TransactionHistory");

            migrationBuilder.RenameIndex(
                name: "IX_transactionHistories_CustormId",
                table: "TransactionHistory",
                newName: "IX_TransactionHistory_CustormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionHistory",
                table: "TransactionHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Customers_CustormId",
                table: "TransactionHistory",
                column: "CustormId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
