using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba1._0.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVilla_Tabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 26, 11, 51, 10, 534, DateTimeKind.Local).AddTicks(1142), new DateTime(2024, 4, 26, 11, 51, 10, 534, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 26, 11, 51, 10, 534, DateTimeKind.Local).AddTicks(1198), new DateTime(2024, 4, 26, 11, 51, 10, 534, DateTimeKind.Local).AddTicks(1198) });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5487), new DateTime(2024, 4, 24, 16, 27, 39, 665, DateTimeKind.Local).AddTicks(5487) });
        }
    }
}
