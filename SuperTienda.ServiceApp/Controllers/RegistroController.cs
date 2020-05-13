using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using SuperTienda.BusinessLayer.Manager.UsuarioManagement;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Core;
using SuperTienda.Common.Facade;
using SuperTienda.Common.Entities;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.ServiceApp.Controllers
{
    [Route("api/registro")]
    [ApiController]
    public class RegistroController : BaseController
    {

        IUsuarioManager _manager;
        ILogger<RegistroController> _logger;
        IRepository _repository;

        public RegistroController(IRepository repository, IUsuarioManager manager, ILogger<RegistroController> logger) : base(manager, logger)
        {
            _manager = manager;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CheckStatus),201)]
        [ProducesResponseType(typeof(CheckStatus),404)]
        public IActionResult Post([FromBody]UsuarioInput input)
        {
            try
            {
                CheckStatus checkStatus = null;

                if (ModelState.IsValid)
                {
                    checkStatus = _manager.Create(input);
                    if(checkStatus.apiEstado.Equals(Status.Error))
                    {
                        return StatusCode(422, checkStatus);
                    }
                    return StatusCode(201, checkStatus);
                }
                else
                {
                    checkStatus = new CheckStatus(Status.Error, Mensaje.InputInvalido);
                    return StatusCode(422, checkStatus);
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CheckStatus),200)]
        [ProducesResponseType(typeof(CheckStatus),422)]
        public IActionResult Put(int id,[FromBody]UsuarioInput input)
        {

            CheckStatus checkStatus = null;
            Usuario usuario = new Usuario();

            if(ModelState.IsValid)
            {
                try
                {
                    usuario = _repository.Single<Usuario>(p => p.Id == id);

                    usuario.Nombres = input.nombres;
                    usuario.Apellidos = input.apellidos;
                    usuario.Email = input.email;
                    usuario.Password = input.contrasena;
                    usuario.ImagenUrl = input.imagenurl;
                    usuario.Estado = input.estado;

                    checkStatus = new CheckStatus(Status.Ok, string.Format(Mensaje.Guardar, Mensaje.Usuario));

                    return StatusCode(200,checkStatus);
                }
                catch(Exception ex)
                {
                    checkStatus = new CheckStatus(Status.Error, ex.Message);
                    return StatusCode(422, checkStatus);
                }
            }
            else
            {
                checkStatus = new CheckStatus(Status.Error, Mensaje.InputInvalido);
                return StatusCode(422, checkStatus);
            }
        }

    }
}