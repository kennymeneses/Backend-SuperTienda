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
using SuperTienda.BusinessLayer.Manager.CategoriaManagement;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Core;
using SuperTienda.Common.Facade;
using SuperTienda.Common.Entities;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.ServiceApp.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : BaseController
    {

        ICategoriaManager _manager;
        ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaManager manager, ILogger<CategoriaController> logger) : base(manager, logger)
        {
            _manager = manager;
            _logger = logger;

        }


        [HttpGet]
        [ProducesResponseType(typeof(DataQuery), 200)]
        [ProducesResponseType(typeof(DataQuery), 404)]
        public IActionResult Get(string texto = "", int pagina = 0, int tamanio = 10)
        {

            try
            {

                CategoriaQueryInput input = new CategoriaQueryInput();
                if(texto==null)
                {
                    texto = "";
                }
                input.texto = texto;
                input.pagina = pagina;
                input.tamanio = tamanio;
                input.idUsuario = 0;
                DataQuery data = _manager.Search(input);
                CheckStatus ChekPermiso = new CheckStatus();
                if(data.apiEstado.Equals(Status.Error))
                {
                    return NotFound(data);
                }
                return Ok(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioIndOutput), 200)]
        [ProducesResponseType(typeof(UsuarioIndOutput), 404)]
        public IActionResult Get(int id)
        {
            try
            {
                CategoriaIndOutput data = (CategoriaIndOutput)_manager.SingleById(id, 0);

                if(data.apiEstado.Equals(Status.Error))
                {
                    return NotFound(data);
                }
                return Ok(data);


            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
}