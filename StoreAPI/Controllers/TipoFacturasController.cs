using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TipoFacturasController : ControllerBase
{
    private StoreContext _context;

    public TipoFacturasController(StoreContext context)
    {
        _context = context;
    }
    
    // GET: api/TipoFaturas
    [HttpGet]
    public IActionResult Get()
    {
        var tiposFatura = _context.TipoFacturas.ToList();
        return Ok(tiposFatura);
    }
    
    // GET: api/TipoFaturas/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var tipoFatura = _context.TipoFacturas.FirstOrDefault(x => x.TipoFacturaId == id);
        
        if (tipoFatura == null)
        {
            return NotFound();
        }
        return Ok(tipoFatura);
    }
    
    // POST: api/TipoFaturas
    [HttpPost]
    public IActionResult Post([FromBody] clsTipoFacturas tipoFatura)
    {
        if (tipoFatura == null || string.IsNullOrEmpty(tipoFatura.TipoFactura))
        {
            return BadRequest("Tipo de factura inválido");
        }
    
        _context.TipoFacturas.Add(tipoFatura);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = tipoFatura.TipoFacturaId }, tipoFatura);
    }
    
    // PUT: api/TipoFaturas/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsTipoFacturas tipoFatura)
    {
        if (tipoFatura == null || id != tipoFatura.TipoFacturaId)
        {
            return BadRequest("Tipo de factura inválido");
        }
    
        var existingTipoFatura = _context.TipoFacturas.FirstOrDefault(x => x.TipoFacturaId == id);
        if (existingTipoFatura == null)
        {
            return NotFound();
        }
    
        existingTipoFatura.TipoFactura = tipoFatura.TipoFactura;
        _context.SaveChanges();
        return NoContent();
    }
    
    // DELETE: api/TipoFaturas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tipoFatura = _context.TipoFacturas.FirstOrDefault(x => x.TipoFacturaId == id);
        if (tipoFatura == null)
        {
            return NotFound();
        }
    
        _context.TipoFacturas.Remove(tipoFatura);
        _context.SaveChanges();
        return NoContent();
    }
}