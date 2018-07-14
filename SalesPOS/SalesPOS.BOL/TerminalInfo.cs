using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class TerminalInfo
    {

        #region _attributes

        long _TerminalID;
        string _TerminalName;
        string _Attribute;
        string _ValueOfAttribute;
        DateTime _ActivationDate;
        DateTime _ExpireDate;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;

        #endregion


        #region _propertise

        public long TerminalID
        {

            get { return _TerminalID; }
            set { _TerminalID = value; }

        }
        public string TerminalName
        {

            get { return _TerminalName; }
            set { _TerminalName = value; }

        }
        public string Attribute
        {

            get { return _Attribute; }
            set { _Attribute = value; }

        }
        public string ValueOfAttribute
        {

            get { return _ValueOfAttribute; }
            set { _ValueOfAttribute = value; }

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


