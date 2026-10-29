
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Empleados.Commands;

public class RegistrarEmpleadoHandler
{
    private readonly IEmpleadoRepository _repository;

    public RegistrarEmpleadoHandler(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> EjecutarAsync(RegistrarEmpleadoCommand comando)
    {
        if (await _repository.ExisteDocumentoAsync(comando.NumeroDocumento.Trim()))
        {
            throw new InvalidOperationException(
                "Ya existe un empleado con ese número de documento.");
        }

        var empleado = new Empleado(
            comando.Nombres,
            comando.Apellidos,
            comando.NumeroDocumento,
            comando.Correo,
            comando.Cargo,
            comando.AreaOrganizacional
        );

        await _repository.AgregarAsync(empleado);
        await _repository.GuardarCambiosAsync();

        return empleado.Id;
    }
}
