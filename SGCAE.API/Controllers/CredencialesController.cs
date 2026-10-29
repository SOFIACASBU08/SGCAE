
using Microsoft.AspNetCore.Mvc;
using SGCAE.Application.Credenciales.Commands;
using SGCAE.Application.Credenciales.Queries;

namespace SGCAE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CredencialesController : ControllerBase
{
    private readonly RegistrarCredencialHandler _registrarHandler;
    private readonly ObtenerCredencialesHandler _obtenerHandler;
    private readonly BloquearCredencialHandler _bloquearHandler;
    private readonly RevocarCredencialHandler _revocarHandler;

    public CredencialesController(
        RegistrarCredencialHandler registrarHandler,
        ObtenerCredencialesHandler obtenerHandler,
        BloquearCredencialHandler bloquearHandler,
        RevocarCredencialHandler revocarHandler)
    {
        _registrarHandler = registrarHandler;
        _obtenerHandler = obtenerHandler;
        _bloquearHandler = bloquearHandler;
        _revocarHandler = revocarHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
    {
        var credenciales = await _obtenerHandler.EjecutarAsync();
        return Ok(credenciales);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] RegistrarCredencialCommand comando)
    {
        try
        {
            var id = await _registrarHandler.EjecutarAsync(comando);

            return Ok(new
            {
                mensaje = "Credencial registrada correctamente.",
                id
            });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { mensaje = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
    
    [HttpPatch("{id:int}/bloquear")]
    public async Task<IActionResult> Bloquear(int id)
    {
        try
        {
            var comando = new BloquearCredencialCommand
            {
                Id = id
            };

            await _bloquearHandler.EjecutarAsync(comando);

            return Ok(new
            {
                mensaje = "Credencial bloqueada correctamente."
            });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { mensaje = ex.Message });
        }
    }
    
    [HttpPatch("{id:int}/revocar")]
    public async Task<IActionResult> Revocar(int id)
    {
        try
        {
            var comando = new RevocarCredencialCommand
            {
                Id = id
            };

            await _revocarHandler.EjecutarAsync(comando);

            return Ok(new
            {
                mensaje = "Credencial revocada correctamente."
            });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { mensaje = ex.Message });
        }
    }


}
