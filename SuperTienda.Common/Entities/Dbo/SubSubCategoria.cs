using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTienda.Common.Entities
{

    [Table("SubSubCategorias", Schema = "dbo")]
    public class SubSubCategoria : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdSubSubCategoria")]
        public int Id { get; set; }

        [Column("NombreSubSubCategoria")]
        public string NombreSubSubCategoria { get; set; }

        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        [Column("IdSubCategoria")]
        public int IdSubCategoria { get; set; }

        [Column("Estado")]
        public int Estado { get; set; }
    }
}
