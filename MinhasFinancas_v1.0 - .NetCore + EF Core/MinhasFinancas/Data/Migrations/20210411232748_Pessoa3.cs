using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Pessoa3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Pessoa_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    documento = table.Column<string>(maxLength: 18, nullable: false),
                    TipoPessoa_ID = table.Column<int>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    dataUltimaAlteracao = table.Column<DateTime>(nullable: false),
                    flagCadastroAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Pessoa_ID);
                    table.ForeignKey(
                        name: "FK_Pessoa_TipoPessoa_TipoPessoa_ID",
                        column: x => x.TipoPessoa_ID,
                        principalTable: "TipoPessoa",
                        principalColumn: "TipoPessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TipoPessoa_ID",
                table: "Pessoa",
                column: "TipoPessoa_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
