using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlanthorWebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger){
            _logger = logger;
            _logger.LogDebug("Nlog injected into AccountController");
        }

        
        [HttpGet]
        public string TestGetMethod()
        {
           _logger.LogDebug("Testing Get method");
           return "Testing Get method";
        }
    }
}