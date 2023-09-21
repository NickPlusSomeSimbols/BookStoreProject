using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LinkReportAndBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BookSoldReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldBookId",
                table: "BookSoldReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_SoldBookId",
                table: "BookSoldReports",
                column: "SoldBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports",
                column: "SoldBookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookSoldReports_SoldBookId",
                table: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "SoldBookId",
                table: "BookSoldReports");
        }
    }
}
