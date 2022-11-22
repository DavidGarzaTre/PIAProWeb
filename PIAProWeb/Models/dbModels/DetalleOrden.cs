using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Detalle_Orden")]
    public partial class DetalleOrden
    {
        [Key]
        [Column("Id_Orden")]
        public int IdOrden { get; set; }
        [Key]
        [Column("Id_Articulo")]
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("IdArticulo")]
        [InverseProperty("DetalleOrdens")]
        public virtual Producto IdArticuloNavigation { get; set; } = null!;
        [ForeignKey("IdOrden")]
        [InverseProperty("DetalleOrdens")]
        public virtual Orden IdOrdenNavigation { get; set; } = null!;
    }
}
