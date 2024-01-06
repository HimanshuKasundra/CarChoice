using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;

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


       

    }
}
