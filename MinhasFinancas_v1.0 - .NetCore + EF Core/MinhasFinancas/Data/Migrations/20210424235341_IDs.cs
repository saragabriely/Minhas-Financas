using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class IDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoInvestimento_ID",
                table: "TipoInvestimento",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StatusReceita_ID",
                table: "StatusReceita",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StatusMeta_ID",
                table: "StatusMeta",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StatusInvestimento_ID",
                table: "StatusInvestimento",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StatusDespesa_ID",
                table: "StatusDespesa",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TipoInvestimento",
                newName: "TipoInvestimento_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StatusReceita",
                newName: "StatusReceita_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StatusMeta",
                newName: "StatusMeta_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StatusInvestimento",
                newName: "StatusInvestimento_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StatusDespesa",
                newName: "StatusDespesa_ID");
        }
    }
}
