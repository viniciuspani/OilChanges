using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OilChanges.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoModelVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoVeiculo",
                table: "Veiculos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoVeiculo",
                table: "Veiculos");
        }
    }
}
