using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class BaseEntityIPLog : BaseEntity
    {
        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
        [Column("IPCreacion")]
        public string IPCreacion { get; set; }

        [Column("FechaEdicion")]
        public DateTime? FechaEdicion { get; set; }
        [Column("IPEdicion")]
        public string IPEdicion { get; set; }
    }
}
