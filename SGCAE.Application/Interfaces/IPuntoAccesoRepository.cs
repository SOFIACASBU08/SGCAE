
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Interfaces;

public interface IPuntoAccesoRepository
{
    Task<List<PuntoAcceso>> ObtenerTodosAsync();

    Task<PuntoAcceso?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(PuntoAcceso puntoAcceso);

    Task GuardarCambiosAsync();
}
