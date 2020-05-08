using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperTienda.Common.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            State = (int)EntityState.New;
            Eliminado = false;
        }

        [Column("Eliminado")]
        public bool Eliminado { get; set; }

        [NotMapped]
        public int State { get; set; }

        public enum EntityState
        {
            New = 1,
            Update = 2,
            Delete = 3,
            Ignore = 4
        }

    }
}
