using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsProductos
{
    [Key]
    public int ProductoId { get; set; }
    [Required]
    public required string Producto { get; set; }
    [Required]
    public int CategoriaId { get; set; }
    public float Costo { get; set; }
    public int Cantidad { get; set; }
    public float Precio { get; set; }
    
    public virtual clsCategorias? Categoria { get; set; }
}