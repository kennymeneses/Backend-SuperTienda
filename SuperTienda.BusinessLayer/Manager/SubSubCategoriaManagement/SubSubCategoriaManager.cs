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

namespace SuperTienda.BusinessLayer.Manager.SubSubCategoriaManagement
{
    public class SubSubCategoriaManager : BusinessManager, ISubSubCategoriaManager
    {

        IRepository _repository;
        ILogger<ISubSubCategoriaManager> _logger;
        IUnitOfWork _unitOfwork;

        public SubSubCategoriaManager(IRepository repository, ILogger<ISubSubCategoriaManager> logger, IUnitOfWork unitOfWork) : base()
        {

            _repository = repository;
            _logger = logger;
            _unitOfwork = unitOfWork;

        }

        public IUnitOfWork UnitOfWork { get { return _unitOfwork; } }

        public DataQuery Search(DataQueryInput input)
        {
            DataQuery data = new DataQuery();
            SubSubCategoriaQueryInput queryInput = (SubSubCategoriaQueryInput)input;

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@tamanio", queryInput.tamanio),
                new SqlParameter("@pagina", queryInput.pagina)
            };
            data = _repository.ExecuteProcedureQuery(Consultas.DboSubSubCategoriaBuscar, sqlParams, Mensaje.SubSubCategoriaPlural);
            return data;
        }

        public SingleQuery SingleById(int id, int idSubSubCategoria)
        {

            SubSubCategoriaIndOutput subsubcategoria = new SubSubCategoriaIndOutput();

            subsubcategoria = _repository.ExecuteProcedureSingle<SubSubCategoriaIndOutput>(Consultas.DboSubSubCategoriaInd, id);
            if(subsubcategoria == null)
            {

                subsubcategoria = new SubSubCategoriaIndOutput
                {
                    apiMensaje = string.Format(Mensaje.NoExiste, Mensaje.SubSubCategoria), apiEstado = Status.Error
                };

            }
            else
            {

            }
            return subsubcategoria;

        }

        public CheckStatus Create(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            SubSubCategoriaInput input = (SubSubCategoriaInput)entity;

            SubSubCategoria subsubcategoria = new SubSubCategoria();
            subsubcategoria.NombreSubSubCategoria = input.nombreSubSubCategoria;
            subsubcategoria.IdCategoria = input.idCategoria;
            subsubcategoria.IdSubCategoria = input.idSubCategoria;

            try
            {
                _repository.Create<SubSubCategoria>(subsubcategoria);
                SaveChanges();
                checkstatus = new CheckStatus(subsubcategoria.Id, subsubcategoria.NombreSubSubCategoria, Status.Ok,
                    string.Format(Mensaje.Guardar, Mensaje.SubSubCategoria));
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
            SubSubCategoriaInput input = (SubSubCategoriaInput)entity;

            SubSubCategoria subsubcategoria = _repository.Single<SubSubCategoria>(p => p.Id == input.idSubSubCategoria);
            
            if(subsubcategoria != null)
            {

                subsubcategoria.NombreSubSubCategoria = input.nombreSubSubCategoria;
                subsubcategoria.IdCategoria = input.idCategoria;
                subsubcategoria.IdSubCategoria = input.idSubCategoria;
                subsubcategoria.Estado = input.estado;
                subsubcategoria.Eliminado = false;

                try
                {

                    _repository.Update<SubSubCategoria>(subsubcategoria);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Guardar, Mensaje.SubSubCategoria));

                }
                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.SubSubCategoria));
            }

            return checkstatus;
        }

        public CheckStatus Delete (int id, int idSubSubCategoria)
        {

            CheckStatus checkstatus = null;
            SubSubCategoria subsubcategoria = _repository.Single<SubSubCategoria>(p => p.Id == id);

            if( subsubcategoria != null)
            {

                subsubcategoria.Eliminado = true;

                try
                {
                    _repository.Update<SubSubCategoria>(subsubcategoria);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                         string.Format(Mensaje.Eliminar, Mensaje.SubSubCategoria));
                }
                catch (Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }

            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.SubSubCategoria));
            }
            return checkstatus;

        }

        public void SaveChanges()
        {

            _unitOfwork.SaveChanges();
        }

    }
}
