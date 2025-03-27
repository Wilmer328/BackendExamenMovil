using Microsoft.EntityFrameworkCore;
using ExamenBackendMovil.Models;

namespace ExamenBackendMovil.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tareas> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().ToTable("usuario");

        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
        modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).HasColumnName("contraseña");
        modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

        // Configuración para las Tarea
        modelBuilder.Entity<Tareas>().ToTable("tareas");
        modelBuilder.Entity<Tareas>().Property(t => t.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Tareas>().Property(t => t.Descripcion).HasColumnName("descripcion");
        modelBuilder.Entity<Tareas>().Property(t => t.CreatedAt).HasColumnName("created_at");

    }

}