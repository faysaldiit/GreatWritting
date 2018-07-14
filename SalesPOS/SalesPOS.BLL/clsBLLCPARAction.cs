using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QISS.DataAccessLayer;
using BOL;


namespace QISS.BLL
{
    public static class clsBLLCPARAction
    {
        //public static DataTable getbyid(string EquipId)
        //{
        //    IQISSDBManager dbManager = new QISSDBManager();
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
        //        param[0] = dbManager.getparam("@EquipId", EquipId.ToString().Trim());

        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "sp_equipment_get", param);
        //        dt = dbManager.GetDataTable(cmd);

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return dt;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        dbManager.Dispose();
        //    }

        //}


        //public static DataTable getAll(string EquipBranchId)
        //{
        //    string id = "ALL";
        //    IQISSDBManager dbManager = new QISSDBManager();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dbManager.Open();
        //        IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
        //        param[0] = dbManager.getparam("@EquipId", id);
        //        param[1] = dbManager.getparam("@EquipBranchId", EquipBranchId.ToString());

        //        IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "sp_equipment_get", param);
        //        dt = dbManager.GetDataTable(cmd);
        //        return dt;

        //    }

        //    catch (Exception ex)
        //    {
        //        return dt;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        dbManager.Dispose();
        //    }
        //}

