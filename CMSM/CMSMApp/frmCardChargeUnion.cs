using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmCardChargeUnion ��ժҪ˵����
	/// </summary>
	public class frmCardChargeUnion : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCurOrgCharge;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtOrgCardID;
		private System.Windows.Forms.TextBox txtDesCardID;
		private System.Windows.Forms.TextBox txtOrgAssName;
		private System.Windows.Forms.TextBox txtDesAssName;
		private System.Windows.Forms.TextBox txtOrgPhone;
		private System.Windows.Forms.TextBox txtDesPhone;
		private System.Windows.Forms.TextBox txtCurDesCharge;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		private System.Windows.Forms.TextBox txtOrgAssID;
		private System.Windows.Forms.TextBox txtDesAssID;
		private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtUnionOutFee;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.TextBox txtCurOrgIG;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtCurDesIG;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtUnionOutIG;
        private Button sbtnOrgRead;
        private Button sbtnUnionOut;
        private Button sbtnDesRead;
        private Button sbtnUnionIn;
        private TextBox txtiSerial;
		bool finalflag=false;

		public frmCardChargeUnion()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtiSerial = new System.Windows.Forms.TextBox();
            this.sbtnUnionOut = new System.Windows.Forms.Button();
            this.sbtnOrgRead = new System.Windows.Forms.Button();
            this.txtUnionOutIG = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCurOrgIG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnionOutFee = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurOrgCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrgPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrgAssName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrgCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrgAssID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sbtnUnionIn = new System.Windows.Forms.Button();
            this.sbtnDesRead = new System.Windows.Forms.Button();
            this.txtCurDesIG = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCurDesCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesAssName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDesCardID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesAssID = new System.Windows.Forms.TextBox();
            this.lblerr = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtiSerial);
            this.groupBox1.Controls.Add(this.sbtnUnionOut);
            this.groupBox1.Controls.Add(this.sbtnOrgRead);
            this.groupBox1.Controls.Add(this.txtUnionOutIG);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCurOrgIG);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtUnionOutFee);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCurOrgCharge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOrgPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOrgAssName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOrgCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrgAssID);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ԭʼ��Ա��Ϣ";
            // 
            // txtiSerial
            // 
            this.txtiSerial.Enabled = false;
            this.txtiSerial.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtiSerial.Location = new System.Drawing.Point(29, 114);
            this.txtiSerial.MaxLength = 7;
            this.txtiSerial.Name = "txtiSerial";
            this.txtiSerial.Size = new System.Drawing.Size(125, 22);
            this.txtiSerial.TabIndex = 31;
            this.txtiSerial.Visible = false;
            // 
            // sbtnUnionOut
            // 
            this.sbtnUnionOut.Location = new System.Drawing.Point(585, 103);
            this.sbtnUnionOut.Name = "sbtnUnionOut";
            this.sbtnUnionOut.Size = new System.Drawing.Size(75, 23);
            this.sbtnUnionOut.TabIndex = 26;
            this.sbtnUnionOut.Text = "�ϲ�ת��";
            this.sbtnUnionOut.UseVisualStyleBackColor = true;
            this.sbtnUnionOut.Click += new System.EventHandler(this.sbtnUnionOut_Click);
            // 
            // sbtnOrgRead
            // 
            this.sbtnOrgRead.Location = new System.Drawing.Point(585, 24);
            this.sbtnOrgRead.Name = "sbtnOrgRead";
            this.sbtnOrgRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnOrgRead.TabIndex = 26;
            this.sbtnOrgRead.Text = "ˢ��";
            this.sbtnOrgRead.UseVisualStyleBackColor = true;
            this.sbtnOrgRead.Click += new System.EventHandler(this.sbtnOrgRead_Click);
            // 
            // txtUnionOutIG
            // 
            this.txtUnionOutIG.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnionOutIG.Location = new System.Drawing.Point(392, 104);
            this.txtUnionOutIG.MaxLength = 7;
            this.txtUnionOutIG.Name = "txtUnionOutIG";
            this.txtUnionOutIG.Size = new System.Drawing.Size(80, 22);
            this.txtUnionOutIG.TabIndex = 30;
            this.txtUnionOutIG.Text = "0";
            this.txtUnionOutIG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnionOutIG_KeyPress);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(328, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "ת�ƻ���";
            // 
            // txtCurOrgIG
            // 
            this.txtCurOrgIG.Enabled = false;
            this.txtCurOrgIG.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurOrgIG.Location = new System.Drawing.Point(528, 64);
            this.txtCurOrgIG.MaxLength = 7;
            this.txtCurOrgIG.Name = "txtCurOrgIG";
            this.txtCurOrgIG.Size = new System.Drawing.Size(144, 22);
            this.txtCurOrgIG.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(464, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "��ǰ����";
            // 
            // txtUnionOutFee
            // 
            this.txtUnionOutFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnionOutFee.Location = new System.Drawing.Point(224, 104);
            this.txtUnionOutFee.MaxLength = 7;
            this.txtUnionOutFee.Name = "txtUnionOutFee";
            this.txtUnionOutFee.Size = new System.Drawing.Size(80, 22);
            this.txtUnionOutFee.TabIndex = 26;
            this.txtUnionOutFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnionOutFee_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(160, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "ת�ƽ��";
            // 
            // txtCurOrgCharge
            // 
            this.txtCurOrgCharge.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurOrgCharge.Location = new System.Drawing.Point(304, 64);
            this.txtCurOrgCharge.MaxLength = 7;
            this.txtCurOrgCharge.Name = "txtCurOrgCharge";
            this.txtCurOrgCharge.Size = new System.Drawing.Size(144, 22);
            this.txtCurOrgCharge.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(240, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "��ǰ���";
            // 
            // txtOrgPhone
            // 
            this.txtOrgPhone.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgPhone.Location = new System.Drawing.Point(72, 64);
            this.txtOrgPhone.MaxLength = 7;
            this.txtOrgPhone.Name = "txtOrgPhone";
            this.txtOrgPhone.Size = new System.Drawing.Size(144, 22);
            this.txtOrgPhone.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "��ϵ�绰";
            // 
            // txtOrgAssName
            // 
            this.txtOrgAssName.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgAssName.Location = new System.Drawing.Point(304, 24);
            this.txtOrgAssName.MaxLength = 7;
            this.txtOrgAssName.Name = "txtOrgAssName";
            this.txtOrgAssName.Size = new System.Drawing.Size(144, 22);
            this.txtOrgAssName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(240, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "��Ա����";
            // 
            // txtOrgCardID
            // 
            this.txtOrgCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgCardID.Location = new System.Drawing.Point(72, 24);
            this.txtOrgCardID.MaxLength = 7;
            this.txtOrgCardID.Name = "txtOrgCardID";
            this.txtOrgCardID.Size = new System.Drawing.Size(144, 22);
            this.txtOrgCardID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "��Ա����";
            // 
            // txtOrgAssID
            // 
            this.txtOrgAssID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgAssID.Location = new System.Drawing.Point(16, 104);
            this.txtOrgAssID.MaxLength = 7;
            this.txtOrgAssID.Name = "txtOrgAssID";
            this.txtOrgAssID.Size = new System.Drawing.Size(144, 22);
            this.txtOrgAssID.TabIndex = 23;
            this.txtOrgAssID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sbtnUnionIn);
            this.groupBox2.Controls.Add(this.sbtnDesRead);
            this.groupBox2.Controls.Add(this.txtCurDesIG);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtCurDesCharge);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDesPhone);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDesAssName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDesCardID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDesAssID);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(0, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 128);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ŀ���Ա��Ϣ";
            // 
            // sbtnUnionIn
            // 
            this.sbtnUnionIn.ForeColor = System.Drawing.Color.Black;
            this.sbtnUnionIn.Location = new System.Drawing.Point(585, 96);
            this.sbtnUnionIn.Name = "sbtnUnionIn";
            this.sbtnUnionIn.Size = new System.Drawing.Size(75, 23);
            this.sbtnUnionIn.TabIndex = 29;
            this.sbtnUnionIn.Text = "�ϲ�ת��";
            this.sbtnUnionIn.UseVisualStyleBackColor = true;
            this.sbtnUnionIn.Click += new System.EventHandler(this.sbtnUnionIn_Click);
            // 
            // sbtnDesRead
            // 
            this.sbtnDesRead.ForeColor = System.Drawing.Color.Black;
            this.sbtnDesRead.Location = new System.Drawing.Point(585, 25);
            this.sbtnDesRead.Name = "sbtnDesRead";
            this.sbtnDesRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnDesRead.TabIndex = 28;
            this.sbtnDesRead.Text = "ˢ��";
            this.sbtnDesRead.UseVisualStyleBackColor = true;
            this.sbtnDesRead.Click += new System.EventHandler(this.sbtnDesRead_Click);
            // 
            // txtCurDesIG
            // 
            this.txtCurDesIG.Enabled = false;
            this.txtCurDesIG.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurDesIG.Location = new System.Drawing.Point(528, 64);
            this.txtCurDesIG.MaxLength = 7;
            this.txtCurDesIG.Name = "txtCurDesIG";
            this.txtCurDesIG.Size = new System.Drawing.Size(144, 22);
            this.txtCurDesIG.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(464, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "��ǰ����";
            // 
            // txtCurDesCharge
            // 
            this.txtCurDesCharge.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurDesCharge.Location = new System.Drawing.Point(304, 64);
            this.txtCurDesCharge.MaxLength = 7;
            this.txtCurDesCharge.Name = "txtCurDesCharge";
            this.txtCurDesCharge.Size = new System.Drawing.Size(144, 22);
            this.txtCurDesCharge.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(240, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "��ǰ���";
            // 
            // txtDesPhone
            // 
            this.txtDesPhone.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesPhone.Location = new System.Drawing.Point(72, 64);
            this.txtDesPhone.MaxLength = 7;
            this.txtDesPhone.Name = "txtDesPhone";
            this.txtDesPhone.Size = new System.Drawing.Size(144, 22);
            this.txtDesPhone.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "��ϵ�绰";
            // 
            // txtDesAssName
            // 
            this.txtDesAssName.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesAssName.Location = new System.Drawing.Point(304, 24);
            this.txtDesAssName.MaxLength = 7;
            this.txtDesAssName.Name = "txtDesAssName";
            this.txtDesAssName.Size = new System.Drawing.Size(144, 22);
            this.txtDesAssName.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(240, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "��Ա����";
            // 
            // txtDesCardID
            // 
            this.txtDesCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesCardID.Location = new System.Drawing.Point(72, 24);
            this.txtDesCardID.MaxLength = 7;
            this.txtDesCardID.Name = "txtDesCardID";
            this.txtDesCardID.Size = new System.Drawing.Size(144, 22);
            this.txtDesCardID.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "��Ա����";
            // 
            // txtDesAssID
            // 
            this.txtDesAssID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesAssID.Location = new System.Drawing.Point(16, 96);
            this.txtDesAssID.MaxLength = 7;
            this.txtDesAssID.Name = "txtDesAssID";
            this.txtDesAssID.Size = new System.Drawing.Size(144, 22);
            this.txtDesAssID.TabIndex = 23;
            this.txtDesAssID.Visible = false;
            // 
            // lblerr
            // 
            this.lblerr.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblerr.Location = new System.Drawing.Point(8, 144);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(528, 64);
            this.lblerr.TabIndex = 24;
            this.lblerr.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(8, 368);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(528, 80);
            this.label10.TabIndex = 25;
            this.label10.Text = "ע���˹����ǽ�ԭʼ�������ת�Ʋ��ݻ�ȫ����Ŀ�꿨��ԭʼ����������٣�Ŀ�꿨���������ӡ�";
            // 
            // frmCardChargeUnion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(690, 460);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblerr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardChargeUnion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ա�����ϲ�";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCardChargeUnion_Closing);
            this.Load += new System.EventHandler(this.frmCardChargeUnion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCardChargeUnion_Load(object sender, System.EventArgs e)
		{
			this.txtOrgCardID.ReadOnly=true;
			this.txtOrgAssName.ReadOnly=true;
			this.txtOrgPhone.ReadOnly=true;
			this.txtCurOrgCharge.ReadOnly=true;
			this.txtDesCardID.ReadOnly=true;
			this.txtDesAssName.ReadOnly=true;
			this.txtDesPhone.ReadOnly=true;
			this.txtCurDesCharge.ReadOnly=true;
			this.sbtnDesRead.Enabled=false;
			this.sbtnUnionOut.Enabled=false;
			this.sbtnUnionIn.Enabled=false;
			this.txtUnionOutFee.ReadOnly=true;
			this.txtUnionOutIG.Enabled=false;
			this.lblerr.Visible=true;
			finalflag=false;
			this.label10.Text="ע���˹����ǽ�ԭʼ�������ת�Ʋ��ݻ�ȫ����Ŀ�꿨��ԭʼ����������٣�Ŀ�꿨���������ӡ�����˵����\n1��ԭʼ��ˢ��������ת�ƽ�ȷ���ϲ�ת����\n2��Ŀ�꿨ˢ����ȷ���ϲ�ת�롣";
		}

		private void sbtnOrgRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��ˢ��ʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }

			string strresult="";
			this.txtOrgAssID.Text="";
			this.txtOrgCardID.Text="";
			this.txtOrgAssName.Text="";
			this.txtOrgPhone.Text="";
			this.txtCurOrgCharge.Text="";
			this.txtCurOrgIG.Text="";

			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("�ÿ������ڱ�ϵͳʹ�õĿ������飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult.Substring(0,2)=="RF")
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�\n"+strresult,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���ȷ�������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("�˿�ΪԱ���������ɽ������ϲ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				if(chs.strCardID==this.txtDesCardID.Text.Trim())
				{
					MessageBox.Show("ͬһ�ſ��������Ҫ�ϲ���ԭʼ���ŵ��������ϣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					DataRow[] drn=SysInitial.dsSys.Tables["AS"].Select("vcCommCode='"+assres.strAssState+"'");
					if(drn==null||drn.Length==0)
					{
						MessageBox.Show("��Ա״̬�������������������������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						string strAssState=drn[0]["vcCommName"].ToString();
						if(assres.strAssState!="0")
						{
							MessageBox.Show("�û�Ա�Ѿ�ʧЧ�����ţ�" + chs.strCardID + "���ִ��ڡ�"+strAssState+"��״̬����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
					}
					if(chs.dCurCharge==-1||chs.iCurIg==-1)
					{
						MessageBox.Show("ˢ��ʧ�ܣ����ͻ������������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					this.txtOrgAssID.Text=assres.strAssID;
					this.txtOrgCardID.Text=assres.strCardID;
					this.txtOrgAssName.Text=assres.strAssName;
					this.txtOrgPhone.Text=assres.strLinkPhone;
					this.txtCurOrgCharge.Text=chs.dCurCharge.ToString();
					this.txtCurOrgIG.Text=chs.iCurIg.ToString();
					this.txtUnionOutFee.Text="";
					this.lblerr.Text="";
					this.txtUnionOutFee.ReadOnly=false;
					this.sbtnOrgRead.Enabled=false;
					this.txtUnionOutIG.Enabled=true;
					if(this.txtOrgCardID.Text.Trim()!="")
					{
						this.sbtnUnionOut.Enabled=true;
					}
				}
				else
				{
					MessageBox.Show("�޴˻�Ա����˲飡  '"+strresult+"'","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
				}
			}
		}

		private void sbtnDesRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��ˢ��ʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }

			string strresult="";
			this.txtDesAssID.Text="";
			this.txtDesCardID.Text="";
			this.txtDesAssName.Text="";
			this.txtDesPhone.Text="";
			this.txtCurDesCharge.Text="";
			this.txtCurDesIG.Text="";

			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("�ÿ������ڱ�ϵͳʹ�õĿ������飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult.Substring(0,2)=="RF")
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�\n"+strresult,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���ȷ�������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("�˿�ΪԱ���������ɽ������ϲ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				if(chs.strCardID==this.txtOrgCardID.Text.Trim())
				{
					MessageBox.Show("ͬһ�ſ��������Ҫ�ϲ���Ŀ�꿨�ŵ��������ϣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					DataRow[] drn=SysInitial.dsSys.Tables["AS"].Select("vcCommCode='"+assres.strAssState+"'");
					if(drn==null||drn.Length==0)
					{
						MessageBox.Show("��Ա״̬�������������������������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						string strAssState=drn[0]["vcCommName"].ToString();
						if(assres.strAssState!="0")
						{
							MessageBox.Show("�û�Ա�Ѿ�ʧЧ�����ţ�" + chs.strCardID + "���ִ��ڡ�"+strAssState+"��״̬����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
					}
					if(chs.dCurCharge==-1||chs.iCurIg==-1)
					{
						MessageBox.Show("ˢ��ʧ�ܣ����ͻ������������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					this.txtDesAssID.Text=assres.strAssID;
					this.txtDesCardID.Text=assres.strCardID;
					this.txtDesAssName.Text=assres.strAssName;
					this.txtDesPhone.Text=assres.strLinkPhone;
					this.txtCurDesCharge.Text=chs.dCurCharge.ToString();
					this.txtCurDesIG.Text=chs.iCurIg.ToString();
					this.sbtnDesRead.Enabled=false;
					if(this.txtOrgCardID.Text.Trim()!=""&&this.txtDesCardID.Text.Trim()!="")
					{
						this.sbtnUnionIn.Enabled=true;
					}
				}
				else
				{
					MessageBox.Show("�޴˻�Ա����˲飡  '"+strresult+"'","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
				}
			}
		}

		private void txtUnionFee_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==8||e.KeyChar==46)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
				return;
			}
		}

		private void sbtnUnionOut_Click(object sender, System.EventArgs e)
		{
			if(this.txtCurOrgCharge.Text.Trim()=="")
			{
				MessageBox.Show("ԭʼ������Ϊ�գ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			if(this.txtUnionOutFee.Text.Trim()=="")
			{
				MessageBox.Show("ת�ƽ���Ϊ�գ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			double dOrgCharge=Math.Round(double.Parse(this.txtCurOrgCharge.Text.Trim()),2);
			double dUnionOutFee=Math.Round(double.Parse(this.txtUnionOutFee.Text.Trim()),2);
			double dOrgIG=Math.Round(double.Parse(this.txtCurOrgIG.Text.Trim()),2);
			double dUnionOutIG=Math.Round(double.Parse(this.txtUnionOutIG.Text.Trim()),2);
			if(dUnionOutFee<0 && this.txtUnionOutFee.Text!="")
			{
				MessageBox.Show("ת������Ϊ0��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			if(dOrgCharge<dUnionOutFee)
			{
				MessageBox.Show("ԭʼ�����㣬��������ȷ��ת����","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			if(dOrgIG<dUnionOutIG && this.txtUnionOutIG.Text!=""&&dUnionOutIG<0)
			{
				MessageBox.Show("ԭʼ�����ֲ�����߲�С��0����������ȷ��ת�����֣�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			try
			{
				CMSMStruct.FillFeeStruct ffsOrg=new CMSMData.CMSMStruct.FillFeeStruct();
                DateTime dtNow = DateTime.Now;
                ffsOrg.iSerial =Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
				ffsOrg.strAssID=this.txtOrgAssID.Text.Trim();
				ffsOrg.strCardID=this.txtOrgCardID.Text.Trim();
				ffsOrg.dFillFee=-dUnionOutFee;
				ffsOrg.dFillProm=0;
				ffsOrg.dFeeLast=dOrgCharge;
				ffsOrg.dFeeCur=dOrgCharge-dUnionOutFee;
				ffsOrg.dIGCur=dOrgIG-dUnionOutIG;
				ffsOrg.dIGLast=dOrgIG;
				ffsOrg.dIG=dUnionOutIG;
                ffsOrg.strFillDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
				ffsOrg.strComments="�ϲ�ת��";
				ffsOrg.strOperName=SysInitial.CurOps.strOperName;
				ffsOrg.strDeptID=SysInitial.LocalDept;

				CMSMStruct.BusiLogStruct busiOrg=new CMSMData.CMSMStruct.BusiLogStruct();
				busiOrg.strAssID=this.txtOrgAssID.Text.Trim();
				busiOrg.strCardID=this.txtOrgCardID.Text.Trim();
				busiOrg.strOperType="OP013";
				busiOrg.strOperName=SysInitial.CurOps.strOperName;
                busiOrg.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString(); 
				busiOrg.strComments="�ϲ�ת��"+dUnionOutFee.ToString()+"Ԫ";
				busiOrg.strDeptID=SysInitial.LocalDept;
				double dOrgChargeBak=dOrgCharge-dUnionOutFee;
                this.txtiSerial.Text = ffsOrg.iSerial.ToString();

				if(ffsOrg.dFeeCur!=dOrgChargeBak)
				{
					MessageBox.Show("��Ա���ϲ�ת��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("ת������ֵ�����ֵ���ȣ�����ֵ��" + dOrgChargeBak.ToString() + " ����ֵ" + ffsOrg.dFeeCur.ToString());
					return;
				}

				string strresult="";
				DialogResult strMes1=MessageBox.Show("�Ƿ�ȷ��Ҫת��"+dUnionOutFee.ToString()+"Ԫ��"+dUnionOutIG.ToString()+"������","ϵͳȷ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if(strMes1==DialogResult.Yes)
				{
					CMSMStruct.CardHardStruct chsOrg=new CMSMData.CMSMStruct.CardHardStruct();
					chsOrg=cs.ReadCardInfo("",out strresult);
					while(chsOrg.strCardID!=ffsOrg.strCardID)
					{
						MessageBox.Show("ԭʼ������ȷ���뽫Ҫ�ϲ���ԭʼ�����ڶ������ϣ��ٵ����ȷ������","��ſ�",MessageBoxButtons.OK);
						chsOrg.strCardID="";
						chsOrg=cs.ReadCardInfo("",out strresult);
					}
					err=null;
					strresult=cs.CardChargeUnionOut(ffsOrg,busiOrg,dOrgChargeBak,out err);
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.IndexOf("CMT",0)>=0)
					{
						finalflag=true;
						MessageBox.Show("��Ա�����ϲ�ת���ɹ��������ת�뿨���ٵ�ˢ��ת����","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						this.sbtnDesRead.Enabled=true;
						this.sbtnUnionOut.Enabled=false;
						this.txtUnionOutFee.ReadOnly=true;
						this.txtUnionOutIG.Enabled=false;
					}
					else
					{
						MessageBox.Show("��Ա�����ϲ�ת��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						lblerr.Text="��Ա�����ϲ�ת��ʧ�ܣ����κϲ���Ч����������Ƿ���ȷ��";
						this.sbtnOrgRead.Enabled=true;
						this.sbtnUnionOut.Enabled=false;
						this.txtUnionOutFee.ReadOnly=true;
						this.txtUnionOutIG.Enabled=false;
						if(err!=null)
						{
							clog.WriteLine(err.ToString()+strresult);
						}
						else
						{
							clog.WriteLine(strresult);
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("��Ա�����ϲ�ת��ʧ�ܣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				lblerr.Text="��Ա�����ϲ�ʧ�ܣ����κϲ���Ч����������Ƿ���ȷ��";
				clog.WriteLine(ex);
			}
		}

		private void sbtnUnionIn_Click(object sender, System.EventArgs e)
		{
			if(this.txtUnionOutFee.Text.Trim()=="")
			{
				MessageBox.Show("ת�ƽ���Ϊ�գ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			double dDesCharge=Math.Round(double.Parse(this.txtCurDesCharge.Text.Trim()),2);
			double dUnionInFee=Math.Round(double.Parse(this.txtUnionOutFee.Text.Trim()),2);
			double dDesIG=Math.Round(double.Parse(this.txtCurDesIG.Text.Trim()),2);
			double dUnionInIG=Math.Round(double.Parse(this.txtUnionOutIG.Text.Trim()),2);
			if(dUnionInFee<0)
			{
				MessageBox.Show("ת�ƽ���Ϊ0��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			try
			{
				CMSMStruct.FillFeeStruct ffsDes=new CMSMData.CMSMStruct.FillFeeStruct();
                DateTime dtNow = DateTime.Now;
                ffsDes.iSerial = Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
				ffsDes.strAssID=this.txtDesAssID.Text.Trim();
				ffsDes.strCardID=this.txtDesCardID.Text.Trim();
				ffsDes.dFillFee=dUnionInFee;
				ffsDes.dFillProm=0;
				ffsDes.dFeeLast=dDesCharge;
				ffsDes.dFeeCur=dDesCharge+dUnionInFee;
				ffsDes.dIG=dUnionInIG;
				ffsDes.dIGLast=dDesIG;
				ffsDes.dIGCur=dDesIG+dUnionInIG;
                ffsDes.strFillDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
				ffsDes.strComments="�ϲ�ת��,ԭ����Ϊ��"+ this.txtOrgCardID.Text +" ";
				ffsDes.strOperName=SysInitial.CurOps.strOperName;
				ffsDes.strDeptID=SysInitial.LocalDept;
                ffsDes.strSerialOld = this.txtiSerial.Text;
                ffsDes.strCardIDOld = this.txtOrgCardID.Text;

				CMSMStruct.BusiLogStruct busiDes=new CMSMData.CMSMStruct.BusiLogStruct();
				busiDes.strAssID=this.txtDesAssID.Text.Trim();
				busiDes.strCardID=this.txtDesCardID.Text.Trim();
				busiDes.strOperType="OP014";
				busiDes.strOperName=SysInitial.CurOps.strOperName;
                busiDes.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
				busiDes.strComments="�ϲ�ת��"+dUnionInFee.ToString()+"Ԫ,ԭ����Ϊ��"+ this.txtOrgCardID.Text +"";
				busiDes.strDeptID=SysInitial.LocalDept;
				double dDesChargeBak=dDesCharge+dUnionInFee;

				if(ffsDes.dFeeCur!=dDesChargeBak)
				{
					MessageBox.Show("��Ա�����ϲ�ת��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("ת�뱸��ֵ�����ֵ���ȣ�����ֵ��" + dDesChargeBak.ToString() + " ����ֵ" + ffsDes.dFeeCur.ToString());
					return;
				}

				string strresult="";
				CMSMStruct.CardHardStruct chsDes=new CMSMData.CMSMStruct.CardHardStruct();
				chsDes=cs.ReadCardInfo("",out strresult);
				while(chsDes.strCardID!=ffsDes.strCardID)
				{
					MessageBox.Show("Ŀ�꿨����ȷ���뽫Ҫ�ϲ���Ŀ�꿨���ڶ������ϣ��ٵ����ȷ������","��ſ�",MessageBoxButtons.OK);
					chsDes.strCardID="";
					chsDes=cs.ReadCardInfo("",out strresult);
				}
				err=null;
				strresult=cs.CardChargeUnionIn(ffsDes,busiDes,dDesChargeBak,out err);
				if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.IndexOf("CMT",0)>=0)
				{
					finalflag=false;
					MessageBox.Show("��Ա�����ϲ�ת��ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					this.ClearText();
					this.lblerr.Text="";
					this.sbtnOrgRead.Enabled=true;
					this.sbtnDesRead.Enabled=false;
					this.sbtnUnionOut.Enabled=false;
					this.sbtnUnionIn.Enabled=false;
					this.txtUnionOutIG.Enabled=false;
				}
				else
				{
					MessageBox.Show("��Ա�����ϲ�ת��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					lblerr.Text="��Ա�����ϲ�ת��ʧ�ܣ������ԣ�������ת�붼ʧ�ܣ�������Ŀ�꿨д���������⣬���¼�±���ת�ƽ���Ҫ�ϲ�ת�Ƶ�ԭʼ���š�Ŀ�꿨�ţ�����Ŀ�꿨�ջأ��Ա�����Ա����";
					this.sbtnDesRead.Enabled=true;
					this.sbtnUnionIn.Enabled=false;
					if(err!=null)
					{
						clog.WriteLine(err.ToString()+strresult);
					}
					else
					{
						clog.WriteLine(strresult);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("��Ա�����ϲ�ʧ�ܣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				lblerr.Text="��Ա�����ϲ�ʧ�ܣ����κϲ���Ч����������Ƿ���ȷ��";
				clog.WriteLine(ex);
			}
		}

        private void txtUnionOutIG_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 )
            {
                return;
            }
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
                return;
            }
        }
        private void txtUnionOutFee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                return;
            }
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
                return;
            }
        }

		private void frmCardChargeUnion_Closing(object sender, CancelEventArgs e)
		{
			if(finalflag)
			{
				DialogResult remsg=MessageBox.Show("ԭʼ����ת���ɹ�����δת�룬�رձ����ܽ��޷���ת�룬��ȷ��Ҫ�رձ�������","����",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);
				if(remsg==DialogResult.Yes)
				{
					e.Cancel=false;
				}
				else
				{
					e.Cancel=true;
				}
			}
		}
	}
}
