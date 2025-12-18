using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Lab.Controllers;

/// <summary>
/// Контролер для визитов пациентов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly AppDbContext _context;
    public VisitsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visits>>> GetVisits()
    {
        return await _context.Visits.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Visits>> GetVisits(int id)
    {
        var visits = await _context.Visits.FindAsync(id);

        if (visits == null)
        {
            return NotFound();
        }
        return visits;
    }
    [HttpPost]
    public async Task<ActionResult<Visits>> PostVisits(Visits visits)
    {
        _context.Visits.Add(visits);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = visits.IdVisits }, visits);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisits(int id, Visits visits)
    {
        if (id != visits.IdVisits)
        {
            return BadRequest();
        }
        _context.Entry(visits).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitsExists(id))
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
    public async Task<IActionResult> DeleteVisits(int id)
    {
        var visits = await _context.Visits.FindAsync(id);
        if (visits == null)
        {
            return NotFound();
        }

        _context.Visits.Remove(visits);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VisitsExists(int id)
    {
        return _context.Visits.Any(e => e.IdVisits == id);
    }
}
