
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Interfaces;

public interface IEmpleadoRepository
{
    Task<List<Empleado>> ObtenerTodosAsync();

    Task<Empleado?> ObtenerPorIdAsync(int id);

    Task<bool> ExisteDocumentoAsync(string numeroDocumento);

    Task AgregarAsync(Empleado empleado);

    Task GuardarCambiosAsync();
}

