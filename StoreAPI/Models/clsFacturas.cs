using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsFacturas
{
    [Key]
    public int FacturaId { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public int TipoFacturaId { get; set; }
    [Required]
    public int ClienteId { get; set; }
    public float SubTotal { get; set; }
    public float Descuento { get; set; }
    [Required]
    public float Monto { get; set; }
    
    public virtual clsTipoFacturas? TipoFactura { get; set; }
    public virtual clsClientes? Cliente { get; set; }
        
    public virtual ICollection<clsDetalleFacturas>? DetalleFactura { get; set; }
}