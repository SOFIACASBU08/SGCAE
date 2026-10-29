
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.Empleados.Commands;

public class ActualizarEmpleadoHandler
{
    private readonly IEmpleadoRepository _repository;

    public ActualizarEmpleadoHandler(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> EjecutarAsync(
        int id,
        ActualizarEmpleadoCommand comando)
    {
        var empleado = await _repository.ObtenerPorIdAsync(id);

        if (empleado == null)
        {
            return false;
        }

        empleado.ActualizarInformacion(
            comando.Nombres,
            comando.Apellidos,
            comando.Correo,
            comando.Cargo,
            comando.AreaOrganizacional
        );

        await _repository.GuardarCambiosAsync();

        return true;
    }
}
