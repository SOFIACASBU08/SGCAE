

namespace SGCAE.Domain.Entities;

public class RegistroAcceso
{
    public int Id { get; private set; }

    public int? EmpleadoId { get; private set; }

    public int PuntoAccesoId { get; private set; }

    public DateTime FechaHora { get; private set; }

    public string TipoMovimiento { get; private set; } = string.Empty;

    public bool AccesoPermitido { get; private set; }

    public string? MotivoRechazo { get; private set; }

    public Empleado? Empleado { get; private set; }

    public PuntoAcceso PuntoAcceso { get; private set; } = null!;

    private RegistroAcceso() { }

    public RegistroAcceso(
        int? empleadoId,
        int puntoAccesoId,
        string tipoMovimiento,
        bool accesoPermitido,
        string? motivoRechazo = null)
    {
        if (empleadoId.HasValue && empleadoId.Value <= 0)
            throw new ArgumentException("El empleado no es válido.");

        if (puntoAccesoId <= 0)
            throw new ArgumentException("El punto de acceso es obligatorio.");

        if (tipoMovimiento != "Entrada" &&
            tipoMovimiento != "Salida")
        {
            throw new ArgumentException(
                "El movimiento debe ser Entrada o Salida.");
        }

        if (!accesoPermitido &&
            string.IsNullOrWhiteSpace(motivoRechazo))
        {
            throw new ArgumentException(
                "Debe indicarse el motivo cuando se rechaza el acceso.");
        }

        if (accesoPermitido && !empleadoId.HasValue)
        {
            throw new ArgumentException(
                "No se puede permitir el acceso sin identificar al empleado.");
        }

        EmpleadoId = empleadoId;
        PuntoAccesoId = puntoAccesoId;
        FechaHora = DateTime.Now;
        TipoMovimiento = tipoMovimiento;
        AccesoPermitido = accesoPermitido;
        MotivoRechazo = accesoPermitido ? null : motivoRechazo?.Trim();
    }
}
