using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNutricion.Migrations
{
    /// <inheritdoc />
    public partial class Nutricion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "PlanesNutricionales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PlanesNutricionales");
        }
    }
}
