using CarChoice.DAL.Car;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarChoice.Areas.Car.Controllers
{
    [Area("Car")]
    [Route("Car/[controller]/[action]")]
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Car List
        CarDAL carDAL = new CarDAL();
        public IActionResult CarList()
        {
            //#region  Car ComboBox
            //ViewBag.CarList = carDAL.dbo_PR_Car_Combobox();
            //#endregion

            DataTable dataTable = carDAL.dbo_PR_CarDetails_SelectAll();

            return View(dataTable);
        }
        #endregion


        #region Car Delete
        public IActionResult CarDelete(int CarID)
        {
            carDAL.dbo_PR_CarDetails_Delete(CarID);
            return RedirectToAction("CarList");
        }
        #endregion
    }
}
