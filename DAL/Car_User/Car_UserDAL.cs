using CarChoice.Areas.Brand.Models;
using CarChoice.Areas.Fuel.Models;
using CarChoice.Areas.Rent.Models;
using CarChoice.Areas.Transmission.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace CarChoice.DAL.Car_User
{
    public class Car_UserDAL:Car_UserDALBase
    {

        #region Brand Dropdown
        public List<BrandDropDownModel> dbo_PR_BrandDetails_Combobox()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<BrandDropDownModel> listOfBrand = new List<BrandDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    BrandDropDownModel brandDropDownModel = new BrandDropDownModel();
                    brandDropDownModel.BrandID = Convert.ToInt32(dataRow["BrandID"]);
                    brandDropDownModel.BrandName = dataRow["BrandName"].ToString();
                    listOfBrand.Add(brandDropDownModel);
                }
                return listOfBrand;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Transmission Dropdown
        public List<TransmissionDropDownModel> dbo_PR_TransmissionType_Combobox()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionType_Combobox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<TransmissionDropDownModel> listOfTransmission = new List<TransmissionDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TransmissionDropDownModel transmissionDropDownModel = new TransmissionDropDownModel();
                    transmissionDropDownModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    transmissionDropDownModel.TransmissionType = dataRow["TransmissionType"].ToString();
                    listOfTransmission.Add(transmissionDropDownModel);
                }
                return listOfTransmission;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Fuel Dropdown
        public List<FuelDropDownModel> dbo_PR_FuelType_Combobox()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelType_Combobox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<FuelDropDownModel> listOfFuel = new List<FuelDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    FuelDropDownModel fuelDropDownModel = new FuelDropDownModel();
                    fuelDropDownModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    fuelDropDownModel.FuelType = dataRow["FuelType"].ToString();
                    listOfFuel.Add(fuelDropDownModel);
                }
                return listOfFuel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Rent Dropdown
        public List<RentDropDownModel> dbo_PR_RentDetails_Combobox()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_Combobox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<RentDropDownModel> listOfRent = new List<RentDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    RentDropDownModel rentDropDownModel = new RentDropDownModel();
                    rentDropDownModel.RentID = Convert.ToInt32(dataRow["RentID"]);
                    rentDropDownModel.Rent = Convert.ToDouble(dataRow["Rent"]);

                    rentDropDownModel.CarType = dataRow["CarType"].ToString();
                    listOfRent.Add(rentDropDownModel);
                }
                return listOfRent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Mail
        [HttpPost]
        public bool SendEmail(string receiver)
        {
            try
            {

                var senderEmail = new MailAddress("himanshukasundra1503@gmail.com", "Car Choice");
                var receiverEmail = new MailAddress(receiver, "Receiver");
                var password = "Kasundra@1503@Himanshu";
                var subject = "Car Booking Confirmed";
                var body = "You Booked Car from CarChoice servies, Thank you!!";
                var smtp = new SmtpClient();
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential(senderEmail.Address, password, "smtp.gmail.com")
                //};

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmail.Address, password, "smtp.gmail.com");


                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;

            }
            catch (Exception)
            {
                //ViewBag.Error = "Some Error";
            }
            return false;
        }
        #endregion

    }
}
