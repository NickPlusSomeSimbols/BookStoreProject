using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorFix_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "BasketItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
