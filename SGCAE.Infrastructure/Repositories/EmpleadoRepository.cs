
using Microsoft.EntityFrameworkCore;
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;
using SGCAE.Infrastructure.Data;

namespace SGCAE.Infrastructure.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly SGCAEDbContext _context;

    public EmpleadoRepository(SGCAEDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empleado>> ObtenerTodosAsync()
    {
        return await _context.Empleados
            .AsNoTracking()
            .OrderBy(e => e.Apellidos)
            .ThenBy(e => e.Nombres)
            .ToListAsync();
    }

    public async Task<Empleado?> ObtenerPorIdAsync(int id)
    {
        return await _context.Empleados
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> ExisteDocumentoAsync(string numeroDocumento)
    {
        return await _context.Empleados
            .AnyAsync(e => e.NumeroDocumento == numeroDocumento);
    }

    public async Task AgregarAsync(Empleado empleado)
    {
        await _context.Empleados.AddAsync(empleado);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}
