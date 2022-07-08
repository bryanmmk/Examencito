using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Administracion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Administracion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Categoria",
                columns: table => new
                {
                    ID_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Categoria", x => x.ID_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "tb_Proveedor",
                columns: table => new
                {
                    ID_Proveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo_Proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Proveedor", x => x.ID_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuario",
                columns: table => new
                {
                    ID_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuario", x => x.ID_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_Medicamentos",
                columns: table => new
                {
                    ID_Medicamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaID_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProveedorID_Proveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Medicamentos", x => x.ID_Medicamento);
                    table.ForeignKey(
                        name: "FK_tb_Medicamentos_tb_Categoria_CategoriaID_Categoria",
                        column: x => x.CategoriaID_Categoria,
                        principalTable: "tb_Categoria",
                        principalColumn: "ID_Categoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Medicamentos_tb_Proveedor_ProveedorID_Proveedor",
                        column: x => x.ProveedorID_Proveedor,
                        principalTable: "tb_Proveedor",
                        principalColumn: "ID_Proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Pedido",
                columns: table => new
                {
                    ID_Pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Medicamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    UsuariosID_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Pedido", x => x.ID_Pedido);
                    table.ForeignKey(
                        name: "FK_tb_Pedido_tb_Medicamentos_ID_Medicamento",
                        column: x => x.ID_Medicamento,
                        principalTable: "tb_Medicamentos",
                        principalColumn: "ID_Medicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Pedido_tb_Usuario_UsuariosID_Usuario",
                        column: x => x.UsuariosID_Usuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_DetallePedido",
                columns: table => new
                {
                    ID_DetallePedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    ID_Pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_DetallePedido", x => x.ID_DetallePedido);
                    table.ForeignKey(
                        name: "FK_tb_DetallePedido_tb_Pedido_ID_Pedido",
                        column: x => x.ID_Pedido,
                        principalTable: "tb_Pedido",
                        principalColumn: "ID_Pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_DetallePedido_ID_Pedido",
                table: "tb_DetallePedido",
                column: "ID_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Medicamentos_CategoriaID_Categoria",
                table: "tb_Medicamentos",
                column: "CategoriaID_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Medicamentos_ProveedorID_Proveedor",
                table: "tb_Medicamentos",
                column: "ProveedorID_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pedido_ID_Medicamento",
                table: "tb_Pedido",
                column: "ID_Medicamento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pedido_UsuariosID_Usuario",
                table: "tb_Pedido",
                column: "UsuariosID_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Administracion");

            migrationBuilder.DropTable(
                name: "tb_DetallePedido");

            migrationBuilder.DropTable(
                name: "tb_Pedido");

            migrationBuilder.DropTable(
                name: "tb_Medicamentos");

            migrationBuilder.DropTable(
                name: "tb_Usuario");

            migrationBuilder.DropTable(
                name: "tb_Categoria");

            migrationBuilder.DropTable(
                name: "tb_Proveedor");
        }
    }
}
