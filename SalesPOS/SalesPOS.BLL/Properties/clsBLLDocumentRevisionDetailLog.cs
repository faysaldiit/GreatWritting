using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using BOL;
using QISS.DataAccessLayer;
using System.Data;
using System.Web;
using System.Xml.Linq;

namespace QISS.BLL
{
    public class clsBLLDocumentRevisionDetailLog
    {
        public static Boolean add(clsBOLDocumentRevisionDetailLog objBOLDocumentRevisionDetailLog)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            bool chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 15);
                param[0] = dbManager.getparam("@DRDLId", objBOLDocumentRevisionDetailLog.DRDLId);
                param[1] = dbManager.getparam("@DRDId", objBOLDocumentRevisionDetailLog.DRDId);
                param[2] = dbManager.getparam("@DRDTitle", objBOLDocumentRevisionDetailLog.DRDTitle);
                param[3] = dbManager.getparam("@DRDDDId", objBOLDocumentRevisionDetailLog.DRDDDId);
                param[4] = dbManager.getparam("@DRDRevisionNo", objBOLDocumentRevisionDetailLog.DRDRevisionNo);
                param[5] = dbManager.getparam("@DRDManualRevisionNo", objBOLDocumentRevisionDetailLog.DRDManualRevisionNo);
                param[6] = dbManager.getparam("@DRDSecChange", objBOLDocumentRevisionDetailLog.DRDSecChange);
                param[7] = dbManager.getparam("@DRDChangeMade", objBOLDocumentRevisionDetailLog.DRDChangeMade);
                param[8] = dbManager.getparam("@DRDFinallyAprvFileName", objBOLDocumentRevisionDetailLog.DRDFinallyAprvFileName);
                if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.none)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '0');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.approved)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '1');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.disapproved)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '2');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.aborted)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '3');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.obsoleted)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '4');
                }

                param[10] = dbManager.getparam("@DRDCreationDate", objBOLDocumentRevisionDetailLog.DRDCreationDate);
                param[11] = dbManager.getparam("@DRDApprovalDate", objBOLDocumentRevisionDetailLog.DRDApprovalDate);
                param[12] = dbManager.getparam("@DRDChangedBy", objBOLDocumentRevisionDetailLog.DRDChangedBy);
                param[13] = dbManager.getparam("@DRDDisApproveReason", objBOLDocumentRevisionDetailLog.DRDDisApproveResion);
                param[14] = dbManager.getparam("@DRDDueDate", objBOLDocumentRevisionDetailLog.DRDDueDate);


                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_document_revision_detail_log_add", param);

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
        public static Boolean update(clsBOLDocumentRevisionDetail objBOLDocumentRevisionDetail)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            bool chk = false;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 15);
                param[0] = dbManager.getparam("@DRDLId", objBOLDocumentRevisionDetailLog.DRDLId);
                param[1] = dbManager.getparam("@DRDId", objBOLDocumentRevisionDetailLog.DRDId);
                param[2] = dbManager.getparam("@DRDTitle", objBOLDocumentRevisionDetailLog.DRDTitle);
                param[3] = dbManager.getparam("@DRDDDId", objBOLDocumentRevisionDetailLog.DRDDDId);
                param[4] = dbManager.getparam("@DRDRevisionNo", objBOLDocumentRevisionDetailLog.DRDRevisionNo);
                param[5] = dbManager.getparam("@DRDManualRevisionNo", objBOLDocumentRevisionDetailLog.DRDManualRevisionNo);
                param[6] = dbManager.getparam("@DRDSecChange", objBOLDocumentRevisionDetailLog.DRDSecChange);
                param[7] = dbManager.getparam("@DRDChangeMade", objBOLDocumentRevisionDetailLog.DRDChangeMade);
                param[8] = dbManager.getparam("@DRDFinallyAprvFileName", objBOLDocumentRevisionDetailLog.DRDFinallyAprvFileName);
                if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.none)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '0');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.approved)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '1');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.disapproved)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '2');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.aborted)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '3');
                }
                else if (objBOLDocumentRevisionDetailLog.DRDIsApproved == clsBOLDocumentRevisionDetailLog.IsApproved.obsoleted)
                {
                    param[9] = dbManager.getparam("@DRDIsApproved", '4');
                }

                param[10] = dbManager.getparam("@DRDCreationDate", objBOLDocumentRevisionDetailLog.DRDCreationDate);
                param[11] = dbManager.getparam("@DRDApprovalDate", objBOLDocumentRevisionDetailLog.DRDApprovalDate);
                param[12] = dbManager.getparam("@DRDChangedBy", objBOLDocumentRevisionDetailLog.DRDChangedBy);
                param[13] = dbManager.getparam("@DRDDisApproveReason", objBOLDocumentRevisionDetailLog.DRDDisApproveResion);
                param[14] = dbManager.getparam("@DRDDueDate", objBOLDocumentRevisionDetailLog.DRDDueDate);



                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_document_revision_detail_log_update", param);

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
        public static Boolean delete(string DocumentRevisionDetailLogId)
        {
            IQISSDBManager dbManager = new QISSDBManager();
            Boolean chk = false;

            try
            {
                dbManager.Open();
                IDbDataParameter[] param = QISSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);
                param[0] = dbManager.getparam("@DRDLId", DocumentRevisionDetailLogId.ToString());
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "usp_document_revision_detail_log_delete", param);
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
