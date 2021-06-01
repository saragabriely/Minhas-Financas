using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Conta3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conta",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "saldoEmConta",
                table: "Conta",
                newName: "SaldoEmConta");

            migrationBuilder.RenameColumn(
                name: "dataUltimaAtualizacao",
                table: "Conta",
                newName: "DataUltimaAtualizacao");

            migrationBuilder.RenameColumn(
                name: "dataCadastro",
                table: "Conta",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "agencia",
                table: "Conta",
                newName: "Agencia");

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "Conta",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ContaBancaria",
                table: "Conta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaBancaria",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "SaldoEmConta",
                table: "Conta",
                newName: "saldoEmConta");

            migrationBuilder.RenameColumn(
                name: "DataUltimaAtualizacao",
                table: "Conta",
                newName: "dataUltimaAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Conta",
                newName: "dataCadastro");

            migrationBuilder.RenameColumn(
                name: "Agencia",
                table: "Conta",
                newName: "agencia");

            migrationBuilder.AlterColumn<string>(
                name: "agencia",
                table: "Conta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "conta",
                table: "Conta",
                nullable: false,
                defaultValue: "");
        }
    }
}
