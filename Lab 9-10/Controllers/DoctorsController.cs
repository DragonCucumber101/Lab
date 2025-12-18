using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Lab.Controllers;

/// <summary>
/// Контролер для врачей
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly AppDbContext _context;
    public DoctorsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
    {
        return await _context.Doctors
    .Include(d => d.Specialty)
    .ToListAsync();
        //return await _context.Doctors.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Doctors>> GetDoctors(int id)
    {
        var doctors = await _context.Doctors
    .Include(d => d.Specialty)
    .FirstOrDefaultAsync(d => d.IdDoctors == id);
        //var doctors = await _context.Doctors.FindAsync(id);

        if (doctors == null)
        {
            return NotFound();
        }
        return doctors;
    }
    [HttpPost]
    public async Task<ActionResult<Doctors>> PostDoctors(Doctors doctors)
    {
        _context.Doctors.Add(doctors);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = doctors.IdDoctors }, doctors);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctors(int id, Doctors doctors)
    {
        if (id != doctors.IdDoctors)
        {
            return BadRequest();
        }
        _context.Entry(doctors).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DoctorsExists(id)) 
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctors(int id)
    {
        var doctors = await _context.Doctors.FindAsync(id);
        if (doctors == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctors);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DoctorsExists(int id)
    {
        return _context.Doctors.Any(e => e.IdDoctors == id);
    }
}
