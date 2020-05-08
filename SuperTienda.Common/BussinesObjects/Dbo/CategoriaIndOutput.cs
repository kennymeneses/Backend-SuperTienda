using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class CategoriaIndOutput : SingleQuery
    {

        public int id { get; set; }
        public string nombreCategoria { get; set; }
        public string fechaCreacion { get; set; }
        public int estado { get; set; }

        public CategoriaIndOutput()
        {
            id = 0;
            nombreCategoria = string.Empty;
            fechaCreacion = string.Empty;
            estado = 0;
        }
    }
}
