using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductSalesDetailsInfo
    {
        #region _attributes

        string _InvoiceNo;
        string _ProductID;
        string _ActualQty;
        string _ActualUnitID;
        string _ActualUnitSalesPrice;
        string _TotalPriceWithoutVat;
        string _VatID;
        string _VatPerchantage;
        string _VatAmount;
        string _TotalPriceWithVat;
        string _DiscountAmount;
        string _ConvertedUnitID;
        string _CovertedQuantity;
        string _ItemType;
        string _DiscountPercent;
        #endregion


        #region _propertise

        public string InvoiceNo
        {

            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }

        }
        public string ProductID
        {

            get { return _ProductID; }
            set { _ProductID = value; }

        }
        public string ActualQty
        {

            get { return _ActualQty; }
            set { _ActualQty = value; }

        }
        public string ActualUnitID
        {

            get { return _ActualUnitID; }
            set { _ActualUnitID = value; }

        }
        public string ActualUnitSalesPrice
        {

            get { return _ActualUnitSalesPrice; }
            set { _ActualUnitSalesPrice = value; }

        }
        public string TotalPriceWithoutVat
        {

            get { return _TotalPriceWithoutVat; }
            set { _TotalPriceWithoutVat = value; }

        }
        public string VatID
        {

            get { return _VatID; }
            set { _VatID = value; }

        }
        public string VatPerchantage
        {

            get { return _VatPerchantage; }
            set { _VatPerchantage = value; }

        }
        public string VatAmount
        {

            get { return _VatAmount; }
            set { _VatAmount = value; }

        }
        public string TotalPriceWithVat
        {

            get { return _TotalPriceWithVat; }
            set { _TotalPriceWithVat = value; }

        }
        public string DiscountAmount
        {

            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }

        }
        public string ConvertedUnitID
        {

            get { return _ConvertedUnitID; }
            set { _ConvertedUnitID = value; }

        }
        public string CovertedQuantity
        {

            get { return _CovertedQuantity; }
            set { _CovertedQuantity = value; }

        }

        public string ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                if (_ItemType == value)
                    return;
                _ItemType = value;
            }
        }
        public string DiscountPercent
        {
            get
            {
                return _DiscountPercent;
            }
            set
            {
                if (_DiscountPercent == value)
                    return;
                _DiscountPercent = value;
            }
        }
        #endregion
    }
}
