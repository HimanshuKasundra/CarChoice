using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.AspNetCore.Hosting;
using CarChoice.Areas.SEC_User.Models;

namespace CarChoice.DAL.SEC_User
{
    public class SEC_UserDALBase : DALHelper
    {
		private readonly IWebHostEnvironment _webHostEnvironment;
		public SEC_UserDALBase(IWebHostEnvironment webHostEnvironment )
		{
			_webHostEnvironment = webHostEnvironment;
		}

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
        public bool dbo_PR_UserDetails_Register(SEC_UserModel SEC_UserModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_UserDetails_SelectUserName");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, SEC_UserModel.UserName);
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
                    if (SEC_UserModel.UserImage != null)
                    {
						string folder = "Photos/Users/";
						folder += Guid.NewGuid().ToString() + "_" + SEC_UserModel.UserImage.FileName;  // Guid.NewGuid().ToString() for making file name unique

						SEC_UserModel.UserImageURL = "/" + folder;

						string serverfolder = Path.Combine( _webHostEnvironment.WebRootPath, folder);

						SEC_UserModel.UserImage.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
					}

                    DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("PR_UserDetails_Insert");
                    sqlDB.AddInParameter(dbCMD1, "FirstName", SqlDbType.VarChar, SEC_UserModel.FirstName);
                    sqlDB.AddInParameter(dbCMD1, "LastName", SqlDbType.VarChar, SEC_UserModel.LastName);
                    sqlDB.AddInParameter(dbCMD1, "Email", SqlDbType.VarChar, SEC_UserModel.Email);
                    sqlDB.AddInParameter(dbCMD1, "UserName", SqlDbType.VarChar, SEC_UserModel.UserName);
                    sqlDB.AddInParameter(dbCMD1, "Password", SqlDbType.VarChar, SEC_UserModel.Password);
                    sqlDB.AddInParameter(dbCMD1, "UserImageURL", SqlDbType.VarChar, SEC_UserModel.UserImageURL);
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
    }
}