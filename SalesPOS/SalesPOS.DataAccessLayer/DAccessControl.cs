using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using SalesPOS.BOL;

namespace SalesPOS.DataAccessLayer
{
    public class DAccessControl
    {
        public static SqlConnection Conn
        {
            get
            {
                SqlConnection conn = new SqlConnection() { ConnectionString = "Data Source=" + UserInfo.DB_Source + ";" + "Initial Catalog=" + UserInfo.DB_Name + ";" + "user id=" + UserInfo.DB_User + ";password=" + UserInfo.DB_Pass + ";" };
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    //erp_perser.reach_connection = false;
                    //erp_perser.connection_faild_msg = ex.Message;
                    //MessageBox.Show("");
                    throw (ex);
                }
                conn.Close();
                return conn;
            }
        }       


        //#region Get Currenet Sub Center Name
        //public void get_sub_center()
        //{
        //    string FileName = "constr.dtl";
        //    if (erp_perser.is_local)
        //        FileName = "constr_local.dtl";

        //    if (!File.Exists(FileName))
        //    {
        //        get_sub_center_from_syscon();
        //        return;
        //    }

        //    string text = "";
        //    text = File.ReadAllText(FileName);
        //    string[] con_details = text.Split(',');
        //    if (text.Length > 20) // if can read row from database
        //    {
        //        if (con_details.Length > 12)
        //        {
        //            string sub_center_code = con_details[12].ToString().Trim();
        //            UserInfo.producer_code = sub_center_code;
        //        }
        //        else UserInfo.producer_code = "";

        //        if (con_details.Length > 11)
        //        {
        //            string sub_center_name = con_details[11].ToString().Trim();
        //            if (sub_center_name == "")
        //                UserInfo.sub_center_name = "CS";
        //            else
        //                UserInfo.sub_center_name = sub_center_name;
        //        }
        //        else
        //            UserInfo.sub_center_name = "CS";
        //    }
        //    else
        //    {
        //        get_sub_center_from_syscon();
        //        return;
        //    }
        //}

        //public void get_sub_center_from_syscon()
        //{
        //    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Syscon.dtl;Jet OLEDB:Database Password=b4xqj");  // connection string change database name and password here.
        //    if (erp_perser.is_local)
        //        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Syscon_working.dtl;Jet OLEDB:Database Password=b4xqj");  // connection string change database name and password here.
        //    con.Open(); //connection must be openned
        //    OleDbCommand cmd = new OleDbCommand("SELECT * from serverinfo", con); // creating query command
        //    OleDbDataReader reader = cmd.ExecuteReader(); // executes query

        //    while (reader.Read()) // if can read row from database
        //    {

        //        if (reader.VisibleFieldCount > 10)
        //        {
        //            string sub_center_name = reader.GetValue(10).ToString().Trim();
        //            if (sub_center_name == "")
        //                UserInfo.sub_center_name = "CS";
        //            else
        //                UserInfo.sub_center_name = sub_center_name;
        //        }
        //        else UserInfo.sub_center_name = "CS";

        //        string sub_center_code = "";
        //        if (reader.VisibleFieldCount > 11)
        //        {
        //            sub_center_code = reader.GetValue(11).ToString().Trim();
        //            UserInfo.producer_code = sub_center_code;
        //        }

        //    }
        //    con.Close();
        //}
        //#endregion


        //#region Get DB Connection Details
        //public void ReadData_from_syscon()
        //{

        //    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Syscon.dtl;Jet OLEDB:Database Password=b4xqj");  // connection string change database name and password here.
        //    if (erp_perser.is_local)
        //        con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Syscon_working.dtl;Jet OLEDB:Database Password=b4xqj");  // connection string change database name and password here.
        //    con.Open(); //connection must be openned
        //    OleDbCommand cmd = new OleDbCommand("SELECT * from serverinfo", con); // creating query command
        //    OleDbDataReader reader = cmd.ExecuteReader(); // executes query

