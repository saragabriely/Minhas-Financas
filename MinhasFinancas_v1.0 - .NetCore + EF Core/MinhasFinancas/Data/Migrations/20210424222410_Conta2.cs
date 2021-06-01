using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Conta2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "saldoEmConta",
                table: "Conta",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "saldoEmConta",
                table: "Conta",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
