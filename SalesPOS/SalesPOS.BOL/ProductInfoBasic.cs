using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductInfoBasic
    {
        #region attributes
        long _ProductId;        
        long _ProductName;
        long _SectionId;
        long _MedicineCommissionId;
        decimal _PurchasePrice;
        decimal _SalesPrice;        
        int _UnitId;
        int _ReorderLevel;
        decimal _Vat;
        bool _Acitivity;
        DateTime _LastUpdateDate;
        long _LastUpdatedBy;  
        
        #endregion

        #region properties
        public long ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        public long ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public long SectionId
        {
            get { return _SectionId; }
            set { _SectionId = value; }
        }
        public long MedicineCommissionId
        {
            get { return _MedicineCommissionId; }
            set { _MedicineCommissionId = value; }
        }
        public decimal PurchasePrice
        {
            get { return _PurchasePrice; }
            set { _PurchasePrice = value; }
        }
        public decimal SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        public int UnitId
        {
            get { return _UnitId; }
            set { _UnitId = value; }
        }
        public int ReorderLevel
        {
            get { return _ReorderLevel; }
            set { _ReorderLevel = value; }
        }
        public decimal Vat
        {
            get { return _Vat; }
            set { _Vat = value; }
        }
        public bool Acitivity
        {
            get { return _Acitivity; }
            set { _Acitivity = value; }
        }
        public DateTime LastUpdateDate
        {
            get { return _LastUpdateDate; }
            set { _LastUpdateDate = value; }
        }
        public long LastUpdatedBy
        {
            get { return _LastUpdatedBy; }
            set { _LastUpdatedBy = value; }
        }
        #endregion

        #region costructore
        public ProductInfoBasic()
        {
            //
            
        }
        #endregion
    }
}
