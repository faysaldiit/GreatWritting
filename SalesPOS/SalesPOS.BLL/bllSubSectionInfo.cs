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
    public static class bllSubSectionInfo
    {
        public static DataTable getAll()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, @"
                            SELECT SubSectionInfo.SubSectionID, SubSectionInfo.SubSectionName, SectionInfo.SectionName, ActivityInfo.Activity
                            FROM SubSectionInfo INNER JOIN
                            SectionInfo ON SubSectionInfo.SectionID = SectionInfo.SectionID INNER JOIN
                            ActivityInfo ON SubSectionInfo.ActivityID = ActivityInfo.ActivityID
                            WHERE (SubSectionInfo.IsDeleted = 0)
                            ORDER BY SectionInfo.SectionName", param);
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

        public static DataTable getById(long SubSectionId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@SubSectionId", SubSectionId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_subsectioninfo_getbyId", param);
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
        public static DataTable getBySectionId(long SectionId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);

                param[0] = dbManager.getparam("@SectionId", SectionId);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_subsectioninfo_getbySectionId", param);
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
        public static bool Insert(SubSectionInfo objSubSectionInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);

                param[0] = dbManager.getparam("@SubSectionName", objSubSectionInfo.SubSectionName.ToString());
                param[1] = dbManager.getparam("@SectionID", objSubSectionInfo.SectionID.ToString());
                param[2] = dbManager.getparam("@ActivityID", objSubSectionInfo.ActivityID.ToString());

                param[3] = dbManager.getparam("@CreatedDate", objSubSectionInfo.CreatedDate);
                param[4] = dbManager.getparam("@CreatedBy", objSubSectionInfo.CreatedBy.ToString());
                param[5] = dbManager.getparam("@IsDeleted", false);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_SubSectionInfo_Add", param);

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
        public static bool Update(SubSectionInfo objSubSectionInfo)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@SubSectionID", objSubSectionInfo.SubSectionID.ToString());
                param[1] = dbManager.getparam("@SubSectionName", objSubSectionInfo.SubSectionName.ToString());
                param[2] = dbManager.getparam("@SectionID", objSubSectionInfo.SectionID.ToString());
                param[3] = dbManager.getparam("@ActivityID", objSubSectionInfo.ActivityID.ToString());
                param[4] = dbManager.getparam("@UpdatedDate", objSubSectionInfo.UpdatedDate);
                param[5] = dbManager.getparam("@UpdatedBy", objSubSectionInfo.UpdatedBy.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "USP_SubSectionInfo_Update", param);

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
        public static bool Delete(long SubSectionId)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@SubSectionId", SubSectionId);
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_subsectioninfo_delete", param);

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
        public static void LoadSectionInfoCombo(System.Windows.Forms.ComboBox cmbActivity)
        {
            DataTable dt = new DataTable();
            dt = bllSectionInfo.getAll();
            cmbActivity.DisplayMember = "SectionName";
            cmbActivity.ValueMember = "SectionID";
            //this.dgvUserList.AutoGenerateColumns = false;
            //this.dgvUserList.DataSource = dt;
            cmbActivity.DataSource = dt;
        }
    }
}
