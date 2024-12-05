using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comandas_Empleados_EmpleadoId",
            //    table: "Comandas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Roles_RolId",
                table: "Empleados");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Empleados_Roles_RolId1",
            //    table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Empleados_Sectores_SectorId1",
            //    table: "Empleados");

            //migrationBuilder.DropIndex(
            //    name: "IX_Empleados_RolId1",
            //    table: "Empleados");

            //migrationBuilder.DropIndex(
            //    name: "IX_Empleados_SectorId1",
            //    table: "Empleados");

            //migrationBuilder.DropIndex(
            //    name: "IX_Comandas_EmpleadoId",
            //    table: "Comandas");

            //migrationBuilder.DropColumn(
            //    name: "RolId1",
            //    table: "Empleados");

            //migrationBuilder.DropColumn(
            //    name: "SectorId1",
            //    table: "Empleados");

            //migrationBuilder.DropColumn(
            //    name: "EmpleadoId",
            //    table: "Comandas");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Roles_RolId",
                table: "Empleados",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Roles_RolId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados");

            //migrationBuilder.AddColumn<int>(
            //    name: "RolId1",
            //    table: "Empleados",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "SectorId1",
            //    table: "Empleados",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "EmpleadoId",
            //    table: "Comandas",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.UpdateData(
            //    table: "Comandas",
            //    keyColumn: "ComandaId",
            //    keyValue: 1,
            //    column: "EmpleadoId",
            //    value: 5);

            //migrationBuilder.UpdateData(
            //    table: "Comandas",
            //    keyColumn: "ComandaId",
            //    keyValue: 2,
            //    column: "EmpleadoId",
            //    value: 5);

            //migrationBuilder.UpdateData(
            //    table: "Comandas",
            //    keyColumn: "ComandaId",
            //    keyValue: 3,
            //    column: "EmpleadoId",
            //    value: 5);

            //migrationBuilder.UpdateData(
            //    table: "Empleados",
            //    keyColumn: "EmpleadoId",
            //    keyValue: 1,
            //    columns: new[] { "RolId1", "SectorId1" },
            //    values: new object[] { null, null });

            //migrationBuilder.UpdateData(
            //    table: "Empleados",
            //    keyColumn: "EmpleadoId",
            //    keyValue: 2,
            //    columns: new[] { "RolId1", "SectorId1" },
            //    values: new object[] { null, null });

            //migrationBuilder.UpdateData(
            //    table: "Empleados",
            //    keyColumn: "EmpleadoId",
            //    keyValue: 3,
            //    columns: new[] { "RolId1", "SectorId1" },
            //    values: new object[] { null, null });

            //migrationBuilder.UpdateData(
            //    table: "Empleados",
            //    keyColumn: "EmpleadoId",
            //    keyValue: 4,
            //    columns: new[] { "RolId1", "SectorId1" },
            //    values: new object[] { null, null });

            //migrationBuilder.UpdateData(
            //    table: "Empleados",
            //    keyColumn: "EmpleadoId",
            //    keyValue: 5,
            //    columns: new[] { "RolId1", "SectorId1" },
            //    values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 11, 1, 15, 45, 12, 571, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 1, 15, 45, 12, 571, DateTimeKind.Local).AddTicks(4972), new DateTime(2024, 11, 1, 16, 15, 12, 571, DateTimeKind.Local).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaFinalizacion" },
                values: new object[] { new DateTime(2024, 11, 1, 15, 45, 12, 571, DateTimeKind.Local).AddTicks(4977), new DateTime(2024, 11, 1, 16, 5, 12, 571, DateTimeKind.Local).AddTicks(4977) });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Empleados_RolId1",
            //    table: "Empleados",
            //    column: "RolId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Empleados_SectorId1",
            //    table: "Empleados",
            //    column: "SectorId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comandas_EmpleadoId",
            //    table: "Comandas",
            //    column: "EmpleadoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comandas_Empleados_EmpleadoId",
            //    table: "Comandas",
            //    column: "EmpleadoId",
            //    principalTable: "Empleados",
            //    principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Roles_RolId",
                table: "Empleados",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Empleados_Roles_RolId1",
            //    table: "Empleados",
            //    column: "RolId1",
            //    principalTable: "Roles",
            //    principalColumn: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Empleados_Sectores_SectorId1",
            //    table: "Empleados",
            //    column: "SectorId1",
            //    principalTable: "Sectores",
            //    principalColumn: "SectorId");
        }
    }
}