        /// <summary>
        /// This menthod is used for add records in the DB table.
        /// </summary>
        /// <param name="objBOLNcrCategory"></param>
        /// <returns></returns>
        public static Boolean add(clsBOLCPARAction objBOLCPARAction)
        { //---START ADD---
            IQISSDBManager dbManager = new QISSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 11);
                param[0] = dbManager.getparam("@CAId", objBOLCPARAction.CAId.ToString());
                param[1] = dbManager.getparam("@CACIId", objBOLCPARAction.CACIId);
                param[2] = dbManager.getparam("@CAActionNo", objBOLCPARAction.CAActionNo);
                //param[3] = dbManager.getparam("@CAJobOrder", objBOLCPARAction.CAJobOrder);
                param[3] = dbManager.getparam("@CAStage", objBOLCPARAction.CAStage);
                //param[4] = dbManager.getparam("@CANoOfSteps", objBOLCPARAction.CANoOfSteps);
                param[4] = dbManager.getparam("@CAAssignedTo", objBOLCPARAction.CAAssignedTo.ToString());
                param[5] = dbManager.getparam("@CADueDate", objBOLCPARAction.CADueDate.ToString());
                param[6] = dbManager.getparam("@CAActionType", objBOLCPARAction.CAActionType);
                param[7] = dbManager.getparam("@CAFirstComment", objBOLCPARAction.CAFirstComment.ToString());
                param[8] = dbManager.getparam("@CASecondComment", string.IsNullOrEmpty(objBOLCPARAction.CASecondComment.ToString()) ? string.Empty : objBOLCPARAction.CASecondComment.ToString());
                param[9] = dbManager.getparam("@CAReportFile", string.IsNullOrEmpty(objBOLCPARAction.CAReportFile.ToString() ) ? string.Empty : objBOLCPARAction.CAReportFile.ToString());
                param[10] = dbManager.getparam("@CADateAction", objBOLCPARAction.CADateAction.ToString());


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_CPAR_Action_add", param);

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
        } //---END ADD---
        public static Boolean addForTakeAction(clsBOLCPARAction objBOLCPARAction, Hashtable objHashTable)
        { //---START ADD---
            IQISSDBManager dbManager = new QISSDBManager();
            Boolean chk = false;
            try
            {
                dbManager.Open();
                dbManager.objHashtable = objHashTable;

                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 11);
                param[0] = dbManager.getparam("@CAId", objBOLCPARAction.CAId.ToString());
                param[1] = dbManager.getparam("@CACIId", objBOLCPARAction.CACIId);
                param[2] = dbManager.getparam("@CAActionNo", objBOLCPARAction.CAActionNo);
                //param[3] = dbManager.getparam("@CAJobOrder", objBOLCPARAction.CAJobOrder);
                param[3] = dbManager.getparam("@CAStage", objBOLCPARAction.CAStage);
                //param[4] = dbManager.getparam("@CANoOfSteps", objBOLCPARAction.CANoOfSteps);
                param[4] = dbManager.getparam("@CAAssignedTo", objBOLCPARAction.CAAssignedTo.ToString());
                param[5] = dbManager.getparam("@CADueDate", objBOLCPARAction.CADueDate.ToString());
                param[6] = dbManager.getparam("@CAActionType", objBOLCPARAction.CAActionType);
                param[7] = dbManager.getparam("@CAFirstComment", objBOLCPARAction.CAFirstComment.ToString());
                param[8] = dbManager.getparam("@CASecondComment", string.IsNullOrEmpty(objBOLCPARAction.CASecondComment.ToString()) ? string.Empty : objBOLCPARAction.CASecondComment.ToString());
                param[9] = dbManager.getparam("@CAReportFile", string.IsNullOrEmpty(objBOLCPARAction.CAReportFile.ToString()) ? string.Empty : objBOLCPARAction.CAReportFile.ToString());
                param[10] = dbManager.getparam("@CADateAction", objBOLCPARAction.CADateAction.ToString());


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_CPAR_Action_add", param);

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
        } //---END ADD---
        public static DataTable getAppReqCompStepCPAR(string CAAssignedTo, string CIBranchId, clsBOLGetAllCPARInformation obj)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            DataTable dt = new DataTable();

            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 6);
                param[0] = dbManager.getparam("@CAAssignedTo", CAAssignedTo.ToString());
                param[1] = dbManager.getparam("@CIBranchId", CIBranchId.ToString());
                param[2] = dbManager.getparam("@CICPARNo", obj.CICPARNo);
                param[3] = dbManager.getparam("@CIInitiator", obj.CIInitiator);
                param[4] = dbManager.getparam("@CIInitiateDate_start", obj.CIInitiateDate_start);
                param[5] = dbManager.getparam("@CIInitiateDate_end", obj.CIInitiateDate_end);

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_CPARAction_APPRequest_CompStep", param);

                dt = dbManager.GetDataTable(cmd);
                return dt;

            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                dbManager.Dispose();
                dt.Dispose();

            }
        }
        public static DataTable getCPARRequestFrom(string CACIId, string CAStage)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            DataTable dt = new DataTable();

            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 2);
                param[0] = dbManager.getparam("@CACIId", CACIId.ToString());
                param[1] = dbManager.getparam("@CAStage", CAStage.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_CPARInfo_getCPARRequestFrom", param);
                dt = dbManager.GetDataTable(cmd);

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }

        }
        public static DataTable getAssignedWorkInformation(string CIId)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            DataTable dt = new DataTable();

            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@CIId", CIId.ToString());

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_CPARAction_get_AssignedWork", param);
                dt = dbManager.GetDataTable(cmd);

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                dt.Dispose();
                dbManager.Dispose();
            }

        }





        // ------------------

        //public static Boolean adddfgdfgd(clsBOLScheduleMaintenance objBOLScheduleMaintenance, Hashtable objHashTable, char operationType)
        //{ //---START ADD---
            //IQISSDBManager dbManager = new QISSDBManager();
            //List<IDbCommand> lst_cmd = new List<IDbCommand>();
            //Boolean chk = false;
            //try
            //{
            //    dbManager.Open();
            //    dbManager.objHashtable = objHashTable;
            //    dbManager.operationType = operationType;

            //    IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 10);
            //    param[0] = dbManager.getparam("@SdlMainId", objBOLScheduleMaintenance.SdlMainId.ToString());
            //    param[1] = dbManager.getparam("@SdlMainEquipId", objBOLScheduleMaintenance.SdlMainEquipId.ToString());
            //    param[2] = dbManager.getparam("@SdlMainBy", objBOLScheduleMaintenance.SdlMainBy.ToString());
            //    param[3] = dbManager.getparam("@SdlMainComment", objBOLScheduleMaintenance.SdlMainComment.ToString());
            //    param[4] = dbManager.getparam("@SdlMainMainType", Convert.ToChar(objBOLScheduleMaintenance.SdlMainMainType));
            //    param[5] = dbManager.getparam("@SdlMainDate", objBOLScheduleMaintenance.SdlMainDate.ToString());
            //    param[6] = dbManager.getparam("@SdlMainSdlType", Convert.ToInt32(objBOLScheduleMaintenance.SdlMainSdlType));
            //    param[7] = dbManager.getparam("@SdlMainDownTime", Convert.ToInt32(objBOLScheduleMaintenance.SdlMainDownTime));
            //    param[8] = dbManager.getparam("@SdlMainCost", Convert.ToDouble(objBOLScheduleMaintenance.SdlMainCost));
            //    //param[9] = dbManager.getparam("@SdlMainIsApproved", Convert.ToChar(objBOLScheduleMaintenance.SdlMainIsApproved));
            //    param[9] = dbManager.getparam("@SdlMainReportFile", objBOLScheduleMaintenance.SdlMainReportFile.ToString());

            //    IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_schedule_maintenance_add", param);
            //    //chk = dbManager.ExecuteQuery(cmd);

            //    lst_cmd.Add(cmd);

            //    foreach (clsBOLEquipmentMaintenanceDetail objBOLEquipmentMaintenanceDetail in objBOLScheduleMaintenance.ObjBOLEquipmentMaintenanceDetail)
            //    {
            //        IDbDataParameter[] paramDocReDet = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 3);

            //        paramDocReDet[0] = dbManager.getparam("@EqmdEquipId", objBOLEquipmentMaintenanceDetail.EqmdEquipId);
            //        paramDocReDet[1] = dbManager.getparam("@EqmdNextDate", objBOLEquipmentMaintenanceDetail.EqmdNextDate);
            //        paramDocReDet[2] = dbManager.getparam("@EqmdOperationType", Convert.ToInt32(objBOLEquipmentMaintenanceDetail.EqmdOperationType));

            //        IDbCommand cmdlstEqip = dbManager.getCommand(CommandType.StoredProcedure, "sp_equipmentMaintenanceDetail_updateNextDate", paramDocReDet);
            //        lst_cmd.Add(cmdlstEqip);
            //    }

            //    chk = dbManager.ExecuteTransaction(lst_cmd);
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            //finally
            //{
            //    dbManager.Dispose();

            //}
            //return chk;
        //} //---END ADD---


        // ------------------



    }
}
