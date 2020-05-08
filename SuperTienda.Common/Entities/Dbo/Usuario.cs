using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTienda.Common.Entities
{
    [Table("Usuario", Schema ="dbo")]
    public class Usuario : BaseEntityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuario")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Contrasena")]
        public string Password { get; set; }

        [Column("ImagenUrl")]
        public string ImagenUrl { get; set; }

        [Column("Estado")]
        public int Estado { get; set; }
    }
}
