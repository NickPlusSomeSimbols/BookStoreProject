using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScemeRecreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookStores_BookStoreId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookStoreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookStoreId",
                table: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "BookStoreId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "BookStorages",
                newName: "BookId");

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

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BookStorages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookStoreId",
                table: "BookStorages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_BookSoldReports_BookSoldReportId",
                table: "BookStores",
                column: "BookSoldReportId",
                principalTable: "BookSoldReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_BookSoldReports_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "BookSoldReportId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "BookStoreId",
                table: "BookStorages");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookStorages",
                newName: "BookID");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BookStorages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookStoreId",
                table: "BookSoldReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookStoreId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookStoreId",
                table: "Books",
                column: "BookStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookStores_BookStoreId",
                table: "Books",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_BookStores_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id");
        }
    }
}
