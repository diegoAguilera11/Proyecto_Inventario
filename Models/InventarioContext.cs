using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Inventario.Models;

public partial class InventarioContext : DbContext
{
    public InventarioContext()
    {
    }

    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=supermercado;user=root;password=Admin123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.Codigo, "codigo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<ProductoSucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto_sucursal");

            entity.HasIndex(e => e.IdProducto, "producto");

            entity.HasIndex(e => e.IdSucursal, "sucursal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sucursal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
