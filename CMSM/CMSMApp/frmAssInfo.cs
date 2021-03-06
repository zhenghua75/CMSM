using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmAssInfo 的摘要说明。
	/// </summary>
	public class frmAssInfo : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbAssAdd;
		private System.Windows.Forms.ToolBarButton tbbAssMod;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox cmbAssName;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIG;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
        private Button sbtnQuery;
        private Button sbtnClose;
        private Button sbtnExcel;

		CommAccess ca=new CommAccess(SysInitial.ConString);

		public frmAssInfo()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssInfo));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbAssAdd = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbbAssMod = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAssName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIG = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sbtnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbAssAdd,
            this.toolBarButton1,
            this.tbbAssMod});
            this.toolBar1.ButtonSize = new System.Drawing.Size(48, 48);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1048, 41);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbAssAdd
            // 
            this.tbbAssAdd.ImageIndex = 0;
            this.tbbAssAdd.Name = "tbbAssAdd";
            this.tbbAssAdd.Text = "添加";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbAssMod
            // 
            this.tbbAssMod.ImageIndex = 1;
            this.tbbAssMod.Name = "tbbAssMod";
            this.tbbAssMod.Text = "修改";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 123);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1048, 307);
            this.dataGrid1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbAssName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(938, 54);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 47;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(857, 24);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 46;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(496, 56);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 21);
            this.dtpEnd.TabIndex = 45;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(496, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(120, 21);
            this.dtpBegin.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(408, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "创建结束日期";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(408, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "创建开始日期";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.Location = new System.Drawing.Point(256, 56);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(128, 22);
            this.txtPhone.TabIndex = 41;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(200, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "电话号码";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Location = new System.Drawing.Point(256, 24);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(128, 20);
            this.cmbType.TabIndex = 39;
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(680, 56);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(144, 20);
            this.cmbDept.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(633, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "门店";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(198, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "会员状态";
            // 
            // cmbAssName
            // 
            this.cmbAssName.Location = new System.Drawing.Point(72, 56);
            this.cmbAssName.Name = "cmbAssName";
            this.cmbAssName.Size = new System.Drawing.Size(104, 20);
            this.cmbAssName.TabIndex = 15;
            this.cmbAssName.Text = "*";
            this.cmbAssName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAssName_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "会员姓名";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(72, 24);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(104, 22);
            this.txtCardID.TabIndex = 1;
            this.txtCardID.Text = "*";
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIG);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFee);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1048, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据汇总";
            // 
            // txtIG
            // 
            this.txtIG.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIG.Location = new System.Drawing.Point(512, 24);
            this.txtIG.Name = "txtIG";
            this.txtIG.Size = new System.Drawing.Size(104, 22);
            this.txtIG.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(464, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "总积分";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(384, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "元";
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFee.Location = new System.Drawing.Point(280, 24);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(104, 22);
            this.txtFee.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(224, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "总余额";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(96, 24);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(64, 22);
            this.txtCount.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "查询条数";
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(857, 54);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 48;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // frmAssInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1048, 486);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmAssInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "会员基本资料管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAssInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					frmAssAdd frmadd=new frmAssAdd();
					frmadd.ShowDialog();
					break;
				case 2:
					if(this.dataGrid1.CurrentRowIndex<0)
					{
						MessageBox.Show("没有数据可以修改！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					}
					else if(this.dataGrid1[this.dataGrid1.CurrentRowIndex,5].ToString()!="正常在用")
					{
						MessageBox.Show("不能修改非正常在用会员资料！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					}
					else
					{
						frmAssMod frmmod=new frmAssMod();
						this.AddOwnedForm(frmmod);
						frmmod.ShowDialog();
					}
					break;
				default:
					break;
			}
		}

		private void DgBind()
		{
			string strCardID=txtCardID.Text.Trim();
			string strAssName=cmbAssName.Text.Trim();
			string strType=cmbType.Text.ToString();
			string strType1="";
			string strDeptID=cmbDept.Text.Trim();
			string strPhone=txtPhone.Text.Trim();
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			if(strDeptID=="全部")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			if (strType=="全部")	
			{
				strType1="all";
			}
			if (strType=="正常")	
			{
				strType1="0";
			}
			if (strType=="挂失")	
			{
				strType1="1";
			}
            if (strType == "补卡")
            {
                strType1 = "2";
            }
            if (strType == "回收")
            {
                strType1 = "3";
            }
			Hashtable htPara=new Hashtable();
            htPara.Add("strType1", strType1);
			htPara.Add("strCardID",strCardID);
			htPara.Add("strAssName",strAssName);
			htPara.Add("strPhone",strPhone);
			htPara.Add("strBegin",strBegin);
			htPara.Add("strEnd",strEnd);
			htPara.Add("strDeptID",strDeptID);
			Exception err=null;
			DataTable dt=new DataTable();
			dt=ca.GetAssociator(htPara, out err);
			if(err!=null)
			{
				MessageBox.Show("查询错误，请检查《vpn》是否连接！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
			if(dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcAssState","AS","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
			}
			double dcharge=0;
			int iIg=0;
			for(int i=0;i<dt.Rows.Count;i++)
			{
				dcharge+=Math.Round(double.Parse(dt.Rows[i]["nCharge"].ToString()),2);
				iIg+=int.Parse(dt.Rows[i]["iIgValue"].ToString());
			}
			txtCount.Text=dt.Rows.Count.ToString();
			txtFee.Text=Math.Round(dcharge,2).ToString();
			txtIG.Text=iIg.ToString();
			if(dt!=null)
			{
				this.dataGrid1.SetDataBinding(dt,"");
                this.EnToCh("会员ID,会员卡号,会员姓名,联系电话,会员类型,会员状态,当前余额,当前积分,门店,创建日期,操作日期,备注,身份证号,联系地址,Email,拼音简码", "60,80,60,100,80,80,80,80,150,140,140,140,90,60,80", dt, this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询错误，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
//			if(e.KeyChar!=13)
//			{
//				if(e.KeyChar==8||e.KeyChar==42)
//				{
//					return;
//				}
//				if(e.KeyChar<48||e.KeyChar>57)
//				{
//					e.Handled=true;
//					return;
//				}
//			}
//			else
//			{
//				this.DgBind();
//			}
		}

		private void cmbAssName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strAssName=cmbAssName.Text.Trim();
				this.FillComboBoxBySpell(cmbAssName,"AssSpell","vcAssName","vcSpell",strAssName);
				this.DgBind();
			}
		}

		private void frmAssInfo_Load(object sender, System.EventArgs e)
		{
			cmbType.Items.Add("全部");
			cmbType.Items.Add("正常");
			cmbType.Items.Add("挂失");
            cmbType.Items.Add("补卡");
            cmbType.Items.Add("回收");
			cmbType.Text="全部";
			this.FillComboBox(this.cmbDept,"MD","vcCommName","all");
			this.cmbDept.SelectedIndex=0;
			if(SysInitial.CurOps.strLimit=="LM002")
			{
				this.sbtnExcel.Enabled=false;
			}
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
						table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
					}		
				}
			}
			else
			{
				MessageBox.Show("没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}

		private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8||e.KeyChar==42)
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)
				{
					e.Handled=true;
					return;
				}
			}
			else
			{
				this.DgBind();
			}
		}
	}
}
