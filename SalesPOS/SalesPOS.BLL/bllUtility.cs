using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesPOS.DataAccessLayer;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Management;
using System.Data;
using SalesPOS.BOL;
using System.Drawing;
using System.IO;
using System.Net;

namespace SalesPOS.BLL
{
    public static class bllUtility
    {
        /// <summary>
        /// This inner class will store all the logged in user infromation, i.e: logged user Id, name company name id etc.... 
        /// </summary>
        public static double Val(object Expression)
        {
            double retNum;
            if (Expression == null)
                return 0;
            else if (Expression.ToString() == "True")
                return 1;
            else if (Double.TryParse(Convert.ToString(Expression).Replace(",", ""), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum) == true)
                return Convert.ToDouble(Expression);
            else
                return 0;
        }

        public static string UploadFile(string FtpUrl, string fileName, string userName, string password, string UploadDirectory)
        {
            string PureFileName = new FileInfo(fileName).Name;
            String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            req.UsePassive = true;
            byte[] data = File.ReadAllBytes(fileName);
            req.ContentLength = data.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();
            return res.StatusDescription;
        }

        public static DataTable generate_datetable(string columns)
        {
            DataTable new_datatable = new DataTable();
            string[] columns_array = columns.Split(',');
            foreach (string col in columns_array)
            {
                DataColumn ncol = new DataColumn(col);
                new_datatable.Columns.Add(ncol);
            }
            return new_datatable;
        }
        public static void ResetGridColor(DataGridView DGV)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AllowUserToResizeRows = false;
            DGV.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            DGV.DefaultCellStyle = dataGridViewCellStyle3;
            DGV.MultiSelect = false;
            DGV.ColumnHeadersHeight = 23;

