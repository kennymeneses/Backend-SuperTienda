using SuperTienda.Common.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class BaseEntityLog : BaseEntity
    {
        [Column("Fecha_Creacion")]
        public DateTime? Fecha_Creacion { get; set; }
        [Column("Fecha_Edicion")]
        public DateTime? Fecha_Edicion { get; set; }

        public BaseEntityLog()
        {
            DateTime fechaActual = new DateTime();
            try
            {
                fechaActual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(Mensaje.TimeZone));
            }
            catch
            {
                fechaActual = DateTime.Now;
            }
            Fecha_Creacion = fechaActual;
            Fecha_Edicion = fechaActual;
        }
    }
}
