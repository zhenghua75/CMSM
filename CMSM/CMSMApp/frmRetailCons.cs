using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;
using System.Threading;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmRetailCons.
	/// </summary>
	public class frmRetailCons : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtTolCharge;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAssType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtBalance;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtPay;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblNotice;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataTable dtConsItem;
        CommAccess cs = new CommAccess(SysInitial.ConString);
        private System.Windows.Forms.Label label17;
		Exception err;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtDiscount;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtTolDiscount;
		private System.Windows.Forms.Label label21;

		bool IsHungFlag=false;
        private Button sbtnRollback;
        private Button sbtnHung;
        private Button sbtnAdd;
        private Button sbtnOk;
        private Button sbtnCancel;
		private string strConsType;
		public frmRetailCons(string strConsType)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.strConsType = strConsType;
			switch(strConsType)
			{
				case "PT002":
					break;
				case "PT008":
					this.Text = "银行卡零售";
					this.groupBox1.Text = "银行卡零售-消费栏目";
					break;
			}
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
            this.label20 = new System.Windows.Forms.Label();
            this.txtTolDiscount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTolCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.sbtnHung = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
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
            this.dataGrid1.Size = new System.Drawing.Size(672, 421);
            this.dataGrid1.TabIndex = 6;
            this.dataGrid1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtTolDiscount);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTolCharge);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTolCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(232, 525);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 65);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消费合计：";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(408, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 16);
            this.label20.TabIndex = 10;
            this.label20.Text = "元";
            // 
            // txtTolDiscount
            // 
            this.txtTolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolDiscount.Location = new System.Drawing.Point(312, 24);
            this.txtTolDiscount.MaxLength = 10;
            this.txtTolDiscount.Name = "txtTolDiscount";
            this.txtTolDiscount.Size = new System.Drawing.Size(96, 21);
            this.txtTolDiscount.TabIndex = 9;
            this.txtTolDiscount.TabStop = false;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(248, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 16);
            this.label21.TabIndex = 8;
            this.label21.Text = "总折扣：";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(616, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "元";
            // 
            // txtTolCharge
            // 
            this.txtTolCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCharge.Location = new System.Drawing.Point(520, 24);
            this.txtTolCharge.MaxLength = 10;
            this.txtTolCharge.Name = "txtTolCharge";
            this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
            this.txtTolCharge.TabIndex = 6;
            this.txtTolCharge.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(456, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "总金额：";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(120, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            this.txtTolCount.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(56, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "总数量：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
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
            this.groupBox2.Location = new System.Drawing.Point(232, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员信息";
            // 
            // txtAssID
            // 
            this.txtAssID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssID.Location = new System.Drawing.Point(312, 56);
            this.txtAssID.MaxLength = 10;
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(104, 21);
            this.txtAssID.TabIndex = 21;
            this.txtAssID.TabStop = false;
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
            this.txtCharge.TabStop = false;
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
            this.txtLinkPhone.TabStop = false;
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
            this.txtAssType.TabStop = false;
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
            this.txtAssName.TabStop = false;
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
            this.txtCardID.TabStop = false;
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
            this.groupBox1.Controls.Add(this.sbtnHung);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtDiscount);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPay);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 590);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消费栏目";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(117, 352);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 34;
            this.sbtnCancel.Text = "关闭";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(34, 352);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 33;
            this.sbtnOk.Text = "结帐(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(117, 192);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 32;
            this.sbtnAdd.Text = "确定";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnHung
            // 
            this.sbtnHung.Location = new System.Drawing.Point(117, 299);
            this.sbtnHung.Name = "sbtnHung";
            this.sbtnHung.Size = new System.Drawing.Size(75, 23);
            this.sbtnHung.TabIndex = 31;
            this.sbtnHung.Text = "挂单";
            this.sbtnHung.UseVisualStyleBackColor = true;
            this.sbtnHung.Click += new System.EventHandler(this.sbtnHung_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(34, 192);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 30;
            this.sbtnRollback.Text = "<<撤消";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(200, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 16);
            this.label19.TabIndex = 29;
            this.label19.Text = "%";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(80, 96);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(112, 21);
            this.txtDiscount.TabIndex = 2;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(32, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 16);
            this.label18.TabIndex = 27;
            this.label18.Text = "折扣";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(192, 240);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "元";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(80, 272);
            this.txtBalance.MaxLength = 10;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(112, 21);
            this.txtBalance.TabIndex = 16;
            this.txtBalance.TabStop = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(32, 280);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "找零";
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(80, 232);
            this.txtPay.MaxLength = 10;
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(112, 21);
            this.txtPay.TabIndex = 5;
            this.txtPay.TextChanged += new System.EventHandler(this.txtPay_TextChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "付费金额";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(192, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "元";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(80, 160);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 21);
            this.txtCount.TabIndex = 3;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "数量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 128);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 21);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "单价";
            // 
            // lblNotice
            // 
            this.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Location = new System.Drawing.Point(24, 392);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(192, 192);
            this.lblNotice.TabIndex = 13;
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(80, 64);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
            this.cmbGoodsName.TabIndex = 1;
            this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(80, 32);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 21);
            this.txtGoodsID.TabIndex = 15;
            this.txtGoodsID.TabStop = false;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "商品编号";
            // 
            // frmRetailCons
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(904, 590);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmRetailCons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "零售";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRetailCons_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRetailCons_KeyDown);
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

		private void frmRetailCons_Load(object sender, System.EventArgs e)
		{
			DateTime dtnowTmp=DateTime.Now;
			if(dtnowTmp.CompareTo(new DateTime(2009,2,1))>0)
			{
				txtPrice.ReadOnly=true;
			}
			else
			{
				txtPrice.ReadOnly=false;
			}
			cmbGoodsName.Text="请输入...";
			txtCardID.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtAssType.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtBalance.ReadOnly=true;
			txtGoodsID.ReadOnly=true;
			txtPay.ReadOnly=false;
			txtDiscount.ReadOnly = !SysInitial.CurOps.IsDiscount;
			txtTolDiscount.ReadOnly = true;
			txtCount.Text="1";
//			txtPay.Text="0";
			txtBalance.Text="0";

			groupBox2.BackColor=Color.AliceBlue;
			groupBox3.BackColor=Color.Snow;

			err=null;
			CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
			assres=cs.GetAssociatorName_Local("V9999",out err);
			if(assres!=null)
			{
				txtCardID.Text=assres.strCardID;
				txtAssName.Text=assres.strAssName;
				txtLinkPhone.Text=assres.strLinkPhone;
				txtCharge.Text=assres.dCharge.ToString();
				txtAssType.Text="零售客户";
				txtAssID.Text=assres.strAssID;
			}
			else
			{
				MessageBox.Show("无零售客户，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

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

			err=null;
			DataTable dttmp=cs.GetConsItemHung(out err);
			if(err!=null||dttmp==null)
			{
                this.sbtnHung.Enabled = false;
			}
			else
			{
				if(dttmp.Rows.Count>0)
				{
                    this.sbtnHung.Text = "取挂";
                    this.sbtnHung.Enabled = true;
				}
				else
				{
                    this.sbtnHung.Text = "挂单";
                    this.sbtnHung.Enabled = true;
				}
			}
		}

		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				double dDiscount = 100;
				if(txtDiscount.Text.Trim().Length>0)
				{
					dDiscount = Double.Parse(txtDiscount.Text);
				}
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())-1).ToString();
						double dPrice = double.Parse(dtConsItem.Rows[i]["Price"].ToString());
						if(dDiscount<100)
						{					
							double dSum = dPrice;
							double dFee = Math.Round(dPrice*dDiscount/100,1);
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())-dFee).ToString();
							dtConsItem.Rows[i]["Rate"]=(double.Parse(dtConsItem.Rows[i]["Rate"].ToString())-(dSum-dFee)).ToString();
							
						}
						else
						{							
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())-dPrice).ToString();
						}
						if(dtConsItem.Rows[i]["Count"].ToString()=="0")
						{
							dtConsItem.Rows.Remove(dtConsItem.Rows[i]);
						}
					}
				}
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
					txtCount.Text="1";
					txtDiscount.Text="";
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
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
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					txtCount.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					txtGoodsID.Focus();
					return;
				}
			}
		}

		private void AddGoodsToDataGrid()
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

			double dDiscount = 100;
			if(txtDiscount.Text.Trim().Length>0)
			{
				dDiscount = Double.Parse(txtDiscount.Text);
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
						if(dDiscount<100)
						{
							double dSum = dPrice*dCount;
							double dFee = Math.Round(dPrice*dCount*dDiscount/100,1);
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+dFee).ToString();
							dtConsItem.Rows[i]["Rate"]=(double.Parse(dtConsItem.Rows[i]["Rate"].ToString())+(dSum-dFee)).ToString();							
						}
						else
						{
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+(dPrice*dCount)).ToString();								
						}
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
					if(dDiscount<100)
					{
						double dSum = dPrice*dCount;
						double dFee = Math.Round(dPrice*dCount*dDiscount/100,1);
						dr[4]= (dSum-dFee).ToString();
						dr[5]=dFee.ToString();
					}
					else
					{
						dr[4]="0";
						dr[5]=(dPrice*dCount).ToString();
					}
					dtConsItem.Rows.Add(dr);
				}
				
				this.DgBind();
				cmbGoodsName.Focus();
			}
			else
			{
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}

		private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)//回车键
			{
				if(e.KeyChar==8)//退格
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)//数字
				{
					e.Handled=true;
					return;
				}
			}
			else
			{
				AddGoodsToDataGrid();
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			if(dtConsItem.Rows.Count<=0)
			{
				MessageBox.Show("没有进行任何消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				//sbtnOk.Enabled=true;
				return;
			}
			if (txtPay.Text=="")
			{
				MessageBox.Show("付费金额不能为空!请核查!","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				//sbtnOk.Enabled=true;
				return;
			}
			double dPay=double.Parse(txtPay.Text.Trim());
			double dTolCharge=double.Parse(txtTolCharge.Text.Trim());
			double dBalance=dPay-dTolCharge;
			double dDiscount = double.Parse(txtTolDiscount.Text.Trim());
			if(dPay<dTolCharge)
			{
				MessageBox.Show("付款金额不能小于总消费金额！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				//sbtnOk.Enabled=true;
				return;
			}

			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strAssID=txtAssID.Text.Trim();
			cis.strCardID=txtCardID.Text.Trim();
			cis.dChargeLast=0;
			cis.dTolCharge=dTolCharge;
            DateTime dtNow = DateTime.Now;
            cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            //20150825175511
            cis.iSerial = Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));//Int64.Parse(cis.strOperDate.Substring(0, 4) + cis.strOperDate.Substring(5, 2) + cis.strOperDate.Substring(8, 2) + cis.strOperDate.Substring(11, 2) + cis.strOperDate.Substring(14, 2) + cis.strOperDate.Substring(17, 2));
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.dTRate=dDiscount;
			cis.dPay=dPay;
			cis.dBalance=dBalance;
			cis.strConsType=this.strConsType;//"PT002";
			cis.dtItem=dtConsItem;
			cis.strDeptID=SysInitial.CurOps.strDeptID;
			err=null;
			string strSerialok=cs.RetailCons(cis,IsHungFlag,out err);
            strSerialok = cis.iSerial.ToString();
			if(err!=null)
			{
				MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(err + "|"+strSerialok);
			}
			else
			{
				IsHungFlag=false;
				System.Windows.Forms.DialogResult diaRes1=MessageBox.Show("结帐成功！是否打印？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					if(strSerialok=="")
					{
						MessageBox.Show("打印小票出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.Close();
					}
					else
					{
                        this.RetailConsPrint(cis,cs,strSerialok,dtConsItem,dTolCharge,dPay,dBalance,dDiscount);
						
					}
				}
				cmbGoodsName.Text="请输入...";
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="";
				txtCount.Text="";
				txtPay.Text="";
				txtBalance.Text="";
				txtTolCount.Text="0";
				txtTolCharge.Text="0";
				txtTolDiscount.Text="0";
				txtDiscount.Text="";
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
						
			//sbtnOk.Enabled=true;
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;
				double dTolFee=0;
				double dTolDiscount = 0;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
					dTolFee+=double.Parse(dtConsItem.Rows[i]["Fee"].ToString());
					dTolDiscount+=double.Parse(dtConsItem.Rows[i]["Rate"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolCharge.Text=dTolFee.ToString();
				txtPay.Text=dTolFee.ToString();
				txtTolDiscount.Text = dTolDiscount.ToString();

				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("商品编号,商品名称,单价,数量,折扣金额,应收金额","100,170,100,100,60,100",dtConsItem,this.dataGrid1);
			}
		}
			
//		}

		private void txtPay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
//			if(e.KeyChar==13)
//			{
//				double dpay=double.Parse(txtPay.Text.Trim());
//				double dTFee=double.Parse(txtTolCharge.Text.Trim());
//				if(dpay<dTFee)
//				{
//					MessageBox.Show("付款金额不能小于总消费金额！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
//				else
//				{
//					txtBalance.Text=(dpay-dTFee).ToString();
//					this.sbtnOk.Focus();
//				}
//			}
		}

		private void frmRetailCons_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{
                case Keys.F6:
                    sbtnOk.PerformClick();
                    break;
                //case Keys.F7:
                //    sbtnAdd.PerformClick();
                //    break;
//				case Keys.Add:   
//					this.OpenDrawer();
//					break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			AddGoodsToDataGrid();
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
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					txtDiscount.Text="";
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
					return;
				}
			}
		}

		private void sbtnHung_Click(object sender, System.EventArgs e)
		{
			err=null;
            if (sbtnHung.Text == "挂单")
			{
				if(dtConsItem.Rows.Count==0)
				{
					MessageBox.Show("无任何消费信息，无需挂单！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(cs.ConsItemInHung(dtConsItem,out err))
				{
					cmbGoodsName.Text="请输入...";
					txtGoodsID.Text="";
					cmbGoodsName.Items.Clear();
					cmbGoodsName.Refresh();
					txtPrice.Text="";
					txtCount.Text="";
					txtPay.Text="";
					txtBalance.Text="";
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
                    this.sbtnHung.Text = "取挂";
					IsHungFlag=false;
					this.DgBind();
					this.cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("挂单失败，不能挂单！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				dtConsItem=cs.GetConsItemHung(out err);
				if(err!=null||dtConsItem==null)
				{
					clog.WriteLine(err);
					MessageBox.Show("取挂失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
                    this.sbtnHung.Text = "挂单";
					IsHungFlag=true;
					this.DgBind();
					this.cmbGoodsName.Focus();
				}
			}
		}

		private void txtPay_TextChanged(object sender, EventArgs e)
		{
			if (this.txtPay.Text!="")
			{
				double dPay=0;
				double dTolCharge=0;
			
				dPay=double.Parse(this.txtPay.Text.Trim());
				dTolCharge=dPay-(double.Parse(this.txtTolCharge.Text.Trim()));
				this.txtBalance.Text=dTolCharge.ToString();
			}
			
		}

		private void txtDiscount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)//回车键
			{
				if(e.KeyChar==8)//退格
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)//数字
				{
					e.Handled=true;
					return;
				}
			}
		}
	}
}
