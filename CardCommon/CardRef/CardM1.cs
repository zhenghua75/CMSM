using System;
using System.Text;
using CardCommon.CardDef;
namespace CardCommon.CardRef
{
	/// <summary>
	/// CardM1 ��ժҪ˵����
	/// </summary>
	public class CardM1
	{
		public int icdev ; // ͨѶ�豸��ʶ��
		public Int16 st; //����ֵ
		public int sec; //����
		public Int16 port; //�˿�
		public int baud; //������

		public CardM1(Int16 comport)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			port=comport;
			//			port=3;
			//			port=(Int16)comboPort.SelectedIndex;
			baud=9600;
			sec=1;
			st=0;
		}

		#region ����ʱ��
		public void SetRFTime(string strToTime)
		{
			Helper.SetDate(strToTime);						
		}
		#endregion

		#region ����
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

		#region Ա������
		public string EmpPutOutCard(string strCardID,double dCurCharge,int iCurIg)
		{
			short ret = Helper.EmpPutCard(strCardID);
			return GetRet(ret,0);
		}
		#endregion

		#region ���ܿ�
		public string EnCard(string strCardID,double dCurCharge,int iCurIg)
		{
			short ret = Helper.EnCard(strCardID,dCurCharge,iCurIg);
			return GetRet(ret,0);
		}
		#endregion

		#region ˢ��
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

		#region �����ϲ�д��
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
		#region Ա��ˢ��
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

		#region ������
		public string RecycleCard()
		{
			return GetRet(Helper.RecycleCard(),0);
		}
		#endregion

		#region �رն�����
		public void quit()
		{
			st=0;
			RFDef.rf_reset(icdev,80);
			st=RFDef.rf_exit(icdev);
			icdev=-1;
		}
		#endregion

		#region ��ֵд��
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

		#region ��Ա����д��
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

		#region ��Ա���ֶһ�д��
		public string IgChangeWriteCard(int iCurIg)
		{
			short ret = Helper.WriteIg(iCurIg);
			return GetRet(ret,0);
		}
		#endregion

		
		#region ����ͨ�Ŵ����������
		public bool TestCommPort()
		{
			//��ʼ��
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

		#region ����ֵ
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
