using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogTableCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogUploadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HttpRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_logEntity_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_logEntity_applicationUserId",
                table: "logEntity",
                column: "applicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logEntity");
        }
    }
}
