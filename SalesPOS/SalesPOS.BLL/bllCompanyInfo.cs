using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;
using System.Windows.Forms;

namespace SalesPOS.BLL 
{
    public static class bllCompanyInfo
    {
        public static DataTable getById(long CompanyId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@CompanyID", CompanyId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_companyinfo_getbyId", param);
                dt = dbManager.GetDataTable(cmd);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }
            return dt;
        }

        public static bool Update(CompanyInfo objCompanyInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 13);

                param[0] = dbManager.getparam("@ActivationDate", objCompanyInfo.ActivationDate);
                param[1] = dbManager.getparam("@ActivityID", objCompanyInfo.ActivityID.ToString());
                param[2] = dbManager.getparam("@Address", objCompanyInfo.Address.ToString());
                param[3] = dbManager.getparam("@CompanyID", objCompanyInfo.CompanyID.ToString());
                param[4] = dbManager.getparam("@CompanyName", objCompanyInfo.CompanyName.ToString());
                param[5] = dbManager.getparam("@ContactNumber", objCompanyInfo.ContactNumber.ToString());
                param[6] = dbManager.getparam("@Email", objCompanyInfo.Email.ToString());
                param[7] = dbManager.getparam("@ExpireDate", objCompanyInfo.ExpireDate);
                param[8] = dbManager.getparam("@FAX", objCompanyInfo.FAX.ToString());
                param[9] = dbManager.getparam("@ShortCode", objCompanyInfo.ShortCode.ToString());
                param[10] = dbManager.getparam("@WebURL", objCompanyInfo.WebURL.ToString());
                param[11] = dbManager.getparam("@UpdatedDate", objCompanyInfo.UpdatedDate);
                param[12] = dbManager.getparam("@UpdatedBy", objCompanyInfo.UpdatedBy.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_CompanyInfo_Update", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
    }
}
