using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class EmpresaListada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaListada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeDePregao = table.Column<string>(nullable: true),
                    CodigoAcao = table.Column<string>(nullable: true),
                    SetorEmpresaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaListada", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmpresaListada_SetorEmpresa_SetorEmpresaID",
                        column: x => x.SetorEmpresaID,
                        principalTable: "SetorEmpresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaListada_SetorEmpresaID",
                table: "EmpresaListada",
                column: "SetorEmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaListada");
        }
    }
}
