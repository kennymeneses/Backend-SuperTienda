using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class SubSubCategoriaInput : BaseInputEntity
    {
        public int idSubSubCategoria { get; set; }
        public string nombreSubSubCategoria { get; set; }
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public int estado { get; set; }

        public SubSubCategoriaInput()
        {
            idSubSubCategoria = 0;
            nombreSubSubCategoria = string.Empty;
            idCategoria = 0;
            idSubCategoria = 0;
            estado = 0;
        }

    }
}
