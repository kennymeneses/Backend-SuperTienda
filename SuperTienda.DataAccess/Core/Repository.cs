using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using SuperTienda.Common.Core;
using SuperTienda.Common.Configuration;
using SuperTienda.DataAccess.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Data.Common;



namespace SuperTienda.DataAccess.Core
{
    public class Repository : IRepository
    {

        DataContext _context;
        public Repository(IDbFactory dbFactory)
        {
            _context = dbFactory.GetDataContext;
        }


        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public T Single<T>(Expression <Func<T,bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }


        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _context.Set<T>().Where<T>(filter).AsQueryable() : _context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual void Create<T>(T TObject) where T : class
        {

            string codigo = string.Empty;
            Type tipo = TObject.GetType();
            PropertyInfo propCodigo = tipo.GetProperty("codigo");

            if(propCodigo != null)
            {

                string entidad = "";
                var nombre = typeof(T).Name;

                Type type = typeof(EntidadNomenclatura);

                foreach (FieldInfo field in type.GetFields())
                {
                    entidad = field.GetValue(null) as string;
                }

                if (!String.IsNullOrEmpty(entidad))
                {
                    SqlParameter[] sqlParams = { new SqlParameter("@entidad", entidad) };
                    codigo = (string)ExecuteProcedureScalar(Consultas.ConCodigoGenerar, sqlParams);
                    propCodigo.SetValue(TObject, codigo);
                }

            }

            var newEntry = _context.Set<T>().Add(TObject);
        }

        public virtual void Delete<T>(T TObject) where T : class
        {
            _context.Set<T>().Remove(TObject);
        }

        public virtual void Update<T>(T TObject) where T : class
        {
            try
            {
                var entry = _context.Entry(TObject);
                _context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete<T>(Expression<Func<T,bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach(var obj in objects)
            {
                _context.Set<T>().Remove(obj);
            }
                
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }

        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();

            cmd.CommandText = procedureCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(sqlParams);
            _context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
            _context.Database.CloseConnection();
        }

        public virtual void ExecuteProcedure(String procedureCommand, int id)
        {

            SqlParameter[] sqlParams = { new SqlParameter("@id", id) };

            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _context.Database.OpenConnection();
                cmd.ExecuteNonQuery();
            _context.Database.CloseConnection();

        }

        public virtual IList<T> ExecuteProcedureQuery<T>(String procedureCommnad, int id) where T : class
        {

            SqlParameter[] parameters = { new SqlParameter("@id", id) };
            return ExecuteProcedureQuery<T>(procedureCommnad, parameters);
        }

        public virtual IList<T> ExecuteProcedureQuery<T>(String procedureCommand, params SqlParameter[] sqlParams) where T : class
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddRange(sqlParams);
            _context.Database.OpenConnection();
            DbDataReader dr = cmd.ExecuteReader();

            var objList = new List<T>();
            var props = typeof(T).GetFilteredProperties();

            var colMapping = dr.GetColumnSchema()
              .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
              .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val =
                          dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            _context.Database.CloseConnection();
            return objList;
        }

