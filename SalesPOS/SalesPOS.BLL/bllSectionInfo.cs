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
    public static class bllSectionInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"select 
                ai.ActivityID,
                ai.Activity,
                si.SectionId,
                si.SectionName,
                si.ActivityID,
                si.UpdatedDate,
                si.UpdatedBy,
                si.DiscountPercent 
                from dbo.SectionInfo si left outer join dbo.ActivityInfo ai
                on ai.ActivityID = si.ActivityID Where si.IsDeleted=0 order by si.SectionName", param);
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
        public static DataTable getById(long SectionId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@SectionId", SectionId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_sectioninfo_getbyId", param);
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
        public static bool Insert(SectionInfo objSectionInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);

                param[0] = dbManager.getparam("@SectionName", objSectionInfo.SectionName.ToString());
                param[1] = dbManager.getparam("@ActivityID", objSectionInfo.ActivityID.ToString());

                param[2] = dbManager.getparam("@CreatedDate", objSectionInfo.CreatedDate);
                param[3] = dbManager.getparam("@CreatedBy", objSectionInfo.CreatedBy.ToString());
                param[4] = dbManager.getparam("@IsDeleted", false);
                param[5] = dbManager.getparam("@DiscountPercent", objSectionInfo.DiscountPercent);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_SectionInfo_Add", param);

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
        public static bool Update(SectionInfo objSectionInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@SectionId", objSectionInfo.SectionID.ToString());
                param[1] = dbManager.getparam("@SectionName", objSectionInfo.SectionName.ToString());
                param[2] = dbManager.getparam("@ActivityID", objSectionInfo.ActivityID.ToString());
                param[3] = dbManager.getparam("@UpdatedDate", objSectionInfo.UpdatedDate);
                param[4] = dbManager.getparam("@UpdatedBy", objSectionInfo.UpdatedBy.ToString());
                param[5] = dbManager.getparam("@DiscountPercent", objSectionInfo.DiscountPercent.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_SectionInfo_Update", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }
        public static bool Delete(long SectionId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@SectionId", SectionId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_sectioninfo_delete", param);

                chk = dbManager.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();

            }
            return chk;
        }

        public static DataTable IsDuplicateCategoryName(long SectionID, string SectionName, string EventType)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);
                param[0] = dbManager.getparam("@SectionID", SectionID);
                param[1] = dbManager.getparam("@SectionName", SectionName);
                param[2] = dbManager.getparam("@EventType", EventType);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "dbo.[USP_IsDuplicateCategoryName]", param);
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
    }
}
