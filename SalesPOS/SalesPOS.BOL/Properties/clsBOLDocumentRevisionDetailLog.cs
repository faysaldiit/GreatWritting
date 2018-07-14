using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOL
{
    public class clsBOLDocumentRevisionDetailLog
    {
        public enum IsApproved { none = '0', approved = '1', disapproved = '2', aborted = '3', obsoleted = '4' };
        
        #region attributes
        private string _DRDLId;       
        private string _DRDId;
        private string _DRDTitle;
        private string _DRDDDId;
        private int _DRDRevisionNo;
        private string _DRDManualRevisionNo;
        private string _DRDSecChange;
        private string _DRDChangeMade;
        private string _DRDFinallyAprvFileName;
        private IsApproved _DRDIsApproved;
        private string _DRDCreationDate;
        private string _DRDApprovalDate;
        private string _DRDChangedBy;
        private string _DRDDisApproveReason;
        private string _DRDDueDate;

        #endregion

        #region properties
        public string DRDLId
        {
            get { return _DRDLId; }
            set { _DRDLId = value; }
        }
        public string DRDId
        {
            get { return _DRDId; }
            set { _DRDId = value; }
        }
        public string DRDTitle
        {
            get { return _DRDTitle; }
            set { _DRDTitle = value; }
        }
        public string DRDDDId
        {
            get { return _DRDDDId; }
            set { _DRDDDId = value; }
        }
        public int DRDRevisionNo
        {
            get { return _DRDRevisionNo; }
            set { _DRDRevisionNo = value; }
        }
        public string DRDManualRevisionNo
        {
            get { return _DRDManualRevisionNo; }
            set { _DRDManualRevisionNo = value; }
        }
        public string DRDSecChange
        {
            get { return _DRDSecChange; }
            set { _DRDSecChange = value; }
        }
        public string DRDChangeMade
        {
            get { return _DRDChangeMade; }
            set { _DRDChangeMade = value; }
        }
        public string DRDFinallyAprvFileName
        {
            get { return _DRDFinallyAprvFileName; }
            set { _DRDFinallyAprvFileName = value; }
        }
        public IsApproved DRDIsApproved
        {
            get { return _DRDIsApproved; }
            set { _DRDIsApproved = value; }
        }
        public string DRDCreationDate
        {
            get { return _DRDCreationDate; }
            set { _DRDCreationDate = value; }
        }
        public string DRDApprovalDate
        {
            get { return _DRDApprovalDate; }
            set { _DRDApprovalDate = value; }
        }
        public string DRDChangedBy
        {
            get { return _DRDChangedBy; }
            set { _DRDChangedBy = value; }
        }
        public string DRDDisApproveResion
        {
            get { return _DRDDisApproveReason; }
            set { _DRDDisApproveReason = value; }
        }
        public string DRDDueDate
        {
            get { return _DRDDueDate; }
            set { _DRDDueDate = value; }
        }
        #endregion

    }
}
