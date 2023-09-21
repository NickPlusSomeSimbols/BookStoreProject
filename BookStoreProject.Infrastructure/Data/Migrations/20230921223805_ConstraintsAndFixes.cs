using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintsAndFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "BookSoldReports");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "BookStores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SoldBookId",
                table: "BookSoldReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_StoreName",
                table: "BookStores",
                column: "StoreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookId_BookStoreId",
                table: "BookStorages",
                columns: new[] { "BookId", "BookStoreId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports",
                column: "SoldBookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_StoreName",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookId_BookStoreId",
                table: "BookStorages");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "BookStores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SoldBookId",
                table: "BookSoldReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "BookSoldReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSoldReports_Books_SoldBookId",
                table: "BookSoldReports",
                column: "SoldBookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
