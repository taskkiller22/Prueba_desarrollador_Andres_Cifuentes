using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_desarrollador_Andres_Cifuentes.Data;
using Prueba_desarrollador_Andres_Cifuentes.Models;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmpleadosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/empleados
    [HttpGet]
    public async Task<ActionResult<List<EmpleadosModel>>> GetAll()
    {
        return await _context.Empleados.ToListAsync();
    }

    // GET: api/empleados/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadosModel>> GetById(int id)
    {
        var empleado = await _context.Empleados.FindAsync(id);

        if (empleado == null)
            return NotFound();

        return empleado;
    }

    // POST: api/empleados
    [HttpPost]
    public async Task<ActionResult> Create(EmpleadosModel empleado)
    {
        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = empleado.Id }, empleado);
    }

    // PUT: api/empleados/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmpleadosModel empleado)
    {
        if (id != empleado.Id)
            return BadRequest();

        _context.Entry(empleado).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/empleados/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var empleado = await _context.Empleados.FindAsync(id);

        if (empleado == null)
            return NotFound();

        _context.Empleados.Remove(empleado);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
