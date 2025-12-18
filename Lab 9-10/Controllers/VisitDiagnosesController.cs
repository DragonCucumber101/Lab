using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace Lab.Controllers;

/// <summary>
/// Контролер для посещений и диагнозов. Это от связующей таблицы посещений и диагнозов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VisitDiagnosesController : ControllerBase
{
    private readonly AppDbContext _context;
    public VisitDiagnosesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitDiagnoses>>> GetVisitDiagnoses()
    {
        return await _context.VisitDiagnoses.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<VisitDiagnoses>> GetVisitDiagnoses(int id)
    {
        var visitDiagnoses = await _context.VisitDiagnoses.FindAsync(id);

        if (visitDiagnoses == null)
        {
            return NotFound();
        }
        return visitDiagnoses;
    }
    [HttpPost]
    public async Task<ActionResult<VisitDiagnoses>> PostVisitDiagnoses(VisitDiagnoses visitDiagnoses)
    {
        _context.VisitDiagnoses.Add(visitDiagnoses);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = visitDiagnoses.IdVisitDiagnoses }, visitDiagnoses);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisitDiagnoses(int id, VisitDiagnoses visitDiagnoses)
    {
        if (id != visitDiagnoses.IdVisitDiagnoses)
        {
            return BadRequest();
        }
        _context.Entry(visitDiagnoses).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitDiagnosesExists(id))
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
    public async Task<IActionResult> DeleteVisitDiagnoses(int id)
    {
        var visitDiagnoses = await _context.VisitDiagnoses.FindAsync(id);
        if (visitDiagnoses == null)
        {
            return NotFound();
        }

        _context.VisitDiagnoses.Remove(visitDiagnoses);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VisitDiagnosesExists(int id)
    {
        return _context.VisitDiagnoses.Any(e => e.IdVisitDiagnoses == id);
    }
}
