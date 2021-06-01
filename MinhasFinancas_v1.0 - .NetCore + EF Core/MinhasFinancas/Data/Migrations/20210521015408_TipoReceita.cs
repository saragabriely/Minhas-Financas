using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class TipoReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoReceitaID",
                table: "Receita",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoReceita",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReceita", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_TipoReceitaID",
                table: "Receita",
                column: "TipoReceitaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_TipoReceita_TipoReceitaID",
                table: "Receita",
                column: "TipoReceitaID",
                principalTable: "TipoReceita",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_TipoReceita_TipoReceitaID",
                table: "Receita");

            migrationBuilder.DropTable(
                name: "TipoReceita");

            migrationBuilder.DropIndex(
                name: "IX_Receita_TipoReceitaID",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "TipoReceitaID",
                table: "Receita");
        }
    }
}
