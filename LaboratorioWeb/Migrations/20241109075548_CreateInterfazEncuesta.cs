using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateInterfazEncuesta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntuacionMesa = table.Column<int>(type: "int", nullable: false),
                    PuntuacionRestaurante = table.Column<int>(type: "int", nullable: false),
                    PuntuacionMozo = table.Column<int>(type: "int", nullable: false),
                    PuntuacionCocinero = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(66)", maxLength: 66, nullable: false),
                    FechaEncuesta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encuesta");

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
    }
}
