using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNutricion.Migrations
{
    /// <inheritdoc />
    public partial class EndPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Almuerzo",
                table: "PlanesNutricionales");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "PlanesNutricionales");

            migrationBuilder.DropColumn(
                name: "Desayuno",
                table: "PlanesNutricionales");

            migrationBuilder.DropColumn(
                name: "Meriendas",
                table: "PlanesNutricionales");

            migrationBuilder.CreateTable(
                name: "DiasPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaSemana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Desayuno = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Almuerzo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Cena = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Meriendas = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdPlanNutricional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiasPlan_PlanesNutricionales_IdPlanNutricional",
                        column: x => x.IdPlanNutricional,
                        principalTable: "PlanesNutricionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiasPlan_IdPlanNutricional",
                table: "DiasPlan",
                column: "IdPlanNutricional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiasPlan");

            migrationBuilder.AddColumn<string>(
                name: "Almuerzo",
                table: "PlanesNutricionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cena",
                table: "PlanesNutricionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desayuno",
                table: "PlanesNutricionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meriendas",
                table: "PlanesNutricionales",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
