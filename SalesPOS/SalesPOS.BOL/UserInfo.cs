using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public  class UserInfo
    {
        #region _attributes

        private string _UserName = null;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _NewPassword = null;

        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }

        private long _UserInfoId;

        public long UserInfoId
        {
            get { return _UserInfoId; }
            set { _UserInfoId = value; }
        }
        string _SoftUser;

        public string SoftUser
        {
            get { return _SoftUser; }
            set { _SoftUser = value; }
        }
        string _SoftPassword;

        public string SoftPassword
        {
            get { return _SoftPassword; }
            set { _SoftPassword = value; }
        }
        string _PasswordsHints;

        public string PasswordsHints
        {
            get { return _PasswordsHints; }
            set { _PasswordsHints = value; }
        }
        long _ActivityID;

        public long ActivityID
        {
            get { return _ActivityID; }
            set { _ActivityID = value; }
        }
        long _Priority;

        public long Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        DateTime _UpdatedDate;

        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        long _UpdatedBy;

        public long UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        DateTime _CreatedDate;

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        long _CreatedBy;

        public long CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        long _IsDeleted;

        public long IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        private static string _DB_Source = null;
        public static string DB_Source
        {
            get { return _DB_Source; }
            set { _DB_Source = value; }
        }



        private static string _DB_Name = null;
        public static string DB_Name
        {
            get { return _DB_Name; }
            set { _DB_Name = value; }
        }


        private static string _DB_User = null;
        public static string DB_User
        {
            get { return _DB_User; }
            set { _DB_User = value; }
        }

        private static string _DB_Pass = null;
        public static string DB_Pass
        {
            get { return _DB_Pass; }
            set { _DB_Pass = value; }
        }

        #endregion


    }
}
