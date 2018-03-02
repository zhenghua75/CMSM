using System;
using System.Data;

namespace CMSMData
{
	/// <summary>
	/// Summary description for CMSMStruct.
	/// </summary>
	public class CMSMStruct
	{
		public CMSMStruct()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public class AssociatorStruct
		{
            public string striSerial;
			public string strAssID;
			public string strCardID;
			public string strAssName;
			public string strSpell;
			public string strAssNbr;
			public string strLinkPhone;
			public string strLinkAddress;
			public string strEmail;
			public string strAssType;
			public string strAssState;
			public double dCharge;
			public int    iIgValue;
			public string strCardFlag;
			public string strComments;
			public string strCreateDate;
			public DateTime dtCreateDate;
			public string strOperDate;
			public string strDeptID;
			public string strCardSerial;
			public bool   setZeroFlag;
			public bool   needZeroFlag;
			public double dRate;
		}

        public class MergeOut
		{
            public string strSerial;
			public string strCardID;
            public string strFillFee;
            public string strIgGet;
			public string strOperName;
			public string strDeptID;
            public string strOperDate;
		}
        public class OperStruct
        {
            public string strOperID;
            public string strOperName;
            public string strLimit;
            public string strPwd;
            public string strDeptID;
            public bool IsDiscount;
        }

		public class  BusiStruct
		{
            public string strNewAssCount;
            public string strLostAssCount;
			public string strFillFeeCount;
            public string strFIllFee;
            public string strBankFillFee;
            public string strAssConsCount;
			public string strAssCons;
            public string strRetailCount;
            public string strRetail;
            public string strSum;
            public string strDateZoom;
            public string strDeptname;
            public string strOperName;
            public string strOperDate;
		}

        public class GoodsStruct
        {
            public string strGoodsID;
            public string strGoodsName;
            public string strSpell;
            public double dPrice;
            public double dRate;
            public int iIgValue;
            public string strNewFlag;
            public string strGoodsType;
            public string strComments;
        }

		public class ConsItemStruct
		{
            public Int64 iSerial;
			public string strAssID;
			public string strCardID;
			public string strOperDate;
			public string strOperName;
			public DataTable dtItem;
			public double dChargeLast;
			public double dTolCharge;
			public double dFee;
			public double dTRate;
			public double dPay;
			public double dBalance;
			public int    iIgLast;
			public int    iIgValue;
			public string strConsType;
			public string strIgType;
			public string strDeptID;
			public string strTolCount;
			public string strComments;
		}

		public class ConsDownStruct
		{
			public string strSerial;
			public string strGoodsID;
			public string strAssID;
			public string strCardID;
			public double dPrice;
			public int    iCount;
			public double dTRate;
			public double dFee;
			public string strComments;
			public string strFlag;
			public string strConsDate;
			public string strOperName;
			public string strDeptID;
		}

		public class CommStruct
		{
			public string strCommName;
			public string strCommCode;
			public string strCommSign;
			public string strComments;
		}

		public class FillFeeStruct
		{
            public Int64 iSerial;
			public string strSerial;
            public string strSerialOld;
			public string strAssID;
			public string strCardID;
            public string strCardIDOld;
			public double dFillFee;
			public double dFillProm;
			public double dFeeLast;
			public double dFeeCur;
			public string strFillDate;
			public string strComments;
			public string strOperName;
			public string strDeptID;
			public double dIG;
			public double dIGLast;
			public double dIGCur;
            public string strType;
		}
        //µ±ÃÏΩ·’Àlhg-2015
        public class DailyAccountStruct
        {
            public string strOper;
            public string strFillCount;
            public string strFillFee;
            public string strFillCountBank;
            public string strFillFeeBank;
            public string strConsCount;
            public string strRetail;
            public string strRetailBank;
            public string strAssCons;
            public string strRoll;
            public string strRollSum;
            public string strLargCount;
            public string strCash;
            public string strDeptID;
            public string strOperDate;
        }

		public class CardHardStruct
		{
			public string strCardID;
			public double dCurCharge;
			public int    iCurIg;
			public bool   needZeroFlag;
			public string strInsertDate;
		}

		public class AssChangeStruct
		{
			public string strCardID;
			public string strChangeField;
			public string strChangeValue;
			public string strOperDate;
		}

		public class BillStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public double dTRate;
			public double dFee;
			public double dPay;
			public double dBalance;
			public int    iIgValue;
			public string strConsType;
			public string strOperName;
			public string strConsDate;
			public string strDeptID;
		}

		public class IntegralStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public string strIgType;
			public int    iIgLast;
			public int    iIgGet;
			public int    iIgArrival;
			public int    iLinkCons;
			public string strIgDate;
			public string strOperName;
			public string strComments;
			public string strDeptID;
		}

		public class BusiLogStruct
		{
			public string strSerial;
			public string strAssID;
			public string strCardID;
			public string strOperType;
			public string strOperName;
			public string strOperDate;
			public string strComments;
			public string strDeptID;
		}

		public class DeptToCenterLogStruct
		{
			public string strFileName;
			public int FileSize;
			public string strCreatingDate;
			public string strCreatedDate;
			public string strUpingDate;
			public string strUpedDate;
			public string strUpdatingDate;
			public string strUpdatedDate;
			public string strCreateFinish;
			public string strUpFinish;
			public string strUpdateFinish;
		}

		public class EmployeeStruct
		{
			public string strCardID;
			public string strEmpName;
			public string strSex;
			public string strEmpNbr;
			public string strInDate;
			public string strDegree;
			public string strLinkPhone;
			public string strAddress;
			public string strPwd;
			public string strOfficer;
			public string strDeptID;
			public string strFlag;
			public string strComments;
			public string strOperDate;
		}

		public class EmpSignStruct
		{
			public string strSerial;
			public string strCardID;
			public string strEmpName;
			public string strSignDate;
			public string strClass;
			public string strSignFlag;
			public string strComments;
			public string strDeptID;
		}

		public class NoticeStruct
		{
			public string strID;
			public string strComments;
			public string strCreateDate;
			public string strActiveFlag;
			public string strDeptFlag;
		}

		public class OperFuncStruct
		{
			public string strOperID;
			public string strFuncName;
			public string strFuncAddress;
		}
	}
}
