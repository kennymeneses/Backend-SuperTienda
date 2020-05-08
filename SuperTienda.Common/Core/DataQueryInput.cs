using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class DataQueryInput
    {
        public string texto { get; set; }
        public int pagina { get; set; }
        public int tamanio { get; set; }
        public int idUsuario { get; set; }
        public int idSubSubCategoria { get; set; }

        public DataQueryInput()
        {
            texto = string.Empty;
            pagina = 1;
            tamanio = 0;
            idUsuario = 0;
            idSubSubCategoria = 0;
        }

        public DataQueryInput(string texto, int pagina, int idUsuario, int idSubSubCategoria)
        {
            this.texto = texto;
            this.pagina = pagina;
            this.idUsuario = idUsuario;
            this.idSubSubCategoria = idSubSubCategoria;
        }
    }
}
