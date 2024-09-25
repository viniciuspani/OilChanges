using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OilChanges.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filtros",
                columns: table => new
                {
                    FiltroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeDeFiltragem = table.Column<int>(type: "int", nullable: false),
                    PressaoMaximaDeOperacao = table.Column<int>(type: "int", nullable: false),
                    Compatibilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filtros", x => x.FiltroId);
                });

            migrationBuilder.CreateTable(
                name: "Oleos",
                columns: table => new
                {
                    OleoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoOleo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oleos", x => x.OleoId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Renavam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "TrocaOleos",
                columns: table => new
                {
                    TrocaOleoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    OleoId = table.Column<int>(type: "int", nullable: false),
                    FiltroId = table.Column<int>(type: "int", nullable: false),
                    KmAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmProximaTroca = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeOleo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataProximaTroca = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrocaOleos", x => x.TrocaOleoId);
                    table.ForeignKey(
                        name: "FK_TrocaOleos_Filtros_FiltroId",
                        column: x => x.FiltroId,
                        principalTable: "Filtros",
                        principalColumn: "FiltroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrocaOleos_Oleos_OleoId",
                        column: x => x.OleoId,
                        principalTable: "Oleos",
                        principalColumn: "OleoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrocaOleos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrocaOleos_FiltroId",
                table: "TrocaOleos",
                column: "FiltroId");

            migrationBuilder.CreateIndex(
                name: "IX_TrocaOleos_OleoId",
                table: "TrocaOleos",
                column: "OleoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrocaOleos_VeiculoId",
                table: "TrocaOleos",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrocaOleos");

            migrationBuilder.DropTable(
                name: "Filtros");

            migrationBuilder.DropTable(
                name: "Oleos");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
