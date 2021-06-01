using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class Pessoa_TipoPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoa_tipoPessoa_IDID",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "tipoPessoa_IDID",
                table: "Pessoa",
                newName: "TipoPessoaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_tipoPessoa_IDID",
                table: "Pessoa",
                newName: "IX_Pessoa_TipoPessoaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoa_TipoPessoaID",
                table: "Pessoa",
                column: "TipoPessoaID",
                principalTable: "TipoPessoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoa_TipoPessoaID",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "TipoPessoaID",
                table: "Pessoa",
                newName: "tipoPessoa_IDID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_TipoPessoaID",
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
    }
}
