using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmFillQuery 的摘要说明。
	/// </summary>
	public class frmFillQuery : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbAssType;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAssName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private string strTmp22="";
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTolProm;
		private System.Windows.Forms.ComboBox cmbOper;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbType;
        private Button sbtnQuery;
        private Button simpleButton1;
        private Button sbtnExcel;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmFillQuery()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTolProm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOper = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAssType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAssName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTolProm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFee);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 438);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 56);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "汇总数据";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(640, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "元";
            // 
            // txtTolProm
            // 
            this.txtTolProm.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTolProm.Location = new System.Drawing.Point(536, 24);
            this.txtTolProm.Name = "txtTolProm";
            this.txtTolProm.Size = new System.Drawing.Size(104, 22);
            this.txtTolProm.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(472, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "赠款金额";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(392, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "元";
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFee.Location = new System.Drawing.Point(288, 24);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(104, 22);
            this.txtFee.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(160, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "总充值金额";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(88, 24);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(64, 22);
            this.txtCount.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "查询条数";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 120);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(848, 318);
            this.dataGrid1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbOper);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAssType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbAssName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(674, 85);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 42;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(593, 85);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 41;
            this.simpleButton1.Text = "打印";
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(508, 85);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 40;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(621, 50);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(128, 20);
            this.cmbType.TabIndex = 38;
            this.cmbType.Text = "全部";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(549, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 37;
            this.label13.Text = "交易类型";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(324, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(168, 20);
            this.cmbDept.TabIndex = 35;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(263, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "门店";
            // 
            // cmbOper
            // 
            this.cmbOper.Location = new System.Drawing.Point(597, 24);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.Size = new System.Drawing.Size(152, 20);
            this.cmbOper.TabIndex = 34;
            this.cmbOper.Text = "*";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(549, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "操作员";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(324, 88);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(324, 56);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(260, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(260, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "开始日期";
            // 
            // cmbAssType
            // 
            this.cmbAssType.Location = new System.Drawing.Point(70, 24);
            this.cmbAssType.Name = "cmbAssType";
            this.cmbAssType.Size = new System.Drawing.Size(168, 20);
            this.cmbAssType.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "会员类型";
            // 
            // cmbAssName
            // 
            this.cmbAssName.Location = new System.Drawing.Point(70, 88);
            this.cmbAssName.Name = "cmbAssName";
            this.cmbAssName.Size = new System.Drawing.Size(168, 20);
            this.cmbAssName.TabIndex = 20;
            this.cmbAssName.Text = "*";
            this.cmbAssName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAssName_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "会员姓名";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(70, 56);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(168, 22);
            this.txtCardID.TabIndex = 17;
            this.txtCardID.Text = "*";
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "会员卡号";
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(755, 85);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 43;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmFillQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 494);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFillQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "充值记录及消费查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFillQuery_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmbAssName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strAssName=cmbAssName.Text.Trim();
				if(strAssName=="")
				{
					this.DgBind();
				}
				else
				{
					this.FillComboBoxBySpell(cmbAssName,"AssSpell","vcAssName","vcSpell",strAssName);
					if(cmbAssName.Text.Trim()==strAssName)
					{
						MessageBox.Show("无此会员！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					this.DgBind();
				}
			}
		}

		private void DgBind()
		{
			Hashtable htPara=new Hashtable();
			string strCardID=txtCardID.Text.Trim();
			htPara.Add("strCardID",strCardID);
			string strAssName=cmbAssName.Text.Trim();
			htPara.Add("strAssName",strAssName);
			string strOperName=cmbOper.Text.Trim();
			string strAssType=cmbAssType.Text.Trim();
			string strDeptID=cmbDept.Text.Trim();
			if(strAssType=="全部")
			{
				strAssType="";
			}
			else
			{
				strAssType=this.GetColEn(strAssType,"AT");
			}
			htPara.Add("strAssType",strAssType);
			if(strOperName=="全部")
			{
				strOperName="";
			}
			htPara.Add("strOperName",strOperName);
			if(strDeptID=="全部")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			htPara.Add("strDeptID",strDeptID);
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			htPara.Add("strBegin",strBegin);
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			htPara.Add("strEnd",strEnd);
			
			htPara.Add("strTmp22",strTmp22);

			Exception err=null;
			DataTable dt=new DataTable();
			dt=cs.GetFillQuery(htPara,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");

				double dFillFee=0;
				double dProm=0;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					dFillFee+=double.Parse(dt.Rows[i]["nFillFee"].ToString());
					dProm+=double.Parse(dt.Rows[i]["nFillProm"].ToString());
				}
				txtCount.Text=dt.Rows.Count.ToString();
				txtFee.Text=Math.Round(dFillFee,2).ToString();
				txtTolProm.Text=Math.Round(dProm,2).ToString();
				this.dataGrid1.CaptionText="会员充值及消费统计报表";
				this.dataGrid1.SetDataBinding(dt,"");
                this.EnToCh("流水号,会员名称,会员类型,会员卡号,充值金额(-为消费),赠款金额,上次余额,当前余额,充值日期,操作员,操作员门店,备注", "80,100,80,80,130,80,80,80,140,80,160,100", dt, this.dataGrid1);
				if(dt.Rows.Count>0)
				{
					this.sbtnExcel.Enabled=true;
				}
				else
				{
					this.sbtnExcel.Enabled=false;
				}
			}
			else
			{
				MessageBox.Show("查询出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			strTmp22="";
			this.label7.Visible=true;
			this.label8.Visible=true;
			this.label9.Visible=true;
			this.label10.Visible=true;
			this.txtFee.Visible=true;
			this.txtTolProm.Visible=true;
			if (this.cmbType.Text.Trim()=="全部")
			{
				this.label7.Visible=false;
				this.label8.Visible=false;
				this.label9.Visible=false;
				this.label10.Visible=false;
				this.txtFee.Visible=false;
				this.txtTolProm.Visible=false;
				strTmp22="22";
			}
			if (this.cmbType.Text.Trim()=="消费")
			{
				this.label7.Visible=true;
				this.label8.Visible=true;
				this.label9.Visible=false;
				this.label10.Visible=false;
				this.txtFee.Visible=true;
				this.txtTolProm.Visible=false;
				this.label7.Text="总消费金额";
				strTmp22="33";
			}
			if(this.cmbType.Text.Trim()=="银行卡充值")
			{
				strTmp22="44";
				this.label7.Text="银行卡充值总金额";
			}
			if(this.cmbType.Text.Trim()=="现金充值")
			{
				strTmp22="55";
				this.label7.Text="现金充值总金额";
			}
			this.DgBind();
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
//				if(e.KeyChar==8||e.KeyChar==42)
//				{
//					return;
//				}
//				if(e.KeyChar<48||e.KeyChar>57)
//				{
//					e.Handled=true;
//					return;
//				}
			}
			else
			{
				this.DgBind();
			}
		}

		private void frmFillQuery_Load(object sender, System.EventArgs e)
		{
			this.cmbType.Items.Add("全部");
			this.cmbType.Items.Add("现金充值");
			this.cmbType.Items.Add("银行卡充值");
			this.cmbType.Items.Add("消费");
			this.FillComboBox(cmbAssType,"AT","vcCommName","allExcRetail");
			this.sbtnExcel.Enabled=false;
			strTmp22="";
			this.label7.Visible=true;
			this.label8.Visible=true;
			this.label9.Visible=true;
			this.label10.Visible=true;
			this.txtFee.Visible=true;
			this.txtTolProm.Visible=true;
			if (this.cmbType.Text.Trim()=="全部")
			{
				this.label7.Visible=false;
				this.label8.Visible=false;
				this.label9.Visible=false;
				this.label10.Visible=false;
				this.txtFee.Visible=false;
				this.txtTolProm.Visible=false;
				strTmp22="22";
			}
			if (this.cmbType.Text.Trim()=="消费")
			{
				this.label7.Visible=true;
				this.label8.Visible=true;
				this.label9.Visible=false;
				this.label10.Visible=false;
				this.txtFee.Visible=true;
				this.txtTolProm.Visible=false;
				this.label7.Text="总消费金额";
				strTmp22="33";
			}
			if(this.cmbType.Text.Trim()=="银行卡充值")
			{
				strTmp22="44";
				this.label7.Text="银行卡充值总金额";
			}
			if(this.cmbType.Text.Trim()=="现金充值")
			{
				strTmp22="55";
				this.label7.Text="现金充值总金额";
			}

			Exception err=null;
			this.cmbOper.Items.Clear();
			DataTable dtOperList=cs.GetConsOperList("all",out err);
			if(dtOperList!=null&&dtOperList.Rows.Count>=0)
			{
				this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","all");
				this.cmbOper.SelectedIndex=0;
			}
			
			if(SysInitial.CurOps.strLimit=="LM003")
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
			this.DgBind();
		}

		private void sbtnExcel_Click(object sender, System.EventArgs e)
		{
			DataTable dt=new DataTable();
			dt=(DataTable)this.dataGrid1.DataSource;
			string table="";
			if(dt!=null && dt.Rows.Count>0)
			{							
				for(int i=0;i<dt.Columns.Count;i++)
				{
					if(dataGrid1.TableStyles[0].GridColumnStyles[i].Width>0)
					{
						if(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="充值金额"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="赠款金额"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="上次余额"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="当前余额")
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "double,";
						}
						else
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
						}
					}		
				}
			}
			else
			{
				MessageBox.Show("表格没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}

		private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(SysInitial.CurOps.strLimit=="LM003")
			{
				this.cmbOper.Items.Clear();
				DataTable dtOperList;
				Exception err=null;
				string strDeptID=this.cmbDept.Text;
				if(strDeptID=="全部")
				{
					this.cmbOper.Items.Add("全部");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
					dtOperList=cs.GetConsOperList("all",out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>=0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","");
					}
					this.cmbOper.SelectedIndex=0;
				}
				else if(this.GetColEn(strDeptID,"MD")==SysInitial.LocalDept)
				{
					this.cmbOper.Items.Add("全部");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
				}
				else
				{
					this.cmbOper.Items.Add("全部");
					strDeptID=this.GetColEn(this.cmbDept.Text,"MD");
					dtOperList=cs.GetConsOperList(strDeptID,out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName",strDeptID);
					}
					else
					{
						if(err!=null)
						{
							MessageBox.Show("系统错误，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
							clog.WriteLine(err);
						}
						return;
					}
					this.cmbOper.SelectedIndex=0;
				}
			}
			else if(SysInitial.CurOps.strLimit=="LM001")
			{
				this.FillComboBox(this.cmbOper,"Oper","vcOperName","all");
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			//zhh 20100311 print
			//this.dataGrid1[this.dataGrid1.CurrentRowIndex,0].ToString();
			string strAssName = this.dataGrid1[this.dataGrid1.CurrentRowIndex,1].ToString();
			string strCardID = this.dataGrid1[this.dataGrid1.CurrentRowIndex,3].ToString();
			string strlastBalance = this.dataGrid1[this.dataGrid1.CurrentRowIndex,6].ToString();
			string strBalance = this.dataGrid1[this.dataGrid1.CurrentRowIndex,7].ToString();
			string strPrepay = this.dataGrid1[this.dataGrid1.CurrentRowIndex,4].ToString();
			string strDonate = this.dataGrid1[this.dataGrid1.CurrentRowIndex,5].ToString();
			string strOperDate = this.dataGrid1[this.dataGrid1.CurrentRowIndex,8].ToString();
			string strOperName = this.dataGrid1[this.dataGrid1.CurrentRowIndex,9].ToString();
			string strDeptName = this.dataGrid1[this.dataGrid1.CurrentRowIndex,10].ToString();

//			CMSM.Print.PrintedBill pBill = new CMSM.Print.PrintedBill();
//			pBill.cnvcBillType = "充值";
//			pBill.cnvcMemberCardNo = strCardID;
//			pBill.cnvcMemberName = strAssName;
//			pBill.cnnLastBalance = Convert.ToDecimal(strlastBalance);
//			pBill.cnnBalance = Convert.ToDecimal(strBalance);
//			pBill.cnnPrepay = Convert.ToDecimal(strPrepay);
//			pBill.cnnDonate = Convert.ToDecimal(strDonate);
//			pBill.cnvcOperName = strOperName;
//			pBill.cndOperDate = Convert.ToDateTime(strOperDate);
//			
//			CMSM.Print.PrintEngine printEngine = new CMSM.Print.PrintEngine(SysInitial.CP);
//			printEngine.AddPrintObject(pBill);
//			printEngine.Print();
			//zhh 20100311
			CMSMData.CMSMStruct.FillFeeStruct ffs=new CMSMData.CMSMStruct.FillFeeStruct();			
			ffs.strCardID=strCardID;
			ffs.dFillFee=Convert.ToDouble(strPrepay);
			ffs.dFillProm=Math.Round(Double.Parse(strDonate.Trim()),2);
			ffs.dFeeLast=Convert.ToDouble(strlastBalance);
			ffs.dFeeCur=Convert.ToDouble(strBalance);
			ffs.strFillDate=strOperDate;

			this.FillFeePrint(ffs,cs,strAssName,strOperName,strDeptName);
		}
	}
}
