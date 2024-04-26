using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class FacturasController : ControllerBase
{
    private StoreContext _context;

    public FacturasController(StoreContext context)
    {
        _context = context;
    }
    
    // GET: api/Facturas
    [HttpGet]
    public IActionResult Get()
    {
        var facturas = _context.Facturas.ToList();
        return Ok(facturas);
    }

    // GET: api/Facturas/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var factura = _context.Facturas.FirstOrDefault(x => x.FacturaId == id);
        if (factura == null)
        {
            return NotFound();
        }
        return Ok(factura);
    }

    // POST: api/Facturas
    [HttpPost]
    public IActionResult Post([FromBody] clsFacturas factura)
    {
        if (factura == null || !ModelState.IsValid)
        {
            return BadRequest("Factura inválida");
        }

        // Verificar si existe el cliente
        var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == factura.ClienteId);
        if (cliente == null)
        {
            return BadRequest("Cliente no encontrado");
        }

        // Verificar si existe el tipo de factura
        var tipoFactura = _context.TipoFacturas.FirstOrDefault(x => x.TipoFacturaId == factura.TipoFacturaId);
        if (tipoFactura == null)
        {
            return BadRequest("Tipo de factura no encontrado");
        }

        _context.Facturas.Add(factura);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = factura.FacturaId }, factura);
    }

    // PUT: api/Facturas/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsFacturas factura)
    {
        if (factura == null || id != factura.FacturaId)
        {
            return BadRequest("Factura inválida");
        }

        if (!_context.Facturas.Any(x => x.FacturaId == id))
        {
            return NotFound();
        }

        // Verificar si existe el cliente
        var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == factura.ClienteId);
        if (cliente == null)
        {
            return BadRequest("Cliente no encontrado");
        }

        // Verificar si existe el tipo de factura
        var tipoFactura = _context.TipoFacturas.FirstOrDefault(x => x.TipoFacturaId == factura.TipoFacturaId);
        if (tipoFactura == null)
        {
            return BadRequest("Tipo de factura no encontrado");
        }

        _context.Entry(factura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Facturas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var factura = _context.Facturas.FirstOrDefault(x => x.FacturaId == id);
        if (factura == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(factura);
        _context.SaveChanges();
        return NoContent();
    }
}