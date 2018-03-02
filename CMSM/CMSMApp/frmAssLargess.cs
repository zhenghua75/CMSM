using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmAssCons.
	/// </summary>
	public class frmAssLargess : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtAssType;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtTolCharge;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ComboBox cmbGoodsName;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtPay;
		private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtIg;
		DataTable dtConsItem;
        private Button sbtnRead;
        private Button sbtnRollback;
        private Button sbtnAdd;
        private Button sbtnOk;
        private Button sbtnCancel;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

		public frmAssLargess()
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTolCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIg = new System.Windows.Forms.TextBox();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAssType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.sbtnRead = new System.Windows.Forms.Button();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGoodsID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(232, 104);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(572, 424);
            this.dataGrid1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTolCharge);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTolCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(232, 528);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(572, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消费合计：";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(448, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "元";
            // 
            // txtTolCharge
            // 
            this.txtTolCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCharge.Location = new System.Drawing.Point(352, 24);
            this.txtTolCharge.MaxLength = 10;
            this.txtTolCharge.Name = "txtTolCharge";
            this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
            this.txtTolCharge.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(288, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "总金额：";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(128, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(64, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "总数量：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txtIg);
            this.groupBox2.Controls.Add(this.txtAssID);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtCharge);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtLinkPhone);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAssType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAssName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCardID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(232, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "赠送会员信息";
            // 
            // txtIg
            // 
            this.txtIg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIg.Enabled = false;
            this.txtIg.Location = new System.Drawing.Point(320, 64);
            this.txtIg.MaxLength = 10;
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(104, 21);
            this.txtIg.TabIndex = 22;
            this.txtIg.Visible = false;
            // 
            // txtAssID
            // 
            this.txtAssID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssID.Location = new System.Drawing.Point(240, 56);
            this.txtAssID.MaxLength = 10;
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(104, 21);
            this.txtAssID.TabIndex = 21;
            this.txtAssID.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(200, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "元";
            // 
            // txtCharge
            // 
            this.txtCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharge.Location = new System.Drawing.Point(96, 64);
            this.txtCharge.MaxLength = 10;
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(104, 21);
            this.txtCharge.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(32, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "当前余额";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLinkPhone.Location = new System.Drawing.Point(536, 64);
            this.txtLinkPhone.MaxLength = 25;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(104, 21);
            this.txtLinkPhone.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(472, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "联系电话";
            // 
            // txtAssType
            // 
            this.txtAssType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssType.Location = new System.Drawing.Point(536, 24);
            this.txtAssType.MaxLength = 10;
            this.txtAssType.Name = "txtAssType";
            this.txtAssType.Size = new System.Drawing.Size(104, 21);
            this.txtAssType.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(472, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "会员类型";
            // 
            // txtAssName
            // 
            this.txtAssName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssName.Location = new System.Drawing.Point(312, 24);
            this.txtAssName.MaxLength = 30;
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(104, 21);
            this.txtAssName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(248, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "会员姓名";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Location = new System.Drawing.Point(96, 24);
            this.txtCardID.MaxLength = 10;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(104, 21);
            this.txtCardID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "会员卡号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnOk);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.sbtnRead);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPay);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 578);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "赠送会员消费栏目";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(133, 330);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 31;
            this.sbtnCancel.Text = "关闭";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(35, 330);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 30;
            this.sbtnOk.Text = "结帐(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(133, 256);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 29;
            this.sbtnAdd.Text = "确定";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(40, 256);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 28;
            this.sbtnRollback.Text = "<<撤消";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // sbtnRead
            // 
            this.sbtnRead.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbtnRead.Location = new System.Drawing.Point(136, 52);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 27;
            this.sbtnRead.Text = "刷卡(F5)";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(80, 365);
            this.txtBalance.MaxLength = 10;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(136, 23);
            this.txtBalance.TabIndex = 23;
            this.txtBalance.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(32, 373);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "找零";
            this.label16.Visible = false;
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(80, 291);
            this.txtPay.MaxLength = 10;
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(136, 23);
            this.txtPay.TabIndex = 21;
            this.txtPay.Visible = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 299);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "付费金额";
            this.label15.Visible = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(192, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "元";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(80, 224);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(128, 23);
            this.txtCount.TabIndex = 4;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "数量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 184);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 23);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "单价";
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(80, 144);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 22);
            this.cmbGoodsName.TabIndex = 2;
            this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(80, 104);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 23);
            this.txtGoodsID.TabIndex = 1;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "商品编号";
            // 
            // frmAssLargess
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmAssLargess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "赠送会员商品消费";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAssLargess_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAssCons_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmAssLargess_Load(object sender, System.EventArgs e)
		{
			cmbGoodsName.Text="请输入...";
			txtCardID.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtAssType.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtCount.ReadOnly=true;

			txtGoodsID.ReadOnly=true;
			cmbGoodsName.Enabled=false;
			txtPrice.ReadOnly=true;
			txtCount.Text="1";
			txtPay.Text="0";
			txtBalance.Text="0";

			groupBox2.BackColor=Color.AliceBlue;
			groupBox3.BackColor=Color.Snow;

            //sbtnRollback.ToolTip="撤消已选商品，每次撤消数量为1";

			dtConsItem=new DataTable();
			dtConsItem.Columns.Add("GoodsID");
			dtConsItem.Columns.Add("GoodsName");
			dtConsItem.Columns.Add("Price");
			dtConsItem.Columns.Add("Count");
			dtConsItem.Columns.Add("Rate");
			dtConsItem.Columns.Add("Fee");
			dtConsItem.Columns.Add("Comments");
			dtConsItem.Columns["Comments"].DefaultValue="";
			DgBind();
		}

		public void sbtnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，刷卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			string strresult="";
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("此卡为员工卡，不可进行消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID, out err);
				if(assres!=null)
				{
					string strAssState=assres.strAssState;
					if(strAssState!="0")
					{
						MessageBox.Show("该会员已经失效，卡号：" + chs.strCardID + "，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					if(assres.dCharge<=0)
					{
						MessageBox.Show("当前余额不足，不能消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					if(chs.dCurCharge<0)
					{
						txtCharge.Text=assres.dCharge.ToString();
					}
					else
					{
						txtCharge.Text=chs.dCurCharge.ToString();
					}
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;			
					txtAssType.Text=GetColCh(assres.strAssType,"AT");
					txtAssID.Text=assres.strAssID;
					txtIg.Text=chs.iCurIg.ToString();
					cmbGoodsName.Enabled=true;
					txtCount.ReadOnly=false;
					sbtnRead.Enabled=false;
					cmbGoodsName.Focus();				
				}
				else
				{
					MessageBox.Show("无会员资料，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void cmbGoodsName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13&&cmbGoodsName.Text.Trim()!="")
			{
				string strSpell=cmbGoodsName.Text.Trim();
				this.FillComboBoxBySpell(cmbGoodsName,"GoodsSpell","vcGoodsName","vcSpell",strSpell);
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByName(cmbGoodsName.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtPrice.Text=gs.dPrice.ToString();
					txtPrice.ReadOnly=true;
					txtCount.Text="1";
					cmbGoodsName.Focus();
				}
				else
				{
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void txtGoodsID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13&&txtGoodsID.Text.Trim()!="")
			{
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
//					txtPrice.Text=gs.dPrice.ToString();
					if (SysInitial.TP=="1")
					{
						txtPrice.Text=gs.dPrice.ToString();
					}
					else
					{
						txtPrice.Text="0";
					}
					txtPrice.ReadOnly=true;
					txtCount.Text="1";
					txtCount.Focus();
				}
				else
				{
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					txtGoodsID.Focus();
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8)
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
				double dCount=0;
				if(txtCount.Text.Trim()=="")
				{
					MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dCount=int.Parse(txtCount.Text.Trim());
				}

				double dPrice=0;
				if(txtPrice.Text.Trim()=="")
				{
					MessageBox.Show("单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dPrice=Double.Parse(txtPrice.Text.Trim());
				}

				if(txtGoodsID.Text.Trim()=="")
				{
					MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtGoodsID.Text="";
					cmbGoodsName.Items.Clear();
					cmbGoodsName.Refresh();
					txtPrice.Text="";
					txtCount.Text="";
				}
//				if((double.Parse(txtTolCharge.Text.Trim())+dPrice)>double.Parse(txtCharge.Text.Trim()))
//				{
//					MessageBox.Show("所剩余额不能再购买此商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					bool sumflag=false;
					for(int i=0;i<dtConsItem.Rows.Count;i++)
					{
						if(gs.strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
						{
							dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+(dPrice*dCount)).ToString();
							sumflag=true;
							break;
						}
					}
					if(!sumflag)
					{
						DataRow dr=dtConsItem.NewRow();
						dr[0]=gs.strGoodsID;
						dr[1]=gs.strGoodsName;
//						dr[2]=dPrice.ToString();
						if (SysInitial.TP=="1")
						{
							dr[2]=gs.dPrice.ToString();
						}
						else
						{
							dr[2]="0";
						}
						dr[3]=dCount.ToString();
						dr[4]="0";
						dr[5]=(dPrice*dCount).ToString();
						dtConsItem.Rows.Add(dr);
					}
					this.DgBind();
					cmbGoodsName.Focus();
				}
				else
				{
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		public void sbtnOk_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，刷卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			if(dtConsItem.Rows.Count<=0)
			{
				MessageBox.Show("没有进行任何消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			double dTolCharge=double.Parse(txtTolCharge.Text.Trim());
//			if(double.Parse(txtCharge.Text.Trim())<dTolCharge)
//			{
//				MessageBox.Show("当前余额不足，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strAssID=txtAssID.Text.Trim();
			cis.strCardID=txtCardID.Text.Trim();
			cis.dChargeLast=double.Parse(txtCharge.Text.Trim());
			cis.dTolCharge=dTolCharge;
			string strCharge=(cis.dChargeLast-dTolCharge).ToString() + "元";
            DateTime dtNow = DateTime.Now;
            cis.iSerial =Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
            cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            //cis.iSerial = Int64.Parse(cis.strOperDate.Substring(0, 4) + cis.strOperDate.Substring(5, 2) + cis.strOperDate.Substring(8, 2) + cis.strOperDate.Substring(11, 2) + cis.strOperDate.Substring(14, 2) + cis.strOperDate.Substring(17, 2));
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.dTRate=0;
			cis.dPay=dTolCharge;
			cis.dBalance=0;
			cis.strConsType="PT004";
			cis.dtItem=dtConsItem;
			cis.iIgLast=int.Parse(txtIg.Text.Trim());
			cis.strIgType="IGT01";
			cis.strDeptID=SysInitial.CurOps.strDeptID;
			DataTable dtIG=SysInitial.dsSys.Tables["IG"];
			int iIGFee=0;
			int iIGProm=0;
			if(dtIG.Rows.Count>0)
			{
				iIGFee=int.Parse(dtIG.Rows[0]["vcCommName"].ToString());
				iIGProm=int.Parse(dtIG.Rows[0]["vcCommCode"].ToString());
			}
			cis.iIgValue=((int)(dTolCharge/iIGFee))*iIGProm;
//			chs.dCurCharge=cis.dChargeLast-cis.dTolCharge;
			chs.dCurCharge=cis.dChargeLast;
			chs.iCurIg=cis.iIgLast+cis.iIgValue;
			string strIG=chs.iCurIg.ToString()+"分";
//			double dCurChargeBaklar=System.Math.Round((double.Parse(txtCharge.Text.Trim())-double.Parse(txtTolCharge.Text.Trim())),2);
			double dCurChargeBaklar=System.Math.Round((double.Parse(txtCharge.Text.Trim())),2);
			if(chs.dCurCharge!=dCurChargeBaklar)
			{
				MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine("赠送结帐备份值与计算值不等：备份值－" + dCurChargeBaklar.ToString() + " 计算值" + chs.dCurCharge.ToString());
				return;
			}

			err=null;
			string strSerialok="";
			string strresult=cs.AssConsLargess(cis,chs,dCurChargeBaklar,out err,out strSerialok);
            strSerialok = cis.iSerial.ToString();
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(err!=null)
				{
					MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
				}
				if(strresult!="")
				{
					MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(strresult);
				}
			}
			else
			{
				System.Windows.Forms.DialogResult diaRes1=MessageBox.Show("赠送成功！是否打印？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					if(strSerialok=="")
					{
						MessageBox.Show("打印小票出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.Close();
					}
					else
					{
						this.AssGiftPrint(chs,cis,cs,strSerialok,dtConsItem,dTolCharge);
						//this.PrintBill(chs.strCardID,strSerialok,strCharge,strIG,this.GetColCh(cis.strDeptID,"MD"),cis.strDeptID);
					}
				}
				
				this.ClearText();
				txtGoodsID.ReadOnly=true;
				cmbGoodsName.Enabled=false;
				txtCount.ReadOnly=true;
				sbtnRead.Enabled=true;
				txtTolCount.Text="0";
				txtTolCharge.Text="0";
				dtConsItem=new DataTable();
				dtConsItem.Columns.Add("GoodsID");
				dtConsItem.Columns.Add("GoodsName");
				dtConsItem.Columns.Add("Price");
				dtConsItem.Columns.Add("Count");
				dtConsItem.Columns.Add("Rate");
				dtConsItem.Columns.Add("Fee");
				dtConsItem.Columns.Add("Comments");
				dtConsItem.Columns["Comments"].DefaultValue="";
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())-1).ToString();
						dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())-double.Parse(dtConsItem.Rows[i]["Price"].ToString())).ToString();
						if(dtConsItem.Rows[i]["Count"].ToString()=="0")
						{
							dtConsItem.Rows.Remove(dtConsItem.Rows[i]);
						}
					}
				}
				this.DgBind();
			}
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;
				double dTolFee=0;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
					dTolFee+=double.Parse(dtConsItem.Rows[i]["Fee"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolCharge.Text=dTolFee.ToString();
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("商品编号,商品名称,单价,数量,折扣金额,应收金额","100,170,100,100,60,100",dtConsItem,this.dataGrid1);
			}
		}

		private void PrintBill(string strCardID,string strSerial,string strCharge,string strIG,string strDeptName,string strDeptID)
		{
            //Hashtable hspara=new Hashtable();
            //hspara.Add("strSerial",strSerial);
            //hspara.Add("strCharge",strCharge);
            //hspara.Add("strIG",strIG);
            //hspara.Add("strDeptName",strDeptName);
            //hspara.Add("strDeptID",strDeptID);
            //hspara.Add("strCon",SysInitial.ConString);
            //hspara.Add("strOperName",SysInitial.CurOps.strOperName);
            //hspara.Add("strCardID",strCardID);
            //DevExpress.XtraPrinting.PrintingSystem ps=new DevExpress.XtraPrinting.PrintingSystem();
            //DevExpress.XtraReports.UI.XtraReport report1=new CMSM.Report.xrConsTiny(hspara);
            //report1.PrintingSystem=ps;
            //report1.CreateDocument();

            ////report1.PaperKind=System.Drawing.Printing.PaperKind.Custom;

            ////ps.PageSettings.PaperKind= System.Drawing.Printing.PaperKind.Custom;
            //ps.PageSettings.TopMargin=0;
            //ps.PageSettings.LeftMargin=-5;
            //ps.PageSettings.RightMargin=0;
            //ps.PageSettings.BottomMargin=0;
            ////			report1.ShowPreview();
            //report1.Print();
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbGoodsName.Text.Trim()!="")
			{
				string strSpell=cmbGoodsName.Text.Trim();
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByName(cmbGoodsName.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
//					txtPrice.Text=gs.dPrice.ToString();
					if (SysInitial.TP=="1")
					{
						txtPrice.Text=gs.dPrice.ToString();
					}
					else
					{
						txtPrice.Text="0";
					}
					txtPrice.ReadOnly=true;
					txtCount.Text="1";
					cmbGoodsName.Focus();
				}
				else
				{
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void frmAssCons_KeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
				case Keys.F5:   
					sbtnRead.PerformClick(); 
					break;
				case Keys.F6:   
					sbtnOk.PerformClick();   
					break;
                //case Keys.F7:
                //    sbtnAdd.PerformClick();
                //    break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			double dCount=0;
			if(txtCount.Text.Trim()=="")
			{
				MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dCount=int.Parse(txtCount.Text.Trim());
			}

			double dPrice=0;
			if(txtPrice.Text.Trim()=="")
			{
				MessageBox.Show("单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dPrice=Double.Parse(txtPrice.Text.Trim());
			}

			if(txtGoodsID.Text.Trim()=="")
			{
				MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="";
				txtCount.Text="";
			}
//			if((double.Parse(txtTolCharge.Text.Trim())+dPrice)>double.Parse(txtCharge.Text.Trim()))
//			{
//				MessageBox.Show("所剩余额不能再购买此商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return;
//			}
			CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			err=null;
			gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
			if(gs!=null)
			{
				txtGoodsID.Text=gs.strGoodsID;
				cmbGoodsName.Text=gs.strGoodsName;
				bool sumflag=false;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(gs.strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
						dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+(dPrice*dCount)).ToString();
						sumflag=true;
						break;
					}
				}
				if(!sumflag)
				{
					DataRow dr=dtConsItem.NewRow();
					dr[0]=gs.strGoodsID;
					dr[1]=gs.strGoodsName;
					dr[2]=dPrice.ToString();
					dr[3]=dCount.ToString();
					dr[4]="0";
					dr[5]=(dPrice*dCount).ToString();
					dtConsItem.Rows.Add(dr);
				}
				this.DgBind();
				cmbGoodsName.Focus();
			}
			else
			{
				MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}
		}
	}
}
