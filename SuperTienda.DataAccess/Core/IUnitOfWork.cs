using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTienda.DataAccess.Core
{
    public interface IUnitOfWork
    {

        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        void SaveChanges();

    }
}
