using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperTienda.Common.Core;
using SuperTienda.DataAccess.Core;


namespace SuperTienda.DataAccess.Core
{
    public interface IRepository
    {

        IQueryable<T> All<T>() where T : class;
        void Create<T>(T TObject) where T : class;
        void Delete<T>(T TObject) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Update<T>(T TObject) where T : class;

        IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class;
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;

        void ExecuteProcedure(string procedureCommand, params SqlParameter[] sqlParams);
        void ExecuteProcedure(string procedureCommand, int id);
        IList<T> ExecuteProcedureQuery<T>(String procedureCommand, params SqlParameter[] sqlParams) where T : class;
        IList<T> ExecuteProcedureQuery<T>(String procedureCommand, int id) where T : class;

        DataQuery ExecuteProcedureQuery(String procedureCommand, DataQueryInput input, string entidadError);
        DataQuery ExecuteProcedureQuery(String procedureCommand, SqlParameter[] sqlParams, string entidadError);

        T ExecuteProcedureSingle<T>(String procedureCommand, int id) where T : class;
        T ExecuteProcedureSingle<T>(String procedureCommand, params SqlParameter[] sqlParams) where T : class;

        object ExecuteFuncion(string functionCommand, params SqlParameter[] sqlParams);
        object ExecuteProcedureScalar(string ExecuteProcedureScalar, SqlParameter[] parameters);

    }
}
