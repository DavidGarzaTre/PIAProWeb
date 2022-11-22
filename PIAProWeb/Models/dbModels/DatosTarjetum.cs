using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Datos_Tarjeta")]
    public partial class DatosTarjetum
    {
        [Key]
        [Column("Id_Tarjeta")]
        public int IdTarjeta { get; set; }
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("Numero_Tarjeta")]
        public int NumeroTarjeta { get; set; }
        [Column("Nombre_Propietario")]
        [StringLength(50)]
        public string NombrePropietario { get; set; } = null!;
        [Column("Fecha_Vencimiento", TypeName = "datetime")]
        public DateTime FechaVencimiento { get; set; }
        [Column("Numero_Seguridad")]
        public int NumeroSeguridad { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("DatosTarjeta")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
