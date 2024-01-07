using CarChoice.Areas.Fuel.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace CarChoice.DAL.Fuel
{
    public class FuelDALBase:DALHelper
    {
        #region Method : dbo.PR_FuelDetails_SelectAll
        public DataTable dbo_PR_FuelDetails_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelDetails_SelectAll");
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

        #region Method : dbo.PR_FuelDetails_Insert & dbo.PR_FuelDetails_UpdateByPk
        public bool dbo_PR_FuelDetails_Save(FuelModel FuelModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {

                if (FuelModel.FuelID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelDetails_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@FuelType", DbType.String, FuelModel.FuelType);

                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelDetails_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int64, FuelModel.FuelID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelType", DbType.String, FuelModel.FuelType);
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

        #region Method : dbo.PR_FuelDetails_SelectByPK
        public FuelModel dbo_PR_FuelDetails_SelectByPK(int? FuelID)
        {
            FuelModel FuelModel = new FuelModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelDetails_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int64, FuelID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    FuelModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    FuelModel.FuelType = dataRow["TransmissonType"].ToString();
                    FuelModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    FuelModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return FuelModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_FuelDetails_Delete
        public void dbo_PR_FuelDetails_Delete(int? FuelID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelDetails_Delete");
                sqlDatabase.AddInParameter(dbCommand, "FuelID", DbType.Int64, FuelID);
                sqlDatabase.ExecuteNonQuery(dbCommand);
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion
    }
}
