using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsTipoFacturas
{
    [Key]
    public int TipoFacturaId { get; set; }
    [Required]
    public required string TipoFactura { get; set; }
    
    public virtual ICollection<clsFacturas>? Invoice { get; set; }
}