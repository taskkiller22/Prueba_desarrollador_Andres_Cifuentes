using Prueba_desarrollador_Andres_Cifuentes.Data;
using Prueba_desarrollador_Andres_Cifuentes.Interfaces;
using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Provider
{
    public class EmpleadosProvider : IEmpleados
    {
        private readonly AppDbContext _context;

        public EmpleadosProvider(AppDbContext context)
        {
            _context = context;
        }
        private readonly List<EmpleadosModel> _empleados;
        private int _nextId;

        public EmpleadosProvider()
        {
            _empleados = new List<EmpleadosModel>();
            _nextId = 1;
        }

        public Task<List<EmpleadosModel>> GetAllAsync()
            => Task.FromResult(_empleados.ToList());

        public Task<EmpleadosModel?> GetByIdAsync(int id)
            => Task.FromResult(_empleados.FirstOrDefault(e => e.Id == id));

        public Task AddAsync(EmpleadosModel empleado)
        {
            empleado.Id = _nextId++;
            _empleados.Add(empleado);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var empleado = _empleados.FirstOrDefault(e => e.Id == id);
            if (empleado != null)
                _empleados.Remove(empleado);

            return Task.CompletedTask;
        }
    }
}
