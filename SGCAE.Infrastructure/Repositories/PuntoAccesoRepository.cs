
using Microsoft.EntityFrameworkCore;
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;
using SGCAE.Infrastructure.Data;

namespace SGCAE.Infrastructure.Repositories;

public class PuntoAccesoRepository : IPuntoAccesoRepository
{
    private readonly SGCAEDbContext _context;

    public PuntoAccesoRepository(SGCAEDbContext context)
    {
        _context = context;
    }

    public async Task<List<PuntoAcceso>> ObtenerTodosAsync()
    {
        return await _context.PuntosAcceso
            .AsNoTracking()
            .OrderBy(p => p.Nombre)
            .ToListAsync();
    }

    public async Task<PuntoAcceso?> ObtenerPorIdAsync(int id)
    {
        return await _context.PuntosAcceso
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AgregarAsync(PuntoAcceso puntoAcceso)
    {
        await _context.PuntosAcceso.AddAsync(puntoAcceso);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}
