using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class RolInput : BaseInputEntity
    {
        public string codigoRol { get; set; }
        public string nombreRol { get; set; }
        
        public RolInput()
        {
            codigoRol = string.Empty;
            nombreRol = string.Empty;
        }
    }
}
