using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class UsuarioInput : BaseInputEntity
    {
        public int id { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string email { get; set; }

        public string contrasena { get; set; }
            
        public string imagenurl { get; set; }

        public int estado { get; set; }
                
        public UsuarioInput()
        {
            id = 0;
            nombres = string.Empty;
            apellidos = string.Empty;
            email = string.Empty;
            contrasena = string.Empty;
            imagenurl = string.Empty;
            estado = 0;
        }
    }
}
