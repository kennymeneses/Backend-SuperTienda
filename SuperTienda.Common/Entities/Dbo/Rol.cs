using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuperTienda.Common.Entities
{
    [Table("Rol", Schema ="dbo")]
    public class Rol : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("IdRol")]
        public int Id { get; set; }

        [Column ("CodigoRol")]
        public string Codigo { get; set; }

        [Column ("NombreRol")]
        public string NombreRol { get; set; }


    }
}
