using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogTableChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logEntity_AspNetUsers_ApplicationUserId",
                table: "logEntity");

            migrationBuilder.DropIndex(
                name: "IX_logEntity_ApplicationUserId",
                table: "logEntity");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "logEntity");

            migrationBuilder.AddColumn<string>(
                name: "LoggedUserId",
                table: "logEntity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_logEntity_LoggedUserId",
                table: "logEntity",
                column: "LoggedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_logEntity_AspNetUsers_LoggedUserId",
                table: "logEntity",
                column: "LoggedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logEntity_AspNetUsers_LoggedUserId",
                table: "logEntity");

            migrationBuilder.DropIndex(
                name: "IX_logEntity_LoggedUserId",
                table: "logEntity");

            migrationBuilder.DropColumn(
                name: "LoggedUserId",
                table: "logEntity");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "logEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_logEntity_ApplicationUserId",
                table: "logEntity",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_logEntity_AspNetUsers_ApplicationUserId",
                table: "logEntity",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
