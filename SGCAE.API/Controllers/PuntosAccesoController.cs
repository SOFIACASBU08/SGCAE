
using Microsoft.AspNetCore.Mvc;
using SGCAE.Application.PuntosAcceso.Commands;
using SGCAE.Application.PuntosAcceso.Queries;

namespace SGCAE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PuntosAccesoController : ControllerBase
{
    private readonly RegistrarPuntoAccesoHandler _registrarHandler;
    private readonly ObtenerPuntosAccesoHandler _obtenerHandler;
    private readonly DesactivarPuntoAccesoHandler _desactivarHandler;

    public PuntosAccesoController(
        RegistrarPuntoAccesoHandler registrarHandler,
        ObtenerPuntosAccesoHandler obtenerHandler,
        DesactivarPuntoAccesoHandler desactivarHandler)
    {
        _registrarHandler = registrarHandler;
        _obtenerHandler = obtenerHandler;
        _desactivarHandler = desactivarHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var puntos = await _obtenerHandler.EjecutarAsync();
        return Ok(puntos);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] RegistrarPuntoAccesoCommand comando)
    {
        try
        {
            var id = await _registrarHandler.EjecutarAsync(comando);

            return Ok(new
            {
                mensaje = "Punto de acceso registrado correctamente.",
                id
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
    
    [HttpPatch("{id:int}/desactivar")]
    public async Task<IActionResult> Desactivar(int id)
    {
        try
        {
            var comando = new DesactivarPuntoAccesoCommand
            {
                Id = id
            };

            await _desactivarHandler.EjecutarAsync(comando);

            return Ok(new
            {
                mensaje = "Punto de acceso desactivado correctamente."
            });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

}
