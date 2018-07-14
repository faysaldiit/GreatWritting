using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class SectionInfo
    {
        #region _attributes

        long _SectionID;
        string _SectionName;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        int _IsDeleted;
        decimal _DiscountPercent;

        #endregion


        #region _propertise

        public long SectionID

        {

        get {return _SectionID;}
        set { _SectionID=value;}

        }
        public string SectionName

        {

        get {return _SectionName;}
        set { _SectionName=value;}

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


        public decimal DiscountPercent
        {

            get { return _DiscountPercent; }
            set { _DiscountPercent = value; }

        }

        #endregion
        
    }
}
