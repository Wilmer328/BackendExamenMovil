using Microsoft.AspNetCore.Mvc;
using ExamenBackendMovil.Models;
using ExamenBackendMovil.Services;



namespace ExamenBackendMovil.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly TareaService _tareaService;

    public TareasController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tareas>>> ObtenerTareas()
    {
        var tareas = await _tareaService.ObtenerTareas();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tareas>> ObtenerTareaPorId(Guid id)
    {
        var tarea = await _tareaService.ObtenerTareasPorId(id);
        if (tarea == null) return NotFound("Tarea no encontrada");

        return Ok(tarea);
    }

    [HttpPost]
    public async Task<ActionResult> CrearTarea([FromBody] Tareas tareas)
    {
        if (tareas == null)
        {
            return BadRequest("Datos de la tarea vienen vacíos");
        }
        var nuevaTarea = await _tareaService.CrearTareas(tareas);
        return Ok(nuevaTarea);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarTarea(Guid id, [FromBody] Tareas tareaActualizada)
    {
        if (tareaActualizada == null)
        {
            return BadRequest("Datos de la tarea vienen vacíos");
        }

        var response = await _tareaService.ActualizarTareas(id, tareaActualizada);

        if (response == false)
        {
            return NotFound("Tarea no encontrada en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarTarea(Guid id)
    {
        var response = await _tareaService.EliminarUTareas(id);
        if (response == false)
        {
            return NotFound("Tarea no encontrada en base de datos");
        }
        return NoContent();
    }
}