using CarChoice.Areas.Car.Models;
using CarChoice.BAL;
using CarChoice.DAL.Car;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarChoice.Areas.Car.Controllers
{
    [CheckAccess]
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
           #region  Car ComboBox
            ViewBag.BrandList = carDAL.dbo_PR_BrandDetails_Combobox();
            ViewBag.TransmissionList = carDAL.dbo_PR_TransmissionType_Combobox();
            ViewBag.FuelList = carDAL.dbo_PR_FuelType_Combobox();
            ViewBag.RentList = carDAL.dbo_PR_RentDetails_Combobox();
            #endregion

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

        #region Car Add
        public IActionResult CarAddEdit(int CarID = 0)
        {
            CarModel carModel = carDAL.dbo_PR_CarDetails_SelectByPK(CarID);
            if (carModel != null)
            {

                ViewBag.BrandList = carDAL.dbo_PR_BrandDetails_Combobox();
                ViewBag.TransmissionList = carDAL.dbo_PR_TransmissionType_Combobox();
                ViewBag.FuelList = carDAL.dbo_PR_FuelType_Combobox();
                ViewBag.RentList = carDAL.dbo_PR_RentDetails_Combobox();

                return View("CarAddEdit", carModel);

            }
            else
            {
                ViewBag.BrandList = carDAL.dbo_PR_BrandDetails_Combobox();
                ViewBag.TransmissionList = carDAL.dbo_PR_TransmissionType_Combobox();
                ViewBag.FuelList = carDAL.dbo_PR_FuelType_Combobox();
                ViewBag.RentList = carDAL.dbo_PR_RentDetails_Combobox();
                return View("CarAddEdit");
            }
        }
        #endregion


        #region Car Insert & Car Update 
        public IActionResult CarSave(CarModel carModel)
        {
            //if (ModelState.IsValid)
            //{
            //    if (carDAL.dbo_PR_CarDetails_Save(carModel))

            //        return RedirectToAction("CarList");
            //}
            //return View("CarAddEdit");
            if (carDAL.dbo_PR_CarDetails_Save(carModel))
            {
                return RedirectToAction("CarList");
            }
            return RedirectToAction("CarAddEdit");
        }
        #endregion

       
    }
}
