using Microsoft.AspNetCore.Mvc;

namespace Rabbit_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
