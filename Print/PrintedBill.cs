
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   �����˲��г���Ա����ϵͳ
* �ļ���:   	Bill.cs
* ����:	     ֣��
* ��������:    2008-01-25
* ��������:    СƱ��ӡ

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;

#endregion

namespace CMSM.Print
{
	/// <summary>
	/// **�������ƣ�СƱ��ӡʵ����
	/// </summary>
	[Serializable]
	public class PrintedBill: IPrintable
	{
		#region ���ݱ����ɱ���
		private string _cnvcMemberCardNo = String.Empty;
		private string _cnvcMemberName = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcBillType = String.Empty;
		private decimal _cnnPrepay;
        private decimal _cnnLastBalance;
        private decimal _cnnBalance;
        private decimal _cnnDonate;
		private string _cnvcDeptName;
		private string _cnvcTel;
		#endregion
		
		#region ���캯��
		public PrintedBill()
		{
		}
		
		
		#endregion
		
		#region ϵͳ��������
		public string cnvcTel
		{
			get {return _cnvcTel;}
			set {_cnvcTel = value;}
		}
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// ��λ����
		/// </summary>
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// ����Ա
		/// </summary>
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// СƱ����
		/// </summary>
		public string cnvcBillType
		{
			get {return _cnvcBillType;}
			set {_cnvcBillType = value;}
		}


		/// <summary>
		/// ʵ��
		/// </summary>
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

        /// <summary>
        /// ��ǰ���
        /// </summary>
        public decimal cnnBalance
        {
            get { return _cnnBalance; }
            set { _cnnBalance = value; }
        }
        /// <summary>
        /// �ϴ����
        /// </summary>
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public decimal cnnDonate
        {
            get { return _cnnDonate; }
            set { _cnnDonate = value; }
        }
		
		#endregion
		
		// Print...
		public void Print(PrintElement element)
		{			
			element.AddSeat(cnvcBillType);
			element.AddHorizontalRule();

			element.AddData("��Ա����",cnvcMemberCardNo);
			element.AddData("��Ա����",cnvcMemberName);
			element.AddHorizontalRule();
            element.AddData("�ϴ����", cnnLastBalance.ToString("F2"));
			element.AddData("��ֵ���",cnnPrepay.ToString("F2"));
            element.AddData("���ͽ��", cnnDonate.ToString("F2"));
            element.AddData("��ǰ���", cnnBalance.ToString("F2"));
			element.AddText("лл�ݹ�!  "+cnvcDeptName);
			element.AddData("����绰",cnvcTel);
			element.AddData("����Ա",cnvcOperName);
			element.AddData("����ʱ��",cndOperDate.ToString("yyyy-MM-dd HH:mm"));
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddHorizontalRule();
		}
	}	

	
	/// <summary>
	/// **�������ƣ�����СƱ��ӡʵ����
	/// </summary>
	[Serializable]
	public class ConsTicket: IPrintable
	{
        private string strOperDate;
		private string strSerial;
		private string strDeptName;
		private string strComment;
		private double dBalance;
		private double dPay;
		private double dDiscount;
		private string strPayType;
		private double dSum;
		private double dCharge;
		private DataTable dtConsItem;
		private DataTable dtNewItem;
		private double dLastBalance;
		private string strCardId;
		private string strTel;
		private DataTable dtIgItem;
		private int dIg;
		public ConsTicket(string strSerial,string strDeptName,string strCardId,string strComment,
			double dLastBalance,double dBalance,
			DataTable dtConsItem,double dSum,double dDiscount,string strPayType,double dPay,double dCharge,DataTable dtNewItem,string strTel,DataTable dtIgItem,int dIg,string strOperDate)
		{
            this.strOperDate = strOperDate;
			this.strSerial=strSerial;
			this.strDeptName = strDeptName;
			this.strComment=strComment;
			this.dBalance = dBalance;
			this.dPay=dPay;
			this.dDiscount = dDiscount;
			this.strPayType = strPayType;
			this.dSum = dSum;
			this.dCharge = dCharge;
			this.dtConsItem = dtConsItem;
			this.dtNewItem = dtNewItem;
			this.dLastBalance=dLastBalance;
			this.strCardId = strCardId;
			this.strTel = strTel;
			this.dtIgItem=dtIgItem;
			this.dIg = dIg;
		}
		
		
		public void Print(PrintElement element)
		{
			element.AddText("лл�ݹ�!  "+this.strDeptName);
            element.AddData("����", this.strOperDate);
            element.AddData("СƱ��", this.strSerial );
			if(this.strCardId.Length>0)
			{
				element.AddData("����", this.strCardId);
				
			}
			if(this.dLastBalance>0)
			{
				element.AddData("�ϴ����", this.dLastBalance.ToString("F2"));
			}
			if(this.strComment.Length>0)
			{
				element.AddData(this.strComment, this.dBalance.ToString("F2"));
			}
			if(this.dIg>0)
			{
				element.AddData("��ǰ����",this.dIg);
			}
			if(this.strTel.Length>0)
			{
				element.AddData("����绰",this.strTel);
			}
			element.AddHorizontalRule();
			
			if(dtConsItem.Rows.Count>0)
			{				
				element.AddFourText("��Ʒ����","����","����","С��");
				foreach(DataRow dr in dtConsItem.Rows)
				{
					element.AddFourText(dr["GoodsName"].ToString(),Convert.ToDouble(dr["Price"]).ToString("F2"),dr["Count"].ToString(),Convert.ToDouble(dr["Fee"]).ToString("F2"));
				}
				
			}
			if(dtIgItem.Rows.Count>0)
			{		
				element.AddFourText("��Ʒ����","����","����","С��");
				foreach(DataRow dr in dtIgItem.Rows)
				{
					element.AddFourText(dr["GoodsName"].ToString(),Convert.ToDouble(dr["IgValue"]).ToString("F2"),dr["Count"].ToString(),Convert.ToDouble(dr["IgPay"]).ToString("F2"));
				}
			}
			element.AddHorizontalRule();
			element.AddData("�ϼ�",this.dSum.ToString("F2"));
			
			if(this.dDiscount>0)
			{
				element.AddData("�ۿ�", this.dDiscount);
			}
			element.AddData(this.strPayType, this.dPay.ToString("F2"));
			element.AddData("����",this.dCharge);
			element.AddHorizontalRule();
			if(dtNewItem.Rows.Count>0)
			{
				element.AddText(this.strDeptName+"�Ƽ���Ʒ��");
				element.AddTwoText("��Ʒ����","����");
				foreach(DataRow dr in dtNewItem.Rows)
				{
					element.AddTwoText(dr["vcGoodsName"].ToString(),dr["nPrice"].ToString());
				}
			}

			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
            //element.AddHorizontalRule();
		}
	}	
}
