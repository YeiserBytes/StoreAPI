using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private StoreContext _context;

    public ClientesController(StoreContext context)
    {
        _context = context;
    }
    
    // GET: api/Clientes
    [HttpGet]
    public IActionResult Get()
    {
        var clientes = _context.Clientes.ToList();
        return Ok(clientes);
    }

    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    // POST: api/Clientes
    [HttpPost]
    public IActionResult Post([FromBody] clsClientes cliente)
    {
        if (cliente == null || string.IsNullOrEmpty(cliente.Nombres))
        {
            return BadRequest("Cliente inválido");
        }

        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
    }

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsClientes cliente)
    {
        if (cliente == null || id != cliente.ClienteId)
        {
            return BadRequest("Cliente inválido");
        }

        var existingCliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);
        if (existingCliente == null)
        {
            return NotFound();
        }

        existingCliente.Nombres = cliente.Nombres;
        existingCliente.Direccion = cliente.Direccion;
        existingCliente.Telefonos = cliente.Telefonos;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}