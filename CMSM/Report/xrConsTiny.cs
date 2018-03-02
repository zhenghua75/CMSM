using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using CMSMData.CMSMDataAccess;

namespace CMSM.Report
{
	/// <summary>
	/// Summary description for xrConsTiny.
	/// </summary>
	public class xrConsTiny : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader0;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter0;
		private DevExpress.XtraReports.UI.XRLabel xrLabel12;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLine xrLine2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel20;
		private DevExpress.XtraReports.UI.XRLabel xrLabel17;
		private DevExpress.XtraReports.UI.XRLabel xrLabel11;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		private DevExpress.XtraReports.UI.XRLabel xrLabel16;
		private DevExpress.XtraReports.UI.XRLabel xrLabel18;
		private DevExpress.XtraReports.UI.XRLabel xrLabel19;
		private DevExpress.XtraReports.UI.XRLabel xrLabel21;
		private DevExpress.XtraReports.UI.XRLabel xrLabel22;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private CMSM.Report.ConsItem consItem1;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
		private DevExpress.XtraReports.UI.XRLabel xrlCharge;
		private DevExpress.XtraReports.UI.XRLabel xrLabel24;
		private DevExpress.XtraReports.UI.XRLabel xrLabel25;
		private DevExpress.XtraReports.UI.XRLabel xrLabel26;
		private DevExpress.XtraReports.UI.XRLabel xrlIg;
		private DevExpress.XtraReports.UI.XRLabel xrLabel27;
		private DevExpress.XtraReports.UI.XRLabel xrlCardID;
		private DevExpress.XtraReports.UI.XRLabel xrLabel28;
		private DevExpress.XtraReports.UI.XRLabel xrLabel29;
		private DevExpress.XtraReports.UI.XRLabel xrLabel30;
		private DevExpress.XtraReports.UI.XRLabel ndRate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public xrConsTiny(Hashtable hspara)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			/// 
			InitializeComponent();
			this.xrLabel6.Text=hspara["strSerial"].ToString();
			this.sqlConnection1.ConnectionString = hspara["strCon"].ToString();
			this.sqlSelectCommand1.CommandText = @"SELECT tbGoods.vcGoodsName, vwConsItem.vcCardID,vwConsItem.nPrice, vwConsItem.iCount, vwConsItem.nFee, vwBill.nTRate, vwBill.nFee AS nTFee, vwBill.nPay, vwBill.nBalance, tbCommCode.vcCommName, vwBill.vcOperName FROM vwConsItem INNER JOIN tbGoods ON vwConsItem.vcGoodsID = tbGoods.vcGoodsID INNER JOIN vwBill ON vwConsItem.iSerial = vwBill.iSerial INNER JOIN tbCommCode ON vwBill.vcConsType = tbCommCode.vcCommCode WHERE vwConsItem.iSerial=" + hspara["strSerial"].ToString() + " and vwConsItem.vcDeptID=vwBill.vcDeptID and vwBill.vcDeptID='" + hspara["strDeptID"].ToString() + "'";
			
