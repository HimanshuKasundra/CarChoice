using CarChoice.Areas.Car_User.Models;
using CarChoice.Areas.Car_User;
using CarChoice.BAL;
using CarChoice.DAL.Car_User;
using CarChoice.DAL.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Converters;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using CarChoice.DAL;
using CarChoice.DAL.Car;

namespace CarChoice.Areas.Car_User.Controllers
{
    [Area("Car_User")]
    [Route("Car_User/[Controller]/[action]")]
    public class Car_UserController : Controller
    {
        private readonly IConfiguration Configuration;

        public Car_UserController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Car List
        Car_UserDAL car_UserDAL = new Car_UserDAL();
        [HttpPost]
        public IActionResult CarListByDate(Car_UserModel car_UserModel)
        {

            #region  Car ComboBox
            ViewBag.BrandList = car_UserDAL.dbo_PR_BrandDetails_Combobox();
            ViewBag.TransmissionList = car_UserDAL.dbo_PR_TransmissionType_Combobox();
            ViewBag.FuelList = car_UserDAL.dbo_PR_FuelType_Combobox();
            ViewBag.RentList = car_UserDAL.dbo_PR_RentDetails_Combobox();
            #endregion

            string connectionStr = this.Configuration.GetConnectionString("ConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection sql = new SqlConnection(connectionStr);
            sql.Open();
            SqlCommand objCmd = sql.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CarDetails_SelectAll_Datewise]";
            objCmd.Parameters.AddWithValue("@PickupDate", car_UserModel.PickupDate);
            objCmd.Parameters.AddWithValue("@ReturnDate", car_UserModel.ReturnDate);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dataTable.Load(objSDR);
            Console.WriteLine("Count" + dataTable.Rows.Count);
            return View("CarList_User", dataTable);

        }
        #endregion

        #region Car List
        
        public IActionResult CarList_User()
        {
            #region  Car ComboBox
            ViewBag.BrandList = car_UserDAL.dbo_PR_BrandDetails_Combobox();
            ViewBag.TransmissionList = car_UserDAL.dbo_PR_TransmissionType_Combobox();
            ViewBag.FuelList = car_UserDAL.dbo_PR_FuelType_Combobox();
            ViewBag.RentList = car_UserDAL.dbo_PR_RentDetails_Combobox();
            #endregion

            DataTable dataTable = car_UserDAL.dbo_PR_CarDetails_SelectAll();

            return View(dataTable);
        }
        #endregion


        #region Car Details


        public IActionResult CarDetails_User(Car_UserModel car_UserModel)
        {

            #region  Car ComboBox
            ViewBag.BrandList = car_UserDAL.dbo_PR_BrandDetails_Combobox();
            ViewBag.TransmissionList = car_UserDAL.dbo_PR_TransmissionType_Combobox();
            ViewBag.FuelList = car_UserDAL.dbo_PR_FuelType_Combobox();
            ViewBag.RentList = car_UserDAL.dbo_PR_RentDetails_Combobox();
            #endregion

            string connectionStr = this.Configuration.GetConnectionString("ConnectionString");
            DataTable dataTable = new DataTable();
            SqlConnection sql = new SqlConnection(connectionStr);
            sql.Open();
            SqlCommand objCmd = sql.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CarDetails_SelectByPk]";
            objCmd.Parameters.AddWithValue("@CarID", car_UserModel.CarID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dataTable.Load(objSDR);
            Console.WriteLine("Count" + dataTable.Rows.Count);
            return View("CarList_User", dataTable);

        }
        #endregion





        //public IActionResult CarDetails_User(int? CarID )
        //{
        //	DataTable dt = car_UserDAL.dbo_PR_CarDetails_SelectByPK(CarID);
        //	if (dt != null)
        //	{
        //		return View("CarDetails_User", dt);
        //	}
        //	else
        //	{
        //		return View("CarDetails_User");
        //	}
        //}

    }
}
