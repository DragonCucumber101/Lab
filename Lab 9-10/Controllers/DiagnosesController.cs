using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace Lab.Controllers;

/// <summary>
/// Контролер для диагнозов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DiagnosesController : ControllerBase 
{
    private readonly AppDbContext _context;
    public DiagnosesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Diagnoses>>> GetDiagnoses()
    {
        return await _context.Diagnoses.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Diagnoses>> GetDiagnoses(int id)
    {
        var diagnoses = await _context.Diagnoses.FindAsync(id);

        if (diagnoses == null)
        {
            return NotFound();
        }
        return diagnoses;
    }
    [HttpPost]
    public async Task<ActionResult<Diagnoses>> PostDiagnoses(Diagnoses diagnoses)
    {
        _context.Diagnoses.Add(diagnoses);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = diagnoses.IdDiagnoses }, diagnoses);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDiagnoses(int id, Diagnoses diagnoses)
    {
        if (id != diagnoses.IdDiagnoses)
        {
            return BadRequest();
        }
        _context.Entry(diagnoses).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DiagnosesExists(id))
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
    public async Task<IActionResult> DeleteDiagnoses(int id)
    {
        var diagnoses = await _context.Diagnoses.FindAsync(id);
        if (diagnoses == null)
        {
            return NotFound();
        }

        _context.Diagnoses.Remove(diagnoses);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DiagnosesExists(int id)
    {
        return _context.Diagnoses.Any(e => e.IdDiagnoses == id);
    }
}
