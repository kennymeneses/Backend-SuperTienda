using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class ProductoInput : BaseInputEntity
    {
        public int idProducto { get; set; }
        public string codigoproducto { get; set; }
        public string nombreproducto { get; set; }
        public string fabricante { get; set; }
        public int aniofabricacion { get; set; }
        public int descuento { get; set; }
        public int stock { get; set; }
        public int idcategoria { get; set; }
        public int idsubcategoria { get; set; }
        public int idsubsubcategoria { get; set; }
        public int estado { get; set; }

        public ProductoInput()
        {
            codigoproducto = string.Empty;
            nombreproducto = string.Empty;
            fabricante = string.Empty;
            aniofabricacion = 0;
            descuento = 0;
            stock = 0;
            idcategoria = 0;
            idsubcategoria = 0;
            idsubsubcategoria = 0;
            estado = 0;
        }

    }
}
