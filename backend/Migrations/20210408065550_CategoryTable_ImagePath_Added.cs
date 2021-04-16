using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class CategoryTable_ImagePath_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImage",
                table: "Categories");
        }
    }
}
