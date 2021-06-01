using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Despesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    ValorAPagar = table.Column<string>(nullable: false),
                    ValorPago = table.Column<string>(nullable: true),
                    CategoriaDespesaID = table.Column<int>(nullable: false),
                    FormaPagamentoID = table.Column<int>(nullable: false),
                    StatusDespesaID = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Despesa_CategoriaDespesa_CategoriaDespesaID",
                        column: x => x.CategoriaDespesaID,
                        principalTable: "CategoriaDespesa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_FormaPagamento_FormaPagamentoID",
                        column: x => x.FormaPagamentoID,
                        principalTable: "FormaPagamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despesa_StatusDespesa_StatusDespesaID",
                        column: x => x.StatusDespesaID,
                        principalTable: "StatusDespesa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_CategoriaDespesaID",
                table: "Despesa",
                column: "CategoriaDespesaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_FormaPagamentoID",
                table: "Despesa",
                column: "FormaPagamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_PessoaID",
                table: "Despesa",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_StatusDespesaID",
                table: "Despesa",
                column: "StatusDespesaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesa");
        }
    }
}
