
using SGCAE.Application.DTOs;
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.Empleados.Queries;

public class ObtenerEmpleadosHandler
{
    private readonly IEmpleadoRepository _repository;

    public ObtenerEmpleadosHandler(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmpleadoDto>> EjecutarAsync()
    {
        var empleados = await _repository.ObtenerTodosAsync();

        return empleados.Select(e => new EmpleadoDto
        {
            Id = e.Id,
            Nombres = e.Nombres,
            Apellidos = e.Apellidos,
            NumeroDocumento = e.NumeroDocumento,
            Correo = e.Correo,
            Cargo = e.Cargo,
            AreaOrganizacional = e.AreaOrganizacional,
            Activo = e.Activo
        }).ToList();
    }
}
