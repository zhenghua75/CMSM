using System;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
namespace CMSM.CMSMApp
{
	/// <summary>
	/// CashDrawer 的摘要说明。
	/// </summary>
	public class CashDrawer
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
			public class DOCINFOA
		{
			[MarshalAs(UnmanagedType.LPStr)]
			public string pDocName;

			[MarshalAs(UnmanagedType.LPStr)]
			public string pOutputFile;

			[MarshalAs(UnmanagedType.LPStr)]
			public string pDataType;
		}

		[DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = true,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] 
			string szPrinter, out IntPtr hPrinter, Int32 pd);

		[DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
			 ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool ClosePrinter(IntPtr hPrinter);
        
		[DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true,
			 CharSet = CharSet.Ansi, ExactSpelling = true,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level,
			[In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

		[DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true,
			 ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool EndDocPrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true,
			 ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool StartPagePrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true,
			 ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool EndPagePrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true,
			 ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32
			dwCount, out Int32 dwWritten);

		/*ESC p M n1 n2
		M =0 代表一个钱箱 n代表脉冲宽度 n1 =40--50 之间
		M =1 代表两个钱箱               n2 =120--150之间
		ESC p 0 50 120
		*/
		static byte[] commandOpenDrawer = new byte[] { 0x1B, 0x70, 0x1, 0x32, 0xC8};//映象店
		private static Thread thread;
		public static void Open()
		{
			thread = new Thread(new ThreadStart(OpenDrawer));
			thread.ApartmentState = ApartmentState.STA;
			//thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		private static void OpenDrawer()
		{
			PrintDocument pdc = new PrintDocument();
			string printerName = pdc.PrinterSettings.PrinterName; 

			IntPtr hPrinter = new IntPtr(0);
			if (OpenPrinter(printerName, out hPrinter, 0))
			{
				Int32 dwWritten = 0;

				DOCINFOA docinfo = new DOCINFOA();
				docinfo.pDocName = "CashPop";

				if (StartDocPrinter(hPrinter, 1, docinfo))
				{
					if (StartPagePrinter(hPrinter))
					{
						IntPtr pBytesCommandOpenDrawer = Marshal.UnsafeAddrOfPinnedArrayElement(commandOpenDrawer, 0);
						WritePrinter(hPrinter, pBytesCommandOpenDrawer, commandOpenDrawer.Length, out dwWritten);
						Marshal.FreeCoTaskMem(pBytesCommandOpenDrawer);

						EndPagePrinter(hPrinter);
					}
					EndDocPrinter(hPrinter);
				}
				ClosePrinter(hPrinter);
				thread.Abort();
			}
		}
	}
}
