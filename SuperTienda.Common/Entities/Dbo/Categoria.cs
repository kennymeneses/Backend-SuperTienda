using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTienda.Common.Entities
{
    [Table("Categorias", Schema = "dbo")]
    public class Categoria : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCategoria")]
        public int Id { get; set; }

        [Column("NombreCategoria")]
        public string NombreCategoria { get; set; }

        [Column("Estado")]
        public int Estado { get; set; }


    }
}
