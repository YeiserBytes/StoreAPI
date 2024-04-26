using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class DetalleFacturasController : ControllerBase
{
    private StoreContext _context;

    public DetalleFacturasController(StoreContext context)
    {
        _context = context;
    }
    
        
    // GET: api/DetalleFacturas
    [HttpGet]
    public IActionResult Get()
    {
        var detalleFacturas = _context.DetalleFacturas.ToList();
        return Ok(detalleFacturas);
    }

    // GET: api/DetalleFacturas/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var detalleFactura = _context.DetalleFacturas.FirstOrDefault(x => x.DetalleFacturasId == id);
        if (detalleFactura == null)
        {
            return NotFound();
        }
        return Ok(detalleFactura);
    }

    // POST: api/DetalleFacturas
    [HttpPost]
    public IActionResult Post([FromBody] clsDetalleFacturas detalleFactura)
    {
        if (detalleFactura == null || !_context.Facturas.Any(x => x.FacturaId == detalleFactura.FacturaId) || !_context.Productos.Any(x => x.ProductoId == detalleFactura.ProductoId))
        {
            return BadRequest("Detalle de factura inválido");
        }

        _context.DetalleFacturas.Add(detalleFactura);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = detalleFactura.DetalleFacturasId }, detalleFactura);
    }

    // PUT: api/DetalleFacturas/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsDetalleFacturas detalleFactura)
    {
        if (detalleFactura == null || id != detalleFactura.DetalleFacturasId)
        {
            return BadRequest("Detalle de factura inválido");
        }

        if (!_context.DetalleFacturas.Any(x => x.DetalleFacturasId == id))
        {
            return NotFound();
        }

        _context.Entry(detalleFactura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/DetalleFacturas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var detalleFactura = _context.DetalleFacturas.FirstOrDefault(x => x.DetalleFacturasId == id);
        if (detalleFactura == null)
        {
            return NotFound();
        }

        _context.DetalleFacturas.Remove(detalleFactura);
        _context.SaveChanges();
        return NoContent();
    }
}