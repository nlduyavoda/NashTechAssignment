using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Rated_Product_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Rated",
                table: "Products",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rated",
                table: "Products");
        }
    }
}
