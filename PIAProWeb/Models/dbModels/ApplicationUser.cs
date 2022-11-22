using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PIAProWeb.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Carritos = new HashSet<Carrito>();
            DatosTarjeta = new HashSet<DatosTarjetum>();
            Ordens = new HashSet<Orden>();
        }

        
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(70)]
        public string Apellido { get; set; } = null!;
        
        [Column("Calle_Numero")]
        [StringLength(200)]
        public string CalleNumero { get; set; } = null!;
        [StringLength(50)]
        public string Estado { get; set; } = null!;
        [StringLength(50)]
        public string? Ciudad { get; set; }
        [Column("Codigo_Postal")]
        public int? CodigoPostal { get; set; }
        [StringLength(200)]
        public string? Referencias { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<DatosTarjetum> DatosTarjeta { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
