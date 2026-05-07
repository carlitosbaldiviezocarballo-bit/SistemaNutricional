using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNutricion.Migrations
{
    /// <inheritdoc />
    public partial class Diagnostico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanesNutricionales_Consultas_IdConsulta",
                table: "PlanesNutricionales");

            migrationBuilder.DropTable(
                name: "Recordatorios");

            migrationBuilder.RenameColumn(
                name: "IdConsulta",
                table: "PlanesNutricionales",
                newName: "IdDiagnostico");

            migrationBuilder.RenameIndex(
                name: "IX_PlanesNutricionales_IdConsulta",
                table: "PlanesNutricionales",
                newName: "IX_PlanesNutricionales_IdDiagnostico");

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recomendacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Consultas_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_IdConsulta",
                table: "Diagnosticos",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanesNutricionales_Diagnosticos_IdDiagnostico",
                table: "PlanesNutricionales",
                column: "IdDiagnostico",
                principalTable: "Diagnosticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanesNutricionales_Diagnosticos_IdDiagnostico",
                table: "PlanesNutricionales");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.RenameColumn(
                name: "IdDiagnostico",
                table: "PlanesNutricionales",
                newName: "IdConsulta");

            migrationBuilder.RenameIndex(
                name: "IX_PlanesNutricionales_IdDiagnostico",
                table: "PlanesNutricionales",
                newName: "IX_PlanesNutricionales_IdConsulta");

            migrationBuilder.CreateTable(
                name: "Recordatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Completado = table.Column<bool>(type: "bit", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recordatorios_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorios_IdPaciente",
                table: "Recordatorios",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanesNutricionales_Consultas_IdConsulta",
                table: "PlanesNutricionales",
                column: "IdConsulta",
                principalTable: "Consultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