			Subreport srep=new Subreport();
			srep.ReportSource=new ADNew(hspara["strCon"].ToString());
			((DetailBand)srep.ReportSource.Bands[0]).Height=10;
			this.PageFooter.Controls.Add(srep);
			this.xrLabel1.Text= hspara["strDeptName"].ToString();
			this.xrLabel4.Text=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
			this.xrLabel2.Text="谢谢光临!  ";
			this.xrlCharge.Text=hspara["strCharge"].ToString();
			this.xrlIg.Text=hspara["strIG"].ToString();
			this.xrLabel29.Text=hspara["strOperName"].ToString();
			this.xrlCardID.Text=hspara["strCardID"].ToString();
			this.xrLabel25.Text=SysInitial.Tel;
			if(hspara.ContainsKey("strRateNum"))
			{
				this.ndRate.Text=hspara["strRateNum"].ToString();
			}
			else
			{
				this.ndRate.Text="--";
			}

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
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			this.consItem1 = new CMSM.Report.ConsItem();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlCardID = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlIg = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlCharge = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.GroupHeader0 = new DevExpress.XtraReports.UI.GroupHeaderBand();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.GroupFooter0 = new DevExpress.XtraReports.UI.GroupFooterBand();
			this.ndRate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			((System.ComponentModel.ISupportInitialize)(this.consItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel11,
																						this.xrLabel13,
																						this.xrLabel14,
																						this.xrLabel15});
			this.Detail.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Detail.Height = 16;
			this.Detail.Name = "Detail";
			this.Detail.ParentStyleUsing.UseFont = false;
			// 
			// xrLabel11
			// 
			this.xrLabel11.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.vcGoodsName", ""));
			this.xrLabel11.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel11.Location = new System.Drawing.Point(0, 0);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.ParentStyleUsing.UseFont = false;
			this.xrLabel11.Size = new System.Drawing.Size(86, 16);
			this.xrLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// consItem1
			// 
			this.consItem1.DataSetName = "ConsItem";
			this.consItem1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// xrLabel13
			// 
			this.xrLabel13.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nPrice", ""));
			this.xrLabel13.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel13.Location = new System.Drawing.Point(86, 0);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.ParentStyleUsing.UseFont = false;
			this.xrLabel13.Size = new System.Drawing.Size(32, 16);
			this.xrLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel14
			// 
			this.xrLabel14.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.iCount", ""));
			this.xrLabel14.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel14.Location = new System.Drawing.Point(118, 0);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.ParentStyleUsing.UseFont = false;
			this.xrLabel14.Size = new System.Drawing.Size(30, 16);
			this.xrLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel15
			// 
			this.xrLabel15.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nFee", ""));
			this.xrLabel15.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel15.Location = new System.Drawing.Point(148, 0);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.ParentStyleUsing.UseFont = false;
			this.xrLabel15.Size = new System.Drawing.Size(41, 16);
			this.xrLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLabel29,
																							this.xrLabel28,
																							this.xrlCardID,
																							this.xrLabel27,
																							this.xrlIg,
																							this.xrLabel26,
																							this.xrLabel25,
																							this.xrLabel24,
																							this.xrlCharge,
																							this.xrLabel23,
																							this.xrLine1,
																							this.xrLabel6,
																							this.xrLabel5,
																							this.xrLabel4,
																							this.xrLabel3,
																							this.xrLabel2,
																							this.xrLabel1});
			this.PageHeader.Height = 201;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLabel29
			// 
			this.xrLabel29.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel29.Location = new System.Drawing.Point(58, 133);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.ParentStyleUsing.UseFont = false;
			this.xrLabel29.Size = new System.Drawing.Size(93, 17);
			// 
			// xrLabel28
			// 
			this.xrLabel28.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel28.Location = new System.Drawing.Point(2, 133);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.ParentStyleUsing.UseFont = false;
			this.xrLabel28.Size = new System.Drawing.Size(48, 17);
			this.xrLabel28.Text = "操作员:";
			this.xrLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrlCardID
			// 
			this.xrlCardID.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrlCardID.Location = new System.Drawing.Point(46, 67);
			this.xrlCardID.Name = "xrlCardID";
			this.xrlCardID.ParentStyleUsing.UseFont = false;
			this.xrlCardID.Size = new System.Drawing.Size(127, 17);
			// 
			// xrLabel27
			// 
			this.xrLabel27.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel27.Location = new System.Drawing.Point(0, 67);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.ParentStyleUsing.UseFont = false;
			this.xrLabel27.Size = new System.Drawing.Size(46, 17);
			this.xrLabel27.Text = "会员卡:";
			this.xrLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrlIg
			// 
			this.xrlIg.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrlIg.Location = new System.Drawing.Point(73, 117);
			this.xrlIg.Name = "xrlIg";
			this.xrlIg.ParentStyleUsing.UseFont = false;
			this.xrlIg.Size = new System.Drawing.Size(93, 17);
			this.xrlIg.Text = "0分";
			// 
			// xrLabel26
			// 
			this.xrLabel26.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel26.Location = new System.Drawing.Point(0, 117);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.ParentStyleUsing.UseFont = false;
			this.xrLabel26.Size = new System.Drawing.Size(73, 16);
			this.xrLabel26.Text = "会员积分:";
			this.xrLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLabel25
			// 
			this.xrLabel25.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel25.Location = new System.Drawing.Point(58, 167);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.ParentStyleUsing.UseFont = false;
			this.xrLabel25.Size = new System.Drawing.Size(126, 17);
			// 
			// xrLabel24
			// 
			this.xrLabel24.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel24.Location = new System.Drawing.Point(2, 167);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.ParentStyleUsing.UseFont = false;
			this.xrLabel24.Size = new System.Drawing.Size(67, 17);
			this.xrLabel24.Text = "服务电话：";
			this.xrLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrlCharge
			// 
			this.xrlCharge.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrlCharge.Location = new System.Drawing.Point(57, 83);
			this.xrlCharge.Name = "xrlCharge";
			this.xrlCharge.ParentStyleUsing.UseFont = false;
			this.xrlCharge.Size = new System.Drawing.Size(119, 16);
			this.xrlCharge.Text = "0元";
			// 
			// xrLabel23
			// 
			this.xrLabel23.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel23.Location = new System.Drawing.Point(0, 83);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.ParentStyleUsing.UseFont = false;
			this.xrLabel23.Size = new System.Drawing.Size(57, 16);
			this.xrLabel23.Text = "会员余额:";
			this.xrLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// xrLine1
			// 
			this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
			this.xrLine1.Location = new System.Drawing.Point(0, 175);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(186, 8);
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel6.Location = new System.Drawing.Point(50, 100);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(123, 16);
			this.xrLabel6.Text = "0";
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel5.Location = new System.Drawing.Point(3, 100);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(46, 16);
			this.xrLabel5.Text = "小票号:";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel4.Location = new System.Drawing.Point(58, 150);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(112, 20);
			this.xrLabel4.Text = "2007-04-28";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel3.Location = new System.Drawing.Point(2, 150);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(48, 19);
			this.xrLabel3.Text = "日  期:";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel2.Location = new System.Drawing.Point(0, 33);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(185, 27);
			this.xrLabel2.Text = "谢谢惠顾!";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel1.Location = new System.Drawing.Point(50, 8);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(97, 16);
			// 
			// GroupHeader0
			// 
			this.GroupHeader0.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrLabel10,
																							  this.xrLabel9,
																							  this.xrLabel8,
																							  this.xrLabel7});
			this.GroupHeader0.Height = 16;
			this.GroupHeader0.Name = "GroupHeader0";
			// 
			// xrLabel10
			// 
			this.xrLabel10.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel10.Location = new System.Drawing.Point(148, 0);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(41, 16);
			this.xrLabel10.Text = "小计";
			this.xrLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel9
			// 
			this.xrLabel9.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel9.Location = new System.Drawing.Point(118, 0);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(30, 16);
			this.xrLabel9.Text = "数量";
			this.xrLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel8.Location = new System.Drawing.Point(86, 0);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(32, 16);
			this.xrLabel8.Text = "单价";
			this.xrLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel7.Location = new System.Drawing.Point(0, 0);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(86, 16);
			this.xrLabel7.Text = "商品名称";
			// 
			// GroupFooter0
			// 
			this.GroupFooter0.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.ndRate,
																							  this.xrLabel30,
																							  this.xrLabel17,
																							  this.xrLabel20,
																							  this.xrLine2,
																							  this.xrLabel12,
																							  this.xrLabel16,
																							  this.xrLabel18,
																							  this.xrLabel19,
																							  this.xrLabel21,
																							  this.xrLabel22});
			this.GroupFooter0.Height = 88;
			this.GroupFooter0.Name = "GroupFooter0";
			// 
			// ndRate
			// 
			this.ndRate.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ndRate.Location = new System.Drawing.Point(133, 16);
			this.ndRate.Name = "ndRate";
			this.ndRate.ParentStyleUsing.UseFont = false;
			this.ndRate.Size = new System.Drawing.Size(56, 16);
			this.ndRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel30
			// 
			this.xrLabel30.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel30.Location = new System.Drawing.Point(65, 16);
			this.xrLabel30.Name = "xrLabel30";
			this.xrLabel30.ParentStyleUsing.UseFont = false;
			this.xrLabel30.Size = new System.Drawing.Size(67, 16);
			this.xrLabel30.Text = "折扣率：";
			this.xrLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel17
			// 
			this.xrLabel17.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel17.Location = new System.Drawing.Point(65, 32);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.ParentStyleUsing.UseFont = false;
			this.xrLabel17.Size = new System.Drawing.Size(67, 16);
			this.xrLabel17.Text = "折扣合计：";
			this.xrLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel20
			// 
			this.xrLabel20.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel20.Location = new System.Drawing.Point(65, 64);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.ParentStyleUsing.UseFont = false;
			this.xrLabel20.Size = new System.Drawing.Size(67, 16);
			this.xrLabel20.Text = "找零：";
			this.xrLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLine2
			// 
			this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
			this.xrLine2.Location = new System.Drawing.Point(0, 80);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.Size = new System.Drawing.Size(186, 8);
			// 
			// xrLabel12
			// 
			this.xrLabel12.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel12.Location = new System.Drawing.Point(65, 0);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.ParentStyleUsing.UseFont = false;
			this.xrLabel12.Size = new System.Drawing.Size(67, 16);
			this.xrLabel12.Text = "应收合计:";
			this.xrLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel16
			// 
			this.xrLabel16.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nTFee", ""));
			this.xrLabel16.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel16.Location = new System.Drawing.Point(133, 0);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.ParentStyleUsing.UseFont = false;
			this.xrLabel16.Size = new System.Drawing.Size(55, 16);
			this.xrLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel18
			// 
			this.xrLabel18.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nTRate", ""));
			this.xrLabel18.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel18.Location = new System.Drawing.Point(133, 32);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.ParentStyleUsing.UseFont = false;
			this.xrLabel18.Size = new System.Drawing.Size(55, 16);
			this.xrLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel19
			// 
			this.xrLabel19.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.vcCommName", ""));
			this.xrLabel19.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel19.Location = new System.Drawing.Point(65, 48);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.ParentStyleUsing.UseFont = false;
			this.xrLabel19.Size = new System.Drawing.Size(67, 16);
			this.xrLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xrLabel21
			// 
			this.xrLabel21.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nPay", ""));
			this.xrLabel21.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel21.Location = new System.Drawing.Point(133, 48);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.ParentStyleUsing.UseFont = false;
			this.xrLabel21.Size = new System.Drawing.Size(55, 16);
			this.xrLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xrLabel22
			// 
			this.xrLabel22.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", this.consItem1, "tbConsItem.nBalance", ""));
			this.xrLabel22.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.xrLabel22.Location = new System.Drawing.Point(133, 64);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.ParentStyleUsing.UseFont = false;
			this.xrLabel22.Size = new System.Drawing.Size(55, 16);
			this.xrLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tbConsItem", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("vcGoodsName", "vcGoodsName"),
																																																					new System.Data.Common.DataColumnMapping("nPrice", "nPrice"),
																																																					new System.Data.Common.DataColumnMapping("iCount", "iCount"),
																																																					new System.Data.Common.DataColumnMapping("nFee", "nFee"),
																																																					new System.Data.Common.DataColumnMapping("nTRate", "nTRate"),
																																																					new System.Data.Common.DataColumnMapping("nTFee", "nTFee"),
																																																					new System.Data.Common.DataColumnMapping("nPay", "nPay"),
																																																					new System.Data.Common.DataColumnMapping("nBalance", "nBalance"),
																																																					new System.Data.Common.DataColumnMapping("vcCommName", "vcCommName")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT tbGoods.vcGoodsName, tbConsItem.vcCardID, tbConsItem.nPrice, tbConsItem.iCount, tbConsItem.nFee, tbBill.nTRate, tbBill.nFee AS nTFee, tbBill.nPay, tbBill.nBalance, tbCommCode.vcCommName, tbConsItem.vcOperName FROM tbConsItem INNER JOIN tbGoods ON tbConsItem.vcGoodsID = tbGoods.vcGoodsID INNER JOIN tbBill ON tbConsItem.iSerial = tbBill.iSerial INNER JOIN tbCommCode ON tbBill.vcConsType = tbCommCode.vcCommCode";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"KMDX-Z9E5N5MK76\";packet size=4096;user id=sa;data source=\".\\sqlex" +
				"press\";persist security info=False;initial catalog=AMSCM_GY";
			this.sqlConnection1.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 0;
			this.PageFooter.Name = "PageFooter";
			// 
			// xrConsTiny
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.GroupHeader0,
																		 this.GroupFooter0,
																		 this.PageFooter});
			this.DataAdapter = this.sqlDataAdapter1;
			this.DataSource = this.consItem1;
			this.PageWidth = 392;
			((System.ComponentModel.ISupportInitialize)(this.consItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}
	}
}