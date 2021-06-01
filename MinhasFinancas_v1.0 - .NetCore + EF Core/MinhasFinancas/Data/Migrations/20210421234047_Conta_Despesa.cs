using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Conta_Despesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "documento",
                table: "Pessoa",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 18);

            migrationBuilder.CreateTable(
                name: "CategoriaDespesa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDespesa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoConta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    agencia = table.Column<string>(nullable: false),
                    digitoAgencia = table.Column<string>(nullable: true),
                    conta = table.Column<string>(nullable: false),
                    digitoConta = table.Column<string>(nullable: true),
                    saldoEmConta = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PessoaID = table.Column<int>(nullable: false),
                    TipoContaID = table.Column<int>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    dataUltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    flagAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conta_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conta_TipoConta_TipoContaID",
                        column: x => x.TipoContaID,
                        principalTable: "TipoConta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_PessoaID",
                table: "Conta",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_TipoContaID",
                table: "Conta",
                column: "TipoContaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaDespesa");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "TipoConta");

            migrationBuilder.AlterColumn<string>(
                name: "documento",
                table: "Pessoa",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18,
                oldNullable: true);
        }
    }
}
