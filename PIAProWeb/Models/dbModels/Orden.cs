using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Orden")]
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        [Key]
        [Column("Id_Orden")]
        public int IdOrden { get; set; }
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("Fecha_Orden", TypeName = "datetime")]
        public DateTime FechaOrden { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Total { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Ordens")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdOrdenNavigation")]
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
