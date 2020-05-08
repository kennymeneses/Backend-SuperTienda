using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SuperTienda.DataAccess.Core;


namespace SuperTienda.DataAccess.Core
{
    public interface IDbFactory
    {
        
        DataContext GetDataContext { get; }

    }
}
