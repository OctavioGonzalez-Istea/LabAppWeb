using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMesaNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 1,
                column: "Nombre",
                value: "M0001");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 2,
                column: "Nombre",
                value: "M0002");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 3,
                column: "Nombre",
                value: "M0003");

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 31, 9, 7, 16, 892, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 10, 31, 9, 7, 16, 892, DateTimeKind.Local).AddTicks(5023), new DateTime(2024, 10, 31, 9, 37, 16, 892, DateTimeKind.Local).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 10, 31, 9, 7, 16, 892, DateTimeKind.Local).AddTicks(5032), new DateTime(2024, 10, 31, 9, 27, 16, 892, DateTimeKind.Local).AddTicks(5032) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 1,
                column: "Nombre",
                value: "Cliente 1");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 2,
                column: "Nombre",
                value: "Cliente 2");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "MesaId",
                keyValue: 3,
                column: "Nombre",
                value: "Cliente 3");

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7684), new DateTime(2024, 9, 28, 16, 1, 57, 22, DateTimeKind.Local).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7691), new DateTime(2024, 9, 28, 15, 51, 57, 22, DateTimeKind.Local).AddTicks(7691) });
        }
    }
}
