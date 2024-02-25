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
using CarChoice.Areas.Customer.Models;
using Microsoft.Extensions.Logging;

namespace CarChoice.Areas.Car_User.Controllers
{
    [Area("Car_User")]
    [Route("Car_User/[Controller]/[action]")]


    public class Car_UserController : Controller
    {
        private readonly IConfiguration Configuration;

        #region constructor
        public Car_UserController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        #endregion

        #region method:Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region method: GetCarPage
        public IActionResult GetCarPage()
        {
            return View();
        }
        #endregion


        #region Car List Datewise
        Car_UserDAL car_UserDAL = new Car_UserDAL();
        [HttpPost]
        public IActionResult CarListByDate(Car_UserModel car_UserModel)
        {
            TempData["PickupDate"] = car_UserModel.PickupDate;
            TempData["ReturnDate"] = car_UserModel.ReturnDate;

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
        public IActionResult CarDetails_User(int CarID, string PickupDate, string ReturnDate)
        {
             TempData["PickupDate"] = PickupDate;
            TempData["ReturnDate"] = ReturnDate;
            Console.WriteLine(CarID);
            #region  Car ComboBox
            ViewBag.BrandList = car_UserDAL.dbo_PR_BrandDetails_Combobox();
            ViewBag.TransmissionList = car_UserDAL.dbo_PR_TransmissionType_Combobox();
            ViewBag.FuelList = car_UserDAL.dbo_PR_FuelType_Combobox();
            ViewBag.RentList = car_UserDAL.dbo_PR_RentDetails_Combobox();
            #endregion


            Car_UserModel carUserModel = car_UserDAL.dbo_PR_CarDetails_SelectByPK(CarID);

            //DataTable dt = customerDAL.dbo_PR_Customer_SelectByPK(CustomerID);
            if (carUserModel != null)
            {
                return View("CarDetails_User", carUserModel);
            }
            else
            {
                return View("CarList_User");
            }

        }
        #endregion

        #region Book Car
        [CheckAccess]
        public IActionResult BookingSave(int CarID, int CustomerID, int RentID ,string PickupDate, string ReturnDate, double totalCost)
        {
            
                if (car_UserDAL.BookingSave(CarID, CustomerID, RentID, PickupDate, ReturnDate, totalCost))
                {
                    //userDAL.SendEmail(Email);
                    return RedirectToAction("BookingHistory", new { CustomerID }   );
                }
            Console.WriteLine(CustomerID);

            return RedirectToAction("CarDetails_User");

        }
        #endregion


        #region Booking History
        [CheckAccess]
        public IActionResult BookingHistory(int CustomerID)
        {
            Console.WriteLine(CustomerID);
            //Car_UserModel carUserModel = car_UserDAL.dbo_PR_Reservation_SelectByCustomrID(CustomerID);
            DataTable dataTable = car_UserDAL.dbo_PR_Reservation_SelectByCustomrID(CustomerID);

            if (dataTable != null)
            {
                return View("BookingHistory", dataTable);
            }
            else
            {
                return View("CarList_User");
            }

        }
        #endregion

        #region Admin Reservation View
        [CheckAccess]
        public IActionResult Admin_ReservationView()
        {
            DataTable dt = car_UserDAL.dbo_PR_ReservationDetails_SelectAll();
            return View(dt);

        }
        #endregion

        #region method:Cancel Trip
        [CheckAccess]
        public IActionResult CancelTrip(int CustomerID, int CarID)
        {

            if (car_UserDAL.dbo_PR_ReservationStatusCancel_UpdateByCustomerID(CustomerID,CarID))
            {
                //userDAL.SendEmail(Email);
                return RedirectToAction("BookingHistory", new { CustomerID });
            }
            Console.WriteLine(CustomerID);

            return RedirectToAction("CarDetails_User");

        }
        #endregion

        #region method:Approval
        [CheckAccess]
        public IActionResult Approval(int CustomerID, int CarID, string Email)
        {

            if (car_UserDAL.dbo_PR_ReservationStatusApprove_UpdateByCustomerID(CustomerID, CarID))
            {
                car_UserDAL.SendEmail(Email);

                return RedirectToAction("Admin_ReservationView");
            }

            return RedirectToAction("CarDetails_User");

        }
        #endregion

        #region method:Denied
        [CheckAccess]
        public IActionResult Denied(int CustomerID, int CarID)
        {

            if (car_UserDAL.dbo_PR_ReservationStatusCancel_UpdateByCustomerID(CustomerID, CarID))
            {
                return RedirectToAction("Admin_ReservationView");

                
            }
            Console.WriteLine(CustomerID);

            return RedirectToAction("CarDetails_User");

        }
        #endregion


        
        public IActionResult Back()
        {

            return RedirectToAction("CarList_User");

        }




    }
}
