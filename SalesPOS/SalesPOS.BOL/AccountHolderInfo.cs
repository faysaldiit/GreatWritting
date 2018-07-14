using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class AccountHolderInfo
    {

        #region _attributes

        long _AccHolderInfoId;
        string _AccountNo;
        string _AccHolderName;
        long _AccountHolderTypeID;
        string _Address;
        string _ContactNo;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        int _IsDeleted;
        long _ZoneID;
        string _RSMID;
        #endregion


        #region _propertise

        public string RSMID
        {
            get { return _RSMID; }
            set { _RSMID = value; }
        }

        public long AccHolderInfoId
        {

            get { return _AccHolderInfoId; }
            set { _AccHolderInfoId = value; }

        }
        public string AccountNo
        {

            get { return _AccountNo; }
            set { _AccountNo = value; }

        }
        public string AccHolderName
        {

            get { return _AccHolderName; }
            set { _AccHolderName = value; }

        }
        public long AccountHolderTypeID
        {

            get { return _AccountHolderTypeID; }
            set { _AccountHolderTypeID = value; }

        }
        public string Address
        {

            get { return _Address; }
            set { _Address = value; }

        }
        public string ContactNo
        {

            get { return _ContactNo; }
            set { _ContactNo = value; }

        }
        public long ActivityID
        {

            get { return _ActivityID; }
            set { _ActivityID = value; }

        }
        public DateTime UpdatedDate
        {

            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }

        }
        public long UpdatedBy
        {

            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }

        }
        public DateTime CreatedDate
        {

            get { return _CreatedDate; }
            set { _CreatedDate = value; }

        }
        public long CreatedBy
        {

            get { return _CreatedBy; }
            set { _CreatedBy = value; }

        }
        public int IsDeleted
        {

            get { return _IsDeleted; }
            set { _IsDeleted = value; }

        }
        public long ZoneID
        {

            get { return _ZoneID; }
            set { _ZoneID = value; }

        }
        #endregion

    }



}
