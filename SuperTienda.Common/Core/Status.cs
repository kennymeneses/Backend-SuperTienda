using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class Status
    {
        public static string Ok = "ok";
        public static string Error = "error";
        public static string Informacion = "informacion";
        public static string Advertencia = "advertencia";
        public static string Inautorizado = "inautorizado";

        public static string Pending = "Pendiente";
        public static string Active = "Activo";
        public static string Inactive = "Inactivo";

        public static string Crear = "Crear";
        public static string Editar = "Editar";
        public static string Eliminar = "Eliminar";

        public static string SinAcceso = "SinAcceso";
        public static string Eliminado = "Eliminado";

        public static string ApiEstado = "apiEstado";
        public static string ApiMensaje = "apiMensaje";




        public static int Activo = 1;
        public static int Inactivo = 2;
        public static int Bloqueado = 2;

        public static int TipoCarpetaAccesos = 1;
        public static int TipoCarpetaPersonal = 2;

        public static string TipoCarpeta = "Carpeta";
        public static string CrearByMesaPartes = "CrearByMesaPartes";

        public static int TextoContiene = 1;
        public static int TextoEmpieza = 2;
        public static int TextoTermine = 3;
        public static int TextoNoContiene = 4;

        public static int NumeroIgual = 1;
        public static int NumeroMayor = 2;
        public static int NumeroMenor = 3;
        public static int NumeroEntre = 4;
        public static int NumeroNoIgual = 5;

        public static int FechaIgual = 1;
        public static int FechaMayor = 2;
        public static int FechaMenor = 3;
        public static int FechaEntre = 4;
        public static int FechaNoIgual = 5;

        public static string Get = "get";
        public static string Post = "post";
        public static string Put = "put";
        public static string Delete = "delete";
    }
}
