
namespace SGCAE.Domain.Entities;

public class PuntoAcceso
{
    public int Id { get; private set; }

    public string Nombre { get; private set; } = string.Empty;

    public string Ubicacion { get; private set; } = string.Empty;

    public bool Activo { get; private set; } = true;

    private PuntoAcceso()
    {
    }

    public PuntoAcceso(string nombre, string ubicacion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del punto de acceso es obligatorio.");

        if (string.IsNullOrWhiteSpace(ubicacion))
            throw new ArgumentException("La ubicación es obligatoria.");

        Nombre = nombre.Trim();
        Ubicacion = ubicacion.Trim();
    }

    public void Desactivar()
    {
        Activo = false;
    }

    public void Activar()
    {
        Activo = true;
    }
}
