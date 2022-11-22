using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_CPU")]
    public partial class EspecsCpu
    {
        [Key]
        public int IdProducto { get; set; }
        [StringLength(50)]
        public string Marca { get; set; } = null!;
        [StringLength(50)]
        public string Modelo { get; set; } = null!;
        [StringLength(50)]
        public string Arquitectura { get; set; } = null!;
        [StringLength(50)]
        public string Generacion { get; set; } = null!;
        [StringLength(50)]
        public string Velocidad { get; set; } = null!;
        [StringLength(50)]
        public string Socket { get; set; } = null!;
        [StringLength(50)]
        public string Nucleos { get; set; } = null!;
        [Column("Grafico_Integrados")]
        [StringLength(50)]
        public string? GraficoIntegrados { get; set; }
        [Column("Frecuencia_de_Graficos")]
        [StringLength(50)]
        public string? FrecuenciaDeGraficos { get; set; }
        [Column("TDP")]
        public int Tdp { get; set; }
        [StringLength(50)]
        public string? Disipador { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsCpu")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
