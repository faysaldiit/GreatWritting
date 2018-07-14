using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class SalesReturnParent
    {
        #region _attributes
        string _TerminalID;
        string _InvoiceNo;
        string _SalesReturnNo;
        string _TotalAmount;
        string _CreatedBy;
        string _CustomerID;

        #endregion


        #region _propertise
        public string TerminalID
        {
            get { return _TerminalID; }
            set { _TerminalID = value; }
        }
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        public string SalesReturnNo
        {
            get { return _SalesReturnNo; }
            set { _SalesReturnNo = value; }
        }
        
        public string TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
 
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        #endregion
    }
}
