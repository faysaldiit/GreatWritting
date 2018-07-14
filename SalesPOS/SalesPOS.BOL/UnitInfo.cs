using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{  
    public  class UnitInfo
    {

        #region _attributes

        long _UnitId;
        string _UnitName;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        int _IsDeleted;

        #endregion


        #region _propertise

        public long UnitId

        {

            get {return _UnitId;}
            set { _UnitId=value;}

        }
        public string UnitName

        {

            get {return _UnitName;}
            set { _UnitName=value;}

        }
        public long ActivityID

        {

            get {return _ActivityID;}
            set { _ActivityID=value;}

        }
        public DateTime UpdatedDate

        {

            get {return _UpdatedDate;}
            set { _UpdatedDate=value;}

        }
        public long UpdatedBy

        {

            get {return _UpdatedBy;}
            set { _UpdatedBy=value;}

        }
        public DateTime CreatedDate

        {

            get {return _CreatedDate;}
            set { _CreatedDate=value;}

        }
        public long CreatedBy

        {

            get {return _CreatedBy;}
            set { _CreatedBy=value;}

        }
        public int IsDeleted

        {

            get {return _IsDeleted;}
            set { _IsDeleted=value;}

        }
        #endregion
    }
}

