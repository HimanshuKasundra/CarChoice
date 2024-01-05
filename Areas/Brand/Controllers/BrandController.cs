using CarChoice.DAL.Brand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using CarChoice.Areas.Brand.Models;
using CarChoice.BAL;
using CarChoice.Areas.SEC_User.Models;

namespace CarChoice.Areas.Brand.Controllers
{
    [CheckAccess]
    [Area("Brand")]
    [Route("Brand/[Controller]/[action]")]
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Brand List
        BrandDAL brandDAL = new BrandDAL();
        public IActionResult BrandList()
        {
            DataTable dataTable = brandDAL.dbo_PR_BrandDetails_SelectAll();
            return View("BrandList",dataTable);
        }
        #endregion

        #region Brand Add
        public IActionResult BrandAddEdit(int BrandID = 0)
        {
            BrandModel brandModel = brandDAL.dbo_PR_BrandDetails_SelectByPK(BrandID);
            if (brandModel != null)
            {
                return View("BrandAddEdit", brandModel);
            }
            else
            {
                return View("BrandAddEdit");
            }
        }
        #endregion

        #region Brand Insert & Brand Update
        public IActionResult BrandSave(BrandModel brandModel)
        {
 
            BrandDAL brandDAL = new BrandDAL();
            bool IsSuccess = brandDAL.dbo_PR_BrandDetails_Save(brandModel );
            if (IsSuccess)
            {
                return RedirectToAction("BrandList");
            }
            else
            {
                return RedirectToAction("BrandList");
            }


        }
        #endregion

        #region Brand Delete
        public IActionResult BrandDelete(int BrandID)
        {
            brandDAL.dbo_PR_BrandDetails_Delete(BrandID);
            return RedirectToAction("BrandList");
        }
        #endregion

        
    }
}
