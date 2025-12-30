using Microsoft.EntityFrameworkCore;
using Prueba_desarrollador_Andres_Cifuentes.Data;
using Prueba_desarrollador_Andres_Cifuentes.Interfaces;
using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Provider
{
    public class EmpleadosDbProvider : IEmpleadosDb
    {
        private readonly AppDbContext _context;

        public EmpleadosDbProvider(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadosModel>> GetAllAsync()
            => await _context.Empleados.AsNoTracking().ToListAsync();

        public async Task<EmpleadosModel?> GetByIdAsync(int id)
            => await _context.Empleados.AsNoTracking()
                                       .FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(EmpleadosModel empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Empleados.FindAsync(id);
            if (emp != null)
            {
                _context.Empleados.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
