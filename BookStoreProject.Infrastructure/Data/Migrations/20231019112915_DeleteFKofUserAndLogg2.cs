using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFKofUserAndLogg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logEntity",
                table: "logEntity");

            migrationBuilder.RenameTable(
                name: "logEntity",
                newName: "Logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "logEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logEntity",
                table: "logEntity",
                column: "Id");
        }
    }
}
