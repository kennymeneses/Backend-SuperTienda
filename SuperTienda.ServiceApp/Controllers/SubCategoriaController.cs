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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SuperTienda.BusinessLayer.Manager.SubCategoriaManagement;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Core;
using SuperTienda.Common.Facade;
using SuperTienda.Common.Entities;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.ServiceApp.Controllers
{
    [Route("api/subcategorias")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubCategoriaController : BaseController
    {

        ISubCategoriaManager _manager;
        ILogger<SubCategoriaController> _logger;

        public SubCategoriaController(ISubCategoriaManager manager, ILogger<SubCategoriaController> logger) : base(manager, logger)
        {

            _manager = manager;
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(typeof(DataQuery), 200)]
        [ProducesResponseType(typeof(DataQuery), 404)]
        public IActionResult Get(string texto = "", int pagina = 0,int tamanio =0)
        {
            try
            {
                SubCategoriaQueryInput input = new SubCategoriaQueryInput();
                if(texto==null)
                {
                    texto = "";
                }
                input.texto = texto ;
                input.pagina = pagina;
                input.tamanio = tamanio;
                input.idUsuario = 0;
                DataQuery data = _manager.Search(input);
                CheckStatus chekStatus = new CheckStatus();
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
        [ProducesResponseType(typeof(SubCategoriaIndOutput), 200)]
        [ProducesResponseType(typeof(SubCategoriaIndOutput), 404)]
        public IActionResult Get(int id)
        {
            
            try
            {
                SubCategoriaIndOutput data = (SubCategoriaIndOutput)_manager.SingleById(id, 0);

                if (data.apiEstado.Equals(Status.Error))
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
        
        [HttpPost]
        [ProducesResponseType(typeof(CheckStatus), 201)]
        [ProducesResponseType(typeof(CheckStatus), 404)]
        public IActionResult Post([FromBody]SubCategoriaInput input)
        {
            try
            {
                CheckStatus checkStatus = null;
                if (ModelState.IsValid)
                {
                    checkStatus = _manager.Create(input);

                    if (checkStatus.apiEstado.Equals(Status.Error))
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
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CheckStatus), 200)]
        [ProducesResponseType(typeof(CheckStatus), 404)]
        public IActionResult Put(int id, [FromBody]SubCategoriaInput input)
        {
            try
            {
                CheckStatus checkStatus = null;
                if (ModelState.IsValid)
                {

                    input.idSubCategoria = id;
                    checkStatus = _manager.Update(input);

                    if (checkStatus.apiEstado.Equals(Status.Error))
                    {
                        return StatusCode(422, checkStatus);
                    }

                    return Ok(checkStatus);
                }
                else
                {
                    checkStatus = new CheckStatus(Status.Error, Mensaje.InputInvalido);
                    return StatusCode(422, checkStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CheckStatus), 200)]
        [ProducesResponseType(typeof(CheckStatus), 404)]
        public IActionResult Delete(int id)
        {
            try
            {
                CheckStatus checkStatus = _manager.Delete(id, 0);

                if (checkStatus.apiEstado.Equals(Status.Error))
                {
                    return StatusCode(422, checkStatus);
                }
                return Ok(checkStatus);
            }

            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
}