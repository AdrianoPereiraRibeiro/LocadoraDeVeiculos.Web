using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class addPlanoCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanosCobrancas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoDeAutomoveisId = table.Column<int>(type: "int", nullable: false),
                    PrecoDiarioPlanoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoQuilometroPlanoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuilometrosDisponiveisPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiarioPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoQuilometroExtrapoladoPlanoControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiarioPlanoLivre = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosCobrancas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanosCobrancas_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                        column: x => x.GrupoDeAutomoveisId,
                        principalTable: "TBGrupoDeAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanosCobrancas_GrupoDeAutomoveisId",
                table: "PlanosCobrancas",
                column: "GrupoDeAutomoveisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanosCobrancas");
        }
    }
}
