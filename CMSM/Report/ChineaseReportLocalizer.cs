using System;
using  DevExpress.XtraPrinting.Localization ; 
namespace CMSM.Report
{
	/// <summary>
	/// ChineaseReportLocalizer 的摘要说明。
	/// </summary>
	public class ChineaseReportLocalizer : DevExpress.XtraPrinting.Localization.PreviewLocalizer
	{

		//public override string Language { get { return "简体中文"; }}
		public override string GetLocalizedString(PreviewStringId id) 
		{
			string ret = "";
			switch(id) 
			{
				case PreviewStringId.Msg_WrongPageSettings:return "是否打印";
				default:
					ret = "";
					break;
			}
			  
			return ret;
		}

	}

}
