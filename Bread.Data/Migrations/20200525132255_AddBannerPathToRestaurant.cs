using Microsoft.EntityFrameworkCore.Migrations;

namespace Bread.Data.Migrations
{
    public partial class AddBannerPathToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerPath",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerPath",
                table: "Restaurants");
        }
    }
}
