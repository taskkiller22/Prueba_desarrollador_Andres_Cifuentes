using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Interfaces
{
    public interface IEmpleados
    {
        Task<List<EmpleadosModel>> GetAllAsync();
        Task<EmpleadosModel?> GetByIdAsync(int id);
        Task AddAsync(EmpleadosModel empleado);
        Task DeleteAsync(int id);
    }

    public interface IEmpleadosDb : IEmpleados { }
    public interface IEmpleadosMemory : IEmpleados { }
}