        public virtual DataQuery ExecuteProcedureQuery(String procedureCommand, DataQueryInput input, string entidadError)
        {
            SqlParameter OutputParam = new SqlParameter("@total", SqlDbType.Int);
            OutputParam.Direction = ParameterDirection.InputOutput;
            OutputParam.Value = 0;
            SqlParameter[] parameters =
             {
                new SqlParameter("@texto",input.texto),
                new SqlParameter("@pagina", input.pagina),
                OutputParam
            };

            DataQuery data = new DataQuery();

            int total = 0;
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddRange(parameters);
            _context.Database.OpenConnection();

            SqlParameter return_Value = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            return_Value.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(return_Value);

            IList<IDictionary<string, object>> objDict = new List<IDictionary<string, object>>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dictionary<string, object> objFilaDicy = new Dictionary<string, object>();

                    objFilaDicy = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);
                    objDict.Add(objFilaDicy);
                }
            }

            /* Output and return values are not available until here */
            if (OutputParam.Value != DBNull.Value)
            {
                total = Convert.ToInt32(OutputParam.Value);
            }

            if (objDict.Count != 0)
            {
                data.data = objDict;
                data.total = total;
            }
            else
            {
                data.apiEstado = Status.Error;
                if (entidadError != null && String.IsNullOrEmpty(entidadError))
                {
                    data.apiMensaje = Mensaje.NoExisteDefecto;
                }
                else
                {
                    data.apiMensaje = String.Format(Mensaje.NoExiste, entidadError);
                }
            }
            _context.Database.CloseConnection();
            return data;
        }

        public virtual DataQuery ExecuteProcedureQuery(string procedureCommand, SqlParameter[] sqlParams, string entidadError)
        {
            SqlParameter OutputParam = new SqlParameter("@total", SqlDbType.Int);
            OutputParam.Direction = ParameterDirection.InputOutput;
            OutputParam.Value = 0;


            sqlParams = sqlParams.Append(OutputParam).ToArray();

            DataQuery data = new DataQuery();

            int total = 0;
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandTimeout = 3600;

            int tiempoEspera = 0;

            if (Mensaje.TiempoEsperaBuscador != "")
            {
                tiempoEspera = Convert.ToInt32(Mensaje.TiempoEsperaBuscador);

            }

            cmd.CommandTimeout = tiempoEspera;

            cmd.Parameters.AddRange(sqlParams);

            _context.Database.OpenConnection();

            //list = connection.Query<T>(sql,
            //       oParams,
            //       commandType: CommandType.StoredProcedure, commandTimeout: 3600).AsList();

            SqlParameter return_Value = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            return_Value.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(return_Value);

            IList<IDictionary<string, object>> objDict = new List<IDictionary<string, object>>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dictionary<string, object> objFilaDicy = new Dictionary<string, object>();

                    objFilaDicy = Enumerable.Range(0, dr.FieldCount).ToDictionary(dr.GetName, dr.GetValue);
                    objDict.Add(objFilaDicy);
                }
            }

            /* Output and return values are not available until here */
            if (OutputParam.Value != DBNull.Value)
            {
                total = Convert.ToInt32(OutputParam.Value);
            }

            if (objDict.Count != 0)
            {
                data.data = objDict;
                data.total = total;
            }
            else
            {
                data.apiEstado = Status.Error;
                if (entidadError != null && String.IsNullOrEmpty(entidadError))
                {
                    data.apiMensaje = Mensaje.NoExisteDefecto;
                }
                else
                {
                    data.apiMensaje = String.Format(Mensaje.NoExiste, entidadError);
                }
            }

            _context.Database.CloseConnection();
            return data;
        }

        public virtual T ExecuteProcedureSingle<T>(String procedureCommand, int id) where T : class
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@id", id)
            };
            return ExecuteProcedureSingle<T>(procedureCommand, parameters);
        }

        public virtual T ExecuteProcedureSingle<T>(String procedureCommand, params SqlParameter[] sqlParams) where T : class
        {
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procedureCommand;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParams);

            int tiempoEspera = 0;

            if (Mensaje.TiempoEsperaBuscador != "")
            {
                tiempoEspera = Convert.ToInt32(Mensaje.TiempoEsperaBuscador);

            }
            cmd.CommandTimeout = tiempoEspera;

            _context.Database.OpenConnection();
            var dr = cmd.ExecuteReader();

            T obj = Activator.CreateInstance<T>();
            var props = typeof(T).GetFilteredProperties();
            Type tipo = obj.GetType();
            var colMapping = dr.GetColumnSchema()
              .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
              .ToDictionary(key => key.ColumnName.ToLower());


            if (dr.Read() && dr.FieldCount != 0)
            {
                foreach (var prop in props)
                {
                    var val =
                            dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                    prop.SetValue(obj, val == DBNull.Value ? null : val);
                }
            }
            else
            {
                obj = null;
            }

            while (dr.NextResult()) { /* ignore subsequent result sets */ }
            _context.Database.CloseConnection();
            return obj;
        }

        public virtual object ExecuteFuncion(string functionCommand, params SqlParameter[] sqlParams)
        {
            string sql = "";

            if (sqlParams.Length == 0)
            {
                sql = string.Format("select dbo.{0}()", functionCommand);
            }
            else
            {
                string nombreParamatros = "";
                foreach (var parametro in sqlParams)
                {
                    nombreParamatros += parametro.ParameterName + ",";
                }

                nombreParamatros = nombreParamatros.Substring(0, nombreParamatros.Length - 1);
                sql = string.Format("select dbo.{0}({1})", functionCommand, nombreParamatros);
            }

            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(sqlParams);
            _context.Database.OpenConnection();

            var scalar = cmd.ExecuteScalar();
            _context.Database.CloseConnection();

            return scalar;
        }

        public virtual object ExecuteProcedureScalar(string procedureCommand, params SqlParameter[] sqlParams)
        {

            string sql = "";

            if (sqlParams.Length == 0)
            {
                sql = string.Format(procedureCommand);
            }
            else
            {
                string nombreParamatros = "";
                foreach (var parametro in sqlParams)
                {
                    nombreParamatros += parametro.ParameterName + ",";
                }

                nombreParamatros = nombreParamatros.Substring(0, nombreParamatros.Length - 1);
                sql = string.Format("{0}  {1}", procedureCommand, nombreParamatros);
            }

            var cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(sqlParams);
            _context.Database.OpenConnection();

            var scalar = cmd.ExecuteScalar();
            _context.Database.CloseConnection();

            return scalar;

        }


    }






    public static class TypeExtensions
        {
            public static PropertyInfo[] GetFilteredProperties(this Type type)
            {
                return type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(NotMappedAttribute), true).Length == 0).ToArray();
            }
        }
    
}
