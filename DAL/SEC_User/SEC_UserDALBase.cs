
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.AspNetCore.Hosting;
using CarChoice.Areas.SEC_User.Models;
using CarChoice.Areas.Customer.Models;

namespace CarChoice.DAL.SEC_User
{
    public class SEC_UserDALBase : DALHelper
    {
		

		#region Method: dbo_PR_SEC_User_SelectByPK
		public DataTable dbo_PR_UserDetails_SelectByUserNamePassword(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UserDetails_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
				sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region Method: dbo_PR_SEC_User_Register
        public bool dbo_PR_UserDetails_Register(SEC_UserModel sEC_UserModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD =sqlDB .GetStoredProcCommand("PR_UserDetails_SelectUserName");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, sEC_UserModel.UserName);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDB.ExecuteReader(dbCMD))
                {
                    dataTable.Load(dataReader);
                }
                if (dataTable.Rows.Count > 0)
                {
                    return false;
                }
                else
                {

                    if (sEC_UserModel.CustomerImage != null)
                    {
                        string FilePath = "wwwroot\\Photos\\Users";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, sEC_UserModel.CustomerImage.FileName);

                        sEC_UserModel.CustomerImageURL = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + sEC_UserModel.CustomerImage.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            sEC_UserModel.CustomerImage.CopyTo(fileStream);
                        }
                    }

                    DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("PR_UserDetails_Insert");
                    sqlDB.AddInParameter(dbCMD1, "FirstName", SqlDbType.VarChar, sEC_UserModel.FirstName);
                    sqlDB.AddInParameter(dbCMD1, "LastName", SqlDbType.VarChar, sEC_UserModel.LastName);
                    sqlDB.AddInParameter(dbCMD1, "Email", SqlDbType.VarChar, sEC_UserModel.Email);
                    sqlDB.AddInParameter(dbCMD1, "UserName", SqlDbType.VarChar, sEC_UserModel.UserName);
                    sqlDB.AddInParameter(dbCMD1, "Password", SqlDbType.VarChar, sEC_UserModel.Password);
                    sqlDB.AddInParameter(dbCMD1, "CustomerImageURL", SqlDbType.VarChar, sEC_UserModel.CustomerImageURL);
                    if (Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCMD1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.PR_User_SelectByPK
        public SEC_UserModel dbo_PR_SEC_User_SelectByPK(int? CustomerID)
        {
            SEC_UserModel sECUserModel = new SEC_UserModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_UserDetails_SelectByPk");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", DbType.Int32, CustomerID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    sECUserModel.CustomerID = Convert.ToInt32(dataRow["CustomerID"]);
                    sECUserModel.FirstName = dataRow["FirstName"].ToString();
                    sECUserModel.LastName = dataRow["LastName"].ToString();
                    sECUserModel.Email = dataRow["Email"].ToString();
                    sECUserModel.UserName = dataRow["UserName"].ToString();
                    sECUserModel.Password = dataRow["Password"].ToString();
                    
                    sECUserModel.CustomerImageURL = dataRow["CustomerImageURL"].ToString();
                    sECUserModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    sECUserModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return sECUserModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

      

    }
}