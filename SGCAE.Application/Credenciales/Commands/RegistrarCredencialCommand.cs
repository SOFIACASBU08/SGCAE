
namespace SGCAE.Application.Credenciales.Commands;

public class RegistrarCredencialCommand
{
    public int EmpleadoId { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public DateTime FechaVencimiento { get; set; }
}
