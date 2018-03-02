using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmBusiIncomeReport.
	/// </summary>
	public class frmBusiIncomeReport : frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnPrint;
        private Button sbtnClose;

		CommAccess ca=new CommAccess(SysInitial.ConString);
        Exception err;

		public frmBusiIncomeReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.sbtnPrint = new System.Windows.Forms.Button();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 96);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(928, 486);
            this.dataGrid1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnPrint);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 96);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(785, 54);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 43;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // sbtnPrint
            // 
            this.sbtnPrint.Location = new System.Drawing.Point(697, 54);
            this.sbtnPrint.Name = "sbtnPrint";
            this.sbtnPrint.Size = new System.Drawing.Size(82, 23);
            this.sbtnPrint.TabIndex = 42;
            this.sbtnPrint.Text = "打印至小票";
            this.sbtnPrint.UseVisualStyleBackColor = true;
            this.sbtnPrint.Click += new System.EventHandler(this.sbtnPrint_Click);
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(616, 54);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 41;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(535, 56);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 40;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "label1";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(64, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(144, 20);
            this.cmbDept.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "门店";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(328, 56);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(328, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(267, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(264, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "开始日期";
            // 
            // frmBusiIncomeReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 582);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBusiIncomeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "业务量报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBusiIncomeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmBusiIncomeReport_Load(object sender, System.EventArgs e)
		{
			this.sbtnExcel.Enabled=false;
			this.sbtnPrint.Enabled=false;
			this.label1.Visible=false;
			this.label2.Visible=false;
			if(SysInitial.CurOps.strLimit=="LM003")
//				if(SysInitial.CurOps.strLimit=="LM003"&&SysInitial.MainDept)
			{
				this.FillComboBox(this.cmbDept,"MD","vcCommName","all");
				this.cmbDept.SelectedIndex=0;
			}
			else
			{
				string strDeptName=this.GetColCh(SysInitial.LocalDept,"MD");
				this.cmbDept.Items.Add(strDeptName);
				this.cmbDept.SelectedIndex=0;
				this.cmbDept.Enabled=false;
			}
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();			
		}

		private void DgBind()
		{
			string strBegin=dtpBegin.Value.Year.ToString();
			if(dtpBegin.Value.Month<10)
			{
				strBegin+="0" + dtpBegin.Value.Month.ToString();
			}
			else
			{
				strBegin+=dtpBegin.Value.Month.ToString();
			}
			if(dtpBegin.Value.Day<10)
			{
				strBegin+="0" + dtpBegin.Value.Day.ToString();
			}
			else
			{
				strBegin+=dtpBegin.Value.Day.ToString();
			}

			string strEnd=dtpEnd.Value.Year.ToString();
			if(dtpEnd.Value.Month<10)
			{
				strEnd+="0" + dtpEnd.Value.Month.ToString();
			}
			else
			{
				strEnd+=dtpEnd.Value.Month.ToString();
			}
			if(dtpEnd.Value.Day<10)
			{
				strEnd+="0" + dtpEnd.Value.Day.ToString();
			}
			else
			{
				strEnd+=dtpEnd.Value.Day.ToString();
			}

			this.label1.Text=strBegin+strEnd;

			string strDeptID=this.cmbDept.Text.Trim();
			this.label2.Text=strDeptID;

			if(strDeptID=="全部")
			{
				strDeptID="%%";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}

			Exception err=null;
			DataTable dt=new DataTable();
			dt=ca.BusiIncomeReport(strDeptID,strBegin,strEnd,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.dgStyle();
				if(strDeptID=="%%")
				{
					this.dataGrid1.CaptionText= SysInitial.CP + "业务量报表--所有门店";
				}
				else
				{
					this.dataGrid1.CaptionText= SysInitial.CP + "业务量报表--" + this.cmbDept.Text.Trim();
				}
				DataTable dtnew=this.ReportConvert(dt);
				this.dataGrid1.ColumnHeadersVisible=false;
				this.dataGrid1.RowHeadersVisible=false;
				this.dataGrid1.SetDataBinding(dtnew,"");
				
				if(dt.Rows.Count>0)
				{
					this.sbtnExcel.Enabled=true;
					this.sbtnPrint.Enabled=true;
				}
				else
				{
					this.sbtnExcel.Enabled=false;
					this.sbtnPrint.Enabled=false;
				}
			}
			else
			{
				MessageBox.Show("业务量报表统计出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private DataTable ReportConvert(DataTable dtreg)
		{
			string strtmp;
			DataTable dtdis=new DataTable();
			dtdis.Columns.Add("type");
			dtdis.Columns.Add("col1");
			dtdis.Columns.Add("col2");
			dtdis.Columns.Add("col3");
			dtdis.Columns.Add("col4");
			dtdis.Columns.Add("col5");
			dtdis.Columns.Add("col6");
			dtdis.Columns.Add("col7");

			DataRow dr=dtdis.NewRow();
			dr["type"]="";
			dr["col1"]="会员数";
			dr["col2"]="可用积分";
			dr["col3"]="使用积分";
			dr["col4"]="金额";
			dr["col5"]="附赠情况";
			dr["col6"]="次数";
			dr["col7"]="商品数";
			dtdis.Rows.Add(dr);

			foreach (DataRow drr in dtreg.Rows)
			{
				if(drr["Type"].ToString().Substring(0,2)!="AT")
				{
					switch(drr["Type"].ToString())
					{
						case "OldState":
							dr=dtdis.NewRow();
							dr["type"]="原状态";
							dr["col1"]=drr["REP1"].ToString();
                            dr["col2"] = "......";
							dr["col3"]="......";
                            dr["col4"] = "......";
							dr["col5"]="......";
							dr["col6"]="......";
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "NewState":
							dr=dtdis.NewRow();
							dr["type"]="现状态";
							dr["col1"]=drr["REP1"].ToString();
                            dr["col2"] = "......";
							dr["col3"]="......";
                            dr["col4"] = "......";
							dr["col5"]="......";
							dr["col6"]="......";
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "NewAss":
							dr=dtdis.NewRow();
							dr["type"]="新入会员";
							dr["col1"]=drr["REP1"].ToString();
                            dr["col2"] = "......";
							dr["col3"]="......";
                            dr["col4"] = "......";
							dr["col5"]="......";
							dr["col6"]="......";
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "LostAss":
							dr=dtdis.NewRow();
							dr["type"]="挂失会员";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]="......";
							dr["col5"]="......";
							dr["col6"]="......";
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "ReleaseAss":
							dr=dtdis.NewRow();
							dr["type"]="补卡会员";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]="......";
							dr["col5"]="......";
							dr["col6"]="......";
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "FillFee":
							dr=dtdis.NewRow();
							dr["type"]="充值";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]=drr["REP5"].ToString();
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "BankFillFee":
							dr=dtdis.NewRow();
							dr["type"]="银行卡充值";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]=drr["REP5"].ToString();
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "FillFeeRollback":
							dr=dtdis.NewRow();
							dr["type"]="回收卡退款";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]=drr["REP5"].ToString();
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]="......";
							dtdis.Rows.Add(dr);
							break;
						case "Retail":
							dr=dtdis.NewRow();
							dr["type"]="零售";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;
						case "AssCons":
							dr=dtdis.NewRow();
							dr["type"]="会员消费";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]=drr["REP5"].ToString();
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;
						case "Larg":
							dr=dtdis.NewRow();
							dr["type"]="会员赠送";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;
						case "Special1":
							dr=dtdis.NewRow();
							dr["type"]="门店报损";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;

						case "Special2":
							dr=dtdis.NewRow();
							dr["type"]="门店品尝";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;

						case "Special3":
							dr=dtdis.NewRow();
							dr["type"]="门店退货";
							dr["col1"]="......";
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;

						case "IgChange":
							dr=dtdis.NewRow();
							dr["type"]="积分兑换";
							dr["col1"]=drr["REP1"].ToString();
                            dr["col2"] = "......";
							strtmp=drr["REP3"].ToString();
							if(strtmp=="0")
							{
								dr["col3"]="0";
							}
							else
							{
								dr["col3"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col4"]="......";
							dr["col5"]="......";
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;

						case "BankRetail":
							dr=dtdis.NewRow();
							dr["type"]="银行卡零售";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							strtmp=drr["REP5"].ToString();
							if(strtmp=="0")
							{
								dr["col5"]="0";
							}
							else
							{
								dr["col5"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
							break;
					}
				}
				else
				{
					DataTable dtat=SysInitial.dsSys.Tables["AT"];
					foreach(DataRow drat in dtat.Rows)
					{
						if(drat["vcCommCode"].ToString()==drr["Type"].ToString())
						{
							dr=dtdis.NewRow();
							dr["type"]=drat["vcCommName"].ToString()+"消费";
							dr["col1"]=drr["REP1"].ToString();
							dr["col2"]="......";
							dr["col3"]="......";
							dr["col4"]=drr["REP4"].ToString();
							strtmp=drr["REP5"].ToString();
							if(strtmp=="0")
							{
								dr["col5"]="0";
							}
							else
							{
								dr["col5"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							strtmp=drr["REP6"].ToString();
							if(strtmp=="0")
							{
								dr["col6"]="0";
							}
							else
							{
								dr["col6"]=strtmp.Substring(0,strtmp.IndexOf(".",0));
							}
							dr["col7"]=drr["REP7"].ToString();
							dtdis.Rows.Add(dr);
						}
					}
				}
			}

			dr=dtdis.NewRow();
			dr["type"]="";
			dr["col1"]="会员增加总数";
			dr["col2"]="积分增加总额";
			dr["col3"]="余额增加总额";
			dr["col4"]="现金增加总额";
			dr["col5"]="赠款增加总额";
			dr["col6"]="会员消费总额";
			dr["col7"]="商品销售总数";
			dtdis.Rows.Add(dr);

			dr=dtdis.NewRow();
			dr["type"]="总计";
			if(dtreg.Rows.Count>17)
			{
				dr["col1"]=dtreg.Rows[15]["REP1"].ToString();
                dr["col2"] = "......";
                dr["col3"] = "......";
				dr["col4"]=dtreg.Rows[15]["REP4"].ToString();
                dr["col5"] = "......";
				dr["col6"]=dtreg.Rows[15]["REP6"].ToString();
				dr["col7"]=dtreg.Rows[15]["REP7"].ToString();
            }
			dtdis.Rows.Add(dr);

			return dtdis;
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnExcel_Click(object sender, System.EventArgs e)
		{
			DataTable dt=new DataTable();
			dt=(DataTable)this.dataGrid1.DataSource;
			if(dt!=null && dt.Rows.Count>0)
			{
				string strDate=this.label1.Text.Trim();
				strDate="起止时间:" + strDate.Substring(0,4) + "年" + int.Parse(strDate.Substring(4,2)).ToString() + "月" + int.Parse(strDate.Substring(6,2)).ToString() + "日--" + strDate.Substring(8,4) + "年" + int.Parse(strDate.Substring(12,2)).ToString() + "月" + int.Parse(strDate.Substring(14,2)).ToString() + "日";
				this.BusiIncomeExportToExcel(this.dataGrid1.CaptionText,strDate,dt);
			}
			else
			{
				MessageBox.Show("表格没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
		}

		private void sbtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
                string strDateZoom = this.label1.Text.Trim();
                err = null;
                DataTable dt = ca.GetBusiQuery(strDateZoom, out err);
                if (dt == null || dt.Rows.Count <= 0 )
                {
                    MessageBox.Show("没有数据可以打印!", "系统提示", MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                CMSMData.CMSMStruct.BusiStruct cis = new CMSMData.CMSMStruct.BusiStruct();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cis.strNewAssCount = dt.Rows[i]["新增会员数"].ToString();
                    cis.strLostAssCount = dt.Rows[i]["挂失会员数"].ToString();
                    cis.strFillFeeCount = dt.Rows[i]["充值次数"].ToString();
                    cis.strFIllFee = dt.Rows[i]["充值金额"].ToString();
                    cis.strBankFillFee = dt.Rows[i]["银联卡充值"].ToString();
                    cis.strAssConsCount = dt.Rows[i]["会员消费次数"].ToString();
                    cis.strAssCons = dt.Rows[i]["会员消费金额"].ToString();
                    cis.strRetailCount = dt.Rows[i]["零售次数"].ToString();
                    cis.strRetail = dt.Rows[i]["零售金额"].ToString();
                    cis.strSum = dt.Rows[i]["现金总额"].ToString();
                    cis.strDeptname = this.cmbDept.Text;
                    cis.strOperName = SysInitial.CurOps.strOperName;
                    DateTime dtNow = DateTime.Now;
                    cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                }
                System.Windows.Forms.DialogResult diaRes1 = MessageBox.Show("是否打印当日结账？", "请确认", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                if (diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
                {
                    this.BusiPrint(cis,ca);
                    this.OpenDrawer();
                }

			}
			catch(Exception er)
			{
				MessageBox.Show("打印机设置有误，无法打印！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(er.ToString());
			}
		}

	}
}
