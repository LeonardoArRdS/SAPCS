using Microsoft.AspNetCore.Mvc;

namespace SAPCS.Controllers
{
    public class AcessoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
