
using SGCAE.Application.Interfaces;
using SGCAE.Domain.Entities;

namespace SGCAE.Application.RegistrosAcceso.Queries;

public class FiltrarRegistrosAccesoHandler
{
    private readonly IRegistroAccesoRepository _registros;

    public FiltrarRegistrosAccesoHandler(
        IRegistroAccesoRepository registros)
    {
        _registros = registros;
    }

    public async Task<List<RegistroAcceso>> EjecutarAsync(
        int? empleadoId,
        DateTime? fechaInicio,
        DateTime? fechaFin,
        int? puntoAccesoId,
        bool? accesoPermitido,
        int pagina = 1,
        int tamanioPagina = 10)
    {
        if (fechaInicio.HasValue &&
            fechaFin.HasValue &&
            fechaInicio.Value > fechaFin.Value)
        {
            throw new ArgumentException(
                "La fecha inicial no puede ser posterior a la fecha final.");
        }

        if (pagina < 1)
            pagina = 1;

        if (tamanioPagina < 1)
            tamanioPagina = 10;

        if (tamanioPagina > 100)
            tamanioPagina = 100;

        return await _registros.FiltrarAsync(
            empleadoId,
            fechaInicio,
            fechaFin,
            puntoAccesoId,
            accesoPermitido,
            pagina,
            tamanioPagina);
    }
}
