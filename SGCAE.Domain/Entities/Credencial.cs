

using SGCAE.Domain.Enums;

namespace SGCAE.Domain.Entities;

public class Credencial
{
    public int Id { get; private set; }

    public int EmpleadoId { get; private set; }

    public string Codigo { get; private set; } = string.Empty;

    public DateTime FechaEmision { get; private set; }

    public DateTime? FechaVencimiento { get; private set; }

    public EstadoCredencial Estado { get; private set; }
        = EstadoCredencial.Vigente;

    public Empleado Empleado { get; private set; } = null!;

    private Credencial() { }

    public Credencial(
        int empleadoId,
        string codigo,
        DateTime fechaEmision,
        DateTime? fechaVencimiento = null)
    {
        if (empleadoId <= 0)
            throw new ArgumentException("El empleado es obligatorio.");

        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código de la credencial es obligatorio.");

        if (fechaVencimiento.HasValue &&
            fechaVencimiento.Value < fechaEmision)
        {
            throw new ArgumentException(
                "La fecha de vencimiento no puede ser anterior a la emisión.");
        }

        EmpleadoId = empleadoId;
        Codigo = codigo.Trim();
        FechaEmision = fechaEmision;
        FechaVencimiento = fechaVencimiento;
        Estado = EstadoCredencial.Vigente;
    }

    public void Bloquear()
    {
        if (Estado == EstadoCredencial.Revocada)
            throw new InvalidOperationException(
                "No se puede bloquear una credencial revocada.");

        Estado = EstadoCredencial.Bloqueada;
    }

    public void Revocar()
    {
        Estado = EstadoCredencial.Revocada;
    }

    public void Reactivar()
    {
        if (Estado == EstadoCredencial.Revocada)
            throw new InvalidOperationException(
                "No se puede reactivar una credencial revocada.");

        Estado = EstadoCredencial.Vigente;
    }

    public bool EstaVigente()
    {
        return Estado == EstadoCredencial.Vigente
            && (!FechaVencimiento.HasValue
                || FechaVencimiento.Value.Date >= DateTime.Today);
    }
}
