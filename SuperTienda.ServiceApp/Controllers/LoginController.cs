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
    [Route("api/login")]
    [ApiController]
    public class LoginController : BaseController
    {

        private readonly IConfiguration _configuracion;
        ILogger<LoginController> _logger;
        IRepository _repository;

        public LoginController(IRepository repository, ILogger<LoginController> logger, IConfiguration configuration): base(configuration)
        {
            _configuracion = configuration;
            _logger = logger;
            _repository = repository;
        }

        private IActionResult BuildToken(LoginInput infocuenta, int id)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, infocuenta.correo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["Llave_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return Ok(new 
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration,id
            });
        }


        [HttpPost]
        [ProducesResponseType(typeof(CheckStatus),201)]
        [ProducesResponseType(typeof(CheckStatus),404)]
        public IActionResult Post([FromBody]LoginInput input)
        {

            CheckStatus checkStatus = null;
            Usuario perfil = null;

            if(ModelState.IsValid)
            { 
                try
                {
                    perfil = _repository.Single<Usuario>(p => p.Email == input.correo);

                    if (perfil.Password == input.contrasena)
                    {
                        return BuildToken(input, perfil.Id);
                    }

                    else
                    {
                        checkStatus = new CheckStatus(Status.Error, "Contraseña Incorrecta");
                        return StatusCode(404, checkStatus);
                    }

                }
                catch
                {
                    checkStatus = new CheckStatus(Status.Error, "Cuenta no registrada");
                    return StatusCode(404, checkStatus);
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