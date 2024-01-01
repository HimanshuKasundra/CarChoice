using CarChoice.DAL.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarChoice.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[Controller]/[action]")]
    public class CustomerController : Controller
	{
        CustomerDAL customerDAL = new CustomerDAL();

        #region CustomerList
        public IActionResult CustomerList()
		{
            DataTable dt=customerDAL.dbo_PR_Customer_SelectAll();   
			return View(dt);
		}
        #endregion

        #region Customer Delete
        public IActionResult CustomerDelete(int CustomerID)
        {
            customerDAL.dbo_PR_Customer_Delete(CustomerID);
            return RedirectToAction("CustomerList");
        }
        #endregion
    }
}
