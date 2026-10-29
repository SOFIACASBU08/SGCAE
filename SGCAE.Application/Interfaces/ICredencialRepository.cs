
using SGCAE.Domain.Entities;

namespace SGCAE.Application.Interfaces;

public interface ICredencialRepository
{
    Task<List<Credencial>> ObtenerTodasAsync();

    Task<Credencial?> ObtenerPorIdAsync(int id);

    Task<bool> ExisteCodigoAsync(string codigo);

    Task AgregarAsync(Credencial credencial);

    Task GuardarCambiosAsync();
}
