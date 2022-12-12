using Microsoft.EntityFrameworkCore.Migrations;

namespace GRSHOP.Data.Migrations
{
    public partial class GroceryEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Grocery",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Grocery");
        }
    }
}
