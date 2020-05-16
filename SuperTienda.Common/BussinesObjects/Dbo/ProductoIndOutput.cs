using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;


namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class ProductoIndOutput : SingleQuery
    {

        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string fabricante { get; set; }
        public int anioFabricacion { get; set; }
        public int descuento { get; set; }
        public int stock { get; set; }
        public string imagenUrl { get; set; }
        public string nomcat { get; set; }
        public string nomsubcat { get; set; }
        public string nomsubsubcat { get; set; }
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public int idSubSubCategoria { get; set; }
        public string fechaCreacion { get; set; }
        public int estado { get; set; }


        public ProductoIndOutput()
        {
            id = 0;
            codigoProducto = string.Empty;
            nombreProducto = string.Empty;
            fabricante = string.Empty;
            anioFabricacion = 0;
            descuento = 0;
            stock = 0;
            imagenUrl = string.Empty;
            nomcat = string.Empty;
            nomsubcat = string.Empty;
            nomsubsubcat = string.Empty;
            idCategoria = 0;
            idSubCategoria = 0;
            idSubSubCategoria = 0;
            fechaCreacion = string.Empty;
            estado = 0;
        }
    }
}