            //DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        public static String changeNumericToWords(double numb)
        {
            String num = numb.ToString();
            return changeToWords(num, false);
        }
        public static String changeCurrencyToWords(String numb)
        {
            return changeToWords(numb, true);
        }
        public static String changeNumericToWords(String numb)
        {
            return changeToWords(numb, false);
        }
        public static String changeCurrencyToWords(double numb)
        {
            return changeToWords(numb.ToString(), true);
        }
        public static String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Paisa " + endStr) : ("");
                        pointStr = translateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { ;}
            return val;
        }
        public static String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 6://Lac' range        
                        case 7:
                            pos = (numDigits % 6) + 1;
                            place = " Lac ";
                            break;
                        case 8://Core
                        case 9:
                        case 10:
                        case 11:
                            pos = (numDigits % 8) + 1;
                            place = " Core ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { ;}
            return word.Trim();
        }
        private static String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String translateCents(String cents)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }


        public static class LoggedInSystemInformation
        {
            private static long _LoggedUserId;
            private static string _LoggedUserName;
            private static string _TerminalID;
            private static string _SoftwareName;
            private static string _LicenseTo;
            private static string _Version;
            private static string _ActivationDate;
            private static string _ExpireDate;
            private static bool _IsAdmin;
            private static string _UserName;
            private static string _LoginPass;
            private static string _CompanyName;
            private static string _CompanyAddress;
            private static string _CompanyContactNo;




            public static string UserName
            {
                get { return LoggedInSystemInformation._UserName; }
                set { LoggedInSystemInformation._UserName = value; }
            }
            public static string LoginPass
            {
                get { return LoggedInSystemInformation._LoginPass; }
                set { LoggedInSystemInformation._LoginPass = value; }
            }

            public static bool IsAdmin
            {
                get { return LoggedInSystemInformation._IsAdmin; }
                set { LoggedInSystemInformation._IsAdmin = value; }

            }

            public static long LoggedUserId
            {
                get { return LoggedInSystemInformation._LoggedUserId; }
                set { LoggedInSystemInformation._LoggedUserId = value; }
            }
            public static string LoggedUserName
            {
                get { return LoggedInSystemInformation._LoggedUserName; }
                set { LoggedInSystemInformation._LoggedUserName = value; }
            }
            public static string TerminalID
            {
                get { return LoggedInSystemInformation._TerminalID; }
                set { LoggedInSystemInformation._TerminalID = value; }
            }

            /*Software information*/
            public static string SoftwareName
            {
                get { return LoggedInSystemInformation._SoftwareName; }
                set { LoggedInSystemInformation._SoftwareName = value; }
            }
            public static string LicenseTo
            {
                get { return LoggedInSystemInformation._LicenseTo; }
                set { LoggedInSystemInformation._LicenseTo = value; }
            }
            public static string Version
            {
                get { return LoggedInSystemInformation._Version; }
                set { LoggedInSystemInformation._Version = value; }
            }
            public static string ActivationDate
            {
                get { return LoggedInSystemInformation._ActivationDate; }
                set { LoggedInSystemInformation._ActivationDate = value; }
            }
            public static string ExpireDate
            {
                get { return LoggedInSystemInformation._ExpireDate; }
                set { LoggedInSystemInformation._ExpireDate = value; }
            }
            public static string CompanyName
            {
                get { return LoggedInSystemInformation._CompanyName; }
                set { LoggedInSystemInformation._CompanyName = value; }
            }
            public static string CompanyAddress
            {
                get { return LoggedInSystemInformation._CompanyAddress; }
                set { LoggedInSystemInformation._CompanyAddress = value; }
            }
            public static string CompanyContactNo
            {
                get { return LoggedInSystemInformation._CompanyContactNo; }
                set { LoggedInSystemInformation._CompanyContactNo = value; }
            }

        }
        public static class DefaultSettings
        {
            private static string _ID;
            private static string _DefaultSaleType;
            private static string _IsEditableSalePrice;
            private static string _DiscountAllow;
            private static string _MiniAccAllow;
            private static string _CreditSaleAllow;
            private static string _SalePrintType;
            private static string _ExpireDateAllow;
            private static string _Store2Display;

            private static string _ftp_url;
            private static string _api_link;

            public static string Api_link
            {
                get { return DefaultSettings._api_link; }
                set { DefaultSettings._api_link = value; }
            }

            public static string Ftp_url
            {
                get { return DefaultSettings._ftp_url; }
                set { DefaultSettings._ftp_url = value; }
            }
            private static string _ftp_user;

            public static string Ftp_user
            {
                get { return DefaultSettings._ftp_user; }
                set { DefaultSettings._ftp_user = value; }
            }
            private static string _ftp_pass;

            public static string Ftp_pass
            {
                get { return DefaultSettings._ftp_pass; }
                set { DefaultSettings._ftp_pass = value; }
            }
            private static string _csv_path_local;

            public static string Csv_path_local
            {
                get { return DefaultSettings._csv_path_local; }
                set { DefaultSettings._csv_path_local = value; }
            }
            private static string _no_of_days_syn;

            public static string No_of_days_syn
            {
                get { return DefaultSettings._no_of_days_syn; }
                set { DefaultSettings._no_of_days_syn = value; }
            }

            public static string ID
            {
                get { return DefaultSettings._ID; }
                set { DefaultSettings._ID = value; }
            }
            public static string DefaultSaleType
            {
                get { return DefaultSettings._DefaultSaleType; }
                set { DefaultSettings._DefaultSaleType = value; }
            }
            public static string IsEditableSalePrice
            {
                get { return DefaultSettings._IsEditableSalePrice; }
                set { DefaultSettings._IsEditableSalePrice = value; }
            }
            public static string DiscountAllow
            {
                get { return DefaultSettings._DiscountAllow; }
                set { DefaultSettings._DiscountAllow = value; }
            }
            public static string Store2Display
            {
                get { return DefaultSettings._Store2Display; }
                set { DefaultSettings._Store2Display = value; }
            }
            public static string ExpireDateAllow
            {
                get { return DefaultSettings._ExpireDateAllow; }
                set { DefaultSettings._ExpireDateAllow = value; }
            }
            public static string MiniAccAllow
            {
                get { return DefaultSettings._MiniAccAllow; }
                set { DefaultSettings._MiniAccAllow = value; }
            }
            public static string CreditSaleAllow
            {
                get { return DefaultSettings._CreditSaleAllow; }
                set { DefaultSettings._CreditSaleAllow = value; }
            }
            public static string SalePrintType
            {
                get { return DefaultSettings._SalePrintType; }
                set { DefaultSettings._SalePrintType = value; }
            }
        }

        public static class ReturnSearchedAccountHolderInfo
        {

            private static AccountHolderInfo _searchedAccountHolderInfo;

            public static AccountHolderInfo returnSearchedAccountHolderInfo
            {
                get { return ReturnSearchedAccountHolderInfo._searchedAccountHolderInfo; }
                set { ReturnSearchedAccountHolderInfo._searchedAccountHolderInfo = value; }
            }

        }
        /// <summary>
        /// this is an inner class which  will set the searched returned value.
        /// </summary>
        public static class ReturnSearchedProduct
        {

            private static ProductInfo _searchedProductInfo;

            public static ProductInfo returnSearchedProductInfo
            {
                get { return ReturnSearchedProduct._searchedProductInfo; }
                set { ReturnSearchedProduct._searchedProductInfo = value; }
            }

        }
        /// <summary>
        /// this is an inner class which we will use to set generic erros/warning/success message into our application.
        /// </summary>
        public static class Messages
        {
            public static String OperationSuccess
            {
                get
                {
                    return "Operation Successfully Done";
                }
            }
            public static String OperationFailure
            {
                get
                {
                    return "Operation Failed";
                }
            }
            public static String OperationCanceled
            {
                get
                {
                    return "Operation Canceled";
                }
            }
            public static String InsertMessage
            {
                get
                {
                    return "Your Data Successfully Inserted";
                }
            }
            public static String UpdateMessage
            {
                get
                {
                    return "Your Data Successfully Updated";
                }
            }
            public static String DeleteMessage
            {
                get
                {
                    return "Your Data Successfully Deleted";
                }
            }

            public static String DeleteFailMessage
            {
                get
                {
                    return "Your Data Delete Operation Failed";
                }
            }

            public static String InsertFailMessage
            {
                get
                {
                    return "Your Data Insert Operation Failed";
                }
            }
            public static String UpdateFailMessage
            {
                get
                {
                    return "Your Data Update Operation Failed";
                }
            }


            public static String DeleteErrorMessage
            {
                get
                {
                    return "Cannot delete. Related with another object.";
                }
            }
            public static String EmptyWarningMessage
            {
                get
                {
                    return "Cannot be empty";
                }
            }

            public static String AlertMessageCaption
            {
                get
                {
                    return "Alert";
                }
            }
            public static String SuccessMessageCaption
            {
                get
                {
                    return "Message";
                }
            }

            public static String DeleteStringForYesNoMsgBox
            {
                get
                {
                    return "Are you sure, you want to delete?";
                }
            }
            public static String CancelStringForYesNoMsgBox
            {
                get
                {
                    return "Are you sure, you want to cancel?";
                }
            }

            public static String ComboBoxItemSelectChekedMessage
            {
                get
                {
                    return "A value must be slected from the list";
                }
            }
            public static String StartTimeMessage
            {
                get
                {
                    return "Start time is greater than end time.";
                }
            }
            public static String EndTimeMessage
            {
                get
                {
                    return "End time is less than start time.";
                }
            }

            public static String RemoveMessage
            {
                get
                {
                    return "Your Data Successfully Removed";
                }
            }

            public static String RemoveFailMessage
            {
                get
                {
                    return "Your Data Remove Operation Failed";
                }
            }

            public static String ActivateMessage
            {
                get
                {
                    return "Your Data Successfully Activated";
                }
            }

            public static String ActivateFailMessage
            {
                get
                {
                    return "Your Data Activation Operation Failed";
                }
            }

            public static String MailSentMessage
            {
                get
                {
                    return "Mail successfully sent";
                }
            }

            public static String MailSentFailMessage
            {
                get
                {
                    return "Mail couldn't sent";
                }
            }




        }
        public static string EncryptPassword(string password)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();
            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(password));
            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();
            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            return returnValue.ToString();
        }
        public static string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL

            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
            //return disk["SerialNumber"].ToString();
        }
        public static bool CreateDB_Backup()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isDBBackup = true;
            try
            {
                dbManager.Open();
                IDbDataParameter[] param = SalesPOSDBManagerFactory.GetParameters(dbManager.ProviderType, 1);;
                param[0] = dbManager.getparam("@DbName", "SalesSystemComilla");

                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[USP_BackupDataBase]", param);
                dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                isDBBackup = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return isDBBackup;
        }
        public static bool LogClear()
        {
            ISalesPOSDBManager dbManager = new SalesPOSDBManager();
            bool isLogClear = true;
            try
            {
                dbManager.Open();
                IDbCommand cmd = dbManager.getCommand(CommandType.StoredProcedure, "[dbo].[clearing_db_log]", null);
                dbManager.GetDataTable(cmd);
            }
            catch (Exception ex)
            {
                isLogClear = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbManager.Dispose();
            }
            return isLogClear;
        }
        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty) // only return MAC Address from first card
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }
        public static void LoadAcitivityCombo(System.Windows.Forms.ComboBox cmbActivity)
        {
            DataTable dt = new DataTable();
            dt = bllActivityInfo.getAll();
            cmbActivity.DisplayMember = "Activity";
            cmbActivity.ValueMember = "ActivityID";
            //this.dgvUserList.AutoGenerateColumns = false;
            //this.dgvUserList.DataSource = dt;
            cmbActivity.DataSource = dt;
        }

        public static DataTable GetDataBySP(string store_procedure)
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

        public static void LoadGridStyle(DataGridView dgv)
        {
            //data grid view style
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
        }
        public static class GlobalEnum
        {
            public enum AccountHolderType
            {
                Supplier = 1,
                Customer = 2
            }

        }
        public static string FormatDate(DateTimePicker dtp)
        {
            string dt = dtp.Value.ToString("dd/MM/yyyy");
            return dt;
        }
        //public static void my_message(string txt_msg)
        //{
        //    DevExpress.XtraEditors.XtraMessageBox.Show(txt_msg, "Sales System");
        //}
        //public static double Val(object Expression)
        //{
        //    double retNum;
        //    if (Expression == null)
        //        return 0;
        //    else if (Expression.ToString() == "True")
        //        return 1;
        //    else if (Double.TryParse(Convert.ToString(Expression).Replace(",", ""), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum) == true)
        //        return Convert.ToDouble(Expression);
        //    else
        //        return 0;
        //}
    }
}
