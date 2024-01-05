using CarChoice.Areas.Customer.Models;
using CarChoice.BAL;
using CarChoice.DAL.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarChoice.Areas.Customer.Controllers
{
    [CheckAccess]
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

        #region Customer Add
        public IActionResult CustomerAddEdit(int CustomerID = 0)
        {
            CustomerModel customerModel = customerDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);
            if (customerModel != null)
            {
                return View("CustomerAddEdit", customerModel);
            }
            else
            {
                return View("CustomerAddEdit");
            }
        }
        #endregion

        #region Customer Details
        public IActionResult CustomerDetails(int CustomerID = 0)
        {
            DataTable dt = customerDAL.dbo_PR_Customer_SelectByPK(CustomerID);
            if (dt != null)
            {
                return View("CustomerDetails", dt);
            }
            else
            {
                return View("CustomerDetails");
            }
        }
        #endregion

        #region Customer Details for Edit
        public IActionResult EditCustomerDetails(int CustomerID = 0)
        {
            CustomerModel customerModel = customerDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);
            if (customerModel != null)
            {
                return View("CustomerDetails", customerModel);
            }
            else
            {
                return View("CustomerDetails");
            }
        }
        #endregion

        #region Country Insert & Country Update
        public IActionResult CustomerSave(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                if (customerDAL.dbo_PR_Customer_Save(customerModel))
                {
                    if (customerModel.CustomerID == 0)
                    {
                        //TempData["CountryInsertMsg"] = "Record Inserted Successfully";
                        return RedirectToAction("CustomerList");
                    }
                    else
                        return RedirectToAction("CustomerList");
                }
            }
            return View("CustomerAddEdit");
        }
        #endregion
    }
}
