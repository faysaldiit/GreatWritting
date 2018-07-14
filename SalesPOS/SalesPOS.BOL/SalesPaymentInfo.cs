using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class SalesPaymentInfo
    {
        #region _attributes

        string _InvoiceNo;
        string _PayTypeId;
        string _PaidAmount;
        string _CardNo;
        string _ExpDate;
        string _CustomerID;
        string _TerminalID;
        string _CreatedBy;

        #endregion

        #region _propertise
        
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
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
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
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
