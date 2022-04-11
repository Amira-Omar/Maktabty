using Microsoft.AspNetCore.Mvc;

namespace Maktabty.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
