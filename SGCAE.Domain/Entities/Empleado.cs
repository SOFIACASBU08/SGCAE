

namespace SGCAE.Domain.Entities;

public class Empleado
{
    public int Id { get; private set; }

    public string Nombres { get; private set; } = string.Empty;

    public string Apellidos { get; private set; } = string.Empty;

    public string NumeroDocumento { get; private set; } = string.Empty;

    public string Correo { get; private set; } = string.Empty;

    public string Cargo { get; private set; } = string.Empty;

    public string AreaOrganizacional { get; private set; } = string.Empty;

    public bool Activo { get; private set; } = true;

    private Empleado() { }

    public Empleado(
        string nombres,
        string apellidos,
        string numeroDocumento,
        string correo,
        string cargo,
        string areaOrganizacional)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres son obligatorios.");

        if (string.IsNullOrWhiteSpace(apellidos))
            throw new ArgumentException("Los apellidos son obligatorios.");

        if (string.IsNullOrWhiteSpace(numeroDocumento))
            throw new ArgumentException("El número de documento es obligatorio.");

        if (string.IsNullOrWhiteSpace(correo))
            throw new ArgumentException("El correo es obligatorio.");

        if (string.IsNullOrWhiteSpace(cargo))
            throw new ArgumentException("El cargo es obligatorio.");

        if (string.IsNullOrWhiteSpace(areaOrganizacional))
            throw new ArgumentException("El área organizacional es obligatoria.");

        Nombres = nombres.Trim();
        Apellidos = apellidos.Trim();
        NumeroDocumento = numeroDocumento.Trim();
        Correo = correo.Trim();
        Cargo = cargo.Trim();
        AreaOrganizacional = areaOrganizacional.Trim();
    }

    public void ActualizarInformacion(
        string nombres,
        string apellidos,
        string correo,
        string cargo,
        string areaOrganizacional)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres son obligatorios.");

        if (string.IsNullOrWhiteSpace(apellidos))
            throw new ArgumentException("Los apellidos son obligatorios.");

        if (string.IsNullOrWhiteSpace(correo))
            throw new ArgumentException("El correo es obligatorio.");

        if (string.IsNullOrWhiteSpace(cargo))
            throw new ArgumentException("El cargo es obligatorio.");

        if (string.IsNullOrWhiteSpace(areaOrganizacional))
            throw new ArgumentException("El área organizacional es obligatoria.");

        Nombres = nombres.Trim();
        Apellidos = apellidos.Trim();
        Correo = correo.Trim();
        Cargo = cargo.Trim();
        AreaOrganizacional = areaOrganizacional.Trim();
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
