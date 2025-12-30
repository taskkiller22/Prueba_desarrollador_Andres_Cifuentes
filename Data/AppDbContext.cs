using Microsoft.EntityFrameworkCore;
using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleadosModel> Empleados => Set<EmpleadosModel>();
        public DbSet<GruposModel> Grupos => Set<GruposModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadosModel>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmpleadosModel>()
                .HasOne(e => e.Grupo)
                .WithMany(g => g.Empleados)
                .HasForeignKey(e => e.GrupoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
