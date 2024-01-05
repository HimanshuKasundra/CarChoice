using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Rent.Models;

namespace CarChoice.DAL.Rent
{
    public class RentDALBase : DALHelper
    {
        #region Method : dbo.PR_RentDetails_SelectAll
        public DataTable dbo_PR_RentDetails_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_SelectAll");
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

        #region Method : dbo.PR_RentDetails_Insert & dbo.PR_RentDetails_UpdateByPk
        public bool dbo_PR_RentDetails_Save(RentModel rentModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {

                if (rentModel.RentID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@Rent", DbType.Double, rentModel.Rent);
                    sqlDatabase.AddInParameter(dbCommand, "@CarType", DbType.String, rentModel.CarType);

                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@RentID", DbType.Int64, rentModel.RentID);
                    sqlDatabase.AddInParameter(dbCommand, "@Rent", DbType.Double, rentModel.Rent);
                    sqlDatabase.AddInParameter(dbCommand, "@CarType", DbType.String, rentModel.CarType);

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

        #region Method : dbo.PR_RentDetails_SelectByPK
        public RentModel dbo_PR_RentDetails_SelectByPK(int? RentID)
        {
            RentModel rentModel = new RentModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@RentID", DbType.Int64, RentID);
               
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    rentModel.RentID = Convert.ToInt32(dataRow["RentID"]);
                    rentModel.Rent = Convert.ToDouble(dataRow["Rent"]);
                    rentModel.CarType = dataRow["CarType"].ToString();
                    rentModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    rentModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return rentModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_RentDetails_Delete
        public void dbo_PR_RentDetails_Delete(int? RentID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RentDetails_Delete");
                sqlDatabase.AddInParameter(dbCommand, "RentID", DbType.Int64, RentID);
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
