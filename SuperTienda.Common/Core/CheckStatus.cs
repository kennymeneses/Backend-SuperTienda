using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class CheckStatus
    {
        public int id { set; get; }
        public string codigo { set; get; }
        public string apiEstado { get; set; }
        public string apiMensaje { get; set; }

        public CheckStatus(string apiEstado, string apiMensaje)
        {
            id = 0;
            codigo = string.Empty;
            this.apiEstado = apiEstado;
            this.apiMensaje = apiMensaje;

        }

        public CheckStatus()
        {
            id = 0;
            codigo = string.Empty;
            apiEstado = Status.Error;
            apiMensaje = string.Empty;
        }

        public CheckStatus(int id, string codigo, string apiEstado, string apiMensaje)
        {
            this.id = id;
            this.codigo = codigo;
            this.apiEstado = apiEstado;
            this.apiMensaje = apiMensaje;
        }
    }
}
