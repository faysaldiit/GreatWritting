using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductSalesInfo
    {
        #region _attributes
        string _TerminalID;
        string _InvoiceNo;
        string _MemoNoteNo;
        string _TotalAmount;
        string _DiscountAmount;
        string _TotalGrossAmount;
        string _ReceivedAmount;
        string _SalesType;
        string _ChangeAmount;
        string _CreatedBy;
        string _CustomerID;
        string _SalesReturn;
        string _RtlManager;
        string _ZoneID;
        string _CommissionAdjustAmount;
        string _AreaID;

        
        #endregion


        #region _propertise
        public string AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }

        public string CommissionAdjustAmount
        {
            get { return _CommissionAdjustAmount; }
            set { _CommissionAdjustAmount = value; }
        }
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
        public string MemoNoteNo
        {
            get { return _MemoNoteNo; }
            set { _MemoNoteNo = value; }
        }
        public string TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        public string DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }
        public string TotalGrossAmount
        {

            get { return _TotalGrossAmount; }
            set { _TotalGrossAmount = value; }

        }
        public string ReceivedAmount
        {
            get { return _ReceivedAmount; }
            set { _ReceivedAmount = value; }
        }
        public string SalesType
        {
            get { return _SalesType; }
            set { _SalesType = value; }
        }
        public string ChangeAmount
        {
            get { return _ChangeAmount; }
            set { _ChangeAmount = value; }
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
        public string SalesReturn
        {
            get { return _SalesReturn; }
            set { _SalesReturn = value; }
        }        
        public string RtlManager
        {
            get { return _RtlManager; }
            set { _RtlManager = value; }
        }
        public string ZoneID
        {
            get { return _ZoneID; }
            set { _ZoneID = value; }
        }
        #endregion
    }
}
