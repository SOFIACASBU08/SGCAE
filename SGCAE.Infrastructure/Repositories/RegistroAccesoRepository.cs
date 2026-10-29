
using Microsoft.EntityFrameworkCore;
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;
using SGCAE.Infrastructure.Data;

namespace SGCAE.Infrastructure.Repositories;

public class RegistroAccesoRepository : IRegistroAccesoRepository
{
    private readonly SGCAEDbContext _context;

    public RegistroAccesoRepository(SGCAEDbContext context)
    {
        _context = context;
    }

    public async Task<List<RegistroAcceso>> ObtenerTodosAsync()
    {
        return await _context.RegistrosAcceso
            .AsNoTracking()
            .OrderByDescending(r => r.FechaHora)
            .ToListAsync();
    }

    public async Task<RegistroAcceso?> ObtenerPorIdAsync(int id)
    {
        return await _context.RegistrosAcceso
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AgregarAsync(RegistroAcceso registro)
    {
        await _context.RegistrosAcceso.AddAsync(registro);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<RegistroAcceso>> FiltrarAsync(
        int? empleadoId,
        DateTime? fechaInicio,
        DateTime? fechaFin,
        int? puntoAccesoId,
        bool? accesoPermitido,
        int pagina,
        int tamanioPagina)
    {
        var consulta = _context.RegistrosAcceso
            .AsNoTracking()
            .AsQueryable();

        if (empleadoId.HasValue)
            consulta = consulta.Where(r => r.EmpleadoId == empleadoId.Value);

        if (fechaInicio.HasValue)
            consulta = consulta.Where(r => r.FechaHora >= fechaInicio.Value);

        if (fechaFin.HasValue)
            consulta = consulta.Where(r => r.FechaHora <= fechaFin.Value);

        if (puntoAccesoId.HasValue)
            consulta = consulta.Where(r => r.PuntoAccesoId == puntoAccesoId.Value);

        if (accesoPermitido.HasValue)
            consulta = consulta.Where(r => r.AccesoPermitido == accesoPermitido.Value);

        if (pagina < 1)
            pagina = 1;

        if (tamanioPagina < 1)
            tamanioPagina = 10;

        return await consulta
            .OrderByDescending(r => r.FechaHora)
            .Skip((pagina - 1) * tamanioPagina)
            .Take(tamanioPagina)
            .ToListAsync();
    }

}
