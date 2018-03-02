
/******************************************************************** FR 1.20E *******
* 项目名称：   云南人才市场会员管理系统
* 文件名:   	Bill.cs
* 作者:	     郑华
* 创建日期:    2008-01-25
* 功能描述:    小票打印

*                                                           Copyright(C) 2008 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;

#endregion

namespace CMSM.Print
{
	/// <summary>
	/// **功能名称：小票打印实体类
	/// </summary>
	[Serializable]
	public class PrintedBill: IPrintable
	{
		#region 数据表生成变量
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
		
		#region 构造函数
		public PrintedBill()
		{
		}
		
		
		#endregion
		
		#region 系统生成属性
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
		/// 会员卡号
		/// </summary>
		public string cnvcMemberCardNo
		{
			get {return _cnvcMemberCardNo;}
			set {_cnvcMemberCardNo = value;}
		}

		/// <summary>
		/// 单位名称
		/// </summary>
		public string cnvcMemberName
		{
			get {return _cnvcMemberName;}
			set {_cnvcMemberName = value;}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// 小票类型
		/// </summary>
		public string cnvcBillType
		{
			get {return _cnvcBillType;}
			set {_cnvcBillType = value;}
		}


		/// <summary>
		/// 实收
		/// </summary>
		public decimal cnnPrepay
		{
			get {return _cnnPrepay;}
			set {_cnnPrepay = value;}
		}

        /// <summary>
        /// 当前余额
        /// </summary>
        public decimal cnnBalance
        {
            get { return _cnnBalance; }
            set { _cnnBalance = value; }
        }
        /// <summary>
        /// 上次余额
        /// </summary>
        public decimal cnnLastBalance
        {
            get { return _cnnLastBalance; }
            set { _cnnLastBalance = value; }
        }
        /// <summary>
        /// 赠送
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

			element.AddData("会员卡号",cnvcMemberCardNo);
			element.AddData("会员名称",cnvcMemberName);
			element.AddHorizontalRule();
            element.AddData("上次余额", cnnLastBalance.ToString("F2"));
			element.AddData("充值金额",cnnPrepay.ToString("F2"));
            element.AddData("赠送金额", cnnDonate.ToString("F2"));
            element.AddData("当前余额", cnnBalance.ToString("F2"));
			element.AddText("谢谢惠顾!  "+cnvcDeptName);
			element.AddData("服务电话",cnvcTel);
			element.AddData("操作员",cnvcOperName);
			element.AddData("操作时间",cndOperDate.ToString("yyyy-MM-dd HH:mm"));
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddBlankLine();
			element.AddHorizontalRule();
		}
	}	

	
	/// <summary>
	/// **功能名称：消费小票打印实体类
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
			element.AddText("谢谢惠顾!  "+this.strDeptName);
            element.AddData("日期", this.strOperDate);
            element.AddData("小票号", this.strSerial );
			if(this.strCardId.Length>0)
			{
				element.AddData("卡号", this.strCardId);
				
			}
			if(this.dLastBalance>0)
			{
				element.AddData("上次余额", this.dLastBalance.ToString("F2"));
			}
			if(this.strComment.Length>0)
			{
				element.AddData(this.strComment, this.dBalance.ToString("F2"));
			}
			if(this.dIg>0)
			{
				element.AddData("当前积分",this.dIg);
			}
			if(this.strTel.Length>0)
			{
				element.AddData("服务电话",this.strTel);
			}
			element.AddHorizontalRule();
			
			if(dtConsItem.Rows.Count>0)
			{				
				element.AddFourText("商品名称","单价","数量","小计");
				foreach(DataRow dr in dtConsItem.Rows)
				{
					element.AddFourText(dr["GoodsName"].ToString(),Convert.ToDouble(dr["Price"]).ToString("F2"),dr["Count"].ToString(),Convert.ToDouble(dr["Fee"]).ToString("F2"));
				}
				
			}
			if(dtIgItem.Rows.Count>0)
			{		
				element.AddFourText("商品名称","积分","数量","小计");
				foreach(DataRow dr in dtIgItem.Rows)
				{
					element.AddFourText(dr["GoodsName"].ToString(),Convert.ToDouble(dr["IgValue"]).ToString("F2"),dr["Count"].ToString(),Convert.ToDouble(dr["IgPay"]).ToString("F2"));
				}
			}
			element.AddHorizontalRule();
			element.AddData("合计",this.dSum.ToString("F2"));
			
			if(this.dDiscount>0)
			{
				element.AddData("折扣", this.dDiscount);
			}
			element.AddData(this.strPayType, this.dPay.ToString("F2"));
			element.AddData("找零",this.dCharge);
			element.AddHorizontalRule();
			if(dtNewItem.Rows.Count>0)
			{
				element.AddText(this.strDeptName+"推荐新品：");
				element.AddTwoText("商品名称","单价");
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
