using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGCAE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompletarEmpleadoYEstadoCredencial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "Credenciales");

            migrationBuilder.AddColumn<string>(
                name: "AreaOrganizacional",
                table: "Empleados",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Empleados",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Credenciales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaOrganizacional",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Credenciales");

            migrationBuilder.AddColumn<bool>(
                name: "Activa",
                table: "Credenciales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
