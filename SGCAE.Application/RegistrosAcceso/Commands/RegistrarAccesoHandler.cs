
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;
using SGCAE.Domain.Enums;

namespace SGCAE.Application.RegistrosAcceso.Commands;

public class RegistrarAccesoHandler
{
    private readonly IEmpleadoRepository _empleados;
    private readonly ICredencialRepository _credenciales;
    private readonly IPuntoAccesoRepository _puntosAcceso;
    private readonly IRegistroAccesoRepository _registros;

    public RegistrarAccesoHandler(
        IEmpleadoRepository empleados,
        ICredencialRepository credenciales,
        IPuntoAccesoRepository puntosAcceso,
        IRegistroAccesoRepository registros)
    {
        _empleados = empleados;
        _credenciales = credenciales;
        _puntosAcceso = puntosAcceso;
        _registros = registros;
    }

    public async Task<int> EjecutarAsync(
        RegistrarAccesoCommand comando)
    {
        if (string.IsNullOrWhiteSpace(comando.CodigoCredencial))
        {
            throw new ArgumentException(
                "El código de la credencial es obligatorio.");
        }

        if (comando.TipoMovimiento != "Entrada" &&
            comando.TipoMovimiento != "Salida")
        {
            throw new ArgumentException(
                "El movimiento debe ser Entrada o Salida.");
        }

        var credenciales = await _credenciales.ObtenerTodasAsync();

        var credencial = credenciales.FirstOrDefault(c =>
            c.Codigo == comando.CodigoCredencial);

        string? motivoRechazo = null;
        Empleado? empleado = null;

        if (credencial == null)
        {
            motivoRechazo = "La credencial no existe.";
        }
        else
        {
            empleado = await _empleados.ObtenerPorIdAsync(
                credencial.EmpleadoId);

            if (empleado == null || !empleado.Activo)
            {
                motivoRechazo = "El empleado está inactivo o no existe.";
            }
            else if (!credencial.EstaVigente())
            {
                motivoRechazo = "La credencial no está vigente.";
            }
        }

        var punto = await _puntosAcceso.ObtenerPorIdAsync(
            comando.PuntoAccesoId);

        if (punto == null)
        {
            throw new ArgumentException(
                "El punto de acceso no existe.");
        }

        if (!punto.Activo)
        {
            motivoRechazo = "El punto de acceso está desactivado.";
        }

        

        var registro = new RegistroAcceso(
            empleado?.Id,
            punto.Id,
            comando.TipoMovimiento,
            motivoRechazo == null,
            motivoRechazo);

        await _registros.AgregarAsync(registro);
        await _registros.GuardarCambiosAsync();

        return registro.Id;
    }
}
