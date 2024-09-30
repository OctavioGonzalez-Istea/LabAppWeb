using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaboratorioWeb.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosMesas",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosMesas", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPedidos",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPedidos", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.MesaId);
                    table.ForeignKey(
                        name: "FK_Mesas_EstadosMesas_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosMesas",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Sectores_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_EstadosPedidos_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosPedidos",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosMesas",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Esperando pedido" },
                    { 2, "Comiendo" },
                    { 3, "Pagando" },
                    { 4, "Cerrada" }
                });

            migrationBuilder.InsertData(
                table: "EstadosPedidos",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pedido recibido" },
                    { 2, "Preparando" },
                    { 3, "Listo para servir" },
                    { 4, "Entregado" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Mozo" },
                    { 2, "Cocinero" },
                    { 3, "Cervecero" },
                    { 4, "Bartender" },
                    { 5, "Socio" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "SectorId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Barra de tragos y vinos" },
                    { 2, "Barra de cerveza artesanal" },
                    { 3, "Cocina" },
                    { 4, "Candy Bar" },
                    { 5, "Caja" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Nombre", "Password", "RolId", "SectorId", "Usuario" },
                values: new object[,]
                {
                    { 1, "Carlos Pérez", "password123", 4, 1, "cperez" },
                    { 2, "Ana Gómez", "password456", 2, 3, "agomez" },
                    { 3, "Pedro Ruiz", "password789", 3, 2, "pruiz" },
                    { 4, "Juan López", "password000", 5, 5, "jlopez" },
                    { 5, "Omar Sanchez", "password012", 1, 4, "osanchez" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "MesaId", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Cliente 1" },
                    { 2, 2, "Cliente 2" },
                    { 3, 3, "Cliente 3" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "Precio", "SectorId", "Stock" },
                values: new object[,]
                {
                    { 1, "Vino Tinto", 1500, 1, 50 },
                    { 2, "Cerveza IPA", 300, 2, 100 },
                    { 3, "Empanadas", 150, 3, 200 },
                    { 4, "Tarta de Chocolate", 600, 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "Comandas",
                columns: new[] { "ComandaId", "MesaId", "NombreCliente" },
                values: new object[,]
                {
                    { 1, 1, "Cliente 1" },
                    { 2, 2, "Cliente 2" },
                    { 3, 3, "Cliente 3" }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "Cantidad", "ComandaId", "EstadoId", "FechaCreacion", "FechaFinalizacion", "ProductoId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7665), null, 1 },
                    { 2, 2, 2, 2, new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7684), new DateTime(2024, 9, 28, 16, 1, 57, 22, DateTimeKind.Local).AddTicks(7685), 1 },
                    { 3, 2, 3, 3, new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7691), new DateTime(2024, 9, 28, 15, 51, 57, 22, DateTimeKind.Local).AddTicks(7691), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolId",
                table: "Empleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SectorId",
                table: "Empleados",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EstadoId",
                table: "Mesas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId",
                table: "Pedidos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadoId",
                table: "Pedidos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SectorId",
                table: "Productos",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "EstadosPedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "EstadosMesas");
        }
    }
}
