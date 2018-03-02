using System;
using System.Text;
using CardCommon.CardDef;
namespace CardCommon.CardRef
{
	/// <summary>
	/// CardM1 的摘要说明。
	/// </summary>
	public class CardM1
	{
		public int icdev ; // 通讯设备标识符
		public Int16 st; //返回值
		public int sec; //扇区
		public Int16 port; //端口
		public int baud; //波特率

		public CardM1(Int16 comport)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			port=comport;
			//			port=3;
			//			port=(Int16)comboPort.SelectedIndex;
			baud=9600;
			sec=1;
			st=0;
		}

		#region 设置时间
		public void SetRFTime(string strToTime)
		{
			Helper.SetDate(strToTime);						
		}
		#endregion

		#region 发卡
		public string PutOutCard(string strCardID,double dCurCharge,int iCurIg,int CardLength)
		{
			short ret=0;
//#if DEBUG
//#else
			switch (CardLength)
			{
				case 8:
					ret = Helper.Put8CardEn(strCardID,dCurCharge,iCurIg);
					break;
				case 7:
					ret = Helper.Put7CardEn(strCardID,dCurCharge,iCurIg);
					break;
				case 5:
					ret = Helper.Put5CardEn(strCardID,dCurCharge,iCurIg);
					break;
			}
//#endif
			return GetRet(ret,0);
		}
		#endregion

		#region 员工发卡
		public string EmpPutOutCard(string strCardID,double dCurCharge,int iCurIg)
		{
			short ret = Helper.EmpPutCard(strCardID);
			return GetRet(ret,0);
		}
		#endregion

		#region 加密卡
		public string EnCard(string strCardID,double dCurCharge,int iCurIg)
		{
			short ret = Helper.EnCard(strCardID,dCurCharge,iCurIg);
			return GetRet(ret,0);
		}
		#endregion

		#region 刷卡
		public string ReadCard(ref string strCardSnr,ref string strCardID,ref double dCurCharge,ref int iCurIg,ref bool IsEn)
		{
			StringBuilder sbCardSnr = new StringBuilder(32);
			StringBuilder sbCardID = new StringBuilder(8);
			IsEn = false;
			dCurCharge=0;
			iCurIg=0;
//#if DEBUG
//			short ret=0;
//			//sbCardSnr="";
//			sbCardID.Append("02999");
//			dCurCharge=1000000;
//			iCurIg=1000000;
//#else
			short ret = Helper.ReadCardAll(sbCardSnr,sbCardID,ref dCurCharge,ref iCurIg,ref IsEn);
//#endif
			dCurCharge = Math.Round(dCurCharge,2);	
			strCardID = sbCardID.ToString();
			strCardSnr = sbCardSnr.ToString();					
			return GetRet(ret,0);
		}
		#endregion

		#region 卡余额合并写卡
		public string UnionChargeWriteCard(double dCurFee,double dCurChargeBak1)
		{
			short ret = Helper.WriteCharge(dCurFee);
			return GetRet(ret,dCurFee);
		}
		#endregion

		public string ReadCardSnr(ref string strCardSnr)
		{
			StringBuilder sbCardSnr = new StringBuilder(32);
//#if DEBUG
//			short ret=0;
//			strCardSnr="E48BB45E850804006263646566676869";
//#else
			short ret = Helper.ReadCardSnr(sbCardSnr);
			strCardSnr = sbCardSnr.ToString();
//#endif
			return GetRet(ret,0);
		}
		#region 员工刷卡
		public string EmpReadCard(out string strCardSnr,out string strCardID,out bool bEn)
		{
			StringBuilder sbCardSnr = new StringBuilder(32);
			StringBuilder sbCardNo = new StringBuilder(5);
			bEn = false;	
			short ret = Helper.EmpReadCard(sbCardSnr,sbCardNo,ref bEn);
			strCardSnr = sbCardSnr.ToString();
			strCardID = sbCardNo.ToString();

			return GetRet(ret,0);
		}
		#endregion

		#region 卡回收
		public string RecycleCard()
		{
			return GetRet(Helper.RecycleCard(),0);
		}
		#endregion

		#region 关闭读卡器
		public void quit()
		{
			st=0;
			RFDef.rf_reset(icdev,80);
			st=RFDef.rf_exit(icdev);
			icdev=-1;
		}
		#endregion

		#region 充值写卡
		public string FillWriteCard(double dFillFee,double dCurChargeBak1,int iCurIg)
		{
//#if DEBUG
//			short ret=0;
//#else
			short ret = Helper.WriteCard(dFillFee,iCurIg);
//#endif
			return GetRet(ret,dFillFee);
		}
		#endregion

		#region 会员消费写卡
		public string ConsWriteCard(double dCurCharge,double dCurChargeBak,int iCurIg)
		{
//#if DEBUG
//		  short ret=0;
//#else
			short ret = Helper.WriteCard(dCurCharge,iCurIg);
//#endif
			return GetRet(ret,dCurCharge);
		}
		#endregion

		#region 会员积分兑换写卡
		public string IgChangeWriteCard(int iCurIg)
		{
			short ret = Helper.WriteIg(iCurIg);
			return GetRet(ret,0);
		}
		#endregion

		
		#region 测试通信串口连接情况
		public bool TestCommPort()
		{
			//初始化
			icdev = RFDef.rf_init(port,baud);
			if(icdev<0)
			{
				quit();
				return false;
			}
			else
			{
				quit();
				return true;
			}
		}
		#endregion

		#region 返回值
		private string GetRet(short iRet,double dCharge)
		{
			string strRet = "";
			if(iRet == 0)
			{
				strRet = "OPSUCCESS";
			}
			else if(iRet<10)
			{
				strRet = "RF00"+iRet.ToString();
			}
			else if(iRet<100)
			{
				strRet = "RF0"+iRet.ToString();
			}
			else
			{
				strRet = iRet.ToString();
			}			
			return strRet;
		}
		#endregion


		public string SetFlag(string strFlag)
		{
			if(strFlag.Length<33)
			{
				strFlag = strFlag.PadLeft(32,'0');
			}
			short ret = Helper.SetFlag(strFlag);
			return GetRet(ret,0);
		}
		public string ReadFlag(ref string strFlag)
		{
			StringBuilder sbFlag = new StringBuilder(32);
			short ret = Helper.ReadFlag(sbFlag);
			strFlag = sbFlag.ToString();
			strFlag = strFlag.TrimStart('0');
			return GetRet(ret,0);
		}
	}
}
