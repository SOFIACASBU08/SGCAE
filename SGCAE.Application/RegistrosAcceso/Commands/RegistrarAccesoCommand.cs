
namespace SGCAE.Application.RegistrosAcceso.Commands;

public class RegistrarAccesoCommand
{
    public string CodigoCredencial { get; set; } = string.Empty;

    public int PuntoAccesoId { get; set; }

    public string TipoMovimiento { get; set; } = string.Empty;
}
