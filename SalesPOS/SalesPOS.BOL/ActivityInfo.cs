using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ActivityInfo
    {
        #region _attributes
        long _ActivityID;

        public long ActivityID
        {
            get { return _ActivityID; }
            set { _ActivityID = value; }
        }
        string _Activity;

        public string Activity
        {
            get { return _Activity; }
            set { _Activity = value; }
        }
        #endregion
    }
}
