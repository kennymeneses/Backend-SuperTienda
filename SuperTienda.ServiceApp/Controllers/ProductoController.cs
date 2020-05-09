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
using SuperTienda.BusinessLayer.Manager.ProductoManagement;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Core;
using SuperTienda.Common.Facade;
using SuperTienda.Common.Entities;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.ServiceApp.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : BaseController
    {

        IProductoManager _manager;
        ILogger<ProductoController> _logger;

        public ProductoController(IProductoManager manager, ILogger<ProductoController> logger):base(manager, logger)
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
                ProductoQueryInput input = new ProductoQueryInput();
                if( texto == null)
                {
                    texto = "";
                }
                input.texto = texto;
                input.pagina = pagina;
                input.tamanio = tamanio;
                input.idUsuario = 0;
                DataQuery data = _manager.Search(input);
                CheckStatus CheckPermiso = new CheckStatus();
                if(data.apiEstado.Equals(Status.Error))
                {
                    return NotFound(data);
                }
                return Ok(data);

            }
            catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.ERROR, ex, ex.Message);
                return new EmptyResult();
            }

        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductoIndOutput), 200)]
        [ProducesResponseType(typeof(ProductoIndOutput), 404)]
        public IActionResult Get(int id)
        {
            try
            {
                ProductoIndOutput data = (ProductoIndOutput)_manager.SingleById(id, 0);

                if (data.apiEstado.Equals(Status.Error))
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

        [HttpPost]
        [ProducesResponseType(typeof(CheckStatus), 201)]
        [ProducesResponseType(typeof(CheckStatus), 404)]
        public IActionResult Post([FromBody]ProductoInput input)
        {
            try
            {
                CheckStatus checkStatus = null;
                if(ModelState.IsValid)
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
            catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CheckStatus), 200)]
        [ProducesResponseType(typeof(CheckStatus), 404)]
        public IActionResult Put(int id, [FromBody]ProductoInput input)
        {

            try
            {
                CheckStatus checkStatus = null;
                if(ModelState.IsValid)
                {
                    input.idProducto = id;
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

    }
}