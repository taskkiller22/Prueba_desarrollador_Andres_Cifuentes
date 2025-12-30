using Prueba_desarrollador_Andres_Cifuentes.Interfaces;
using Prueba_desarrollador_Andres_Cifuentes.Models;

namespace Prueba_desarrollador_Andres_Cifuentes.Provider
{
    public class EmpleadosFallbackProvider : IEmpleados
    {
        private readonly IEmpleadosDb _db;
        private readonly IEmpleadosMemory _memory;

        public EmpleadosFallbackProvider(IEmpleadosDb db, IEmpleadosMemory memory)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public async Task<List<EmpleadosModel>> GetAllAsync()
        {
            var data = await TryGetFromDbAsync();
            return (data != null && data.Any()) ? data : await _memory.GetAllAsync();
        }

        public async Task<EmpleadosModel?> GetByIdAsync(int id)
        {
            var emp = await TryGetFromDbByIdAsync(id);
            return emp ?? await _memory.GetByIdAsync(id);
        }

        public async Task AddAsync(EmpleadosModel empleado)
        {
            if (empleado == null) throw new ArgumentNullException(nameof(empleado));

            if (!await TryAddToDbAsync(empleado))
            {
                await _memory.AddAsync(empleado);
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (!await TryDeleteFromDbAsync(id))
            {
                await _memory.DeleteAsync(id);
            }
        }

        #region Private helpers

        private async Task<List<EmpleadosModel>?> TryGetFromDbAsync()
        {
            try
            {
                return await _db.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }

        private async Task<EmpleadosModel?> TryGetFromDbByIdAsync(int id)
        {
            try
            {
                return await _db.GetByIdAsync(id);
            }
            catch
            {
                return null;
            }
        }

        private async Task<bool> TryAddToDbAsync(EmpleadosModel empleado)
        {
            try
            {
                await _db.AddAsync(empleado);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> TryDeleteFromDbAsync(int id)
        {
            try
            {
                await _db.DeleteAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
