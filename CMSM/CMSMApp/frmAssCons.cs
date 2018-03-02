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
	public class frmAssCons : CMSM.CMSMApp.frmBase
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
        private System.Windows.Forms.Label lblNotice;
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
		private System.Windows.Forms.Label lblerr;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtZeroFlag;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtRate;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtTolRate;
		private System.Windows.Forms.TextBox txtAssTypeCode;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtTolShCharge;
		bool IsHungFlag=false;
		private System.Windows.Forms.TextBox txtDiscount;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtTolDiscount;
		private System.Windows.Forms.Label label24;
        private Button sbtnCancel;
        private Button sbtnOk;
        private Button sbtnHung;
        private Button sbtnAdd;
        private Button sbtnRollback;
        private Button sbtnRead;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

		public frmAssCons()
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
            this.label21 = new System.Windows.Forms.Label();
            this.txtTolShCharge = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTolRate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTolDiscount = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTolCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblerr = new System.Windows.Forms.Label();
            this.txtAssTypeCode = new System.Windows.Forms.TextBox();
            this.txtZeroFlag = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.sbtnRead = new System.Windows.Forms.Button();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.sbtnHung = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
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
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 0;
            // 
            // txtTolShCharge
            // 
            this.txtTolShCharge.Location = new System.Drawing.Point(0, 0);
            this.txtTolShCharge.Name = "txtTolShCharge";
            this.txtTolShCharge.Size = new System.Drawing.Size(100, 21);
            this.txtTolShCharge.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 23);
            this.label22.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 0;
            // 
            // txtTolRate
            // 
            this.txtTolRate.Location = new System.Drawing.Point(0, 0);
            this.txtTolRate.Name = "txtTolRate";
            this.txtTolRate.Size = new System.Drawing.Size(100, 21);
            this.txtTolRate.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 0;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(232, 104);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(800, 422);
            this.dataGrid1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTolDiscount);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTolCharge);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTolCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(232, 526);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 64);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消费合计：";
            // 
            // txtTolDiscount
            // 
            this.txtTolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolDiscount.Location = new System.Drawing.Point(304, 24);
            this.txtTolDiscount.MaxLength = 10;
            this.txtTolDiscount.Name = "txtTolDiscount";
            this.txtTolDiscount.Size = new System.Drawing.Size(96, 21);
            this.txtTolDiscount.TabIndex = 11;
            this.txtTolDiscount.TabStop = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(240, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 16);
            this.label24.TabIndex = 10;
            this.label24.Text = "总折扣：";
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
            this.txtTolCharge.Location = new System.Drawing.Point(512, 24);
            this.txtTolCharge.MaxLength = 10;
            this.txtTolCharge.Name = "txtTolCharge";
            this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
            this.txtTolCharge.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(456, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "总实收：";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(80, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "总数量：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lblerr);
            this.groupBox2.Controls.Add(this.txtAssTypeCode);
            this.groupBox2.Controls.Add(this.txtZeroFlag);
            this.groupBox2.Controls.Add(this.label17);
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
            this.groupBox2.Location = new System.Drawing.Point(232, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员信息";
            // 
            // lblerr
            // 
            this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblerr.Location = new System.Drawing.Point(57, 21);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(624, 64);
            this.lblerr.TabIndex = 23;
            this.lblerr.Visible = false;
            // 
            // txtAssTypeCode
            // 
            this.txtAssTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssTypeCode.Location = new System.Drawing.Point(344, 48);
            this.txtAssTypeCode.MaxLength = 10;
            this.txtAssTypeCode.Name = "txtAssTypeCode";
            this.txtAssTypeCode.ReadOnly = true;
            this.txtAssTypeCode.Size = new System.Drawing.Size(80, 21);
            this.txtAssTypeCode.TabIndex = 26;
            this.txtAssTypeCode.Visible = false;
            // 
            // txtZeroFlag
            // 
            this.txtZeroFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZeroFlag.Location = new System.Drawing.Point(560, 48);
            this.txtZeroFlag.MaxLength = 10;
            this.txtZeroFlag.Name = "txtZeroFlag";
            this.txtZeroFlag.ReadOnly = true;
            this.txtZeroFlag.Size = new System.Drawing.Size(80, 21);
            this.txtZeroFlag.TabIndex = 25;
            this.txtZeroFlag.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(248, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 24;
            this.label17.Text = "当前积分";
            // 
            // txtIg
            // 
            this.txtIg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIg.Location = new System.Drawing.Point(312, 64);
            this.txtIg.MaxLength = 10;
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(104, 21);
            this.txtIg.TabIndex = 22;
            // 
            // txtAssID
            // 
            this.txtAssID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssID.Location = new System.Drawing.Point(440, 48);
            this.txtAssID.MaxLength = 10;
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(80, 21);
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
            this.txtAssName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAssName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssName.Location = new System.Drawing.Point(312, 24);
            this.txtAssName.MaxLength = 30;
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.ReadOnly = true;
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
            this.txtCardID.MaxLength = 8;
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
            this.groupBox1.Controls.Add(this.sbtnRead);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.sbtnHung);
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnOk);
            this.groupBox1.Controls.Add(this.txtDiscount);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label18);
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
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消费栏目";
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(133, 43);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 106;
            this.sbtnRead.Text = "刷卡(F5)";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(136, 234);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 105;
            this.sbtnAdd.Text = "确定";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(34, 234);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 104;
            this.sbtnRollback.Text = "<<撤消";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // sbtnHung
            // 
            this.sbtnHung.Location = new System.Drawing.Point(136, 339);
            this.sbtnHung.Name = "sbtnHung";
            this.sbtnHung.Size = new System.Drawing.Size(64, 23);
            this.sbtnHung.TabIndex = 103;
            this.sbtnHung.Text = "挂单";
            this.sbtnHung.UseVisualStyleBackColor = true;
            this.sbtnHung.Click += new System.EventHandler(this.sbtnHung_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(136, 395);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(72, 23);
            this.sbtnCancel.TabIndex = 102;
            this.sbtnCancel.Text = "关闭";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(40, 395);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(64, 23);
            this.sbtnOk.TabIndex = 101;
            this.sbtnOk.Text = "结帐(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(80, 136);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(112, 21);
            this.txtDiscount.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(32, 136);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 16);
            this.label23.TabIndex = 53;
            this.label23.Text = "折扣";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(64, 16);
            this.txtRate.MaxLength = 10;
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(72, 21);
            this.txtRate.TabIndex = 50;
            this.txtRate.TabStop = false;
            this.txtRate.Visible = false;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "折扣";
            this.label18.Visible = false;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(80, 312);
            this.txtBalance.MaxLength = 10;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(136, 21);
            this.txtBalance.TabIndex = 23;
            this.txtBalance.TabStop = false;
            this.txtBalance.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(32, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "找零";
            this.label16.Visible = false;
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(80, 272);
            this.txtPay.MaxLength = 10;
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(136, 21);
            this.txtPay.TabIndex = 5;
            this.txtPay.Visible = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 280);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "付费金额";
            this.label15.Visible = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(192, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "元";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(80, 200);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 21);
            this.txtCount.TabIndex = 3;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "数量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 168);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 21);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "单价";
            // 
            // lblNotice
            // 
            this.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Location = new System.Drawing.Point(24, 472);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(192, 112);
            this.lblNotice.TabIndex = 13;
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(80, 104);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
            this.cmbGoodsName.TabIndex = 1;
            this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(80, 72);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 21);
            this.txtGoodsID.TabIndex = 100;
            this.txtGoodsID.TabStop = false;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "商品编号";
            // 
            // frmAssCons
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1032, 590);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmAssCons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员消费";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAssCons_Load);
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

		private void frmAssCons_Load(object sender, System.EventArgs e)
		{
			cmbGoodsName.Text="请输入...";
			txtCardID.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtIg.ReadOnly=true;
			txtAssType.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtCount.ReadOnly=true;
			lblerr.Visible=false;

			txtGoodsID.ReadOnly=true;
			cmbGoodsName.Enabled=false;
			txtPrice.ReadOnly=true;
			txtCount.Text="1";
			txtPay.Text="0";
			txtDiscount.ReadOnly = !SysInitial.CurOps.IsDiscount;
			txtTolDiscount.ReadOnly = true;
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
			dtConsItem.Columns.Add("Rate_tmp");
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
			lblerr.Visible=false;
            chs = cs.ReadCardInfo("", out strresult);

            if (!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
            {
                if (strresult == CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
                {
                    MessageBox.Show("该卡不属于本系统使用的卡，请检查！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
                if (strresult != "")
                {
                    strresult = this.GetColCh(strresult, "ERR");
                }
                MessageBox.Show("刷卡失败，请重试！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (strresult != null)
                {
                    clog.WriteLine(strresult);
                }
                return;
            }
            //chs.strCardID = "00066";
            //chs.dCurCharge = 100;

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
				chs.strInsertDate=SysInitial.dtQLTime.ToString("yyyy-MM-dd");
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					string strAssState=assres.strAssState;
					if(strAssState!="0")
					{
						MessageBox.Show("该会员已经失效，卡号：" + chs.strCardID + "，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					if(assres.dCharge<0)
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
					double dChargeRem=Math.Round(double.Parse(txtCharge.Text.Trim()),2);
					if(int.Parse(SysInitial.Card)==8)
					{
						if(dChargeRem<=2&&assres.strAssType=="AT001")
						{
							double dRate=0;
							if(!cs.AssTypeTrans(assres.strCardID,"AT002",out dRate,out err))
							{
								clog.WriteLine("变更卡类型失败："+assres.strCardID+"。\n"+err.ToString());
							}
							else
							{
								assres.strAssType="AT002";
								assres.dRate=dRate;
							}
						}
					}
					
					if(assres.dtCreateDate.CompareTo(SysInitial.dtQLTime)<0&&!assres.setZeroFlag)
					{
						chs.iCurIg=0;
						this.txtZeroFlag.Text="1";
					}
					else
					{
						this.txtZeroFlag.Text="0";
					}
					if(chs.iCurIg<0)
					{
						txtIg.Text=assres.iIgValue.ToString();
					}
					else
					{
						txtIg.Text=chs.iCurIg.ToString();
					}
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;			
					txtAssType.Text=GetColCh(assres.strAssType,"AT");
					txtAssTypeCode.Text=assres.strAssType;
					txtAssID.Text=assres.strAssID;
					txtRate.Text=assres.dRate.ToString();
					cmbGoodsName.Enabled=true;
					txtCount.ReadOnly=false;
					sbtnRead.Enabled=false;
					cmbGoodsName.Focus();				
				}
				else
				{
					MessageBox.Show("无会员资料，卡号：" + chs.strCardID + " 请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
					double dRate=Math.Round(double.Parse(txtRate.Text.Trim()),2);
					if(dRate==0)
						dRate=1;
					else
						dRate=Math.Round(dRate*0.1,2);
					double dCount=1;
					double dPrice=double.Parse (this.txtPrice.Text);
					bool sumflag=false;
					if (gs.strComments=="是")
					{
						for(int i=0;i<dtConsItem.Rows.Count;i++)
						{

							if(gs.strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
							{
								dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
								dtConsItem.Rows[i]["Fee"]=(Math.Round(int.Parse(dtConsItem.Rows[i]["Count"].ToString())*dPrice*dRate,2)).ToString();
								dtConsItem.Rows[i]["Rate"]=(Math.Round(Math.Round(int.Parse(dtConsItem.Rows[i]["Count"].ToString())*dPrice,2)-Math.Round(double.Parse(dtConsItem.Rows[i]["Fee"].ToString()),2),2)).ToString();
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
							dr[4]=(Math.Round(Math.Round(dPrice*dCount,2)-Math.Round(dPrice*dCount*dRate,2),2)).ToString();
							dr[5]=(Math.Round(dPrice*dCount*dRate,2)).ToString();
						}
						this.DgBind();
						cmbGoodsName.Focus();
					}
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
					txtPrice.Text=gs.dPrice.ToString();
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

        private void AddGoodsToDataGrid()
        {
            double dCount = 0;
            if (txtCount.Text.Trim() == "")
            {
                MessageBox.Show("数量不能为空！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            else
            {
                dCount = int.Parse(txtCount.Text.Trim());
            }

            double dPrice = 0;
            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("单价不能为空！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            else
            {
                dPrice = Double.Parse(txtPrice.Text.Trim());
            }

            double dDiscount = 100;
            if (txtDiscount.Text.Trim().Length > 0)
            {
                dDiscount = Double.Parse(txtDiscount.Text);
            }
            if (txtGoodsID.Text.Trim() == "")
            {
                MessageBox.Show("商品信息有误，请重新选择商品！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                txtGoodsID.Text = "";
                cmbGoodsName.Items.Clear();
                cmbGoodsName.Refresh();
                txtPrice.Text = "";
                txtCount.Text = "";
            }
            CMSMData.CMSMStruct.GoodsStruct gs = new CMSMData.CMSMStruct.GoodsStruct();
            err = null;
            gs = cs.GetGoodsByID(txtGoodsID.Text.Trim(), out err);
            if (gs != null)
            {
                txtGoodsID.Text = gs.strGoodsID;
                cmbGoodsName.Text = gs.strGoodsName;
                bool sumflag = false;
                for (int i = 0; i < dtConsItem.Rows.Count; i++)
                {
                    if (gs.strGoodsID == dtConsItem.Rows[i]["GoodsID"].ToString())
                    {
                        dtConsItem.Rows[i]["Count"] = (double.Parse(dtConsItem.Rows[i]["Count"].ToString()) + dCount).ToString();
                        if (dDiscount < 100)
                        {
                            double dSum = dPrice * dCount;
                            double dFee = Math.Round(dPrice * dCount * dDiscount / 100, 1);
                            dtConsItem.Rows[i]["Fee"] = (double.Parse(dtConsItem.Rows[i]["Fee"].ToString()) + dFee).ToString();
                            dtConsItem.Rows[i]["Rate"] = (double.Parse(dtConsItem.Rows[i]["Rate"].ToString()) + (dSum - dFee)).ToString();
                        }
                        else
                        {
                            dtConsItem.Rows[i]["Fee"] = (double.Parse(dtConsItem.Rows[i]["Fee"].ToString()) + (dPrice * dCount)).ToString();
                        }
                        sumflag = true;
                        break;
                    }
                }

                if (!sumflag)
                {
                    DataRow dr = dtConsItem.NewRow();
                    dr[0] = gs.strGoodsID;
                    dr[1] = gs.strGoodsName;
                    dr[2] = dPrice.ToString();
                    dr[3] = dCount.ToString();
                    if (dDiscount < 100)
                    {
                        double dSum = dPrice * dCount;
                        double dFee = Math.Round(dPrice * dCount * dDiscount / 100, 1);
                        dr[4] = (dSum - dFee).ToString();
                        dr[5] = dFee.ToString();
                    }
                    else
                    {
                        dr[4] = "0";
                        dr[5] = (dPrice * dCount).ToString();
                    }
                    dtConsItem.Rows.Add(dr);
                }
                this.DgBind();
                cmbGoodsName.Focus();
            }
            else
            {
                if (err != null)
                {
                    clog.WriteLine(err);
                }
                MessageBox.Show("无此商品信息！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
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
				AddGoodsToDataGrid();
			}
		}

		public void sbtnOk_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，结账失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }
			string strresult="";
			lblerr.Visible=false;
            chs = cs.ReadCardInfo("", out strresult);
            if (!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
            {
                if (strresult == CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
                {
                    MessageBox.Show("该卡不属于本系统使用的卡，请检查！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
                if (strresult != "")
                {
                    strresult = this.GetColCh(strresult, "ERR");
                }
                MessageBox.Show("刷卡失败，请重试！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (strresult != null)
                {
                    clog.WriteLine(strresult);
                }
                return;
            }
            //chs.strCardID = "00066";
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
			string aa=chs.strCardID;
			if(chs.strCardID!=txtCardID.Text.Trim())
			{
				MessageBox.Show("结帐卡与首次刷卡不是同一张卡，结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
				return;
			}
			else
			{
				#region 开始结帐
				if(dtConsItem.Rows.Count<=0)
				{
					MessageBox.Show("没有进行任何消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					return;
				}
				double dTolCharge=double.Parse(txtTolCharge.Text.Trim());
				if(double.Parse(txtCharge.Text.Trim())<dTolCharge)
				{
					MessageBox.Show("当前余额不足，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
				cis.strAssID=txtAssID.Text.Trim();
				cis.strCardID=txtCardID.Text.Trim();
				cis.dChargeLast=double.Parse(txtCharge.Text.Trim());
				cis.dTolCharge=double.Parse(txtTolShCharge.Text.Trim());;
				string strCharge=(cis.dChargeLast-dTolCharge).ToString() + "元";
                DateTime dtNow = DateTime.Now;
                cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                cis.iSerial = Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
                //cis.iSerial = Int64.Parse(cis.strOperDate.Substring(0, 4) + cis.strOperDate.Substring(5, 2) + cis.strOperDate.Substring(8, 2) + cis.strOperDate.Substring(11, 2) + cis.strOperDate.Substring(14, 2) + cis.strOperDate.Substring(17, 2));
				cis.strOperName=SysInitial.CurOps.strOperName;
				cis.dTRate=double.Parse(txtTolRate.Text.Trim());
				cis.dPay=dTolCharge;
				cis.dBalance=0;
				cis.strConsType="PT001";
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
				chs.dCurCharge=System.Math.Round((cis.dChargeLast-dTolCharge),2);
				double dCurChargeBak=System.Math.Round((double.Parse(txtCharge.Text.Trim())-double.Parse(txtTolCharge.Text.Trim())),2);
				chs.iCurIg=cis.iIgLast+cis.iIgValue;
				string strIG=chs.iCurIg.ToString()+"分";

				if(chs.dCurCharge!=dCurChargeBak)
				{
					MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("结帐备份值与计算值不等：备份值－" + dCurChargeBak.ToString() + " 计算值" + chs.dCurCharge.ToString());
					return;
				}

				if(this.txtZeroFlag.Text.Trim()=="1")
					chs.needZeroFlag=true;
				else
					chs.needZeroFlag=false;
				err=null;
				string strSerialok="";
				strresult="";
				strresult=cs.AssCons(cis,chs,dCurChargeBak,out err,out strSerialok);
                strSerialok = cis.iSerial.ToString();
				if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
				{
					if(int.Parse(SysInitial.Card)==8)
					{
						if(chs.dCurCharge<=2&&txtAssTypeCode.Text.Trim()=="AT001")
						{
							double dRate=0;
							err=null;
							if(!cs.AssTypeTrans(chs.strCardID,"AT002",out dRate,out err))
							{
								clog.WriteLine("变更卡类型失败："+chs.strCardID+"。\n"+err.ToString());
							}
						}
					}
					clog.WriteLine(strresult);
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
							//this.PrintBill(chs.strCardID,strSerialok,strCharge,strIG,this.GetColCh(cis.strDeptID,"MD"),this.txtRate.Text.Trim(),cis.strDeptID);
							this.AssConsPrint(chs,cis,cs,strSerialok,dtConsItem,dTolCharge);
						}
					}
					
				}
				else
				{
					MessageBox.Show("结帐失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					lblerr.Text="结帐失败，本次消费无效，请检查余额是否正确！";
					lblerr.Visible=true;
					clog.WriteLine(err+ "\n" + strresult);
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
				#endregion
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			err=null;
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				double dDiscount = 100;
				if(txtDiscount.Text.Trim().Length>0)
				{
					dDiscount = Double.Parse(txtDiscount.Text);
				}

				gs=cs.GetGoodsByID(strGoodsID,out err);
				if (gs.strComments=="是")
				{
					double dRate=Math.Round(double.Parse(txtRate.Text.Trim()),2);
					if(dRate==0)
						dRate=1;
					else
						dRate=Math.Round(dRate*0.1,2);
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

				else
				{
					double dRate=Math.Round(double.Parse(txtRate.Text.Trim()),2);
					if(dRate==0)
						dRate=1;
					else
						dRate=Math.Round(dRate*0.1,2);
					for(int i=0;i<dtConsItem.Rows.Count;i++)
					{
						if(strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
						{
							double dPrice = double.Parse(dtConsItem.Rows[i]["Price"].ToString());
							dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())-1).ToString();
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
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;
				double dTolFee=0;
				double dTolRate=0;
				double dTolPay=0;
				double dTolDiscount = 0;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
					dTolFee+=Math.Round(double.Parse(dtConsItem.Rows[i]["Price"].ToString())*double.Parse(dtConsItem.Rows[i]["Count"].ToString()),2);
					dTolPay+=double.Parse(dtConsItem.Rows[i]["Fee"].ToString());
					dTolRate+=double.Parse(dtConsItem.Rows[i]["Rate"].ToString());
					dTolDiscount+=double.Parse(dtConsItem.Rows[i]["Rate"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolShCharge.Text=dTolFee.ToString();
				txtTolRate.Text=dTolRate.ToString();
				txtTolCharge.Text=dTolPay.ToString();

				txtTolDiscount.Text = dTolDiscount.ToString();
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("商品编号,商品名称,单价,数量,折扣金额,实收金额","100,170,100,100,60,100",dtConsItem,this.dataGrid1);
			}
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
//				case Keys.Add:   
//					this.OpenDrawer();
//					break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			AddGoodsToDataGrid();
		}

		private void sbtnHung_Click(object sender, System.EventArgs e)
		{
			err=null;
			if(sbtnHung.Text=="挂单")
			{
				if(dtConsItem.Rows.Count==0)
				{
					MessageBox.Show("无任何消费信息，无需挂单！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(cs.ConsItemInHung_Card(dtConsItem,out err))
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
					this.sbtnHung.Text="取挂";
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
				dtConsItem=cs.GetConsItemHung_Card(out err);
				if(err!=null||dtConsItem==null)
				{
					clog.WriteLine(err);
					MessageBox.Show("取挂失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					this.sbtnHung.Text="挂单";
					IsHungFlag=true;
					this.DgBind();
					this.cmbGoodsName.Focus();
				}
			}
		}
	}
}
