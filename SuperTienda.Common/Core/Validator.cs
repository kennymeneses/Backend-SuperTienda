using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class Validator : Attribute
    {
        public int orden { get; set; }
        public bool obligatorio { get; set; }

        public Validator()
        {
            orden = 0;
            obligatorio = true;
        }
    }
}
