using  CarChoice.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarChoice.DAL.SEC_User;
using CarChoice.Areas.Customer.Models;
using CarChoice.DAL.Customer;

namespace CarChoice.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {
       
        public IActionResult SEC_UserLogin()
        {
            return View();
        }
        public IActionResult SEC_UserRegister()
        {
            return View();
        }


		#region Login
		[HttpPost]
        public IActionResult Login(SEC_UserModel SEC_UserModel)
        {
            string error = null;
            //Console.WriteLine("Hello ", SEC_UserModel.UserName);
            if (SEC_UserModel.UserName == null)
            {
                error += "User Name is required";
            }
            if (SEC_UserModel.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = "UserName or Password is Incorrect";
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                SEC_UserDAL SEC_UserDAL = new SEC_UserDAL();
                DataTable dt = SEC_UserDAL.dbo_PR_UserDetails_SelectByUserNamePassword(SEC_UserModel.UserName, SEC_UserModel.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        HttpContext.Session.SetString("CustomerID", dr["CustomerID"].ToString());
                        HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
						HttpContext.Session.SetString("Email", dr["Email"].ToString());
						HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
						HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
						HttpContext.Session.SetString("IsActive", dr["IsActive"].ToString());
                        Console.WriteLine(HttpContext.Session.GetString("UserName"));

                        break;
                    }
                    
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("SEC_UserLogin");
                }
				if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null && HttpContext.Session.GetString("IsAdmin") =="True")

				{
					return RedirectToAction("SEC_AdminDashboard", "SEC_Admin", new { area = "SEC_Admin" });
				}
				else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion


        #region Register
        public IActionResult Register(SEC_UserModel SEC_UserModel)
        {
            SEC_UserDAL SEC_UserDAL = new SEC_UserDAL();
            bool IsSuccess = SEC_UserDAL.dbo_PR_UserDetails_Register(SEC_UserModel);
            if (IsSuccess)
            {
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                return RedirectToAction("SEC_UserRegister");
            }
        }

        #endregion

        #region logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SEC_UserLogin");
        }

		#endregion
		SEC_UserDAL SEC_UserDAL = new SEC_UserDAL();

        //#region Customer Details for Edit
        //public IActionResult SEC_UserEditDetails(int CustomerID = 0)
        //{

        //    SEC_UserModel sEC_UserModel = SEC_UserDAL.dbo_PR_CustomerEdit_SelectByPK(CustomerID);
        //    if (sEC_UserModel != null)
        //    {
        //        return View("SEC_UserEditDetails", sEC_UserModel);
        //    }
        //    else
        //    {
        //        return View("SEC_UserEditDetails");
        //    }
        //}
        //#endregion
    }
}
