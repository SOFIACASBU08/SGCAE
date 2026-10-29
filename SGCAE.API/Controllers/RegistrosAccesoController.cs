
using Microsoft.AspNetCore.Mvc;
using SGCAE.Application.RegistrosAcceso.Commands;
using SGCAE.Application.RegistrosAcceso.Queries;

namespace SGCAE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrosAccesoController : ControllerBase
{
    private readonly RegistrarAccesoHandler _registrarAcceso;
    private readonly ObtenerRegistrosAccesoHandler _obtenerRegistros;
    private readonly FiltrarRegistrosAccesoHandler _filtrarRegistros;

    public RegistrosAccesoController(
        RegistrarAccesoHandler registrarAcceso,
        ObtenerRegistrosAccesoHandler obtenerRegistros,
        FiltrarRegistrosAccesoHandler filtrarRegistros)
    {
        _registrarAcceso = registrarAcceso;
        _obtenerRegistros = obtenerRegistros;
        _filtrarRegistros = filtrarRegistros;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] RegistrarAccesoCommand comando)
    {
        try
        {
            var id = await _registrarAcceso.EjecutarAsync(comando);

            return Ok(new
            {
                id,
                mensaje = "Intento de acceso procesado correctamente."
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var registros = await _obtenerRegistros.EjecutarAsync();
        return Ok(registros);
    }
    
    [HttpGet("filtrar")]
    public async Task<IActionResult> Filtrar(
        [FromQuery] int? empleadoId,
        [FromQuery] DateTime? fechaInicio,
        [FromQuery] DateTime? fechaFin,
        [FromQuery] int? puntoAccesoId,
        [FromQuery] bool? accesoPermitido,
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanioPagina = 10)
    {
        try
        {
            var registros = await _filtrarRegistros.EjecutarAsync(
                empleadoId,
                fechaInicio,
                fechaFin,
                puntoAccesoId,
                accesoPermitido,
                pagina,
                tamanioPagina);

            return Ok(registros);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

}