        //    while (reader.Read()) // if can read row from database
        //    {
        //        //this.Text = reader.GetValue(0).ToString() + ", " + reader.GetValue(1).ToString() + ", " + reader.GetValue(2).ToString() + ", " + reader.GetValue(3).ToString();
        //        UserInfo.DB_Source = reader.GetValue(0).ToString();
        //        UserInfo.DB_Name = reader.GetValue(1).ToString();
        //        UserInfo.DB_User = reader.GetValue(2).ToString();
        //        UserInfo.DB_Pass = reader.GetValue(3).ToString();

        //        //string sub_center_name=reader.GetValue(10).ToString().Trim();
        //        //if (sub_center_name == "")
        //        //    UserInfo.sub_center_name = "CS";
        //        //else
        //        //    UserInfo.sub_center_name = sub_center_name;
        //    }
        //    con.Close();
        //}
        //public void ReadData()
        //{
        //    string FileName = "constr.dtl";
        //    if (erp_perser.is_local)
        //        FileName = "constr_local.dtl";

        //    if (!File.Exists(FileName))
        //    {
        //        ReadData_from_syscon();
        //        return;
        //    }

        //    string text = "";
        //    text = File.ReadAllText(FileName);
        //    string[] con_details = text.Split(',');
        //    if (text.Length > 20) // if can read row from database
        //    {
        //        UserInfo.DB_Source = con_details[0].ToString();
        //        UserInfo.DB_Name = con_details[1].ToString();
        //        UserInfo.DB_User = con_details[2].ToString();
        //        string raw_pass = con_details[3].ToString();
        //        string config = con_details[4].ToString();
        //        string f_pass = "";
        //        for (int i = 0; i < config.Length; i = i + 2)
        //        {
        //            f_pass = raw_pass.Substring(0, Convert.ToInt32(config.Substring(i, 1)));
        //            raw_pass = f_pass + raw_pass.Substring(Convert.ToInt32(config.Substring(i + 1, 1)) + f_pass.Length);
        //        }
        //        UserInfo.DB_Pass = raw_pass;

        //        UserInfo.report_DB_Source = con_details[7].ToString();
        //        UserInfo.report_DB_Name = con_details[8].ToString();
        //        UserInfo.report_DB_User = con_details[9].ToString();
        //        UserInfo.report_DB_Pass = con_details[10].ToString();

        //        UserInfo.outlet_DB_Source = con_details[7].ToString();
        //        UserInfo.outlet_DB_Name = con_details[8].ToString();
        //        UserInfo.outlet_DB_User = con_details[9].ToString();
        //        UserInfo.outlet_DB_Pass = con_details[10].ToString();

        //        //string sub_center_name = con_details[11].ToString().Trim();
        //        //if (sub_center_name == "")
        //        //    UserInfo.sub_center_name = "CS";
        //        //else
        //        //    UserInfo.sub_center_name = sub_center_name;
        //    }
        //    else
        //    {
        //        ReadData_from_syscon();
        //        return;
        //    }

        //}
        //#endregion


        //public void ReadData_outlet()
        //{
        //    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Syscon.dtl;Jet OLEDB:Database Password=b4xqj");  // connection string change database name and password here.
        //    con.Open(); //connection must be openned
        //    OleDbCommand cmd = new OleDbCommand("SELECT * from serverinfo", con); // creating query command
        //    OleDbDataReader reader = cmd.ExecuteReader(); // executes query

        //    while (reader.Read()) // if can read row from database
        //    {
        //        //this.Text = reader.GetValue(0).ToString() + ", " + reader.GetValue(1).ToString() + ", " + reader.GetValue(2).ToString() + ", " + reader.GetValue(3).ToString();
        //        UserInfo.outlet_DB_Source = reader.GetValue(6).ToString();
        //        UserInfo.outlet_DB_Name = reader.GetValue(7).ToString();
        //        UserInfo.outlet_DB_User = reader.GetValue(8).ToString();
        //        UserInfo.outlet_DB_Pass = reader.GetValue(9).ToString();
        //    }
        //    con.Close();
        //}
    }
}
