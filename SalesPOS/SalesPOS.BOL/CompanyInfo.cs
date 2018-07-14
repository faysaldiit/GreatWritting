using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class CompanyInfo
    {

        #region _attributes

        long _CompanyID;
        string _CompanyName;
        string _ShortCode;
        string _Address;
        string _ContactNumber;
        string _FAX;
        string _Email;
        string _WebURL;
        DateTime _ActivationDate;
        DateTime _ExpireDate;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;

        #endregion


        #region _propertise

        public long CompanyID
        {

            get { return _CompanyID; }
            set { _CompanyID = value; }

        }
        public string CompanyName
        {

            get { return _CompanyName; }
            set { _CompanyName = value; }

        }
        public string ShortCode
        {

            get { return _ShortCode; }
            set { _ShortCode = value; }

        }
        public string Address
        {

            get { return _Address; }
            set { _Address = value; }

        }
        public string ContactNumber
        {

            get { return _ContactNumber; }
            set { _ContactNumber = value; }

        }
        public string FAX
        {

            get { return _FAX; }
            set { _FAX = value; }

        }
        public string Email
        {

            get { return _Email; }
            set { _Email = value; }

        }
        public string WebURL
        {

            get { return _WebURL; }
            set { _WebURL = value; }

        }
        public DateTime ActivationDate
        {

            get { return _ActivationDate; }
            set { _ActivationDate = value; }

        }
        public DateTime ExpireDate
        {

            get { return _ExpireDate; }
            set { _ExpireDate = value; }

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
