using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOL
{
    public class clsBOLCPARAction
    {
        #region attributes

        private string _CAId;
        private string _CACIId;                   
        private int _CAActionNo;        
        private int _CAJobOrder;        
        private int _CAStage;        
        private int _CANoOfSteps;       
        private string _CAAssignedTo;       
        private string _CADueDate;        
        private char _CAActionType;        
        private string _CAFirstComment;       
        private string _CASecondComment;       
        private string _CAReportFile;       
        private string _CADateAction; 

        #endregion
       
        #region properties

        public string CAId
        {
            get { return _CAId; }
            set { _CAId = value; }
        }
        public string CACIId
        {
            get { return _CACIId; }
            set { _CACIId = value; }
        }  
        public int CAActionNo
        {
            get { return _CAActionNo; }
            set { _CAActionNo = value; }
        }
        public int CAJobOrder
        {
            get { return _CAJobOrder; }
            set { _CAJobOrder = value; }
        }
        public int CAStage
        {
            get { return _CAStage; }
            set { _CAStage = value; }
        }
        public int CANoOfSteps
        {
            get { return _CANoOfSteps; }
            set { _CANoOfSteps = value; }
        }
        public string CAAssignedTo
        {
            get { return _CAAssignedTo; }
            set { _CAAssignedTo = value; }
        }
        public string CADueDate
        {
            get { return _CADueDate; }
            set { _CADueDate = value; }
        }
        public char CAActionType
        {
            get { return _CAActionType; }
            set { _CAActionType = value; }
        }
        public string CAFirstComment
        {
            get { return _CAFirstComment; }
            set { _CAFirstComment = value; }
        }
        public string CASecondComment
        {
            get { return _CASecondComment; }
            set { _CASecondComment = value; }
        }
        public string CAReportFile
        {
            get { return _CAReportFile; }
            set { _CAReportFile = value; }
        }
        public string CADateAction
        {
            get { return _CADateAction; }
            set { _CADateAction = value; }
        }

        #endregion
    }
}
