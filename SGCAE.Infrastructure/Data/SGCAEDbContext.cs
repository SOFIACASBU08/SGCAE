


using Microsoft.EntityFrameworkCore;
using SGCAE.Domain.Entities;

namespace SGCAE.Infrastructure.Data;

public class SGCAEDbContext : DbContext
{
    public SGCAEDbContext(DbContextOptions<SGCAEDbContext> options)
        : base(options)
    {
    }

    public DbSet<Empleado> Empleados => Set<Empleado>();

    public DbSet<PuntoAcceso> PuntosAcceso => Set<PuntoAcceso>();

    public DbSet<Credencial> Credenciales => Set<Credencial>();

    public DbSet<RegistroAcceso> RegistrosAcceso => Set<RegistroAcceso>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de empleados
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(30);

            entity.HasIndex(e => e.NumeroDocumento)
                .IsUnique();

            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Cargo)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.AreaOrganizacional)
                .IsRequired()
                .HasMaxLength(100);
        });

        // Configuración de puntos de acceso
        modelBuilder.Entity<PuntoAcceso>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Ubicacion)
                .IsRequired()
                .HasMaxLength(200);
        });

        // Configuración de credenciales
        modelBuilder.Entity<Credencial>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(c => c.Codigo)
                .IsUnique();

            entity.Property(c => c.Estado)
                .HasConversion<int>()
                .IsRequired();

            entity.HasOne(c => c.Empleado)
                .WithMany()
                .HasForeignKey(c => c.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de registros de acceso
        modelBuilder.Entity<RegistroAcceso>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.TipoMovimiento)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(r => r.MotivoRechazo)
                .HasMaxLength(250);

            entity.HasOne(r => r.Empleado)
                .WithMany()
                .HasForeignKey(r => r.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.PuntoAcceso)
                .WithMany()
                .HasForeignKey(r => r.PuntoAccesoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(r => r.FechaHora);
        });
    }
}
