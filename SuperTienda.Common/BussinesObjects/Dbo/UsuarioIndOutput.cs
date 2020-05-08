using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class UsuarioIndOutput : SingleQuery
    {

        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string imagenUrl { get; set; }
        public string fecha_Creacion { get; set; }
        public int estado { get; set; }


        public UsuarioIndOutput()
        {
            id = 0;
            nombres = string.Empty;
            apellidos = string.Empty;
            email = string.Empty;
            contrasena = string.Empty;
            imagenUrl = string.Empty;
            fecha_Creacion = string.Empty;
            estado = 0;
        }
    }
}
