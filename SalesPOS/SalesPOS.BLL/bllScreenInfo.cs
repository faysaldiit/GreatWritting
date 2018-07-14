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
  public class bllScreenInfo
    {

      public static bool InsertScreen(ScreenInfo objScreenInfo)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          Boolean chk = false;
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType,3);

              //param[0] = dbManager.getparam("@ScreenCode", objScreenInfo.ScreenCode.ToString());
              param[0] = dbManager.getparam("@ScreenName", objScreenInfo.ScreenName.ToString());
              param[1] = dbManager.getparam("@FormName", objScreenInfo.FormName.ToString());
              param[2] = dbManager.getparam("@MenuCode", objScreenInfo.MenuCode.ToString());

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "Inser_ScreenMaster", param);

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

      public static DataTable getMenuList()
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = null;
              IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select distinct MenuID,MenuName,menudescription from  dbo.MasterMenuInfo", param);
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


      public static DataTable getMenu_ScreenList()
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = null;
              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "ScreenList_ScreenMaster", param);
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

      public static bool InsertScreen_UserPermission(ScreenInfo objScreenInfo)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          Boolean chk = false;
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);

              //param[0] = dbManager.getparam("@ScreenCode", objScreenInfo.ScreenCode.ToString());
              param[0] = dbManager.getparam("@UserInfoId", objScreenInfo.UserInfoId.ToString());
              param[1] = dbManager.getparam("@ScreenID", objScreenInfo.ScreenCode.ToString());
              param[2] = dbManager.getparam("@MenuID", objScreenInfo.MenuCode.ToString());

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "Insert_UserMenuConfigure", param);

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

      public static DataTable getUserSubMenuList(long MenuID,long UnitInfoId)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);

              param[0] = dbManager.getparam("@UserID", UnitInfoId);
              param[1] = dbManager.getparam("@MenuCode", MenuID);

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "ScreenList_For_UserLogin", param);
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

      public static DataTable getUserMenuList(long UnitInfoId)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

              param[0] = dbManager.getparam("@UserID", UnitInfoId);

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[usp_MenuList_For_UserLogin]", param);
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

      public static DataTable getUserInformation(long LoginID)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

              param[0] = dbManager.getparam("@UserInfoId", LoginID);

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "Search_UserInfo_By_LoginID", param);
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

      public static DataTable getUserAccessInformation(long UserInfoID)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

              param[0] = dbManager.getparam("@UserInfoID", UserInfoID);

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_Access_MenuItem_Lost_By_UserLoginID", param);
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


      public static DataTable getUserList()
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          DataTable dt = new DataTable();
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = null;

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_UserList", param);
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

      public static bool UpdateUserPassword(UserInfo obj_Userinfo)
      {
          ISalesPOSDBManager dbManager = new SalesPOSDBManager();
          Boolean chk = false;
          try
          {
              dbManager.Open();
              IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 4);

              //param[0] = dbManager.getparam("@ScreenCode", objScreenInfo.ScreenCode.ToString());
              param[0] = dbManager.getparam("@UserInfoId", obj_Userinfo.UserInfoId);
              param[1] = dbManager.getparam("@SoftUser", obj_Userinfo.SoftUser.ToString());
              param[2] = dbManager.getparam("@SoftPassword", obj_Userinfo.SoftPassword.ToString());
              param[3] = dbManager.getparam("@NewPassword", obj_Userinfo.NewPassword.ToString());

              IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_Updaet_User_Password", param);

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
