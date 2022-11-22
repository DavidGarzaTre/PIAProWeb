using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Especs_PlacaMadre")]
    public partial class EspecsPlacaMadre
    {
        [Key]
        public int IdProducto { get; set; }
        [StringLength(50)]
        public string Marca { get; set; } = null!;
        [StringLength(50)]
        public string Modelo { get; set; } = null!;
        [Column("Marca_Proceesador")]
        [StringLength(60)]
        public string MarcaProceesador { get; set; } = null!;
        [Column("Procesador_Compatibles")]
        [StringLength(200)]
        public string ProcesadorCompatibles { get; set; } = null!;
        [Column("Modelo_Chipset")]
        [StringLength(50)]
        public string ModeloChipset { get; set; } = null!;
        [Column("Tipo_MemoriaDDR")]
        [StringLength(50)]
        public string TipoMemoriaDdr { get; set; } = null!;
        [Column("Ranuras_Memoria")]
        [StringLength(50)]
        public string RanurasMemoria { get; set; } = null!;
        [Column("Maxima_Memoria")]
        [StringLength(50)]
        public string MaximaMemoria { get; set; } = null!;
        [Column("Arquitectura_Memoria")]
        [StringLength(50)]
        public string ArquitecturaMemoria { get; set; } = null!;
        [Column("Tipo_Ranura_Expansion")]
        [StringLength(60)]
        public string? TipoRanuraExpansion { get; set; }
        [Column("Entradas_Almacenamiento")]
        [StringLength(50)]
        public string EntradasAlmacenamiento { get; set; } = null!;
        [Column("ENtradas_Video")]
        [StringLength(150)]
        public string EntradasVideo { get; set; } = null!;
        [Column("Chipset_Audio")]
        [StringLength(60)]
        public string ChipsetAudio { get; set; } = null!;
        [Column("Puerto_Red")]
        [StringLength(70)]
        public string PuertoRed { get; set; } = null!;
        [Column("Puertos_Usb_traseros")]
        public int PuertosUsbTraseros { get; set; }
        [Column("Puertos_HDMI_traseros")]
        public int PuertosHdmiTraseros { get; set; }
        [Column("Puertos_DisplayPort_traseros")]
        public int PuertosDisplayPortTraseros { get; set; }
        [Column("Puertos_red_traseros")]
        public int PuertosRedTraseros { get; set; }
        [Column("Puertos_audio_traseros")]
        public int PuertosAudioTraseros { get; set; }
        [Column("Conector_24pin_Interno")]
        public int Conector24pinInterno { get; set; }
        [Column("Conector_12v8pin_Interno")]
        public int Conector12v8pinInterno { get; set; }
        [Column("Conector_Sata_Interno")]
        public int ConectorSataInterno { get; set; }
        [Column("Conector_M2_Interno")]
        public int ConectorM2Interno { get; set; }
        [Column("Conector_cpufan_Interno")]
        public int ConectorCpufanInterno { get; set; }
        [Column("Conector_tpm_Interno")]
        public int ConectorTpmInterno { get; set; }
        [Column("Especificacion_Extra")]
        [StringLength(300)]
        public string? EspecificacionExtra { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("EspecsPlacaMadre")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
