using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class CommissionCalc
    {
        #region _attributes

        string _CommissionCalcID;
        string _AccountNo;
        string _CommissionCalcDate;
        string _InvoiceNo;
        string _ProductCode;
        decimal _AdjustmentQty;
        decimal _AverageRate;
        decimal _CommissionPercent;
        decimal _CommissionAmount;
        decimal _ClossingQty;
        string _CalcDate;
        int _IsLastClossing;

        #endregion


        #region _propertise

        public string CommissionCalcID
        {
            get { return _CommissionCalcID; }
            set { _CommissionCalcID = value; }
        }
        public string AccountNo
        {

            get { return _AccountNo; }
            set { _AccountNo = value; }

        }
        public string CommissionCalcDate
        {

            get { return _CommissionCalcDate; }
            set { _CommissionCalcDate = value; }

        }
        public string InvoiceNo
        {

            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }

        }
        public string ProductCode
        {

            get { return _ProductCode; }
            set { _ProductCode = value; }

        }
        public decimal AdjustmentQty
        {

            get { return _AdjustmentQty; }
            set { _AdjustmentQty = value; }

        }
        public decimal AverageRate
        {

            get { return _AverageRate; }
            set { _AverageRate = value; }

        }
        public decimal CommissionPercent
        {

            get { return _CommissionPercent; }
            set { _CommissionPercent = value; }

        }
        public decimal CommissionAmount
        {

            get { return _CommissionAmount; }
            set { _CommissionAmount = value; }

        }
        public decimal ClossingQty
        {

            get { return _ClossingQty; }
            set { _ClossingQty = value; }

        }
        public string CalcDate
        {
            get { return _CalcDate; }
            set { _CalcDate = value; }
        }
        public int IsLastClossing
        {
            get { return _IsLastClossing; }
            set { _IsLastClossing = value; }
        }

        #endregion
    }
}
