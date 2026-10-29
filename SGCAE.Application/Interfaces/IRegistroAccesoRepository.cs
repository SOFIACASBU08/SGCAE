
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Interfaces;

public interface IRegistroAccesoRepository
{
    Task<List<RegistroAcceso>> ObtenerTodosAsync();

    Task<RegistroAcceso?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(RegistroAcceso registro);

    Task GuardarCambiosAsync();

    Task<List<RegistroAcceso>> FiltrarAsync(
    int? empleadoId,
    DateTime? fechaInicio,
    DateTime? fechaFin,
    int? puntoAccesoId,
    bool? accesoPermitido,
    int pagina,
    int tamanioPagina);
}

