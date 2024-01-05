using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarChoice.Areas.Brand.Models;

namespace CarChoice.DAL.Brand
{
    public class BrandDALBase:DALHelper
    {
        #region Method : dbo.PR_Brand_SelectAll
        public DataTable dbo_PR_BrandDetails_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_SelectAll");
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

        #region Method : dbo.PR_BrandDetails_Insert & dbo.PR_BrandDetails_UpdateByPk
        public bool dbo_PR_BrandDetails_Save(BrandModel brandModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (brandModel.Logo != null)
                {
                    string FilePath = "wwwroot\\Photos\\Brands";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileNameWithPath = Path.Combine(path, brandModel.Logo.FileName);
                    brandModel.BrandLogo = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + brandModel.Logo.FileName;

                    using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        brandModel.Logo.CopyTo(fileStream);
                    }
                }

                if (brandModel.BrandID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@BrandName", DbType.String, brandModel.BrandName);
                    sqlDatabase.AddInParameter(dbCommand, "@BrandLogo", DbType.String, brandModel.BrandLogo);
                   
                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@BrandID", DbType.Int64, brandModel.BrandID);
                    sqlDatabase.AddInParameter(dbCommand, "@BrandName", DbType.String, brandModel.BrandName);
                    sqlDatabase.AddInParameter(dbCommand, "@BrandLogo", DbType.String, brandModel.BrandLogo);
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

        #region Method : dbo.PR_Brand_SelectByPK
        public BrandModel dbo_PR_BrandDetails_SelectByPK(int? BrandID)
        {
            BrandModel brandModel = new BrandModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@BrandID", DbType.Int64, BrandID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    brandModel.BrandID = Convert.ToInt32(dataRow["BrandID"]);
                    brandModel.BrandName = dataRow["BrandName"].ToString();
                    brandModel.BrandLogo = dataRow["BrandLogo"].ToString();
                    brandModel.Created = Convert.ToDateTime(dataRow["Created"].ToString());
                    brandModel.Modified = Convert.ToDateTime(dataRow["Modified"].ToString());
                }
                return brandModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.PR_BrandDetails_Delete
        public void dbo_PR_BrandDetails_Delete(int? BrandID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BrandDetails_Delete");
                sqlDatabase.AddInParameter(dbCommand, "BrandID", DbType.Int64, BrandID);
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
