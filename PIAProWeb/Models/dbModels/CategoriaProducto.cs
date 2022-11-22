using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Categoria_Producto")]
    [Index("Nombre", Name = "UQ__Categori__75E3EFCFF18DD025", IsUnique = true)]
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("Id_categoria")]
        public int IdCategoria { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(150)]
        public string? Descripcion { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
