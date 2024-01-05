using CarChoice.DAL.Transmission;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarChoice.Areas.Transmission.Models;
using CarChoice.BAL;

namespace CarChoice.Areas.Transmission.Controllers
{
    [CheckAccess]
    [Area("Transmission")]
    [Route("Transmission/[Controller]/[action]")]
    public class TransmissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Transmission Type List
        TransmissionDAL transmissionDAL = new TransmissionDAL();
        public IActionResult TransmissionList()
        {
            DataTable dataTable = transmissionDAL.dbo_PR_TransmissionDetails_SelectAll();
            return View("TransmissionList", dataTable);
        }
        #endregion

        #region Transmission Add
        public IActionResult TransmissionAddEdit(int TransmissionID = 0)
        {
            TransmissionModel transmissionModel = transmissionDAL.dbo_PR_TransmissionDetails_SelectByPK(TransmissionID);
            if (transmissionModel != null)
            {
                return View("TransmissionAddEdit", transmissionModel);
            }
            else
            {
                return View("TransmissionAddEdit");
            }
        }
        #endregion

        #region Transmission Insert & Transmission Update
        public IActionResult TransmissionSave(TransmissionModel transmissionModel)
        {

            TransmissionDAL transmissionDAL = new TransmissionDAL();
            bool IsSuccess = transmissionDAL.dbo_PR_TransmissionDetails_Save(transmissionModel);
            if (IsSuccess)
            {
                return RedirectToAction("TransmissionList");
            }
            else
            {
                return RedirectToAction("TransmissionList");
            }


        }
        #endregion

        #region Transmission Delete
        public IActionResult TransmissionDelete(int TransmissionID)
        {
            transmissionDAL.dbo_PR_TransmissionDetails_Delete(TransmissionID);
            return RedirectToAction("TransmissionList");
        }
        #endregion


    }
}
