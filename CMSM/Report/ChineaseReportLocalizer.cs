using System;
using  DevExpress.XtraPrinting.Localization ; 
namespace CMSM.Report
{
	/// <summary>
	/// ChineaseReportLocalizer ��ժҪ˵����
	/// </summary>
	public class ChineaseReportLocalizer : DevExpress.XtraPrinting.Localization.PreviewLocalizer
	{

		//public override string Language { get { return "��������"; }}
		public override string GetLocalizedString(PreviewStringId id) 
		{
			string ret = "";
			switch(id) 
			{
				case PreviewStringId.Msg_WrongPageSettings:return "�Ƿ��ӡ";
				default:
					ret = "";
					break;
			}
			  
			return ret;
		}

	}

}
