using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Car.Models;

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
        public CarModel dbo_PR_CarDetails_SelectByPK(int? CarID)
        {
            CarModel carModel = new CarModel();
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

    }
}
