using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogTableRestructuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logEntity_AspNetUsers_applicationUserId",
                table: "logEntity");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "logEntity",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "HttpRequest",
                table: "logEntity",
                newName: "ResponseJson");

            migrationBuilder.RenameIndex(
                name: "IX_logEntity_applicationUserId",
                table: "logEntity",
                newName: "IX_logEntity_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "RequestJson",
                table: "logEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestPath",
                table: "logEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_logEntity_AspNetUsers_ApplicationUserId",
                table: "logEntity",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logEntity_AspNetUsers_ApplicationUserId",
                table: "logEntity");

            migrationBuilder.DropColumn(
                name: "RequestJson",
                table: "logEntity");

            migrationBuilder.DropColumn(
                name: "RequestPath",
                table: "logEntity");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "logEntity",
                newName: "applicationUserId");

            migrationBuilder.RenameColumn(
                name: "ResponseJson",
                table: "logEntity",
                newName: "HttpRequest");

            migrationBuilder.RenameIndex(
                name: "IX_logEntity_ApplicationUserId",
                table: "logEntity",
                newName: "IX_logEntity_applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_logEntity_AspNetUsers_applicationUserId",
                table: "logEntity",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
