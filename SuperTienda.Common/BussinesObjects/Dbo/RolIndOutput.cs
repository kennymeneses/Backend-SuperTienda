using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class RolIndOutput : SingleQuery
    {

        public int idRol { get; set; }
        public string codigoRol { get; set; }
        public string nombreRol { get; set; }
        public string fechaCreacion { get; set; }


        public RolIndOutput()
        {
            idRol = 0;
            codigoRol = string.Empty;
            nombreRol = string.Empty;
            fechaCreacion = string.Empty;
        }

    }
}
