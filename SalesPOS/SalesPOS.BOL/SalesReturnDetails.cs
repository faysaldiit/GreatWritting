using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS
{
    public class SalesReturnDetails
    {
        #region _attributes

        string _InvoiceNo;
        string _SalesReturnNo;
        string _ProductID;
        string _ReturnQuantity;
        string _UnitID;
        string _UnitSalesPrice;
        string _VatPerchantage;        

        #endregion


        #region _propertise

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
        public string ProductID
        {

            get { return _ProductID; }
            set { _ProductID = value; }

        }
        public string ReturnQuantity
        {

            get { return _ReturnQuantity; }
            set { _ReturnQuantity = value; }

        }
        public string UnitID
        {

            get { return _UnitID; }
            set { _UnitID = value; }

        }
        public string UnitSalesPrice
        {

            get { return _UnitSalesPrice; }
            set { _UnitSalesPrice = value; }

        }       
        
        public string VatPerchantage
        {

            get { return _VatPerchantage; }
            set { _VatPerchantage = value; }

        }              

        #endregion

    }
}
