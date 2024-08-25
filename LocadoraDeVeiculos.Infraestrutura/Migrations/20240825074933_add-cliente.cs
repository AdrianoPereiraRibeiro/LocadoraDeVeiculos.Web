using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class addcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculo_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                table: "TBVeiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBVeiculo",
                table: "TBVeiculo");

            migrationBuilder.RenameTable(
                name: "TBVeiculo",
                newName: "Veiculos");

            migrationBuilder.RenameIndex(
                name: "IX_TBVeiculo_GrupoDeAutomoveisId",
                table: "Veiculos",
                newName: "IX_Veiculos_GrupoDeAutomoveisId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoPessoa = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(100)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                table: "Veiculos",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "TBVeiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_GrupoDeAutomoveisId",
                table: "TBVeiculo",
                newName: "IX_TBVeiculo_GrupoDeAutomoveisId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "TBVeiculo",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "TBVeiculo",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBVeiculo",
                table: "TBVeiculo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculo_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                table: "TBVeiculo",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
