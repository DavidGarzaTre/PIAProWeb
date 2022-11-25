using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIAProWeb.Models.DTO
{
    public class ProductoCreateDTO
    {
        public int IdCategoria { get; set; }
        [StringLength(120)]
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioProducto { get; set; }
        [StringLength(300)]
        public string Descripcion { get; set; } = null!;
        public IFormFile? ImagenProducto { get; set; }=null!;
        [StringLength(50)]
        public string StockProducto { get; set; } = null!;
        [StringLength(50)]

        //SpecsCPU
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

        //Specs Disco Duro
        [Column("Tipo_Disco")]
        [StringLength(100)]
        public string TipoDisco { get; set; } = null!;
        [StringLength(50)]
        public string Interfaz { get; set; } = null!;
        [StringLength(50)]
        public string Capacidad { get; set; } = null!;
    }
}
