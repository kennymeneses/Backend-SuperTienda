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

namespace SuperTienda.BusinessLayer.Manager.UsuarioManagement
{
    public class UsuarioManager : BusinessManager, IUsuarioManager
    {

        IRepository _repository;
        ILogger<UsuarioManager> _logger;
        IUnitOfWork _unitOfwork;

        public UsuarioManager(IRepository repository, ILogger<UsuarioManager> logger, IUnitOfWork unitOfWork) :base()
        {

            _repository = repository;
            _logger = logger;
            _unitOfwork = unitOfWork;

        }

        public IUnitOfWork UnitOfWork { get { return _unitOfwork;  } }

        public DataQuery Search(DataQueryInput input)
        {
            DataQuery data = new DataQuery();
            UsuarioQueryInput queryInput = (UsuarioQueryInput)input;

            SqlParameter[] sqlParams =
                {
                new SqlParameter("@tamanio", queryInput.tamanio),
                new SqlParameter("@pagina", queryInput.pagina)                
            };

            data = _repository.ExecuteProcedureQuery(Consultas.DboUsuarioBuscar, sqlParams, Mensaje.UsuarioPlural);

            return data;
        }

        public SingleQuery SingleById(int id, int idUsuario)
        {

            UsuarioIndOutput usuario = new UsuarioIndOutput();

            usuario = _repository.ExecuteProcedureSingle<UsuarioIndOutput>(Consultas.DboUsuarioInd, id);
            if (usuario ==null)
            {

                usuario = new UsuarioIndOutput
                {
                    apiMensaje = string.Format(Mensaje.NoExiste, Mensaje.Usuario), apiEstado= Status.Error
                };

            }

            //else
            //{
                
            //}

            return usuario;
        }

        public CheckStatus Create(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            UsuarioInput input = (UsuarioInput)entity;

            Usuario usuario = new Usuario();

            usuario.Nombres = input.nombres;
            usuario.Apellidos = input.apellidos;
            usuario.Email = input.email;
            usuario.Password = input.contrasena;
            usuario.ImagenUrl = input.imagenurl;
            usuario.Estado = input.estado;


            try
            {
                _repository.Create<Usuario>(usuario);
                SaveChanges();

                checkstatus = new CheckStatus(usuario.Id, usuario.Nombres, Status.Ok,
                    string.Format(Mensaje.Guardar, Mensaje.Usuario));
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
            UsuarioInput input = (UsuarioInput)entity;

            Usuario usuario = _repository.Single<Usuario>(p => p.Id == input.id);

            if (usuario != null)
            {
                usuario.Nombres = input.nombres;
                usuario.Apellidos = input.apellidos;
                usuario.Email = input.email;
                usuario.ImagenUrl = input.imagenurl;
                usuario.Estado = input.estado;
                usuario.Eliminado = false;

                try
                {
                    _repository.Update<Usuario>(usuario);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok, string.Format(Mensaje.Guardar, Mensaje.Usuario));
                }

                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }

            else
            {
                checkstatus = new CheckStatus(Status.Error, String.Format(Mensaje.NoExiste, Mensaje.Usuario));
            }

            return checkstatus;
        }

        public CheckStatus Delete(int id, int idUsuario)
        {

            CheckStatus checkstatus = null;
            Usuario usuario = _repository.Single<Usuario>(p => p.Id == id);

            if(usuario != null)
            {
                usuario.Eliminado = true;

                try
                {
                    _repository.Update<Usuario>(usuario);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok, string.Format(Mensaje.Eliminar, Mensaje.Usuario));
                }

                catch (Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error, String.Format(Mensaje.NoExiste, Mensaje.Usuario));                 
            }

            return checkstatus;


        }

        public void SaveChanges()
        {
            _unitOfwork.SaveChanges();
        }
    }
}
