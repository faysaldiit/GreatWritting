using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductPurchaseInfo
    {
        #region _attributes

        string _PurchaseID;
        string _PurchaseDate;
        string _MemoNo;
        double _TotalAmount;
        double _TotalPaid;
        string _SupplierAccountNo;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        string _TransactionType;
        #endregion


        #region _propertise
        public string TransactionType
        {
            get
            {
                return _TransactionType;
            }
            set
            {
                if (_TransactionType == value)
                    return;
                _TransactionType = value;
            }
        }
        public string PurchaseID
        {

            get { return _PurchaseID; }
            set { _PurchaseID = value; }

        }
        public string PurchaseDate
        {

            get { return _PurchaseDate; }
            set { _PurchaseDate = value; }

        }
        public string MemoNo
        {

            get { return _MemoNo; }
            set { _MemoNo = value; }

        }
        public double TotalAmount
        {

            get { return _TotalAmount; }
            set { _TotalAmount = value; }

        }
        public double TotalPaid
        {

            get { return _TotalPaid; }
            set { _TotalPaid = value; }

        }
        public string SupplierAccountNo
        {

            get { return _SupplierAccountNo; }
            set { _SupplierAccountNo = value; }

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
