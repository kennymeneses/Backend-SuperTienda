using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Entities;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.BusinessLayer.Core;
using SuperTienda.Common.Core;
using SuperTienda.DataAccess;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.BusinessLayer.Manager.CategoriaManagement
{
    public class CategoriaManager : BusinessManager, ICategoriaManager
    {

        IRepository _repository;
        ILogger<CategoriaManager> _logger;
        IUnitOfWork _unitOfwork;

        public CategoriaManager(IRepository repository, ILogger<CategoriaManager> logger, IUnitOfWork unitOfWork) : base()
        {

            _repository = repository;
            _logger = logger;
            _unitOfwork = unitOfWork;

        }

        public IUnitOfWork UnitOfWork { get { return _unitOfwork; } }

        public DataQuery Search(DataQueryInput input)
        {

            DataQuery data = new DataQuery();
            CategoriaQueryInput queryInput = (CategoriaQueryInput)input;

            SqlParameter[] sqlParams = 
                { 
                new SqlParameter("@tamanio", queryInput.tamanio),
                new SqlParameter("@pagina", queryInput.pagina)
            };

            data = _repository.ExecuteProcedureQuery(Consultas.DboCategoriaBuscar, sqlParams, Mensaje.CategoriaPlural);
            return data;
        }

        public SingleQuery SingleById(int id, int idCategoria)
        {

            CategoriaIndOutput categoria = new CategoriaIndOutput();

            categoria = _repository.ExecuteProcedureSingle<CategoriaIndOutput>(Consultas.DboCategoriaInd, id);

            if(categoria == null)
            {

                categoria = new CategoriaIndOutput
                {
                    apiMensaje = string.Format(Mensaje.NoExiste, Mensaje.Categoria), apiEstado = Status.Error
                };

            }
            else
            {

            }

            return categoria;
        }

        public CheckStatus Create(BaseInputEntity entity)
        {

            CheckStatus checkstatus = null;
            CategoriaInput input = (CategoriaInput)entity;

            Categoria categoria = new Categoria();
            categoria.NombreCategoria = input.nombreCategoria;
            categoria.Estado = input.estado;

            try
            {
                _repository.Create<Categoria>(categoria);
                SaveChanges();

                checkstatus = new CheckStatus(categoria.Id, categoria.NombreCategoria, Status.Ok,
                    string.Format(Mensaje.Guardar, Mensaje.Categoria));
            }
            catch(Exception ex)
            {
                checkstatus = new CheckStatus(Status.Error, ex.Message);
            }
            return checkstatus;
        }

        public CheckStatus Update(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            CategoriaInput input = (CategoriaInput)entity;

            Categoria categoria = _repository.Single<Categoria>(p => p.Id == input.id);

            if(categoria != null)
            {
                categoria.NombreCategoria = input.nombreCategoria;
                categoria.Eliminado = false;
                try
                {

                    _repository.Update<Categoria>(categoria);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Guardar, Mensaje.Categoria));
                }
                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.Categoria));
            }

            return checkstatus;
        }

        public CheckStatus Delete(int id, int idCategoria)
        {
            CheckStatus checkstatus = null;
            Categoria categoria = _repository.Single<Categoria>(p => p.Id == id);

            if(categoria != null)
            {
                categoria.Eliminado = true;
                try
                {
                    
                    _repository.Update<Categoria>(categoria);
                    SaveChanges();
                    checkstatus = new CheckStatus(Status.Ok, 
                        string.Format(Mensaje.Eliminar, Mensaje.Categoria));
                }

                catch (Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.Categoria));
            }

            return checkstatus;
            
        }

        public void SaveChanges()
        {

            _unitOfwork.SaveChanges();
        }

    }
}
