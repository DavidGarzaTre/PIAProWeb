using System.ComponentModel.DataAnnotations;

namespace PIAProWeb.Models.DTO{
    public class ProductoUpdateDTO
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        [StringLength(120)]
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioProducto { get; set; }
        [StringLength(300)]
        public string Descripcion { get; set; } = null!;
        public IFormFile? ImagenProducto { get; set; } = null!;
        [StringLength(50)]
        public string? Imagen { get; set; }
        public string StockProducto { get; set; } = null!;
    }
}
