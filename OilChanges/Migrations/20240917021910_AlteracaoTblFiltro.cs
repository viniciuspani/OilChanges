using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OilChanges.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTblFiltro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensoes",
                table: "Filtros");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Filtros",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Compatibilidade",
                table: "Filtros",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Filtros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Compatibilidade",
                table: "Filtros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimensoes",
                table: "Filtros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
