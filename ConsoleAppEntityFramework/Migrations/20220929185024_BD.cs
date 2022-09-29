using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEntityFramework.Migrations
{
    public partial class BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClientes",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClientes", x => x.Rut);
                });

            migrationBuilder.CreateTable(
                name: "tblProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<int>(type: "int", nullable: false),
                    ClienteRut = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVentas_tblClientes_ClienteRut",
                        column: x => x.ClienteRut,
                        principalTable: "tblClientes",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDetallesVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDetallesVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDetallesVentas_tblProductos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "tblProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDetallesVentas_tblVentas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "tblVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesVentas_ProductoId",
                table: "tblDetallesVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesVentas_VentaId",
                table: "tblDetallesVentas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVentas_ClienteRut",
                table: "tblVentas",
                column: "ClienteRut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDetallesVentas");

            migrationBuilder.DropTable(
                name: "tblProductos");

            migrationBuilder.DropTable(
                name: "tblVentas");

            migrationBuilder.DropTable(
                name: "tblClientes");
        }
    }
}
