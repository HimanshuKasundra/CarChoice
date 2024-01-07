using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using CarChoice.Areas.Car.Models;
using CarChoice.Areas.Brand.Models;

namespace CarChoice.DAL.Car
{
    public class CarDALBase : DALHelper
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

        #region Method : dbo.PR_CarDetails_Delete
        public void dbo_PR_CarDetails_Delete(int? CarID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int64, CarID);
                sqlDatabase.ExecuteNonQuery(dbCommand);
                return;
            }
            catch (Exception ex)
            {
                return;
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

        #region Method : dbo.PR_CarDetails_Insert & dbo.PR_CarDetails_Update
        public bool dbo_PR_CarDetails_Save(CarModel carModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (carModel.CarImage != null)
                {
                    string FilePath = "wwwroot\\Photos\\Cars";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileNameWithPath = Path.Combine(path, carModel.CarImage.FileName);
                    carModel.CarImageURL = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + carModel.CarImage.FileName;

                    using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        carModel.CarImage.CopyTo(fileStream);
                    }
                }

                if (carModel.CarID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, carModel.CarName);
                    sqlDatabase.AddInParameter(dbCommand, "@BrandID", DbType.Int32, carModel.BrandID);
                    sqlDatabase.AddInParameter(dbCommand, "@Model", DbType.String, carModel.Model);
                    sqlDatabase.AddInParameter(dbCommand, "@Year", DbType.Int32, carModel.Year);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, carModel.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, carModel.FuelID) ;
                    sqlDatabase.AddInParameter(dbCommand, "@Availability", DbType.String, carModel.Availability);
                    sqlDatabase.AddInParameter(dbCommand, "@VehicleNo", DbType.String, carModel.VehicleNo);
                    sqlDatabase.AddInParameter(dbCommand, "@RentID", DbType.Int32, carModel.RentID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarImageURL", DbType.String, carModel.CarImageURL);
                   
                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarDetails_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, carModel.CarID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, carModel.CarName);
                    sqlDatabase.AddInParameter(dbCommand, "@BrandID", DbType.Int32, carModel.BrandID);
                    sqlDatabase.AddInParameter(dbCommand, "@Model", DbType.String, carModel.Model);
                    sqlDatabase.AddInParameter(dbCommand, "@Year", DbType.Int32, carModel.Year);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, carModel.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, carModel.FuelID);
                    sqlDatabase.AddInParameter(dbCommand, "@Availability", DbType.String, carModel.Availability);
                    sqlDatabase.AddInParameter(dbCommand, "@VehicleNo", DbType.String, carModel.VehicleNo);
                    sqlDatabase.AddInParameter(dbCommand, "@RentID", DbType.Int32, carModel.RentID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarImageURL", DbType.String, carModel.CarImageURL);
                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion




    }
}
