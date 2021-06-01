using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Conta1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "digitoAgencia",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "digitoConta",
                table: "Conta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "digitoAgencia",
                table: "Conta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "digitoConta",
                table: "Conta",
                nullable: true);
        }
    }
}
