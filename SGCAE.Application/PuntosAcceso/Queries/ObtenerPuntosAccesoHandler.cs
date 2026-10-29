
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.PuntosAcceso.Queries;

public class ObtenerPuntosAccesoHandler
{
    private readonly IPuntoAccesoRepository _repository;

    public ObtenerPuntosAccesoHandler(
        IPuntoAccesoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PuntoAcceso>> EjecutarAsync()
    {
        return await _repository.ObtenerTodosAsync();
    }
}
