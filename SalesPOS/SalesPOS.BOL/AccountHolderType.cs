using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class AccountHolderType
    {

        #region _attributes

        long _AccountHolderTypeID;
        string _AccountHolderTypeName;
        string _AccountHolderTypePrefix;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;

       

        #endregion


        #region _propertise

        public long AccountHolderTypeID
        {

            get { return _AccountHolderTypeID; }
            set { _AccountHolderTypeID = value; }

        }
        public string AccountHolderTypeName
        {

            get { return _AccountHolderTypeName; }
            set { _AccountHolderTypeName = value; }

        }
        public string AccountHolderTypePrefix
        {
            get { return _AccountHolderTypePrefix; }
            set { _AccountHolderTypePrefix = value; }
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
        #endregion

    }



}
