using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;


namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class ProductoIndOutput : SingleQuery
    {

        public int idProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string fabricante { get; set; }
        public int anioFabricacion { get; set; }
        public int descuento { get; set; }
        public int stock { get; set; }
        public string imagenUrl { get; set; }
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public int idSubSubCategoria { get; set; }


        public ProductoIndOutput()
        {
            idProducto = 0;
            codigoProducto = string.Empty;
            nombreProducto = string.Empty;
            fabricante = string.Empty;
            anioFabricacion = 0;
            descuento = 0;
            stock = 0;
            imagenUrl = string.Empty;
            idCategoria = 0;
            idSubCategoria = 0;
            idSubSubCategoria = 0;
        }
    }
}
