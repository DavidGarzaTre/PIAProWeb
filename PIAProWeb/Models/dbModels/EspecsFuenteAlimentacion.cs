using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_Fuente_Alimentacion")]
    public partial class EspecsFuenteAlimentacion
    {
        [Key]
        public int IdProducto { get; set; }
        [Column("Maxima_Potencia")]
        [StringLength(60)]
        public string MaximaPotencia { get; set; } = null!;
        [StringLength(80)]
        public string Ventilador { get; set; } = null!;
        [StringLength(60)]
        public string Conector { get; set; } = null!;
        [Column("Conectores_SATA")]
        [StringLength(50)]
        public string ConectoresSata { get; set; } = null!;
        [Column("Entrada_Voltaje")]
        [StringLength(50)]
        public string EntradaVoltaje { get; set; } = null!;

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsFuenteAlimentacion")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
