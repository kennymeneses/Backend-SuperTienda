using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class CategoriaInput : BaseInputEntity
    {
        public int id { get; set; }
        public string nombreCategoria { get; set; }
        public int estado { get; set; }

        public CategoriaInput()
        {
            id = 0;
            nombreCategoria = string.Empty;
            estado = 0;
        }

    }
}
