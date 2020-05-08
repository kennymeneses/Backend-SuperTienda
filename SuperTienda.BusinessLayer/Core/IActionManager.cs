using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.BusinessLayer.Core
{
    public interface IActionManager
    {
        IUnitOfWork UnitOfWork { get; }
        DataQuery Search(DataQueryInput input);
        SingleQuery SingleById(int id, int idUsuario);
        CheckStatus Create(BaseInputEntity entity);
        CheckStatus Update(BaseInputEntity entity);
        CheckStatus Delete(int id, int idUsuario);

        void SaveChanges();
    }
}
