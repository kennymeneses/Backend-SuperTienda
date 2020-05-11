using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.BussinesObjects.Dbo
{
    public class LoginInput
    {
        public string correo { get; set; }
        public string contrasena { get; set; }

        public LoginInput()
        {
            correo = string.Empty;
            contrasena = string.Empty;
        }
    }
}
