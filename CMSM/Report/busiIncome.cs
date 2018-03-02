using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using CMSMData.CMSMDataAccess;

namespace CMSM.Report
{
	/// <summary>
	/// Summary description for busiIncome.
	/// </summary>
	public class busiIncome : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private CMSM.Report.dsincome dsincome1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel11;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.XRLabel xrLabel12;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		private DevExpress.XtraReports.UI.XRLabel xrLabel16;
		private DevExpress.XtraReports.UI.XRLabel xrLabel17;
		private DevExpress.XtraReports.UI.XRLabel xrLabel18;
		private DevExpress.XtraReports.UI.XRLabel xrLabel19;
		private DevExpress.XtraReports.UI.XRLabel xrLabel20;
		private DevExpress.XtraReports.UI.XRLabel xrLabel21;
		private DevExpress.XtraReports.UI.XRLabel xrLabel22;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
		private DevExpress.XtraReports.UI.XRLabel xrLabel24;
		private DevExpress.XtraReports.UI.XRLabel xrLabel25;
		private DevExpress.XtraReports.UI.XRLabel xrLabel26;
		private DevExpress.XtraReports.UI.XRLabel xrLabel27;
		private DevExpress.XtraReports.UI.XRLabel xrLabel28;
		private DevExpress.XtraReports.UI.XRLabel xrLabel29;
		private DevExpress.XtraReports.UI.XRLine xrLine2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel30;
		private DevExpress.XtraReports.UI.XRLabel xrLabel32;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel33;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public busiIncome(string strCon,string strDateZoom,string strDeptName,string strBegin,string strEnd)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			this.xrLabel3.Text=strDeptName;
			this.sqlConnection1.ConnectionString = strCon;
			this.sqlSelectCommand2.CommandText= @"SELECT (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'NewAss') AS 新增会员数, (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'LostAss') AS 挂失会员数, (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'FillFee') AS 充值次数, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'FillFee') AS 充值金额, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'BankFillFee') AS 银联卡充值,(SELECT SUM(REP6) FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费次数, (SELECT SUM(REP4) FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费金额, (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'Retail') AS 零售次数, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'Retail') AS 零售金额, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '" + strDateZoom + "' AND Type = 'Total') AS 现金总额";
			
