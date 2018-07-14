using System;
using System.Windows.Forms;
using System.Collections;

using SalesPOS.DataAccessLayer;
using SalesPOS.BOL;
using SalesPOS.Report;

using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Data;





namespace SalesPOS.BLL
{
  public  class bllReportUtility
    {
      ISalesPOSDBManager dbManager = new SalesPOSDBManager();
        #region"Updated PrintPreview method with ui parameter"
      
        public void PrintPreview(ReportClass iReport, string rpt_procedure, Hashtable ht, bool isPrint)
        {
          
            try
            {
                DataTable DTab_reportData = (DataTable)ReportData(rpt_procedure);
                if (DTab_reportData.Rows.Count > 0)
                {
                    if (isPrint == false)
                    {
                       // frmRptv ifrmPrint = new frmRptv();
                        
                        iReport.SetDataSource(DTab_reportData);
                        foreach (object obj in ht.Keys)
                        {
                            iReport.SetParameterValue(obj.ToString(), ht[obj]);
                        }
                        frmPrint ifrmPrint = new frmPrint(iReport);                        
                        ifrmPrint.Visible = true;
                    }
                    else
                    {
                        iReport.ReportOptions.EnableSaveDataWithReport = true;
                        iReport.SetDataSource(DTab_reportData);
                        foreach (object obj in ht.Keys)
                        {
                            iReport.SetParameterValue(obj.ToString(), ht[obj]);
                        }
                        iReport.PrintToPrinter(1, false, 0, 0); //iReport.PrintToPrinter(1, false, 0, 0);
                    }
                }
                else
                {
                    MessageBox.Show("No Records Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
              
            }
        }
   
        #endregion

        public static DataTable ReportData(string store_procedure)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            DataTable dt = new DataTable();
            try
            {                
                dbManager.Open();                
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, store_procedure, param);
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

        public static bool Exec_Store_Procedure(string store_procedure)
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool chk=true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = null;
                IDbCommand cmd = dbManager.getCommand(CommandType.Text, store_procedure, param);
                dbManager.ExecuteQuery(cmd);


            }
            catch (Exception ex)
            {
                chk = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return chk;
        }

    }
}
