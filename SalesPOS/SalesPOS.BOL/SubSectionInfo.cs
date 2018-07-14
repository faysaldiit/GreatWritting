using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class SubSectionInfo
    {

        #region _attributes

        long _SubSectionID;
        string _SubSectionName;
        long _SectionID;
        long _ActivityID;
        DateTime _UpdatedDate;
        long _UpdatedBy;
        DateTime _CreatedDate;
        long _CreatedBy;
        int _IsDeleted;

        #endregion


        #region _propertise

        public long SubSectionID
        {

            get { return _SubSectionID; }
            set { _SubSectionID = value; }

        }
        public string SubSectionName
        {

            get { return _SubSectionName; }
            set { _SubSectionName = value; }

        }
        public long SectionID
        {

            get { return _SectionID; }
            set { _SectionID = value; }

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

        #endregion

    }
}
