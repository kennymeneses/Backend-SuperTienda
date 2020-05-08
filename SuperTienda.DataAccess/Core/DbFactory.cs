using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.DataAccess.Core
{
    public class DbFactory : IDbFactory, IDisposable
    {

        private DataContext _dataContext;
        public DbFactory(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public DataContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }


        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                }
            }
            isDisposed = true;
        }

    }
}
