using ExamenBackendMovil.Models;
using Microsoft.EntityFrameworkCore;
using ExamenBackendMovil.Data;

namespace ExamenBackendMovil.Services;

public class TareaService
{
    private readonly DataContext _context;
    public TareaService(DataContext context)
    {
        _context = context;
    }
    //obtener todos los usuarios
    public async Task<List<Tareas>> ObtenerTareas()
    {
        return await _context.Tareas.ToListAsync();
    }
    //obtener un usuario por id
    public async Task<Tareas?> ObtenerTareasPorId(Guid id)
    {
        return await _context.Tareas.FirstOrDefaultAsync(u => u.Id == id);
    }
    //crear un usuario 
    public async Task<Tareas> CrearTareas(Tareas tareas)
    {
        tareas.Id = Guid.NewGuid();
        tareas.CreatedAt = DateTime.UtcNow;

        _context.Tareas.Add(tareas);
        await _context.SaveChangesAsync();

        return tareas;
    }
    //actualizar un usuario
    public async Task<bool> ActualizarTareas(Guid id, Tareas tareasActualizado)
    {
        var tareas = await _context.Tareas.FindAsync(id);
        if (tareas == null) return false;

        tareas.Nombre = tareasActualizado.Nombre;
        tareas.Descripcion = tareasActualizado.Descripcion;
    

        await _context.SaveChangesAsync();
        return true;
    }
    //eliminar un usuario
    public async Task<bool> EliminarUTareas(Guid id)
    {
        var tareas = await _context.Tareas.FindAsync(id);
        if (tareas == null) return false;

        _context.Tareas.Remove(tareas);
        await _context.SaveChangesAsync();
        return true;
    }
}