using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGCAE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermitirAccesoSinEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "RegistrosAcceso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "RegistrosAcceso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
