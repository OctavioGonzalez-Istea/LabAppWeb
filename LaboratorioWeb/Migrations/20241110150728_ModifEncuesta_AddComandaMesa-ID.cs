using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class ModifEncuesta_AddComandaMesaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Encuesta",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(66)",
                oldMaxLength: 66);

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Encuesta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Encuesta",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 11, 10, 12, 7, 27, 756, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 7, 27, 756, DateTimeKind.Local).AddTicks(118), new DateTime(2024, 11, 10, 12, 37, 27, 756, DateTimeKind.Local).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 10, 12, 7, 27, 756, DateTimeKind.Local).AddTicks(125), new DateTime(2024, 11, 10, 12, 27, 27, 756, DateTimeKind.Local).AddTicks(126) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Encuesta");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Encuesta");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Encuesta",
                type: "nvarchar(66)",
                maxLength: 66,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 11, 9, 4, 55, 48, 313, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 9, 4, 55, 48, 313, DateTimeKind.Local).AddTicks(9203), new DateTime(2024, 11, 9, 5, 25, 48, 313, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 9, 4, 55, 48, 313, DateTimeKind.Local).AddTicks(9210), new DateTime(2024, 11, 9, 5, 15, 48, 313, DateTimeKind.Local).AddTicks(9210) });
        }
    }
}
