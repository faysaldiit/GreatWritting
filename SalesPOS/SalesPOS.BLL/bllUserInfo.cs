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
    public static class bllUserInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;


                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select UserInfoId, SoftUser,SoftPassword, PasswordsHints,UserName,ui.ActivityID , Activity from UserInfo ui left outer join dbo.ActivityInfo ai
on ai.ActivityID = ui.ActivityID Where ui.IsDeleted=0", param);
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
        public static DataTable getById(long UserInfoId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@UserInfoId", UserInfoId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_useronfo_getbyId", param);
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
        public static bool Insert(UserInfo objUserInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 8);
                
                param[0] = dbManager.getparam("@SoftUser", objUserInfo.SoftUser.ToString());
                param[1] = dbManager.getparam("@SoftPassword", objUserInfo.SoftPassword.ToString());
                param[2] = dbManager.getparam("@ActivityID", objUserInfo.ActivityID.ToString());
                param[3] = dbManager.getparam("@PasswordsHints", objUserInfo.PasswordsHints.ToString());
                param[4] = dbManager.getparam("@CreatedDate", objUserInfo.CreatedDate);
                param[5] = dbManager.getparam("@CreatedBy", objUserInfo.CreatedBy.ToString());
                param[6] = dbManager.getparam("@IsAdmin", objUserInfo.IsAdmin);
                param[7] = dbManager.getparam("@UserName", objUserInfo.UserName.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_useronfo_insert", param);

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
        public static bool Update(UserInfo objUserInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 9);
                param[0] = dbManager.getparam("@UserInfoId", objUserInfo.UserInfoId.ToString());
                param[1] = dbManager.getparam("@SoftUser", objUserInfo.SoftUser.ToString());               
                param[2] = dbManager.getparam("@ActivityID", objUserInfo.ActivityID.ToString());
                param[3] = dbManager.getparam("@UpdatedDate", objUserInfo.UpdatedDate);
                param[4] = dbManager.getparam("@UpdatedBy", objUserInfo.UpdatedBy.ToString());
                param[5] = dbManager.getparam("@UserName", objUserInfo.UserName.ToString());
                param[6] = dbManager.getparam("@SoftPassword", objUserInfo.SoftPassword.ToString());
                param[7] = dbManager.getparam("@PasswordsHints", objUserInfo.PasswordsHints.ToString());
                param[8] = dbManager.getparam("@IsAdmin", objUserInfo.IsAdmin);
               

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_useronfo_update", param);

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
        public static bool Delete(long UserInfoId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@UserInfoId", UserInfoId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_useronfo_delete", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
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
