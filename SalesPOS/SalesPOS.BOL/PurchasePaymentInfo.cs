using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class PurchasePaymentInfo
    {
        #region _attributes

        string _PurchaseID;
        string _PayTypeId;
        string _PaidAmount;
        string _CardNo;
        string _ExpDate;
        string _SupplierID;
        string _TerminalID;
        string _CreatedBy;

        #endregion

        #region _propertise

        public string PurchaseID
        {
            get { return _PurchaseID; }
            set { _PurchaseID = value; }
        }
        public string PayTypeId
        {
            get { return _PayTypeId; }
            set { _PayTypeId = value; }
        }
        public string PaidAmount
        {
            get { return _PaidAmount; }
            set { _PaidAmount = value; }
        }
        public string CardNo
        {
            get { return _CardNo; }
            set { _CardNo = value; }
        }
        public string ExpDate
        {
            get { return _ExpDate; }
            set { _ExpDate = value; }
        }
        public string SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        public string TerminalID
        {
            get { return _TerminalID; }
            set { _TerminalID = value; }
        }
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        #endregion
    }
}
