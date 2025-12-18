using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Lab.Controllers;

/// <summary>
/// Контролер для специализаций. В целом его можно не трогать, я просто заранее вставлю в него нужные данные
/// , а остальные таблицы просто должны подхватывать данные из него, выводя в духе "А.А. Попов невролог".
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecialtiesController : ControllerBase
{
    private readonly AppDbContext _context;
    public SpecialtiesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Specialties>>> GetSpecialties()
    {
        return await _context.Specialties.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Specialties>> GetSpecialties(int id)
    {
        var specialties = await _context.Specialties.FindAsync(id);

        if (specialties == null)
        {
            return NotFound();
        }
        return specialties;
    }
    [HttpPost]
    public async Task<ActionResult<Specialties>> PostSpecialties(Specialties specialties)
    {
        _context.Specialties.Add(specialties);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = specialties.IdSpecialty }, specialties);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSpecialties(int id, Specialties specialties)
    {
        if (id != specialties.IdSpecialty)
        {
            return BadRequest();
        }
        _context.Entry(specialties).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SpecialtiesExists(id))
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
    public async Task<IActionResult> DeleteSpecialties(int id)
    {
        var specialties = await _context.Specialties.FindAsync(id);
        if (specialties == null)
        {
            return NotFound();
        }

        _context.Specialties.Remove(specialties);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SpecialtiesExists(int id)
    {
        return _context.Specialties.Any(e => e.IdSpecialty == id);
    }
}
