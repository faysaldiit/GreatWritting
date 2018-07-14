using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductInfo
    {
        #region attributes
        string _SerialNo;
        string _ProductID;
        string _ProductName;
        string _OtherCode;
        string _ProductDescription;
        string _ProductImage; //temporarily
        long _SectionId;
        long _TypeID;
        long _SubSectionID;
        //long _MedicineCommissionId;
        //decimal _PurchasePrice;
        //decimal _SalesPrice;
        //int _UnitId;
        int _ReorderLevel;
        decimal _VatId;
        string _ManufacturerID;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        int _IsDeleted;
        int _IsFractionAllow;

        #endregion

        #region properties
        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        public string ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string OtherCode
        {
            get { return _OtherCode; }
            set { _OtherCode = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string ProductDescription
        {
            get { return _ProductDescription; }
            set { _ProductDescription = value; }
        }
        public string ProductImage
        {
            get { return _ProductImage; }
            set { _ProductImage = value; }
        }
        public long SectionId
        {
            get { return _SectionId; }
            set { _SectionId = value; }
        }
        public long TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        public long SubSectionID
        {
            get { return _SubSectionID; }
            set { _SubSectionID = value; }
        }
        //public long MedicineCommissionId
        //{
        //    get { return _MedicineCommissionId; }
        //    set { _MedicineCommissionId = value; }
        //}
        //public decimal PurchasePrice
        //{
        //    get { return _PurchasePrice; }
        //    set { _PurchasePrice = value; }
        //}
        //public decimal SalesPrice
        //{
        //    get { return _SalesPrice; }
        //    set { _SalesPrice = value; }
        //}
        //public int UnitId
        //{
        //    get { return _UnitId; }
        //    set { _UnitId = value; }
        //}
        public int ReorderLevel
        {
            get { return _ReorderLevel; }
            set { _ReorderLevel = value; }
        }
        public decimal VatId
        {
            get { return _VatId; }
            set { _VatId = value; }
        }
        public string ManufacturerID
        {
            get { return _ManufacturerID; }
            set { _ManufacturerID = value; }
        }
        public long ActivityID
        {

            get { return _ActivityID; }
            set { _ActivityID = value; }

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
        public int IsDeleted
        {

            get { return _IsDeleted; }
            set { _IsDeleted = value; }

        }
        public int IsFractionAllow
        {

            get { return _IsFractionAllow; }
            set { _IsFractionAllow = value; }

        }
        #endregion
    }
}
