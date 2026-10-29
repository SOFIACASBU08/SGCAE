
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.Empleados.Commands;

public class DesactivarEmpleadoHandler
{
    private readonly IEmpleadoRepository _repository;

    public DesactivarEmpleadoHandler(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> EjecutarAsync(int id)
    {
        var empleado = await _repository.ObtenerPorIdAsync(id);

        if (empleado == null)
        {
            return false;
        }

        empleado.Desactivar();

        await _repository.GuardarCambiosAsync();

        return true;
    }
}
