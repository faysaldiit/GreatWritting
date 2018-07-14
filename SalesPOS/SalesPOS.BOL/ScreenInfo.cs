using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class ScreenInfo
    {

        #region _attributes
        private static string _User_Name = null;

        public static string User_Name
        {
            get { return ScreenInfo._User_Name; }
            set { ScreenInfo._User_Name = value; }
        }
        private static string _User_ID = null;

        public static string User_ID
        {
            get { return ScreenInfo._User_ID; }
            set { ScreenInfo._User_ID = value; }
        }
        private long _screenCode;

        public long ScreenCode
        {
            get { return _screenCode; }
            set { _screenCode = value; }
        }
        private string _screenName;

        public string ScreenName
        {
            get { return _screenName; }
            set { _screenName = value; }
        }
        private string _formName;

        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        private long _menuCode;

        public long MenuCode
        {
            get { return _menuCode; }
            set { _menuCode = value; }
        }

        private long _userInfoId;

        public long UserInfoId
        {
            get { return _userInfoId; }
            set { _userInfoId = value; }
        }
	
        #endregion
    }
}
