using Microsoft.AspNetCore.Mvc;
using Rabbit_API.Models;

namespace Rabbit_API.Controllers
{
    [Route("api/Thread")]
    [ApiController]
    public class ThreadController : Controller
    {
        protected APIResponse _response;
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
