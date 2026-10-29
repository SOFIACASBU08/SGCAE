using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGCAE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuntosAcceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntosAcceso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credenciales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credenciales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credenciales_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAcceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    PuntoAccesoId = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccesoPermitido = table.Column<bool>(type: "bit", nullable: false),
                    MotivoRechazo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosAcceso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosAcceso_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosAcceso_PuntosAcceso_PuntoAccesoId",
                        column: x => x.PuntoAccesoId,
                        principalTable: "PuntosAcceso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credenciales_Codigo",
                table: "Credenciales",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credenciales_EmpleadoId",
                table: "Credenciales",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_NumeroDocumento",
                table: "Empleados",
                column: "NumeroDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAcceso_EmpleadoId",
                table: "RegistrosAcceso",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAcceso_FechaHora",
                table: "RegistrosAcceso",
                column: "FechaHora");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAcceso_PuntoAccesoId",
                table: "RegistrosAcceso",
                column: "PuntoAccesoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credenciales");

            migrationBuilder.DropTable(
                name: "RegistrosAcceso");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "PuntosAcceso");
        }
    }
}
