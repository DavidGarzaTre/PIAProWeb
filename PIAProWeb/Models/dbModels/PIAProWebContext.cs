using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIAProWeb.Models.dbModels
{
    public partial class PIAProWebContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
        public PIAProWebContext()
        {
        }

        public PIAProWebContext(DbContextOptions<PIAProWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; } = null!;
        public virtual DbSet<DatosTarjetum> DatosTarjeta { get; set; } = null!;
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; } = null!;
        public virtual DbSet<EspecsCpu> EspecsCpus { get; set; } = null!;
        public virtual DbSet<EspecsDiscoduro> EspecsDiscoduros { get; set; } = null!;
        public virtual DbSet<EspecsFuenteAlimentacion> EspecsFuenteAlimentacions { get; set; } = null!;
        public virtual DbSet<EspecsGrafica> EspecsGraficas { get; set; } = null!;
        public virtual DbSet<EspecsPlacaMadre> EspecsPlacaMadres { get; set; } = null!;
        public virtual DbSet<EspecsRam> EspecsRams { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
     

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProducto })
                    .HasName("PK__Carrito__5B65BF975107183C");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Producto1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Carrito_Usuarios");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__4A033A932CE71C3D");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();
            });

            modelBuilder.Entity<DatosTarjetum>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("PK__Datos_Ta__F5762032B459290D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DatosTarjeta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Datos_Tarjeta_Usuarios");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => new { e.IdOrden, e.IdArticulo })
                    .HasName("PK__Detalle___370733B6C49303A3");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_Detalle_Orden_Producto");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_Detalle_Orden_Orden");
            });

            modelBuilder.Entity<EspecsCpu>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_C__09889210ECD857D0");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsCpu)
                    .HasForeignKey<EspecsCpu>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_CPU_Producto");
            });

            modelBuilder.Entity<EspecsDiscoduro>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_d__098892101F57B502");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsDiscoduro)
                    .HasForeignKey<EspecsDiscoduro>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_discoduro_Producto");
            });

            modelBuilder.Entity<EspecsFuenteAlimentacion>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_F__09889210980AD2C9");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsFuenteAlimentacion)
                    .HasForeignKey<EspecsFuenteAlimentacion>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_Fuente_Alimentacion_Producto");
            });

            modelBuilder.Entity<EspecsGrafica>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_G__098892103BF442AA");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsGrafica)
                    .HasForeignKey<EspecsGrafica>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_Graficas_Producto");
            });

            modelBuilder.Entity<EspecsPlacaMadre>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_P__098892101E962375");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsPlacaMadre)
                    .HasForeignKey<EspecsPlacaMadre>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_PlacaMadre_Producto");
            });

            modelBuilder.Entity<EspecsRam>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Especs_r__09889210C637BAF8");

                entity.Property(e => e.IdProducto).ValueGeneratedNever();

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.EspecsRam)
                    .HasForeignKey<EspecsRam>(d => d.IdProducto)
                    .HasConstraintName("FK_Especs_ram_Producto");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK__Orden__370733B6E70FCB69");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Orden_Usuarios");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__2085A9CF821D5EDD");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria_Producto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