			this.xrLabel4.Text=strBegin;
			this.xrLabel7.Text=strEnd;
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
			this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
			this.dsincome1 = new CMSM.Report.dsincome();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsincome1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel32,
																						this.xrLabel30,
																						this.xrLine2,
																						this.xrLabel29,
																						this.xrLabel28,
																						this.xrLabel27,
																						this.xrLabel26,
																						this.xrLabel25,
																						this.xrLabel24,
																						this.xrLabel23,
																						this.xrLabel22,
																						this.xrLabel21,
																						this.xrLabel20,
																						this.xrLabel19,
																						this.xrLabel18,
																						this.xrLabel17,
																						this.xrLabel16,
																						this.xrLabel15,
																						this.xrLabel14,
																						this.xrLabel13,
																						this.xrLabel12,
																						this.xrLabel10,
																						this.xrLabel11,
																						this.xrLabel9,
																						this.xrLabel8,
																						this.xrLabel33});
			this.Detail.Height = 190;
			this.Detail.Name = "Detail";
			// 
			// xrLabel32
			// 
			this.xrLabel32.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel32.Location = new System.Drawing.Point(0, 67);
			this.xrLabel32.Name = "xrLabel32";
			this.xrLabel32.ParentStyleUsing.UseFont = false;
			this.xrLabel32.Size = new System.Drawing.Size(90, 16);
			this.xrLabel32.Text = "银联卡充值：";
			this.xrLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel30
			// 
			this.xrLabel30.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel30.Location = new System.Drawing.Point(159, 67);
			this.xrLabel30.Name = "xrLabel30";
			this.xrLabel30.ParentStyleUsing.UseFont = false;
			this.xrLabel30.Size = new System.Drawing.Size(20, 16);
			this.xrLabel30.Text = "元";
			this.xrLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLine2
			// 
			this.xrLine2.Location = new System.Drawing.Point(0, 152);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.Size = new System.Drawing.Size(180, 8);
			// 
			// xrLabel29
			// 
			this.xrLabel29.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel29.Location = new System.Drawing.Point(159, 162);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.ParentStyleUsing.UseFont = false;
			this.xrLabel29.Size = new System.Drawing.Size(20, 16);
			this.xrLabel29.Text = "元";
			this.xrLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel28
			// 
			this.xrLabel28.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel28.Location = new System.Drawing.Point(159, 135);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.ParentStyleUsing.UseFont = false;
			this.xrLabel28.Size = new System.Drawing.Size(20, 16);
			this.xrLabel28.Text = "元";
			this.xrLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel27
			// 
			this.xrLabel27.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel27.Location = new System.Drawing.Point(160, 103);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.ParentStyleUsing.UseFont = false;
			this.xrLabel27.Size = new System.Drawing.Size(20, 16);
			this.xrLabel27.Text = "元";
			this.xrLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel26
			// 
			this.xrLabel26.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel26.Location = new System.Drawing.Point(160, 48);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.ParentStyleUsing.UseFont = false;
			this.xrLabel26.Size = new System.Drawing.Size(20, 16);
			this.xrLabel26.Text = "元";
			this.xrLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel25
			// 
			this.xrLabel25.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel25.Location = new System.Drawing.Point(0, 162);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.ParentStyleUsing.UseFont = false;
			this.xrLabel25.Size = new System.Drawing.Size(90, 16);
			this.xrLabel25.Text = "现金总额：";
			this.xrLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel24
			// 
			this.xrLabel24.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.现金总额", ""));
			this.xrLabel24.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel24.Location = new System.Drawing.Point(90, 162);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.ParentStyleUsing.UseFont = false;
			this.xrLabel24.Size = new System.Drawing.Size(70, 16);
			this.xrLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dsincome1
			// 
			this.dsincome1.DataSetName = "dsincome";
			this.dsincome1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// xrLabel23
			// 
			this.xrLabel23.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel23.Location = new System.Drawing.Point(0, 135);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.ParentStyleUsing.UseFont = false;
			this.xrLabel23.Size = new System.Drawing.Size(90, 16);
			this.xrLabel23.Text = "零售金额：";
			this.xrLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel22
			// 
			this.xrLabel22.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.零售金额", ""));
			this.xrLabel22.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel22.Location = new System.Drawing.Point(90, 135);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.ParentStyleUsing.UseFont = false;
			this.xrLabel22.Size = new System.Drawing.Size(70, 16);
			this.xrLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel21
			// 
			this.xrLabel21.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel21.Location = new System.Drawing.Point(0, 119);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.ParentStyleUsing.UseFont = false;
			this.xrLabel21.Size = new System.Drawing.Size(90, 16);
			this.xrLabel21.Text = "零售次数：";
			this.xrLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel20
			// 
			this.xrLabel20.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.零售次数", ""));
			this.xrLabel20.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel20.Location = new System.Drawing.Point(90, 119);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.ParentStyleUsing.UseFont = false;
			this.xrLabel20.Size = new System.Drawing.Size(70, 16);
			this.xrLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel19
			// 
			this.xrLabel19.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel19.Location = new System.Drawing.Point(0, 103);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.ParentStyleUsing.UseFont = false;
			this.xrLabel19.Size = new System.Drawing.Size(90, 16);
			this.xrLabel19.Text = "会员消费金额：";
			this.xrLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel18
			// 
			this.xrLabel18.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.会员消费金额", ""));
			this.xrLabel18.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel18.Location = new System.Drawing.Point(90, 103);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.ParentStyleUsing.UseFont = false;
			this.xrLabel18.Size = new System.Drawing.Size(70, 16);
			this.xrLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel17
			// 
			this.xrLabel17.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel17.Location = new System.Drawing.Point(0, 86);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.ParentStyleUsing.UseFont = false;
			this.xrLabel17.Size = new System.Drawing.Size(90, 16);
			this.xrLabel17.Text = "会员消费次数：";
			this.xrLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel16
			// 
			this.xrLabel16.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.会员消费次数", ""));
			this.xrLabel16.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel16.Location = new System.Drawing.Point(90, 86);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.ParentStyleUsing.UseFont = false;
			this.xrLabel16.Size = new System.Drawing.Size(70, 16);
			this.xrLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel15
			// 
			this.xrLabel15.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel15.Location = new System.Drawing.Point(0, 48);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.ParentStyleUsing.UseFont = false;
			this.xrLabel15.Size = new System.Drawing.Size(90, 16);
			this.xrLabel15.Text = "充值金额：";
			this.xrLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel14
			// 
			this.xrLabel14.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.充值金额", ""));
			this.xrLabel14.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel14.Location = new System.Drawing.Point(90, 48);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.ParentStyleUsing.UseFont = false;
			this.xrLabel14.Size = new System.Drawing.Size(70, 16);
			this.xrLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel13
			// 
			this.xrLabel13.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel13.Location = new System.Drawing.Point(0, 32);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.ParentStyleUsing.UseFont = false;
			this.xrLabel13.Size = new System.Drawing.Size(90, 16);
			this.xrLabel13.Text = "充值次数：";
			this.xrLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel12
			// 
			this.xrLabel12.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.充值次数", ""));
			this.xrLabel12.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel12.Location = new System.Drawing.Point(90, 32);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.ParentStyleUsing.UseFont = false;
			this.xrLabel12.Size = new System.Drawing.Size(70, 16);
			this.xrLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel10
			// 
			this.xrLabel10.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.挂失会员数", ""));
			this.xrLabel10.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel10.Location = new System.Drawing.Point(90, 16);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(70, 16);
			this.xrLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel11
			// 
			this.xrLabel11.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel11.Location = new System.Drawing.Point(0, 16);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.ParentStyleUsing.UseFont = false;
			this.xrLabel11.Size = new System.Drawing.Size(90, 16);
			this.xrLabel11.Text = "挂失会员数：";
			this.xrLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel9
			// 
			this.xrLabel9.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.新增会员数", ""));
			this.xrLabel9.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel9.Location = new System.Drawing.Point(90, 0);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(70, 16);
			this.xrLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel8.Location = new System.Drawing.Point(0, 0);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(90, 16);
			this.xrLabel8.Text = "新增会员数：";
			this.xrLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel33
			// 
			this.xrLabel33.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.dsincome1, "Table.银联卡充值", ""));
			this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel33.Location = new System.Drawing.Point(90, 66);
			this.xrLabel33.Name = "xrLabel33";
			this.xrLabel33.ParentStyleUsing.UseFont = false;
			this.xrLabel33.Size = new System.Drawing.Size(70, 16);
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLine1,
																							this.xrLabel7,
																							this.xrLabel6,
																							this.xrLabel5,
																							this.xrLabel4,
																							this.xrLabel3,
																							this.xrLabel2,
																							this.xrLabel1});
			this.PageHeader.Height = 88;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(0, 79);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(180, 9);
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel7.Location = new System.Drawing.Point(64, 64);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(116, 16);
			this.xrLabel7.Text = "2008年4月1日";
			this.xrLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel6.Location = new System.Drawing.Point(0, 64);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(64, 16);
			this.xrLabel6.Text = "结束时间：";
			this.xrLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel5.Location = new System.Drawing.Point(0, 46);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(64, 16);
			this.xrLabel5.Text = "起始时间：";
			this.xrLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel4.Location = new System.Drawing.Point(64, 46);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(116, 16);
			this.xrLabel4.Text = "2008年4月1日";
			this.xrLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel3.Location = new System.Drawing.Point(48, 29);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(133, 16);
			this.xrLabel3.Text = "湖畔";
			this.xrLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel2.Location = new System.Drawing.Point(0, 29);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(52, 16);
			this.xrLabel2.Text = "门店：";
			this.xrLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel1.Location = new System.Drawing.Point(32, 3);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(110, 19);
			this.xrLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("新增会员数", "新增会员数"),
																																																			   new System.Data.Common.DataColumnMapping("挂失会员数", "挂失会员数"),
																																																			   new System.Data.Common.DataColumnMapping("充值次数", "充值次数"),
																																																			   new System.Data.Common.DataColumnMapping("充值金额", "充值金额"),
																																																			   new System.Data.Common.DataColumnMapping("银联卡充值", "银联卡充值"),
																																																			   new System.Data.Common.DataColumnMapping("会员消费次数", "会员消费次数"),
																																																			   new System.Data.Common.DataColumnMapping("会员消费金额", "会员消费金额"),
																																																			   new System.Data.Common.DataColumnMapping("零售次数", "零售次数"),
																																																			   new System.Data.Common.DataColumnMapping("零售金额", "零售金额"),
																																																			   new System.Data.Common.DataColumnMapping("现金总额", "现金总额")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'NewAss') AS 新增会员数, (SELECT REP1 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'LostAss') AS 挂失会员数, (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'FillFee') AS 充值次数, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'FillFee') AS 充值金额, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'BankFillFee') AS 银联卡充值, (SELECT SUM(REP6) FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费次数, (SELECT SUM(REP4) FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type IN ('AssCons' , 'PromCons')) AS 会员消费金额, (SELECT REP6 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'Retail') AS 零售次数, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'Retail') AS 零售金额, (SELECT REP4 FROM tbBusiIncomeReport WHERE vcDateZoom = '2008040120080503' AND Type = 'Total') AS 现金总额";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"KMDX-Z9E5N5MK76\";packet size=4096;user id=sa;data source=\"192.168" +
				".1.5\";persist security info=False;initial catalog=AMSCM_XG_MD_Test";
			// 
			// busiIncome
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader});
			this.DataAdapter = this.sqlDataAdapter1;
			this.DataSource = this.dsincome1;
			this.Margins = new System.Drawing.Printing.Margins(100, 556, 100, 100);
			((System.ComponentModel.ISupportInitialize)(this.dsincome1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion



	}
}
