using Microsoft.EntityFrameworkCore.Migrations;

namespace Bread.Data.Migrations
{
    public partial class ChangeRestaurantBannerPathToImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerPath",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "BannerPath",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
