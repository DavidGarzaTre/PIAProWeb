using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_ram")]
    public partial class EspecsRam
    {
        [Key]
        public int IdProducto { get; set; }
        [StringLength(50)]
        public string Capacidad { get; set; } = null!;
        [StringLength(50)]
        public string Velocidad { get; set; } = null!;
        [StringLength(50)]
        public string Tecnologia { get; set; } = null!;
        [Column("Voltaje_Alimentacion")]
        [StringLength(50)]
        public string VoltajeAlimentacion { get; set; } = null!;
        [StringLength(50)]
        public string Latencia { get; set; } = null!;

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsRam")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
