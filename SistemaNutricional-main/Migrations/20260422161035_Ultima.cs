using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNutricion.Migrations
{
    /// <inheritdoc />
    public partial class Ultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "Consultas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
