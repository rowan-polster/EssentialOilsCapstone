using Microsoft.EntityFrameworkCore.Migrations;

namespace EssentialOilsCapstone.Migrations
{
    public partial class UserOilFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "UserOil",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumStars",
                table: "UserOil",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "UserOil");

            migrationBuilder.DropColumn(
                name: "NumStars",
                table: "UserOil");
        }
    }
}
