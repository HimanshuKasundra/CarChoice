using CarChoice.DAL.SEC_Admin;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarChoice.Areas.SEC_Admin.Controllers
{
	public class SEC_AdminController : Controller
	{
        #region Admin Dashboard
        [Area("SEC_Admin")]
        [Route("SEC_Admin/[controller]/[action]")]
        public IActionResult SEC_AdminDashboard()
		{
			SEC_AdminDAL SEC_AdminDAL = new SEC_AdminDAL();
			DataTable dataTable = SEC_AdminDAL.SEC_Admin_Dashboard();
			return View(dataTable);
		}
		#endregion



	}
}
