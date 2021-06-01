using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class AcoesEntrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcoesEntrada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNegociacao = table.Column<string>(nullable: true),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeCompra = table.Column<int>(nullable: false),
                    ValorCorretagem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorISS = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmpresaListadaID = table.Column<int>(nullable: false),
                    TipoMercadoID = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcoesEntrada", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AcoesEntrada_EmpresaListada_EmpresaListadaID",
                        column: x => x.EmpresaListadaID,
                        principalTable: "EmpresaListada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcoesEntrada_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcoesEntrada_TipoMercado_TipoMercadoID",
                        column: x => x.TipoMercadoID,
                        principalTable: "TipoMercado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcoesEntrada_EmpresaListadaID",
                table: "AcoesEntrada",
                column: "EmpresaListadaID");

            migrationBuilder.CreateIndex(
                name: "IX_AcoesEntrada_PessoaID",
                table: "AcoesEntrada",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_AcoesEntrada_TipoMercadoID",
                table: "AcoesEntrada",
                column: "TipoMercadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcoesEntrada");
        }
    }
}
