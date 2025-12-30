using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Interfaces
{
    public interface IGrupos
    {
        //Select all
        Task<List<GruposModel>> GetAllAsync();
        //Select 
        Task<GruposModel?> GetByIdAsync(int id);
        //Create
        Task AddAsync(GruposModel grupos);
        //Delete
        Task DeleteAsync(int id);
    }
}
