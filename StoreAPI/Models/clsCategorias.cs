using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsCategorias
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Categoria { get; set; }
    
    public virtual ICollection<clsProductos>? Productos { get; set; }
}