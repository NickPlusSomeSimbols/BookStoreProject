using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Basket",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Basket");
        }
    }
}
