using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNutricion.Migrations
{
    /// <inheritdoc />
    public partial class Dtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recomendaciones",
                table: "Consultas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recomendaciones",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
