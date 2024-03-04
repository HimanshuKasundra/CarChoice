using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Brand.Models;
using CarChoice.Areas.Car.Models;
using CarChoice.Areas.Transmission.Models;
using CarChoice.Areas.Fuel.Models;
using CarChoice.Areas.Rent.Models;

namespace CarChoice.DAL.Car
{
    public class CarDAL:CarDALBase
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
    }
}
