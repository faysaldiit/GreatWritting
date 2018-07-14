using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class AccountTransactions
    {
        #region _attributes

        string _TransactionNumber;
        string _AccountHolderCode;
         string _AccountHead;
        string _TransactionType;
        string _RefNumber;
        string _Remarks;
        decimal _PreviousBalance;
        decimal _BillAmount;
        decimal _TotalDueAmount;
        decimal _PaidAmount;

        #endregion


        #region _propertise

        public string TransactionNumber
        {
            get { return _TransactionNumber; }
            set { _TransactionNumber = value; }
        }
        public string AccountHolderCode
        {

            get { return _AccountHolderCode; }
            set { _AccountHolderCode = value; }

        }
        public string AccountHead
        {

            get { return _AccountHead; }
            set { _AccountHead = value; }

        }
        public string TransactionType
        {

            get { return _TransactionType; }
            set { _TransactionType = value; }

        }
        public string RefNumber
        {

            get { return _RefNumber; }
            set { _RefNumber = value; }

        }
        public string Remarks
        {

            get { return _Remarks; }
            set { _Remarks = value; }

        }
        public decimal PreviousBalance
        {

            get { return _PreviousBalance; }
            set { _PreviousBalance = value; }

        }
        public decimal BillAmount
        {

            get { return _BillAmount; }
            set { _BillAmount = value; }

        }
        public decimal TotalDueAmount
        {

            get { return _TotalDueAmount; }
            set { _TotalDueAmount = value; }

        }
        public decimal PaidAmount
        {

            get { return _PaidAmount; }
            set { _PaidAmount = value; }

        }

        #endregion
    }
}
