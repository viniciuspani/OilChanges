using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OilChanges.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTblFiltroNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacidadeDeFiltragem",
                table: "Filtros");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Filtros");

            migrationBuilder.DropColumn(
                name: "PressaoMaximaDeOperacao",
                table: "Filtros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapacidadeDeFiltragem",
                table: "Filtros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Filtros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PressaoMaximaDeOperacao",
                table: "Filtros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
