using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba1._0.Migrations
{
    /// <inheritdoc />
    public partial class ControlarNullables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9125), new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9124) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 30, 13, 50, 8, 22, DateTimeKind.Local).AddTicks(3513), new DateTime(2024, 4, 30, 13, 50, 8, 22, DateTimeKind.Local).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 4, 30, 13, 50, 8, 22, DateTimeKind.Local).AddTicks(3516), new DateTime(2024, 4, 30, 13, 50, 8, 22, DateTimeKind.Local).AddTicks(3515) });
        }
    }
}
