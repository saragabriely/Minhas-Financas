using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class TipoPessoaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoa_TipoPessoa_ID",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "TipoPessoa_ID",
                table: "TipoPessoa",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TipoPessoa_ID",
                table: "Pessoa",
                newName: "tipoPessoa_IDID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_TipoPessoa_ID",
                table: "Pessoa",
                newName: "IX_Pessoa_tipoPessoa_IDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoa_tipoPessoa_IDID",
                table: "Pessoa",
                column: "tipoPessoa_IDID",
                principalTable: "TipoPessoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoa_tipoPessoa_IDID",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TipoPessoa",
                newName: "TipoPessoa_ID");

            migrationBuilder.RenameColumn(
                name: "tipoPessoa_IDID",
                table: "Pessoa",
                newName: "TipoPessoa_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_tipoPessoa_IDID",
                table: "Pessoa",
                newName: "IX_Pessoa_TipoPessoa_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoa_TipoPessoa_ID",
                table: "Pessoa",
                column: "TipoPessoa_ID",
                principalTable: "TipoPessoa",
                principalColumn: "TipoPessoa_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
