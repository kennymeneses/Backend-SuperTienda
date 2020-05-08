using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class DataQuery
    {
        public IList<IDictionary<string, object>> data { get; set; }
        public string apiEstado { get; set; }
        public string apiMensaje { get; set; }
        public int total { get; set; }

        public DataQuery()
        {
            data = new List<IDictionary<string, object>>();
            apiEstado = Status.Ok;
            apiMensaje = String.Empty;
            total = 0;
        }
    }
}
