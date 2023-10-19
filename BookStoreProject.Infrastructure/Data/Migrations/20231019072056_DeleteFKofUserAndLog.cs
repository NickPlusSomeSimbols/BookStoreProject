using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFKofUserAndLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logEntity_AspNetUsers_LoggedUserId",
                table: "logEntity");

            migrationBuilder.DropIndex(
                name: "IX_logEntity_LoggedUserId",
                table: "logEntity");

            migrationBuilder.AlterColumn<string>(
                name: "LoggedUserId",
                table: "logEntity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoggedUserId",
                table: "logEntity",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
