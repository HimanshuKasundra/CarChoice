using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Transmission.Models;

namespace CarChoice.DAL.Transmission
{
    public class TransmissionDALBase : DALHelper
    {
        #region Method : dbo.PR_TransmissionDetails_SelectAll
        public DataTable dbo_PR_TransmissionDetails_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionDetails_SelectAll");
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

        #region Method : dbo.PR_TransmissionDetails_Insert & dbo.PR_TransmissionDetails_UpdateByPk
        public bool dbo_PR_TransmissionDetails_Save(TransmissionModel transmissionModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
               
                if (transmissionModel.TransmissionID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionDetails_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionType", DbType.String, transmissionModel.TransmissionType);

                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionDetails_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int64, transmissionModel.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionType", DbType.String, transmissionModel.TransmissionType);
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

        #region Method : dbo.PR_TransmissionDetails_SelectByPK
        public TransmissionModel dbo_PR_TransmissionDetails_SelectByPK(int? TransmissionID)
        {
            TransmissionModel transmissionModel = new TransmissionModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionDetails_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int64, TransmissionID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    transmissionModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    transmissionModel.TransmissionType = dataRow["TransmissonType"].ToString();
                    transmissionModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    transmissionModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return transmissionModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_TransmissionDetails_Delete
        public void dbo_PR_TransmissionDetails_Delete(int? TransmissionID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_TransmissionDetails_Delete");
                sqlDatabase.AddInParameter(dbCommand, "TransmissionID", DbType.Int64, TransmissionID);
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
