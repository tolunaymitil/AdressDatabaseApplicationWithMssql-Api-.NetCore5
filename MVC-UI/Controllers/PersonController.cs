using Microsoft.AspNetCore.Mvc;

namespace MVC_UI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonAdd()
        {
            return View();
        }
        public IActionResult PersonDelete()
        {
            return View();
        }
    }

}
