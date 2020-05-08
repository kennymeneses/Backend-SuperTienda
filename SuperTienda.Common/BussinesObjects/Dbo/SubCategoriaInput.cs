using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class SubCategoriaInput : BaseInputEntity
    {
        public int idSubCategoria { get; set; }
        public string nombreSubCategoria { get; set; }
        public int idCategoria { get; set; }
        public int estado { get; set; }

        public SubCategoriaInput()
        {
            idSubCategoria = 0;
            nombreSubCategoria = string.Empty;
            idCategoria = 0;
            estado = 0;
        }

    }
}
