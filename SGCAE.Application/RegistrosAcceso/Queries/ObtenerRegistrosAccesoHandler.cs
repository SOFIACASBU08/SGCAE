
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.RegistrosAcceso.Queries;

public class ObtenerRegistrosAccesoHandler
{
    private readonly IRegistroAccesoRepository _registros;

    public ObtenerRegistrosAccesoHandler(
        IRegistroAccesoRepository registros)
    {
        _registros = registros;
    }

    public async Task<List<RegistroAcceso>> EjecutarAsync()
    {
        return await _registros.ObtenerTodosAsync();
    }
}
