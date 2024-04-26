using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models;

public class clsClientes
{
    [Key]
    public int ClienteId { get; set; }
    [Required]
    public string Nombres { get; set; }
    public string Direccion { get; set; }
    public string Telefonos { get; set; }
}