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

namespace SuperTienda.BusinessLayer.Manager.SubCategoriaManagement
{
    public class SubCategoriaManager : BusinessManager, ISubCategoriaManager
    {

        IRepository _repository;
        ILogger<ISubCategoriaManager> _logger;
        IUnitOfWork _unitOfwork;

        public SubCategoriaManager(IRepository repository, ILogger<ISubCategoriaManager> logger, IUnitOfWork unitOfWork) : base()
        {

            _repository = repository;
            _logger = logger;
            _unitOfwork = unitOfWork;

        }

        public IUnitOfWork UnitOfWork { get { return _unitOfwork; } }

        public DataQuery Search(DataQueryInput input)
        {
            DataQuery data = new DataQuery();
            SubCategoriaQueryInput queryInput = (SubCategoriaQueryInput)input;

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@tamanio", queryInput.tamanio),
                new SqlParameter("@pagina", queryInput.pagina)
            };
            data = _repository.ExecuteProcedureQuery(Consultas.DboSubCategoriaBuscar, sqlParams, Mensaje.SubCategoriaPlural);
            return data;
        }

        public SingleQuery SingleById(int id, int idSubCategoria)
        {
            SubCategoriaIndOutput subcategoria = new SubCategoriaIndOutput();

            subcategoria = _repository.ExecuteProcedureSingle<SubCategoriaIndOutput>(Consultas.DboSubCategoriaInd, id);
            if(subcategoria == null)
            {
                subcategoria = new SubCategoriaIndOutput
                {
                    apiMensaje = string.Format(Mensaje.NoExiste, Mensaje.SubCategoria), apiEstado = Status.Error
                };
            }
            else
            {

            }

            return subcategoria;
        }

        public CheckStatus Create(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            SubCategoriaInput input = (SubCategoriaInput)entity;

            SubCategoria subcategoria = new SubCategoria();

            subcategoria.NombreSubCategoria = input.nombreSubCategoria;
            subcategoria.IdCategoria = input.idCategoria;
            subcategoria.Estado = input.estado;

            try
            {
                _repository.Create<SubCategoria>(subcategoria);
                SaveChanges();
                checkstatus = new CheckStatus(subcategoria.Id, subcategoria.NombreSubCategoria, Status.Ok,
                    string.Format(Mensaje.Guardar, Mensaje.SubCategoria));
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
            SubCategoriaInput input = (SubCategoriaInput)entity;

            SubCategoria subcategoria = _repository.Single<SubCategoria>(p => p.Id == input.idSubCategoria);

            if(subcategoria != null)
            {
                subcategoria.NombreSubCategoria = input.nombreSubCategoria;
                subcategoria.IdCategoria = input.idCategoria;
                subcategoria.Estado = input.estado;
                subcategoria.Eliminado = false;
                try
                {
                    _repository.Update<SubCategoria>(subcategoria);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Guardar, Mensaje.SubCategoria));
                }
                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error, String.Format(Mensaje.NoExiste, Mensaje.SubCategoria));
            }
            return checkstatus;
        }

        public CheckStatus Delete(int id, int idSubCategoria)
        {
            CheckStatus checkstatus = null;
            SubCategoria subcategoria = _repository.Single<SubCategoria>(p => p.Id == id);

            if(subcategoria != null)
            {
                subcategoria.Eliminado = true;

                try
                {

                    _repository.Update<SubCategoria>(subcategoria);
                    SaveChanges();
                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Eliminar, Mensaje.SubCategoria));

                }
                catch (Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.SubCategoria));
            }
            return checkstatus;

        }

        public void SaveChanges()
        {

            _unitOfwork.SaveChanges();
        }
    }
}
