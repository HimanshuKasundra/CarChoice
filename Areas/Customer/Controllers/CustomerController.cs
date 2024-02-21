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
                Console.WriteLine(@CV.IsAdmin());
                if(@CV.IsAdmin()=="True") {
                    return View("Admin_CustomerDetails", dt);

                }
                else
                {
                    return View("CustomerDetails", dt);

                }
            }
            else
            {
                return View("CustomerDetails");
            }
        }
        #endregion


        #region Admin Details
        public IActionResult AdminDetails(int CustomerID)
        {
            CustomerModel customerModel = customerDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);

            //DataTable dt = customerDAL.dbo_PR_Customer_SelectByPK(CustomerID);
            if (customerModel != null)
            {
                    return View("AdminDetailsEdit", customerModel);
            }
            else
            {
                return View("SEC_AdminDashboard","SEC_Admin");
            }
        }
        #endregion

        #region Customer Details for Edit
        public IActionResult EditCustomerDetails(int CustomerID)
        {
            Console.WriteLine(CustomerID);
            CustomerModel customerModel = customerDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);
            if (customerModel != null)
            {
                return View("CustomerAddEdit", customerModel);
            }
            else
            {
                return View("CustomerDetails");
            }
        }
        #endregion

        #region CustomerSave
        public IActionResult CustomerSave(CustomerModel customerModel)
        {
			Console.WriteLine(customerModel.CustomerID);

			if (customerDAL.dbo_PR_Customer_Save(customerModel))
                {
                    if (customerModel.CustomerID == 0)
                    {
                        //TempData["CountryInsertMsg"] = "Record Inserted Successfully";
                        return RedirectToAction("CustomerDetails","Customer");
                    }
                    else
                        return RedirectToAction("Index","Home");
                }
            
            return View("CustomerAddEdit");
        }
        #endregion


        #region AdminSave
        public IActionResult AdminSave(CustomerModel customerModel)
        {
            Console.WriteLine(customerModel.CustomerID);

            if (customerDAL.dbo_PR_Customer_Save(customerModel))
            {
                
                    return RedirectToAction("SEC_AdminDashboard","SEC_Admin", new { area="SEC_Admin" });
            }

            return View("AdminDetailsEdit");
        }
        #endregion



        #region Admin Details for Edit
        public IActionResult EditAdminDetails(int CustomerID)
        {
            Console.WriteLine(CustomerID);
            CustomerModel customerModel = customerDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);
            if (customerModel != null)
            {
                return View("AdminDetailsEdit", customerModel);
            }
            else
            {
                return View("SEC_AdminDashboard","SEC_Admin");
            }
        }
        #endregion

        public IActionResult Back()
        {
            if (@CV.IsAdmin() == "True")
            {
                return RedirectToAction("CustomerList");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
