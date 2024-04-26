using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private StoreContext _context;

    public ProductosController(StoreContext context)
    {
        _context = context;
    }
            
    // GET: api/Productos
    [HttpGet]
    public IActionResult Get()
    {
        var productos = _context.Productos.ToList();
        return Ok(productos);
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    // POST: api/Productos
    [HttpPost]
    public IActionResult Post([FromBody] clsProductos producto)
    {
        if (producto == null || string.IsNullOrEmpty(producto.Producto))
        {
            return BadRequest("Producto inválido");
        }

        // Verificar si existe la categoría
        var categoria = _context.Categorias.FirstOrDefault(x => x.Id == producto.CategoriaId);
        if (categoria == null)
        {
            return BadRequest("Categoría no encontrada");
        }

        _context.Productos.Add(producto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsProductos producto)
    {
        if (producto == null || id != producto.ProductoId)
        {
            return BadRequest("Producto inválido");
        }

        if (!_context.Productos.Any(x => x.ProductoId == id))
        {
            return NotFound();
        }

        // Verificar si existe la categoría
        var categoria = _context.Categorias.FirstOrDefault(x => x.Id == producto.CategoriaId);
        if (categoria == null)
        {
            return BadRequest("Categoría no encontrada");
        }

        _context.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        _context.SaveChanges();
        return NoContent();
    }
}