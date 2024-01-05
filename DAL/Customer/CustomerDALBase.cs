using CarChoice.Areas.Customer.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
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

        #region Method : dbo.PR_Customer_Delete
        public void dbo_PR_Customer_Delete(int CustomerID)
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

        #region Method : dbo.PR_Customer_Insert & dbo.PR_Customer_Update
        public bool dbo_PR_Customer_Save(CustomerModel customerModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (customerModel.CustomerID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Customer_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@FirstName", DbType.String, customerModel.FirstName);
                    sqlDatabase.AddInParameter(dbCommand, "@LastName", DbType.String, customerModel.LastName);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, customerModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Mobile", DbType.String, customerModel.Mobile);
                    sqlDatabase.AddInParameter(dbCommand, "@Address", DbType.String, customerModel.Address);
                    sqlDatabase.AddInParameter(dbCommand, "@LicenceNumber", DbType.String, customerModel.LicenceNumber);
                    sqlDatabase.AddInParameter(dbCommand, "@LicenceImageURL", DbType.String, customerModel.LicenceImageURL);
                    sqlDatabase.AddInParameter(dbCommand, "@CustomerImageURL", DbType.String, customerModel.CustomerImageURL);
                    sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.Int64, DBNull.Value);
                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.String, customerModel.CustomerID);
                    sqlDatabase.AddInParameter(dbCommand, "@FirstName", DbType.String, customerModel.FirstName);
                    sqlDatabase.AddInParameter(dbCommand, "@LastName", DbType.String, customerModel.LastName);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, customerModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Mobile", DbType.String, customerModel.Mobile);
                    sqlDatabase.AddInParameter(dbCommand, "@Address", DbType.String, customerModel.Address);
                    sqlDatabase.AddInParameter(dbCommand, "@LicenceNumber", DbType.String, customerModel.LicenceNumber);
                    sqlDatabase.AddInParameter(dbCommand, "@LicenceImageURL", DbType.String, customerModel.LicenceImageURL);
                    sqlDatabase.AddInParameter(dbCommand, "@CustomerImageURL", DbType.String, customerModel.CustomerImageURL);
                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.Int64, DBNull.Value);
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

        #region Method : dbo.PR_Customer_SelectByPK
        public DataTable dbo_PR_Customer_SelectByPK(int? CustomerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Customer_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.Int64, CustomerID);
                DataTable dt = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dt.Load(dataReader);
                }
               
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_CustomerEdit_SelectByPK
        public CustomerModel dbo_PR_CustomerEdit_SelectByPK(int? CustomerID)
        {
            CustomerModel customerModel = new CustomerModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Customer_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.Int64, CustomerID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    customerModel.CustomerID = Convert.ToInt32(dataRow["CustomerID"]);
                    customerModel.FirstName = dataRow["FirstName"].ToString();
                    customerModel.LastName = dataRow["LastName"].ToString();
                    customerModel.Email = dataRow["Email"].ToString();
                    customerModel.Mobile = dataRow["Mobile"].ToString();
                    customerModel.Address = dataRow["Address"].ToString();
                    customerModel.LicenceNumber = dataRow["LicenceNumber"].ToString();
                    customerModel.LicenceImageURL = dataRow["LicenceImageURL"].ToString();
                    customerModel.CustomerImageURL = dataRow["CustomerImageURL"].ToString();
                    customerModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    customerModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return customerModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
