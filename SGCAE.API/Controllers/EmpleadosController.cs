

using Microsoft.AspNetCore.Mvc;
using SGCAE.Application.Empleados.Commands;
using SGCAE.Application.Empleados.Queries;

namespace SGCAE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly ObtenerEmpleadosHandler _obtenerHandler;
    private readonly RegistrarEmpleadoHandler _registrarHandler;
    private readonly ActualizarEmpleadoHandler _actualizarHandler;
    private readonly DesactivarEmpleadoHandler _desactivarHandler;

    public EmpleadosController(
        ObtenerEmpleadosHandler obtenerHandler,
        RegistrarEmpleadoHandler registrarHandler,
        ActualizarEmpleadoHandler actualizarHandler,
        DesactivarEmpleadoHandler desactivarHandler)
    {
        _obtenerHandler = obtenerHandler;
        _registrarHandler = registrarHandler;
        _actualizarHandler = actualizarHandler;
        _desactivarHandler = desactivarHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var empleados = await _obtenerHandler.EjecutarAsync();
        return Ok(empleados);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] RegistrarEmpleadoCommand comando)
    {
        try
        {
            var id = await _registrarHandler.EjecutarAsync(comando);

            return CreatedAtAction(
                nameof(ObtenerTodos),
                new { id },
                new
                {
                    mensaje = "Empleado registrado correctamente.",
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(
        int id,
        [FromBody] ActualizarEmpleadoCommand comando)
    {
        try
        {
            var actualizado = await _actualizarHandler.EjecutarAsync(
                id, comando);

            if (!actualizado)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró un empleado con ese ID."
                });
            }

            return Ok(new
            {
                mensaje = "Empleado actualizado correctamente."
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
        var desactivado = await _desactivarHandler.EjecutarAsync(id);

        if (!desactivado)
        {
            return NotFound(new
            {
                mensaje = "No se encontró un empleado con ese ID."
            });
        }

        return Ok(new
        {
            mensaje = "Empleado desactivado correctamente."
        });
    }
}
