using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.Infrastructure.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    costoPromedio = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    stock = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleTransaccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransaccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    costoUnitario = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTransaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleTransaccion_Articulo_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleTransaccion_Transaccion_TransaccionId",
                        column: x => x.TransaccionId,
                        principalTable: "Transaccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTransaccion_ArticuloId",
                table: "DetalleTransaccion",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTransaccion_TransaccionId",
                table: "DetalleTransaccion",
                column: "TransaccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleTransaccion");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Transaccion");
        }
    }
}
