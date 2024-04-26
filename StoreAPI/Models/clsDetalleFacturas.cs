using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsDetalleFacturas
{
    [Key]
    public int DetalleFacturasId { get; set; }
    [Required]
    public int FacturaId { get; set; }
    [Required]
    public int ProductoId { get; set; }
    public float Costo { get; set; }
    public int Cantidad { get; set; }
    public float Precio { get; set; }
    
    public virtual clsFacturas? Factura { get; set; }
    public virtual clsProductos? Producto { get; set; }
}