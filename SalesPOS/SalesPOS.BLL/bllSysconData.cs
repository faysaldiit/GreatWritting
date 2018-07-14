using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesPOS.BLL
{
    public class bllSysconData
    {
        private static string _DataSource;
        private static string _Database;
        private static string _User;
        private static string _Password;

        public string DataSource
        {
            get
            {
                return _DataSource;
            }
        }
        public string Database
        {
            get
            {
                return _Database;
            }
        }
        public string User
        {
            get
            {
                return _User;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
        }

        private void ReadData()
        {
            string DbPath = Application.StartupPath;
            DbPath = DbPath + "\\Syscon.dtl";
            //iDBUtility.SetConnectionParameters(DbPath, "", "b4xqj");
            //iDBUtility.Select("serverinfo");

            // database connection open


            //read data


            //databse connection close

        }
    }
}
