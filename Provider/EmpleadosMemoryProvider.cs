using Prueba_desarrollador_Andres_Cifuentes.Interfaces;
using Prueba_desarrollador_Andres_Cifuentes.Models;

public class EmpleadosMemoryProvider : IEmpleadosMemory
{
    private static readonly List<EmpleadosModel> _empleados = new()
    {
        new() { Id = 1, Nombre = "Juan Pérez", Codigo = 1001, Posicion = "Developer", SalarioBase = 5000 },
        new() { Id = 2, Nombre = "Ana Gómez", Codigo = 1002, Posicion = "QA", SalarioBase = 4000 }
    };

    private static int _nextId = 3;

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
        var emp = _empleados.FirstOrDefault(e => e.Id == id);
        if (emp != null) _empleados.Remove(emp);
        return Task.CompletedTask;
    }
}
