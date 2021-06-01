using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Acao02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNegociacao = table.Column<string>(nullable: true),
                    ValorCompra = table.Column<string>(nullable: true),
                    QuantidadeCompra = table.Column<int>(nullable: false),
                    ValorCorretagem = table.Column<string>(nullable: true),
                    ValorISS = table.Column<string>(nullable: true),
                    EmpresaListadaID = table.Column<int>(nullable: false),
                    TipoMercadoID = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false),
                    TipoMovimentoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Acao_EmpresaListada_EmpresaListadaID",
                        column: x => x.EmpresaListadaID,
                        principalTable: "EmpresaListada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acao_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acao_TipoMercado_TipoMercadoID",
                        column: x => x.TipoMercadoID,
                        principalTable: "TipoMercado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acao_TipoMovimento_TipoMovimentoID",
                        column: x => x.TipoMovimentoID,
                        principalTable: "TipoMovimento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acao_EmpresaListadaID",
                table: "Acao",
                column: "EmpresaListadaID");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_PessoaID",
                table: "Acao",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_TipoMercadoID",
                table: "Acao",
                column: "TipoMercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_TipoMovimentoID",
                table: "Acao",
                column: "TipoMovimentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acao");
        }
    }
}
