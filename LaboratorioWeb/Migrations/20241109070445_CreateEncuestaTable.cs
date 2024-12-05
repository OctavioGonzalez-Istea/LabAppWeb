using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateEncuestaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 11, 9, 4, 4, 45, 417, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 9, 4, 4, 45, 417, DateTimeKind.Local).AddTicks(9829), new DateTime(2024, 11, 9, 4, 34, 45, 417, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 9, 4, 4, 45, 417, DateTimeKind.Local).AddTicks(9835), new DateTime(2024, 11, 9, 4, 24, 45, 417, DateTimeKind.Local).AddTicks(9836) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 11, 2, 18, 35, 46, 963, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 2, 18, 35, 46, 963, DateTimeKind.Local).AddTicks(1120), new DateTime(2024, 11, 2, 19, 5, 46, 963, DateTimeKind.Local).AddTicks(1121) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 2, 18, 35, 46, 963, DateTimeKind.Local).AddTicks(1125), new DateTime(2024, 11, 2, 18, 55, 46, 963, DateTimeKind.Local).AddTicks(1126) });
        }
    }
}
