using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.IO;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmSysSet.
	/// </summary>
	public class frmSysSet : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox ltbGoods;
        private System.Windows.Forms.ListBox ltbAD;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbt1;
		private System.Windows.Forms.RadioButton rbt3;
		private System.Windows.Forms.RadioButton rbt2;
		private System.Windows.Forms.RadioButton rbt4;
		private System.Windows.Forms.RadioButton rbt5;
		private System.Windows.Forms.RadioButton rbt6;
		private System.Windows.Forms.RadioButton rbt7;
		private System.Windows.Forms.RadioButton rbt8;
		private System.Windows.Forms.RadioButton rbt9;
        private System.Windows.Forms.RadioButton rbt10;
		private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtIg;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtPromRate3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtPromRate2;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPromRate1;
        private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCardRoll;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtPromRate4;
		private System.Windows.Forms.TextBox txtPromRate5;
        private Button sbtnClose;
        private Button sbtnAdd;
        private Button sbtnRemove;
        private Button sbtnSave;
        private Button sbtnSet;
        private Button sbtnProm;
        private Button simpleButton1;
        private Button sbtnCom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSysSet()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnSave = new System.Windows.Forms.Button();
            this.sbtnRemove = new System.Windows.Forms.Button();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ltbAD = new System.Windows.Forms.ListBox();
            this.ltbGoods = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sbtnCom = new System.Windows.Forms.Button();
            this.rbt10 = new System.Windows.Forms.RadioButton();
            this.rbt9 = new System.Windows.Forms.RadioButton();
            this.rbt8 = new System.Windows.Forms.RadioButton();
            this.rbt7 = new System.Windows.Forms.RadioButton();
            this.rbt6 = new System.Windows.Forms.RadioButton();
            this.rbt5 = new System.Windows.Forms.RadioButton();
            this.rbt4 = new System.Windows.Forms.RadioButton();
            this.rbt2 = new System.Windows.Forms.RadioButton();
            this.rbt3 = new System.Windows.Forms.RadioButton();
            this.rbt1 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sbtnSet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sbtnProm = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPromRate5 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPromRate4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPromRate3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPromRate2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPromRate1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCardRoll = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnSave);
            this.groupBox1.Controls.Add(this.sbtnRemove);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ltbAD);
            this.groupBox1.Controls.Add(this.ltbGoods);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新商品推荐设置";
            // 
            // sbtnSave
            // 
            this.sbtnSave.Location = new System.Drawing.Point(165, 520);
            this.sbtnSave.Name = "sbtnSave";
            this.sbtnSave.Size = new System.Drawing.Size(75, 23);
            this.sbtnSave.TabIndex = 16;
            this.sbtnSave.Text = "保存";
            this.sbtnSave.UseVisualStyleBackColor = true;
            this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
            // 
            // sbtnRemove
            // 
            this.sbtnRemove.Location = new System.Drawing.Point(184, 226);
            this.sbtnRemove.Name = "sbtnRemove";
            this.sbtnRemove.Size = new System.Drawing.Size(56, 23);
            this.sbtnRemove.TabIndex = 15;
            this.sbtnRemove.Text = "<<移除";
            this.sbtnRemove.UseVisualStyleBackColor = true;
            this.sbtnRemove.Click += new System.EventHandler(this.sbtnRemove_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(184, 125);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(56, 23);
            this.sbtnAdd.TabIndex = 14;
            this.sbtnAdd.Text = "添加>>";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(292, 519);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 13;
            this.sbtnClose.Text = "退出";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(304, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "推荐新品";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "现有商品";
            // 
            // ltbAD
            // 
            this.ltbAD.ItemHeight = 12;
            this.ltbAD.Location = new System.Drawing.Point(248, 48);
            this.ltbAD.Name = "ltbAD";
            this.ltbAD.Size = new System.Drawing.Size(168, 436);
            this.ltbAD.TabIndex = 1;
            // 
            // ltbGoods
            // 
            this.ltbGoods.ItemHeight = 12;
            this.ltbGoods.Location = new System.Drawing.Point(16, 48);
            this.ltbGoods.Name = "ltbGoods";
            this.ltbGoods.Size = new System.Drawing.Size(165, 436);
            this.ltbGoods.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sbtnCom);
            this.groupBox3.Controls.Add(this.rbt10);
            this.groupBox3.Controls.Add(this.rbt9);
            this.groupBox3.Controls.Add(this.rbt8);
            this.groupBox3.Controls.Add(this.rbt7);
            this.groupBox3.Controls.Add(this.rbt6);
            this.groupBox3.Controls.Add(this.rbt5);
            this.groupBox3.Controls.Add(this.rbt4);
            this.groupBox3.Controls.Add(this.rbt2);
            this.groupBox3.Controls.Add(this.rbt3);
            this.groupBox3.Controls.Add(this.rbt1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(432, 452);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 123);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "通信串口设置：";
            // 
            // sbtnCom
            // 
            this.sbtnCom.Location = new System.Drawing.Point(200, 78);
            this.sbtnCom.Name = "sbtnCom";
            this.sbtnCom.Size = new System.Drawing.Size(75, 23);
            this.sbtnCom.TabIndex = 36;
            this.sbtnCom.Text = "设置";
            this.sbtnCom.UseVisualStyleBackColor = true;
            this.sbtnCom.Click += new System.EventHandler(this.sbtnCom_Click);
            // 
            // rbt10
            // 
            this.rbt10.Location = new System.Drawing.Point(88, 72);
            this.rbt10.Name = "rbt10";
            this.rbt10.Size = new System.Drawing.Size(64, 24);
            this.rbt10.TabIndex = 35;
            this.rbt10.Text = "COM10";
            // 
            // rbt9
            // 
            this.rbt9.Location = new System.Drawing.Point(24, 72);
            this.rbt9.Name = "rbt9";
            this.rbt9.Size = new System.Drawing.Size(56, 24);
            this.rbt9.TabIndex = 34;
            this.rbt9.Text = "COM9";
            // 
            // rbt8
            // 
            this.rbt8.Location = new System.Drawing.Point(216, 48);
            this.rbt8.Name = "rbt8";
            this.rbt8.Size = new System.Drawing.Size(56, 24);
            this.rbt8.TabIndex = 33;
            this.rbt8.Text = "COM8";
            // 
            // rbt7
            // 
            this.rbt7.Location = new System.Drawing.Point(152, 48);
            this.rbt7.Name = "rbt7";
            this.rbt7.Size = new System.Drawing.Size(56, 24);
            this.rbt7.TabIndex = 32;
            this.rbt7.Text = "COM7";
            // 
            // rbt6
            // 
            this.rbt6.Location = new System.Drawing.Point(88, 48);
            this.rbt6.Name = "rbt6";
            this.rbt6.Size = new System.Drawing.Size(56, 24);
            this.rbt6.TabIndex = 31;
            this.rbt6.Text = "COM6";
            // 
            // rbt5
            // 
            this.rbt5.Location = new System.Drawing.Point(24, 48);
            this.rbt5.Name = "rbt5";
            this.rbt5.Size = new System.Drawing.Size(56, 24);
            this.rbt5.TabIndex = 30;
            this.rbt5.Text = "COM5";
            // 
            // rbt4
            // 
            this.rbt4.Location = new System.Drawing.Point(216, 24);
            this.rbt4.Name = "rbt4";
            this.rbt4.Size = new System.Drawing.Size(56, 24);
            this.rbt4.TabIndex = 29;
            this.rbt4.Text = "COM4";
            // 
            // rbt2
            // 
            this.rbt2.Location = new System.Drawing.Point(88, 24);
            this.rbt2.Name = "rbt2";
            this.rbt2.Size = new System.Drawing.Size(56, 24);
            this.rbt2.TabIndex = 28;
            this.rbt2.Text = "COM2";
            // 
            // rbt3
            // 
            this.rbt3.Location = new System.Drawing.Point(152, 24);
            this.rbt3.Name = "rbt3";
            this.rbt3.Size = new System.Drawing.Size(56, 24);
            this.rbt3.TabIndex = 27;
            this.rbt3.Text = "COM3";
            // 
            // rbt1
            // 
            this.rbt1.Location = new System.Drawing.Point(24, 24);
            this.rbt1.Name = "rbt1";
            this.rbt1.Size = new System.Drawing.Size(56, 24);
            this.rbt1.TabIndex = 26;
            this.rbt1.Text = "COM1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.sbtnSet);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtIg);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.txtFee);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(3, 59);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(284, 88);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "消费积分设置";
            // 
            // sbtnSet
            // 
            this.sbtnSet.Location = new System.Drawing.Point(197, 59);
            this.sbtnSet.Name = "sbtnSet";
            this.sbtnSet.Size = new System.Drawing.Size(75, 23);
            this.sbtnSet.TabIndex = 29;
            this.sbtnSet.Text = "设置";
            this.sbtnSet.UseVisualStyleBackColor = true;
            this.sbtnSet.Click += new System.EventHandler(this.sbtnSet_Click);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(8, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 32);
            this.label6.TabIndex = 28;
            this.label6.Text = " 注意：该参数如果不配置，将视为消费无积分";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(208, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "积分";
            // 
            // txtIg
            // 
            this.txtIg.Location = new System.Drawing.Point(160, 12);
            this.txtIg.MaxLength = 10;
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(48, 21);
            this.txtIg.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "消费";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(56, 12);
            this.txtFee.MaxLength = 10;
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(48, 21);
            this.txtFee.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(104, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "元，赠送";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sbtnProm);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txtPromRate5);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txtPromRate4);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtPromRate3);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtPromRate2);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtPromRate1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(3, 147);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 248);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "充值赠款金额设置";
            // 
            // sbtnProm
            // 
            this.sbtnProm.Location = new System.Drawing.Point(197, 179);
            this.sbtnProm.Name = "sbtnProm";
            this.sbtnProm.Size = new System.Drawing.Size(75, 23);
            this.sbtnProm.TabIndex = 51;
            this.sbtnProm.Text = "设置";
            this.sbtnProm.UseVisualStyleBackColor = true;
            this.sbtnProm.Click += new System.EventHandler(this.sbtnProm_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(208, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 16);
            this.label16.TabIndex = 50;
            this.label16.Text = "%";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(8, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "充值赠款500以上";
            // 
            // txtPromRate5
            // 
            this.txtPromRate5.Location = new System.Drawing.Point(144, 136);
            this.txtPromRate5.MaxLength = 10;
            this.txtPromRate5.Name = "txtPromRate5";
            this.txtPromRate5.Size = new System.Drawing.Size(56, 21);
            this.txtPromRate5.TabIndex = 48;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(208, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 47;
            this.label18.Text = "%";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(8, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 16);
            this.label19.TabIndex = 46;
            this.label19.Text = "充值赠款400-500";
            // 
            // txtPromRate4
            // 
            this.txtPromRate4.Location = new System.Drawing.Point(144, 104);
            this.txtPromRate4.MaxLength = 10;
            this.txtPromRate4.Name = "txtPromRate4";
            this.txtPromRate4.Size = new System.Drawing.Size(56, 21);
            this.txtPromRate4.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(204, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 44;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(8, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 16);
            this.label15.TabIndex = 43;
            this.label15.Text = "充值赠款300-400";
            // 
            // txtPromRate3
            // 
            this.txtPromRate3.Location = new System.Drawing.Point(144, 72);
            this.txtPromRate3.MaxLength = 10;
            this.txtPromRate3.Name = "txtPromRate3";
            this.txtPromRate3.Size = new System.Drawing.Size(56, 21);
            this.txtPromRate3.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(204, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "%";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(8, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "充值赠款200-300";
            // 
            // txtPromRate2
            // 
            this.txtPromRate2.Location = new System.Drawing.Point(144, 40);
            this.txtPromRate2.MaxLength = 10;
            this.txtPromRate2.Name = "txtPromRate2";
            this.txtPromRate2.Size = new System.Drawing.Size(56, 21);
            this.txtPromRate2.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(19, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 32);
            this.label11.TabIndex = 38;
            this.label11.Text = " 注意：该参数如果不配置，将视为充值赠款为0";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(204, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 36;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "充值赠款100-200";
            // 
            // txtPromRate1
            // 
            this.txtPromRate1.Location = new System.Drawing.Point(144, 8);
            this.txtPromRate1.MaxLength = 10;
            this.txtPromRate1.Name = "txtPromRate1";
            this.txtPromRate1.Size = new System.Drawing.Size(56, 21);
            this.txtPromRate1.TabIndex = 34;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.simpleButton1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtCardRoll);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(3, 395);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 66);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "回收卡收取比例设置";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(197, 25);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 41;
            this.simpleButton1.Text = "设置";
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(200, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "%";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(11, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "回收卡收取比例";
            // 
            // txtCardRoll
            // 
            this.txtCardRoll.Location = new System.Drawing.Point(121, 27);
            this.txtCardRoll.MaxLength = 10;
            this.txtCardRoll.Name = "txtCardRoll";
            this.txtCardRoll.Size = new System.Drawing.Size(56, 21);
            this.txtCardRoll.TabIndex = 37;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(432, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 464);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // frmSysSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(722, 575);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统参数设置";
            this.Load += new System.EventHandler(this.frmSysSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSysSet_Load(object sender, System.EventArgs e)
		{
			DataTable dtgoods=SysInitial.dsSys.Tables["Goods"];
			for(int i=0;i<dtgoods.Rows.Count;i++)
			{
				ltbGoods.Items.Add(dtgoods.Rows[i]["vcGoodsName"].ToString());
				if(dtgoods.Rows[i]["cNewFlag"].ToString()=="1")
				{
					ltbAD.Items.Add(dtgoods.Rows[i]["vcGoodsName"].ToString());
				}	
			}
			dtgoods=new DataTable();
			dtgoods=SysInitial.dsSys.Tables["IG"];
			if(dtgoods.Rows.Count>0)
			{
				txtFee.Text=dtgoods.Rows[0]["vcCommName"].ToString();
				txtIg.Text=dtgoods.Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtFee.Text="";
				txtIg.Text="";
			}

			if(SysInitial.dsSys.Tables["FP1"].Rows.Count>0)
			{
				txtPromRate1.Text=SysInitial.dsSys.Tables["FP1"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate1.Text="0";
			}
			if(SysInitial.dsSys.Tables["FP2"].Rows.Count>0)
			{
				txtPromRate2.Text=SysInitial.dsSys.Tables["FP2"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate2.Text="0";
			}

			if(SysInitial.dsSys.Tables["FP3"].Rows.Count>0)
			{
				txtPromRate3.Text=SysInitial.dsSys.Tables["FP3"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate3.Text="0";
			}

			if(SysInitial.dsSys.Tables["FP4"].Rows.Count>0)
			{
				txtPromRate4.Text=SysInitial.dsSys.Tables["FP4"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate4.Text="0";
			}

			if(SysInitial.dsSys.Tables["FP5"].Rows.Count>0)
			{
				txtPromRate5.Text=SysInitial.dsSys.Tables["FP5"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtPromRate3.Text="0";
			}

			if(SysInitial.dsSys.Tables["FP6"].Rows.Count>0)
			{
				txtCardRoll.Text=SysInitial.dsSys.Tables["FP6"].Rows[0]["vcCommCode"].ToString();
			}
			else
			{
				txtCardRoll.Text="0";
			}
			
			this.txtPromRate1.ReadOnly=false;
			this.txtPromRate2.ReadOnly=false;
			this.txtPromRate3.ReadOnly=false;
			this.txtPromRate4.ReadOnly=false;
			this.txtPromRate5.ReadOnly=false;
			this.sbtnProm.Enabled=true;
			this.label6.ForeColor=Color.Red;
			this.label11.ForeColor=Color.Red;

			switch(SysInitial.intCom)
			{
				case 0:
					this.rbt1.Checked=true;
					break;
				case 1:
					this.rbt2.Checked=true;
					break;
				case 2:
					this.rbt3.Checked=true;
					break;
				case 3:
					this.rbt4.Checked=true;
					break;
				case 4:
					this.rbt5.Checked=true;
					break;
				case 5:
					this.rbt6.Checked=true;
					break;
				case 6:
					this.rbt7.Checked=true;
					break;
				case 7:
					this.rbt8.Checked=true;
					break;
				case 8:
					this.rbt9.Checked=true;
					break;
				case 9:
					this.rbt10.Checked=true;
					break;
			}
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			if(ltbGoods.Items.Count==0)
			{
				MessageBox.Show("没有商品信息，请先录入商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			if(ltbAD.Items.Count>=10)
			{
				MessageBox.Show("推荐新品只能设置10个！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			for(int i=0;i<ltbAD.Items.Count;i++)
			{
				if(ltbGoods.SelectedItem.ToString()==ltbAD.Items[i].ToString())
				{
					return;
				}
			}
			if(ltbGoods.SelectedItem==null)
			{
				MessageBox.Show("请确定选中某个商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			else
			{
				ltbAD.Items.Add(ltbGoods.SelectedItem);
			}
		}

		private void sbtnRemove_Click(object sender, System.EventArgs e)
		{
			if(ltbAD.Items.Count==0)
			{
				MessageBox.Show("目前还没有要推荐的商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			ltbAD.Items.Remove(ltbAD.SelectedItem);
		}

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			ArrayList al=new ArrayList();
			for(int i=0;i<ltbAD.Items.Count;i++)
			{
				al.Add(ltbAD.Items[i].ToString());
			}
			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
			cs.UpdateGoodsNew(al,out err);
			if(err==null)
			{
				MessageBox.Show("推荐新品设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("推荐新品设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnSet_Click(object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.CommStruct cos=new CMSMData.CMSMStruct.CommStruct();
			if(txtFee.Text.Trim()=="")
			{
				cos.strCommName="0";
			}
			else if(double.Parse(txtFee.Text.Trim())<0)
			{
				MessageBox.Show("充值金额不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommName=txtFee.Text.Trim();
			}

			if(txtIg.Text.Trim()=="")
			{
				cos.strCommCode="0";
			}
			else if(double.Parse(txtIg.Text.Trim())<0)
			{
				MessageBox.Show("赠送积分分值不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommCode=txtIg.Text.Trim();
			}
			cos.strCommSign="IG";
			cos.strComments="积分赠送";
			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
			cs.UpdateIgComm(cos,out err);
			if(err==null)
			{
				MessageBox.Show("充值积分设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("充值积分设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void sbtnProm_Click(Object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.CommStruct cos=new CMSMData.CMSMStruct.CommStruct();
			Hashtable htpar=new Hashtable();
			if(txtPromRate1.Text.Trim()=="")
			{
				cos.strCommCode="0";
			}
			else if(double.Parse(txtPromRate1.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommCode=txtPromRate1.Text.Trim();
			}
			cos.strCommName="充值赠款100-200";
			cos.strCommSign="FP1";
			cos.strComments="充值赠款";
			htpar.Add("FP1",cos);

			CMSMData.CMSMStruct.CommStruct cos2=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate2.Text.Trim()=="")
			{
				cos2.strCommCode="0";
			}
			else if(double.Parse(txtPromRate2.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos2.strCommCode=txtPromRate2.Text.Trim();
			}
			cos2.strCommName="充值赠款200-300";
			cos2.strCommSign="FP2";
			cos2.strComments="充值赠款";
			htpar.Add("FP2",cos2);

			CMSMData.CMSMStruct.CommStruct cos3=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate3.Text.Trim()=="")
			{
				cos3.strCommCode="0";
			}
			else if(double.Parse(txtPromRate3.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos3.strCommCode=txtPromRate3.Text.Trim();
			}
			cos3.strCommName="充值赠款300-400";
			cos3.strCommSign="FP3";
			cos3.strComments="充值赠款";
			htpar.Add("FP3",cos3);

			CMSMData.CMSMStruct.CommStruct cos4=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate4.Text.Trim()=="")
			{
				cos4.strCommCode="0";
			}
			else if(double.Parse(txtPromRate4.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos4.strCommCode=txtPromRate4.Text.Trim();
			}
			cos4.strCommName="充值赠款400-500";
			cos4.strCommSign="FP4";
			cos4.strComments="充值赠款";
			htpar.Add("FP4",cos4);

			CMSMData.CMSMStruct.CommStruct cos5=new CMSMData.CMSMStruct.CommStruct();
			if(txtPromRate5.Text.Trim()=="")
			{
				cos5.strCommCode="0";
			}
			else if(double.Parse(txtPromRate5.Text.Trim())<0)
			{
				MessageBox.Show("充值赠款比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos5.strCommCode=txtPromRate5.Text.Trim();
			}
			cos5.strCommName="充值赠款500以上";
			cos5.strCommSign="FP5";
			cos5.strComments="充值赠款";
			htpar.Add("FP5",cos5);

			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
			cs.UpdateFillPromComm(htpar,out err);
			if(err==null)
			{
				MessageBox.Show("充值赠款比例设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("充值赠款比例设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}

		private void sbtnCom_Click(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Control con1 in this.groupBox3.Controls)
			{
				if(con1 is RadioButton)
				{
					RadioButton rbttmp=con1 as RadioButton;
					if(rbttmp.Checked)
					{
						string rbtname=rbttmp.Name.Substring(3,rbttmp.Name.Length-3);
						int icom=int.Parse(rbtname);
						icom=icom-1;
						SysInitial.intCom=Int16.Parse(icom.ToString());
						string FileName="comset.bet";
						string filePath=Environment.CurrentDirectory;
						if(System.IO.File.Exists(filePath+@"\"+FileName))
							System.IO.File.Delete(filePath+@"\"+FileName);
						StreamWriter swFile = new StreamWriter(filePath+@"\"+FileName,true);
						swFile.WriteLine("COMPort=" + SysInitial.intCom.ToString());
						swFile.Close();
						MessageBox.Show("通信串口设置成功，连接正常！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						break;
					}
					else
					{
						continue;
					}
				}
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.CommStruct cos=new CMSMData.CMSMStruct.CommStruct();
			Hashtable htpar=new Hashtable();
			if(txtCardRoll.Text.Trim()=="")
			{
				cos.strCommCode="0";
			}
			else if(double.Parse(txtCardRoll.Text.Trim())<0)
			{
				MessageBox.Show("回收比例不能小于0！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				cos.strCommCode=txtCardRoll.Text.Trim();
			}
			cos.strCommName="回收收取比例";
			cos.strCommSign="FP4";
			cos.strComments="回收比例";
			htpar.Add("FP4",cos);

			
			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err=null;
			cs.UpdateRollPromComm(htpar,out err);
			if(err==null)
			{
				MessageBox.Show("充值赠款比例设置成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
					Application.Exit();
				}
				return;
			}
			else
			{
				MessageBox.Show("充值赠款比例设置失败！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				return;
			}
		}
	}
}
