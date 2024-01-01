using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CarChoice.DAL.Customer
{
	public class CustomerDALBase:DALHelper
	{
        #region Method: dbo.PR_Customer_SelectAll
        public DataTable dbo_PR_Customer_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Customer_SelectAll");
                DataTable dt = new DataTable();
                using(IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dt.Load(dataReader);
                }
                return dt;

            }
            catch (Exception ex) {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_LOC_Country_Delete
        public void dbo_PR_Customer_Delete(int? CustomerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Customer_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "CustomerID", DbType.Int64, CustomerID);
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
