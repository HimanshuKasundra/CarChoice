using  CarChoice.Areas.SEC_User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarChoice.DAL.SEC_User;

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
		private readonly IConfiguration Configuration;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public SEC_UserController(IConfiguration _Configuration, IWebHostEnvironment webHostEnvironment)
		{
			Configuration = _Configuration;
			_webHostEnvironment = webHostEnvironment;
		}


		#region Login
		[HttpPost]
        public IActionResult Login(SEC_UserModel SEC_UserModel)
        {
            string error = null;
            Console.WriteLine("Hello ", SEC_UserModel.UserName);
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
                TempData["Error"] = error;
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                SEC_UserDAL SEC_UserDAL = new SEC_UserDAL(_webHostEnvironment);
                DataTable dt = SEC_UserDAL.dbo_PR_UserDetails_SelectByUserNamePassword(SEC_UserModel.UserName, SEC_UserModel.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
						HttpContext.Session.SetString("Email", dr["Email"].ToString());
						HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
						HttpContext.Session.SetString("isAdmin", dr["IsAdmin"].ToString());
						HttpContext.Session.SetString("isActive", dr["IsActive"].ToString());
						break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("SEC_UserLogin");
                }
				if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null && HttpContext.Session.GetString("UserName") == "himanshu")
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
            SEC_UserDAL SEC_UserDAL = new SEC_UserDAL(_webHostEnvironment);
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
    }
}
