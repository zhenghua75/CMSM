using System;
using System.Text;
using System.Runtime.InteropServices;
namespace CardCommon.CardRef
{
	/// <summary>
	/// Helper 的摘要说明。
	/// </summary>
	class Helper
	{
		[DllImport("Card32.dll", EntryPoint = "SetDate", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short SetDate(string dataTme);
		
		[DllImport("Card32.dll", EntryPoint = "Put8CardEn", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short Put8CardEn(string strCardNo,double dCharge, int iIg);

		[DllImport("Card32.dll", EntryPoint = "Put7CardEn", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short Put7CardEn(string strCardNo,double dCharge, int iIg);

		[DllImport("Card32.dll", EntryPoint = "Put5CardEn", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short Put5CardEn(string strCardNo,double dCharge, int iIg);

		[DllImport("Card32.dll", EntryPoint = "EnCard", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short EnCard(string strCardNo,double dCharge, int iIg);

		[DllImport("Card32.dll", EntryPoint = "WriteCharge", SetLastError = true,
			 CharSet = CharSet.Auto, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short WriteCharge(double dCharge);

		[DllImport("Card32.dll", EntryPoint = "WriteIg", SetLastError = true,
			 CharSet = CharSet.Auto, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short WriteIg(int iIg);

		[DllImport("Card32.dll", EntryPoint = "WriteCard", SetLastError = true,
			 CharSet = CharSet.Auto, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short WriteCard(double dCharge, int iIg);

		[DllImport("Card32.dll", EntryPoint = "ReadCardAll", SetLastError = true,
			 CharSet = CharSet.Auto, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short ReadCardAll( [MarshalAs(UnmanagedType.LPStr)]StringBuilder strCardSnr, [MarshalAs(UnmanagedType.LPStr)]StringBuilder strCardNo, ref double dCharge, ref int iIg,ref bool bEn);

		[DllImport("Card32.dll", EntryPoint = "ReadCardSnr", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short ReadCardSnr([MarshalAs(UnmanagedType.LPStr)]StringBuilder strCardSnr);

		[DllImport("Card32.dll", EntryPoint = "EmpPutCard", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short EmpPutCard(string strCardNo);

		[DllImport("Card32.dll", EntryPoint = "EmpPutCard", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short EmpPutCardOld(string strCardNo);

		[DllImport("Card32.dll", EntryPoint = "EmpReadCard", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short EmpReadCard([MarshalAs(UnmanagedType.LPStr)]StringBuilder strCardSnr,[MarshalAs(UnmanagedType.LPStr)]StringBuilder  strCardNo,ref bool bEn);
	

		[DllImport("Card32.dll", EntryPoint = "RecycleCard", SetLastError = true,
			 CharSet = CharSet.Auto, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short RecycleCard();


		[DllImport("Card32.dll", EntryPoint = "SetFlag", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short SetFlag(string strFlag);


		[DllImport("Card32.dll", EntryPoint = "ReadFlag", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = false,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern short ReadFlag([MarshalAs(UnmanagedType.LPStr)]StringBuilder strFlag);
	}
}
