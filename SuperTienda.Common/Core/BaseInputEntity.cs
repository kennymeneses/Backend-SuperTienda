using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class BaseInputEntity
    {
        [NotMapped]
        public int idUsuario { get; set; }
        [NotMapped]
        public string usuario { get; set; }
        [NotMapped]
        public string ip { get; set; }

        public BaseInputEntity()
        {

            idUsuario = 0;
            usuario = string.Empty;
            ip = string.Empty;

        }
    }
}
