using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Receita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    DataPrevistaRecebimento = table.Column<DateTime>(nullable: false),
                    DataDeRecebimento = table.Column<DateTime>(nullable: true),
                    ValorAReceber = table.Column<string>(nullable: false),
                    ValorRecebido = table.Column<string>(nullable: true),
                    FormaRecebimentoID = table.Column<int>(nullable: false),
                    StatusReceitaID = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receita_FormaRecebimento_FormaRecebimentoID",
                        column: x => x.FormaRecebimentoID,
                        principalTable: "FormaRecebimento",
                        principalColumn: "FormaRecebimento_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receita_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receita_StatusReceita_StatusReceitaID",
                        column: x => x.StatusReceitaID,
                        principalTable: "StatusReceita",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_FormaRecebimentoID",
                table: "Receita",
                column: "FormaRecebimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_PessoaID",
                table: "Receita",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_StatusReceitaID",
                table: "Receita",
                column: "StatusReceitaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}
