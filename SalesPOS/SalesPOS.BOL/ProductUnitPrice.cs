using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class ProductUnitPrice
    {

        #region _attributes

        long _PSPID;
        string _ProductID;
        long _UnitID;
        long _UnitQty;
        double _Price;
        long _UnitPrice;
        long _ActivityID;
        Boolean _IsMinimumUnit;
        DateTime _CreatedDate;
        long _CreatedBy;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        double _WholeSalePrice;
        long _WholeSaleUnitPrice;

        #endregion


        #region _propertise

        public long PSPID
        {

            get { return _PSPID; }
            set { _PSPID = value; }

        }
        public string ProductID
        {

            get { return _ProductID; }
            set { _ProductID = value; }

        }
        public long UnitID
        {

            get { return _UnitID; }
            set { _UnitID = value; }

        }
        public long UnitQty
        {

            get { return _UnitQty; }
            set { _UnitQty = value; }

        }
        public double Price
        {

            get { return _Price; }
            set { _Price = value; }

        }
        public long UnitPrice
        {

            get { return _UnitPrice; }
            set { _UnitPrice = value; }

        }
        public double WholeSalePrice
        {

            get { return _WholeSalePrice; }
            set { _WholeSalePrice = value; }

        }
        public long WholeSaleUnitPrice
        {

            get { return _WholeSaleUnitPrice; }
            set { _WholeSaleUnitPrice = value; }

        }
        public long ActivityID
        {

            get { return _ActivityID; }
            set { _ActivityID = value; }

        }
        public Boolean IsMinimumUnit
        {

            get { return _IsMinimumUnit; }
            set { _IsMinimumUnit = value; }

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

        #endregion

    }

}
