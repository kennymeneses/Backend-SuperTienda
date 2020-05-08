using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class SubCategoriaIndOutput: SingleQuery
    {

        public int idSubCategoria { get; set; }
        public string nombreSubCategoria { get; set; }
        public int idCategoria { get; set; }
        public string fechaCreacion { get; set; }
        public int estado { get; set; }

        public SubCategoriaIndOutput()
        {
            idSubCategoria = 0;
            nombreSubCategoria = string.Empty;
            idCategoria = 0;
            fechaCreacion = string.Empty;
            estado = 0;
        }
    }
}
