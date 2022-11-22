using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        [Column("Id_Producto")]
        public int IdProducto { get; set; }
        [Column("Cantidad_Producto")]
        public int CantidadProducto { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("Carritos")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Carritos")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
