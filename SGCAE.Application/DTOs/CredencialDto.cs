
namespace SGCAE.Application.DTOs;

public class CredencialDto
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime? FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string Estado { get; set; } = string.Empty;
}

