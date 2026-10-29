
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Enums;

namespace SGCAE.Application.Credenciales.Commands;

public class RevocarCredencialHandler
{
    private readonly ICredencialRepository _repository;

    public RevocarCredencialHandler(ICredencialRepository repository)
    {
        _repository = repository;
    }

    public async Task EjecutarAsync(RevocarCredencialCommand comando)
    {
        var credencial = await _repository.ObtenerPorIdAsync(comando.Id);

        if (credencial == null)
        {
            throw new ArgumentException("La credencial no existe.");
        }

        if (credencial.Estado == EstadoCredencial.Revocada)
        {
            throw new InvalidOperationException(
                "La credencial ya está revocada.");
        }

        credencial.Revocar();

        await _repository.GuardarCambiosAsync();
    }
}
