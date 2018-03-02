using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using CMSMData.CMSMDataAccess;

namespace CMSM.Report
{
	/// <summary>
	/// Summary description for ADNew.
	/// </summary>
	public class ADNew : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private CMSM.Report.GoodsNew goodsNew1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader0;
		private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ADNew(string strcon)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			this.sqlConnection1.ConnectionString=strcon;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.goodsNew1 = new CMSM.Report.GoodsNew();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.GroupHeader0 = new DevExpress.XtraReports.UI.GroupHeaderBand();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
			((System.ComponentModel.ISupportInitialize)(this.goodsNew1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel2,
																						this.xrLabel3});
			this.Detail.Height = 16;
			this.Detail.Name = "Detail";
			// 
			// xrLabel2
			// 
			this.xrLabel2.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.goodsNew1, "tbGoods.vcGoodsName", ""));
			this.xrLabel2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel2.Location = new System.Drawing.Point(0, 0);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(100, 16);
			// 
			// goodsNew1
			// 
			this.goodsNew1.DataSetName = "GoodsNew";
			this.goodsNew1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// xrLabel3
			// 
			this.xrLabel3.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.goodsNew1, "tbGoods.nPrice", ""));
			this.xrLabel3.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel3.Location = new System.Drawing.Point(125, 0);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(56, 16);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tbGoods", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("vcGoodsName", "vcGoodsName"),
																																																				 new System.Data.Common.DataColumnMapping("nPrice", "nPrice")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT vcGoodsName, nPrice FROM tbGoods WHERE (cNewFlag = \'1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=KLONG;packet size=4096;user id=sa;data source=klong;persist securi" +
				"ty info=False;initial catalog=AMSCM";
			// 
			// ReportHeader
			// 
			this.ReportHeader.Height = 0;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// GroupHeader0
			// 
			this.GroupHeader0.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrLabel7,
																							  this.xrLabel8,
																							  this.xrLabel23});
			this.GroupHeader0.Height = 29;
			this.GroupHeader0.Name = "GroupHeader0";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel7.Location = new System.Drawing.Point(0, 17);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(83, 12);
			this.xrLabel7.Text = "商品名称";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel8.Location = new System.Drawing.Point(123, 17);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(34, 12);
			this.xrLabel8.Text = "单价";
			this.xrLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel23
			// 
			this.xrLabel23.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel23.Location = new System.Drawing.Point(0, 0);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.ParentStyleUsing.UseFont = false;
			this.xrLabel23.Size = new System.Drawing.Size(117, 17);
			// 
			// GroupHeader1
			// 
			this.GroupHeader1.Height = 0;
			this.GroupHeader1.Level = 1;
			this.GroupHeader1.Name = "GroupHeader1";
			// 
			// ADNew
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.ReportHeader,
																		 this.GroupHeader0,
																		 this.GroupHeader1});
			this.DataAdapter = this.sqlDataAdapter1;
			this.DataSource = this.goodsNew1;
			this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
			((System.ComponentModel.ISupportInitialize)(this.goodsNew1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}
