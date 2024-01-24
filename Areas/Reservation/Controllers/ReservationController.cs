using Microsoft.AspNetCore.Mvc;

namespace CarChoice.Areas.Reservation.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
