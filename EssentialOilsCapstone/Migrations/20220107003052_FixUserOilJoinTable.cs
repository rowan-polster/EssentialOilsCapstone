using Microsoft.EntityFrameworkCore.Migrations;

namespace EssentialOilsCapstone.Migrations
{
    public partial class FixUserOilJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOil_AspNetUsers_UserId1",
                table: "UserOil");

            migrationBuilder.DropIndex(
                name: "IX_UserOil_UserId1",
                table: "UserOil");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserOil");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOil",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserOil_UserId",
                table: "UserOil",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOil_AspNetUsers_UserId",
                table: "UserOil",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOil_AspNetUsers_UserId",
                table: "UserOil");

            migrationBuilder.DropIndex(
                name: "IX_UserOil_UserId",
                table: "UserOil");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserOil",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserOil",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOil_UserId1",
                table: "UserOil",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOil_AspNetUsers_UserId1",
                table: "UserOil",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
