using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Context;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private StoreContext _context;

    public CategoriasController(StoreContext context)
    {
        _context = context;
    }
    
    // GET: api/Categorias
    [HttpGet]
    public IActionResult Get()
    {
        var categorias = _context.Categorias.ToList();

        return Ok(categorias);
    }

    // GET: api/Categorias/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
        if (categoria != null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    // POST: api/Categorias
    [HttpPost]
    [Route("/categoria")]
    public IActionResult Post([FromBody] clsCategorias? categoria)
    {
        if (categoria == null || string.IsNullOrEmpty(categoria.Categoria))
        {
            return BadRequest("Categoria Inválida");
        }

        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
    }
    
    // PUT: api/Categorias/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] clsCategorias categoria)
    {
        if (categoria == null || id != categoria.Id)
        {
            return BadRequest("Categoria inválida");
        }

        var existingCategoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
        if (existingCategoria == null)
        {
            return NotFound();
        }

        existingCategoria.Categoria = categoria.Categoria;
        _context.SaveChanges();
        return NoContent();
    }
    
    // DELETE: api/Categorias/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return NoContent();
    }
}