using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreReportAndStorageRelationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_BookSoldReports_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "BookStores");

            migrationBuilder.AddColumn<int>(
                name: "BookStoreId",
                table: "BookSoldReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.AddColumn<int>(
                name: "BookSoldReportId",
                table: "BookStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "BookStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_BookSoldReports_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId",
                principalTable: "BookSoldReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
