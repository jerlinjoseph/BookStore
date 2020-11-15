using BookStore.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _logger;

        public HomeController(ILoggerService logger)
        {
            _logger = logger;
            
        }
        public IActionResult Index()
        {
            _logger.LogInfo("We are in Index again");
            return Ok("Hello World");
        }
    }
}