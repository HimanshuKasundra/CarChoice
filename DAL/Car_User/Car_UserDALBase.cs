using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Car_User.Models;

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
        public Car_UserModel dbo_PR_CarDetails_SelectByPK(int? CarID)
        {
            Car_UserModel carModel = new Car_UserModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_SelectByPK");
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
                    carModel.Model = dataRow["Model"].ToString();
                    carModel.Year = Convert.ToInt32(dataRow["Year"]);
                    carModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    carModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    carModel.Availability = dataRow["Availability"].ToString();
                    carModel.VehicleNo = dataRow["VehicleNo"].ToString();
                    carModel.RentID = Convert.ToInt32(dataRow["RentID"]);
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




		//        #region Method : dbo.PR_CarDetails_SelectAll_Datewise
		//        public Car_UserModel dbo_PR_CarDetails_SelectAll_Datewise(DateTime? PickupDate, DateTime? ReturnDate)
		//        {
		//            Car_UserModel carUserModel = new Car_UserModel();
		//            try
		//            {
		//                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
		//                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_SelectAll_Datewise");
		//                sqlDatabase.AddInParameter(dbCommand, "@PickupDate", DbType.DateTime, PickupDate);
		//                sqlDatabase.AddInParameter(dbCommand, "@ReturnDate", DbType.DateTime, ReturnDate);

		//                DataTable dataTable = new DataTable();
		//                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
		//                {
		//                    dataTable.Load(dataReader);
		//                }
		//                foreach (DataRow dataRow in dataTable.Rows)
		//                {
		//                    carUserModel.CarName = dataRow["CarName"].ToString();
		//                    carUserModel.BrandID = Convert.ToInt32(dataRow["BrandID"]);
		//                    carUserModel.Model = dataRow["Model"].ToString();
		//                    carUserModel.Year = Convert.ToInt32(dataRow["Year"]);
		//                    carUserModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
		//                    carUserModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
		//                    carUserModel.Availability = dataRow["Availability"].ToString();
		//                    carUserModel.VehicleNo = dataRow["VehicleNo"].ToString();
		//                    carUserModel.RentID = Convert.ToInt32(dataRow["RentID"]);
		//                    carUserModel.CarImageURL = dataRow["CarImageURL"].ToString();

		//                }
		//                return carUserModel;
		//            }
		//            catch (Exception ex)
		//            {
		//                return null;
		//            }
		//        }
		//#endregion

	}
}
