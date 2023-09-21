using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnlinkReportAndBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSoldReports_BookSoldReportId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookSoldReportId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookSoldReportId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookSoldReportId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSoldReportId",
                table: "Books",
                column: "BookSoldReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSoldReports_BookSoldReportId",
                table: "Books",
                column: "BookSoldReportId",
                principalTable: "BookSoldReports",
                principalColumn: "Id");
        }
    }
}
