using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookStoreId",
                table: "BookSoldReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "BookStoreId",
                table: "BookSoldReports");
        }
    }
}
