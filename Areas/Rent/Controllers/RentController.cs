using CarChoice.DAL.Rent;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarChoice.Areas.Rent.Models;
using CarChoice.BAL;

namespace CarChoice.Areas.Rent.Controllers
{
    [CheckAccess]
    [Area("Rent")]
    [Route("Rent/[Controller]/[action]")]
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Rent List
        RentDAL rentDAL = new RentDAL();
        public IActionResult RentList()
        {
            DataTable dataTable = rentDAL.dbo_PR_RentDetails_SelectAll();
            return View("RentList", dataTable);
        }
        #endregion

        #region Rent Add
        public IActionResult RentAddEdit(int RentID = 0)
        {
            RentModel rentModel = rentDAL.dbo_PR_RentDetails_SelectByPK(RentID);
            if (rentModel != null)
            {
                return View("RentAddEdit", rentModel);
            }
            else
            {
                return View("RentAddEdit");
            }
        }
        #endregion

        #region Rent Insert & Rent Update
        public IActionResult RentSave(RentModel RentModel)
        {

            RentDAL rentDAL = new RentDAL();
            bool IsSuccess = rentDAL.dbo_PR_RentDetails_Save(RentModel);
            if (IsSuccess)
            {
                return RedirectToAction("RentList");
            }
            else
            {
                return RedirectToAction("RentList");
            }


        }
        #endregion

        #region Rent Delete
        public IActionResult RentDelete(int RentID)
        {
            rentDAL.dbo_PR_RentDetails_Delete(RentID);
            return RedirectToAction("RentList");
        }
        #endregion


    }
}
