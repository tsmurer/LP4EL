using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopJoin.API.Migrations
{
    public partial class remove_cpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
