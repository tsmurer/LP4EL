using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopJoin.API.Migrations
{
    public partial class UsernameToEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
