using CarChoice.BAL;
using CarChoice.DAL.Car;
using CarChoice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace CarChoice.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Car List
        CarDAL carDAL = new CarDAL();
        public IActionResult Index()
        {
                #region  Car ComboBox
                ViewBag.BrandList = carDAL.dbo_PR_BrandDetails_Combobox();
                ViewBag.TransmissionList = carDAL.dbo_PR_TransmissionType_Combobox();
                ViewBag.FuelList = carDAL.dbo_PR_FuelType_Combobox();
                ViewBag.RentList = carDAL.dbo_PR_RentDetails_Combobox();
                #endregion

                DataTable dataTable = carDAL.dbo_PR_CarDetails_SelectAll();

                return View(dataTable);
            
            #endregion
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}