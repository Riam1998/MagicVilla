using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prueba1._0.Migrations
{
    /// <inheritdoc />
    public partial class AlimentandoTablaPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5470), "", 50.0, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la Villa...", new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5487), new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5487), "", 40.0, "Premium Vista a la Piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
