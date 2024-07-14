using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_erp.App.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
