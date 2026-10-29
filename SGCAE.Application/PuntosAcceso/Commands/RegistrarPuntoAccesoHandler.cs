
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.PuntosAcceso.Commands;

public class RegistrarPuntoAccesoHandler
{
    private readonly IPuntoAccesoRepository _repository;

    public RegistrarPuntoAccesoHandler(
        IPuntoAccesoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> EjecutarAsync(
        RegistrarPuntoAccesoCommand comando)
    {
        if (string.IsNullOrWhiteSpace(comando.Nombre))
        {
            throw new ArgumentException(
                "El nombre del punto de acceso es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(comando.Ubicacion))
        {
            throw new ArgumentException(
                "La ubicación del punto de acceso es obligatoria.");
        }

        var puntoAcceso = new PuntoAcceso(
            comando.Nombre,
            comando.Ubicacion);

        await _repository.AgregarAsync(puntoAcceso);
        await _repository.GuardarCambiosAsync();

        return puntoAcceso.Id;
    }
}
