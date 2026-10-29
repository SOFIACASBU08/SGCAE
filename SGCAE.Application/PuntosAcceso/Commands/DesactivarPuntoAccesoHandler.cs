
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.PuntosAcceso.Commands;

public class DesactivarPuntoAccesoHandler
{
    private readonly IPuntoAccesoRepository _repository;

    public DesactivarPuntoAccesoHandler(
        IPuntoAccesoRepository repository)
    {
        _repository = repository;
    }

    public async Task EjecutarAsync(
        DesactivarPuntoAccesoCommand comando)
    {
        var punto = await _repository.ObtenerPorIdAsync(comando.Id);

        if (punto == null)
        {
            throw new ArgumentException(
                "El punto de acceso no existe.");
        }

        punto.Desactivar();

        await _repository.GuardarCambiosAsync();
    }
}
