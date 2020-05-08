using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuperTienda.Common.Entities
{

    [Table("SubCategorias", Schema = "dbo")]
    public class SubCategoria : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdSubCategoria")]
        public int Id { get; set; }

        [Column("NombreSubCategoria")]
        public string NombreSubCategoria { get; set; }

        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        [Column("Estado")]
        public int Estado { get; set; }


    }
}
