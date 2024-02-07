using Microsoft.AspNetCore.Mvc;

namespace CarChoice.Areas.Car_User.Controllers
{
    public class Car_UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
