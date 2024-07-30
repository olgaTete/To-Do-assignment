using Microsoft.AspNetCore.Mvc;

namespace Console_core.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
