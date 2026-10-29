
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Credenciales.Commands;

public class RegistrarCredencialHandler
{
    private readonly ICredencialRepository _credencialRepository;
    private readonly IEmpleadoRepository _empleadoRepository;

    public RegistrarCredencialHandler(
        ICredencialRepository credencialRepository,
        IEmpleadoRepository empleadoRepository)
    {
        _credencialRepository = credencialRepository;
        _empleadoRepository = empleadoRepository;
    }

    public async Task<int> EjecutarAsync(
        RegistrarCredencialCommand comando)
    {
        if (await _credencialRepository.ExisteCodigoAsync(
            comando.Codigo.Trim()))
        {
            throw new InvalidOperationException(
                "Ya existe una credencial con ese código.");
        }

        var empleado = await _empleadoRepository.ObtenerPorIdAsync(
            comando.EmpleadoId);

        if (empleado == null)
        {
            throw new ArgumentException(
                "No existe un empleado con ese ID.");
        }

        if (!empleado.Activo)
        {
            throw new InvalidOperationException(
                "No se puede asignar una credencial a un empleado inactivo.");
        }

        var credencial = new Credencial(
            comando.EmpleadoId,
            comando.Codigo,
            DateTime.Now,
            comando.FechaVencimiento);

        await _credencialRepository.AgregarAsync(credencial);
        await _credencialRepository.GuardarCambiosAsync();

        return credencial.Id;
    }
}
