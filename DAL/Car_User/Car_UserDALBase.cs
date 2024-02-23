using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Car_User.Models;
using CarChoice.BAL;

namespace CarChoice.DAL.Car_User
{
    public class Car_UserDALBase:DALHelper
    {
        #region Method : dbo.PR_Car_SelectAll
        public DataTable dbo_PR_CarDetails_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_SelectAll");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        #region Method : dbo.PR_CarDetails_SelectByPK
        public Car_UserModel dbo_PR_CarDetails_SelectByPK(int CarID)
        {
            Car_UserModel carModel = new Car_UserModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_SelectByPk");
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int64, CarID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    carModel.CarID = Convert.ToInt32(dataRow["CarID"]);
                    carModel.CarName = dataRow["CarName"].ToString();
                    carModel.BrandID = Convert.ToInt32(dataRow["BrandID"]);
                    carModel.BrandName = dataRow["BrandName"].ToString();
                    carModel.Model = dataRow["Model"].ToString();
                    carModel.Year = Convert.ToInt32(dataRow["Year"]);
                    carModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    carModel.TransmissionType = dataRow["TransmissionType"].ToString();
                    carModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    carModel.FuelType = dataRow["FuelType"].ToString();
                    carModel.Availability = dataRow["Availability"].ToString();
                    carModel.VehicleNo = dataRow["VehicleNo"].ToString();
                    carModel.RentID = Convert.ToInt32(dataRow["RentID"]);
                    carModel.Rent = Convert.ToDouble(dataRow["Rent"]);
                    carModel.CarType = dataRow["CarType"].ToString();

                    carModel.CarImageURL = dataRow["CarImageURL"].ToString();
                    carModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    carModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return carModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Booking
        public bool BookingSave(int CarID, int CustomerID, int RentID, string PickupDate, string ReturnDate, double totalCost)
        {
            DateTime From = Convert.ToDateTime(PickupDate);
            DateTime To = Convert.ToDateTime(ReturnDate);

            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ReservationDetails_Insert");
            sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
            sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.Int32, CustomerID);
            sqlDatabase.AddInParameter(dbCommand, "@RentID", DbType.Int32, RentID);

            sqlDatabase.AddInParameter(dbCommand, "@PickupDate", DbType.DateTime, From);
            sqlDatabase.AddInParameter(dbCommand, "@ReturnDate", DbType.DateTime, To);
            sqlDatabase.AddInParameter(dbCommand, "@TotalCost", DbType.Double, totalCost);

            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
            return isSuccess;
        }
        #endregion


        #region BookingList
        public DataTable dbo_PR_Reservation_SelectByCustomrID(int CustomerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Reservation_SelectByCustomrID");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.Int32, CustomerID);

                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                //foreach (DataRow dataRow in dataTable.Rows)
                //{
                //    carModel.CarName = dataRow["CarName"].ToString();
                //    carModel.BrandName = dataRow["BrandName"].ToString();
                //    carModel.Rent = Convert.ToDouble(dataRow["Rent"]);
                //    carModel.PickupDate = Convert.ToDateTime(dataRow["PickupDate"]);
                //    carModel.ReturnDate = Convert.ToDateTime(dataRow["ReturnDate"]);
                //    carModel.TotalCost = Convert.ToDouble(dataRow["TotalCost"]);

                //}
                return dataTable;
            }catch(Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
