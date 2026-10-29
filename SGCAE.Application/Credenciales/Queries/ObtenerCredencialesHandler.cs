
using SGCAE.Application.DTOs;
using SGCAE.Application.Interfaces;

namespace SGCAE.Application.Credenciales.Queries;

public class ObtenerCredencialesHandler
{
    private readonly ICredencialRepository _repository;

    public ObtenerCredencialesHandler(
        ICredencialRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CredencialDto>> EjecutarAsync()
    {
        var credenciales = await _repository.ObtenerTodasAsync();

        return credenciales.Select(c => new CredencialDto
        {
            Id = c.Id,
            EmpleadoId = c.EmpleadoId,
            Codigo = c.Codigo,
            FechaEmision = c.FechaEmision,
            FechaVencimiento = c.FechaVencimiento,
            Estado = c.Estado.ToString()
        }).ToList();
    }
}
