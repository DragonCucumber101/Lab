using Lab.Data;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Lab.Controllers;

/// <summary>
/// Контролер для пациентов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PatientsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patients>>> GetPatient()
    {
        return await _context.Patients.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Patients>> GetPatient(int id)
    {
        var patients = await _context.Patients.FindAsync(id);

        if (patients == null)
        {
            return NotFound();
        }
        return patients;
    }
    [HttpPost]
    public async Task<ActionResult<Patients>> PostPatient(Patients patients)
    {
        _context.Patients.Add(patients);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPatient), new { id = patients.IdPatients }, patients);
        //return CreatedAtAction("GetProduct", new { id = patients.IdPatients }, patients);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, Patients patients)
    {
        if (id != patients.IdPatients)
        {
            return BadRequest();
        }
        _context.Entry(patients).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(); 
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientExists(id))
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
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patients = await _context.Patients.FindAsync(id);
        if (patients == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patients);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.IdPatients == id);
    }
}
