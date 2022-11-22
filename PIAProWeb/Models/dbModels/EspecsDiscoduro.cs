using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_discoduro")]
    public partial class EspecsDiscoduro
    {
        [Key]
        public int IdProducto { get; set; }
        [Column("Tipo_Disco")]
        [StringLength(100)]
        public string TipoDisco { get; set; } = null!;
        [StringLength(50)]
        public string Interfaz { get; set; } = null!;
        [StringLength(50)]
        public string Capacidad { get; set; } = null!;
        [StringLength(50)]
        public string? Velocidad { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsDiscoduro")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
