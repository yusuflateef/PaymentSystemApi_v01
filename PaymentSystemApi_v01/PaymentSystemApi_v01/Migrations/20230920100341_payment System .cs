using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSystemApi_v01.Migrations
{
    /// <inheritdoc />
    public partial class paymentSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_CustormId",
                table: "TransactionHistory");

            migrationBuilder.CreateTable(
                name: "Marchants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarchantNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AverageTransactionVolume = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CustormId",
                table: "TransactionHistory",
                column: "CustormId");

            migrationBuilder.CreateIndex(
                name: "IX_Marchants_MarchantNumber",
                table: "Marchants",
                column: "MarchantNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marchants");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_CustormId",
                table: "TransactionHistory");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CustormId",
                table: "TransactionHistory",
                column: "CustormId",
                unique: true);
        }
    }
}
