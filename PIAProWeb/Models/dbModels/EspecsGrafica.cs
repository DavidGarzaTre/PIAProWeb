using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_Graficas")]
    public partial class EspecsGrafica
    {
        [Key]
        public int IdProducto { get; set; }
        [StringLength(50)]
        public string Marca { get; set; } = null!;
        [StringLength(50)]
        public string Modelo { get; set; } = null!;
        [StringLength(70)]
        public string Chipset { get; set; } = null!;
        [Column("GPU")]
        [StringLength(70)]
        public string Gpu { get; set; } = null!;
        [Column("CUDA_Cores")]
        [StringLength(70)]
        public string CudaCores { get; set; } = null!;
        [StringLength(50)]
        public string Memoria { get; set; } = null!;
        [Column("Tipo_Memoria")]
        [StringLength(50)]
        public string TipoMemoria { get; set; } = null!;
        [Column("Frecuencia_Memoria")]
        [StringLength(50)]
        public string FrecuenciaMemoria { get; set; } = null!;
        [StringLength(50)]
        public string DirectX { get; set; } = null!;
        [StringLength(50)]
        public string Interfaz { get; set; } = null!;
        [Column("Salidas_Video")]
        [StringLength(100)]
        public string SalidasVideo { get; set; } = null!;

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsGrafica")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
