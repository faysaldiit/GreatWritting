using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPOS.BOL
{
    public class AccountTransaction
    {
        #region _attributes

        string _ATID;
        string _RefNo;
        string _TransactionDate;
        string _TerminalID;
        string _AccountHolderID;
        string _ATTID;
        string _Description;
        string _Debit;
        string _Credit;
        string _CreatedBy;
        string _CreatedDate;

        string _SearchDateFrom;
        string _SearchDateTo;
        string _SearchAccountNo;
        string _SearchATTID;
        string _SearchIsEditable;
        string _SearchRef;
        string _SearchAmount;
        #endregion


        #region _propertise

        public string ATID
        {
            get { return _ATID; }
            set { _ATID = value; }
        }
        public string RefNo
        {
            get { return _RefNo; }
            set { _RefNo = value; }
        }
        public string TransactionDate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
        }
        public string TerminalID
        {
            get { return _TerminalID; }
            set { _TerminalID = value; }
        }
        public string AccountHolderID
        {
            get { return _AccountHolderID; }
            set { _AccountHolderID = value; }
        }
        public string ATTID
        {
            get { return _ATTID; }
            set { _ATTID = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Debit
        {
            get { return _Debit; }
            set { _Debit = value; }
        }
        public string Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public string CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }


        public string SearchAccountNo
        {
            get { return _SearchAccountNo; }
            set { _SearchAccountNo = value; }
        }
        public string SearchATTID
        {
            get { return _SearchATTID; }
            set { _SearchATTID = value; }
        }
        public string SearchDateFrom
        {
            get { return _SearchDateFrom; }
            set { _SearchDateFrom = value; }
        }
        public string SearchDateTo
        {
            get { return _SearchDateTo; }
            set { _SearchDateTo = value; }
        }
        public string SearchIsEditable
        {
            get { return _SearchIsEditable; }
            set { _SearchIsEditable = value; }
        }
        public string SearchRef
        {
            get { return _SearchRef; }
            set { _SearchRef = value; }
        }
        public string SearchAmount
        {
            get { return _SearchAmount; }
            set { _SearchAmount = value; }
        }
        #endregion
    }
   
}
