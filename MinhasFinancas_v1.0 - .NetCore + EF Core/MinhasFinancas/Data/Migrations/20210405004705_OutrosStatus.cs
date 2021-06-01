using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhasFinancas.Data.Migrations
{
    public partial class OutrosStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusDespesa",
                columns: table => new
                {
                    StatusDespesa_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDespesa", x => x.StatusDespesa_ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusInvestimento",
                columns: table => new
                {
                    StatusInvestimento_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInvestimento", x => x.StatusInvestimento_ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusMeta",
                columns: table => new
                {
                    StatusMeta_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMeta", x => x.StatusMeta_ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoInvestimento",
                columns: table => new
                {
                    TipoInvestimento_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInvestimento", x => x.TipoInvestimento_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusDespesa");

            migrationBuilder.DropTable(
                name: "StatusInvestimento");

            migrationBuilder.DropTable(
                name: "StatusMeta");

            migrationBuilder.DropTable(
                name: "TipoInvestimento");
        }
    }
}
