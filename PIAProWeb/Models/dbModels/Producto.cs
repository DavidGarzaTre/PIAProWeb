using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        [Key]
        [Column("Id_Producto")]
        public int IdProducto { get; set; }
        [Column("Id_Categoria")]
        public int IdCategoria { get; set; }
        [Column("Nombre_Producto")]
        [StringLength(120)]
        public string NombreProducto { get; set; } = null!;
        [Column("Precio_Producto", TypeName = "decimal(11, 2)")]
        public decimal PrecioProducto { get; set; }
        [StringLength(300)]
        public string Descripcion { get; set; } = null!;
        [Column("Imagen_Producto")]
        public string ImagenProducto { get; set; } = null!;
        [Column("Stock_Producto")]
        [StringLength(50)]
        public string StockProducto { get; set; } = null!;

        [ForeignKey("IdCategoria")]
        [InverseProperty("Productos")]
        public virtual CategoriaProducto IdCategoriaNavigation { get; set; } = null!;
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsCpu? EspecsCpu { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsDiscoduro? EspecsDiscoduro { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsFuenteAlimentacion? EspecsFuenteAlimentacion { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsGrafica? EspecsGrafica { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsPlacaMadre? EspecsPlacaMadre { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual EspecsRam? EspecsRam { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdArticuloNavigation")]
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}