using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimKeyToRep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId");
        }
    }
}
