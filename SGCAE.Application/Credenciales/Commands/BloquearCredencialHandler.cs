
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.Credenciales.Commands;

public class BloquearCredencialHandler
{
    private readonly ICredencialRepository _repository;

    public BloquearCredencialHandler(ICredencialRepository repository)
    {
        _repository = repository;
    }

    public async Task EjecutarAsync(BloquearCredencialCommand comando)
    {
        var credencial = await _repository.ObtenerPorIdAsync(comando.Id);

        if (credencial == null)
        {
            throw new ArgumentException(
                "La credencial no existe.");
        }

        if (credencial.Estado == SGCAE.Domain.Enums.EstadoCredencial.Revocada)
        {
            throw new InvalidOperationException(
                "No se puede bloquear una credencial revocada.");
        }

        credencial.Bloquear();

        await _repository.GuardarCambiosAsync();
    }
}
