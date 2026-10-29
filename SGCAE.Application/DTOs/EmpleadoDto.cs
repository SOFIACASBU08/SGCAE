
namespace SGCAE.Application.DTOs;

public class EmpleadoDto
{
    public int Id { get; set; }

    public string Nombres { get; set; } = string.Empty;

    public string Apellidos { get; set; } = string.Empty;

    public string NumeroDocumento { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string Cargo { get; set; } = string.Empty;

    public string AreaOrganizacional { get; set; } = string.Empty;

    public bool Activo { get; set; }
}
