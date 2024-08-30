using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class addgrupodeautomoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

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
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCliente_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoDeAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoDeAutomoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBGrupoDeAutomoveis_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBPrecosCombustiveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPrecosCombustiveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPrecosCombustiveis_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBTaxasEServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    FixoOuDiario = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxasEServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTaxasEServicos_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteEqualsCondutor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(200)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(200)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(200)", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBCondutor_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

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
                    PrecoDiarioPlanoLivre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_PlanosCobrancas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: false),
                    GrupoDeAutomoveisId = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoDeAutomoveis_GrupoDeAutomoveisId",
                        column: x => x.GrupoDeAutomoveisId,
                        principalTable: "TBGrupoDeAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_Id = table.Column<int>(type: "int", nullable: false),
                    GrupoDeAutomoveis_Id = table.Column<int>(type: "int", nullable: false),
                    Veiculo_Id = table.Column<int>(type: "int", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataRetorno = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValorEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Plano_Id = table.Column<int>(type: "int", nullable: false),
                    AluguelAtivo = table.Column<bool>(type: "bit", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_PlanosCobrancas_Plano_Id",
                        column: x => x.Plano_Id,
                        principalTable: "PlanosCobrancas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBGrupoDeAutomoveis_GrupoDeAutomoveis_Id",
                        column: x => x.GrupoDeAutomoveis_Id,
                        principalTable: "TBGrupoDeAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBVeiculo_Veiculo_Id",
                        column: x => x.Veiculo_Id,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AluguelTaxaEServico",
                columns: table => new
                {
                    AluguelId = table.Column<int>(type: "int", nullable: false),
                    TaxasEServicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AluguelTaxaEServico", x => new { x.AluguelId, x.TaxasEServicosId });
                    table.ForeignKey(
                        name: "FK_AluguelTaxaEServico_TBAluguel_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "TBAluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AluguelTaxaEServico_TBTaxasEServicos_TaxasEServicosId",
                        column: x => x.TaxasEServicosId,
                        principalTable: "TBTaxasEServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AluguelTaxaEServico_TaxasEServicosId",
                table: "AluguelTaxaEServico",
                column: "TaxasEServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosCobrancas_GrupoDeAutomoveisId",
                table: "PlanosCobrancas",
                column: "GrupoDeAutomoveisId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosCobrancas_UsuarioId",
                table: "PlanosCobrancas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_Cliente_Id",
                table: "TBAluguel",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_GrupoDeAutomoveis_Id",
                table: "TBAluguel",
                column: "GrupoDeAutomoveis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_Plano_Id",
                table: "TBAluguel",
                column: "Plano_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_Usuario_Id",
                table: "TBAluguel",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_Veiculo_Id",
                table: "TBAluguel",
                column: "Veiculo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_Usuario_Id",
                table: "TBCliente",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_Usuario_Id",
                table: "TBCondutor",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBGrupoDeAutomoveis_Usuario_Id",
                table: "TBGrupoDeAutomoveis",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBPrecosCombustiveis_Usuario_Id",
                table: "TBPrecosCombustiveis",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxasEServicos_Usuario_Id",
                table: "TBTaxasEServicos",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoDeAutomoveisId",
                table: "TBVeiculo",
                column: "GrupoDeAutomoveisId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_Usuario_Id",
                table: "TBVeiculo",
                column: "Usuario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AluguelTaxaEServico");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBPrecosCombustiveis");

            migrationBuilder.DropTable(
                name: "TBAluguel");

            migrationBuilder.DropTable(
                name: "TBTaxasEServicos");

            migrationBuilder.DropTable(
                name: "PlanosCobrancas");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBVeiculo");

            migrationBuilder.DropTable(
                name: "TBGrupoDeAutomoveis");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
