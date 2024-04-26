using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Models;

namespace StoreAPI.Context;

public partial class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }
    
    public DbSet<clsCategorias> Categorias { get; set; }
    public DbSet<clsClientes> Clientes { get; set; }
    public DbSet<clsDetalleFacturas> DetalleFacturas { get; set; }
    public DbSet<clsFacturas> Facturas { get; set; }
    public DbSet<clsTipoFacturas> TipoFacturas { get; set; }
    public DbSet<clsProductos> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
