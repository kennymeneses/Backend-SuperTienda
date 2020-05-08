using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class SingleQuery
    {

        [NotMapped]
        public string apiEstado { get; set; }
        [NotMapped]
        public string apiMensaje { get; set; }


        public SingleQuery()
        {
            this.apiEstado = Status.Ok;
            this.apiMensaje = String.Empty;
        }

    }
}
