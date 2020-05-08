using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTienda.Common.Entities
{
    [Table("Productos", Schema = "dbo")]
    public class Producto : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("CodigoProducto")]
        public string CodigoProducto { get; set; }

        [Column("NombreProducto")]
        public string NombreProducto { get; set; }

        [Column("Fabricante")]
        public string Fabricante { get; set; }

        [Column("ImagenUrl")]
        public string ImagenUrl { get; set; }

        [Column("AnioFabricacion")]
        public int AnioFabricacion { get; set; }

        [Column("Descuento")]
        public int Descuento { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        [Column("IdSubCategoria")]
        public int IdSubCategoria { get; set; }

        [Column("IdSubSubCategoria")]
        public int IdSubSubCategoria { get; set; }

        [Column("Estado")]
        public int Estado { get; set; }
    }
}
