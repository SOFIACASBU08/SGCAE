
namespace SGCAE.Application.Empleados.Commands;

public class RegistrarEmpleadoCommand
{
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string AreaOrganizacional { get; set; } = string.Empty;
}
