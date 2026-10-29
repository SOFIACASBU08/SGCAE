
using Microsoft.EntityFrameworkCore;
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;
using SGCAE.Infrastructure.Data;

namespace SGCAE.Infrastructure.Repositories;

public class CredencialRepository : ICredencialRepository
{
    private readonly SGCAEDbContext _context;

    public CredencialRepository(SGCAEDbContext context)
    {
        _context = context;
    }

    public async Task<List<Credencial>> ObtenerTodasAsync()
    {
        return await _context.Credenciales
            .AsNoTracking()
            .OrderBy(c => c.Codigo)
            .ToListAsync();
    }

    public async Task<Credencial?> ObtenerPorIdAsync(int id)
    {
        return await _context.Credenciales
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> ExisteCodigoAsync(string codigo)
    {
        return await _context.Credenciales
            .AnyAsync(c => c.Codigo == codigo);
    }

    public async Task AgregarAsync(Credencial credencial)
    {
        await _context.Credenciales.AddAsync(credencial);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}
