using CarChoice.DAL.Fuel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarChoice.Areas.Fuel.Models;
using CarChoice.BAL;

namespace CarChoice.Areas.Fuel.Controllers
{
    [CheckAccess]
    [Area("Fuel")]
    [Route("Fuel/[Controller]/[action]")]
    public class FuelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Fuel Type List
        FuelDAL FuelDAL = new FuelDAL();
        public IActionResult FuelList()
        {
            DataTable dataTable = FuelDAL.dbo_PR_FuelDetails_SelectAll();
            return View("FuelList", dataTable);
        }
        #endregion

        #region Fuel Add
        public IActionResult FuelAddEdit(int FuelID = 0)
        {
            FuelModel FuelModel = FuelDAL.dbo_PR_FuelDetails_SelectByPK(FuelID);
            if (FuelModel != null)
            {
                return View("FuelAddEdit", FuelModel);
            }
            else
            {
                return View("FuelAddEdit");
            }
        }
        #endregion

        #region Fuel Insert & Fuel Update
        public IActionResult FuelSave(FuelModel FuelModel)
        {

            FuelDAL FuelDAL = new FuelDAL();
            bool IsSuccess = FuelDAL.dbo_PR_FuelDetails_Save(FuelModel);
            if (IsSuccess)
            {
                return RedirectToAction("FuelList");
            }
            else
            {
                return RedirectToAction("FuelList");
            }


        }
        #endregion

        #region Fuel Delete
        public IActionResult FuelDelete(int FuelID)
        {
            FuelDAL.dbo_PR_FuelDetails_Delete(FuelID);
            return RedirectToAction("FuelList");
        }
        #endregion


    }
}
