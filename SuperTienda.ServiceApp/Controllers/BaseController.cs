using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SuperTienda.BusinessLayer.Core;

namespace SuperTienda.ServiceApp.Controllers
{
    public class BaseController : Controller
    {

        private IActionManager _manager;
        private ILogger _logger;
        private IConfiguration configuration;

        public BaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public BaseController(IActionManager manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }
        public IActionManager ActionManager { get { return _manager; } }
        public ILogger Logger { get { return _logger; } }
    }
}
