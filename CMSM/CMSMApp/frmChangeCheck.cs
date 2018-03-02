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
	/// Summary description for frmChangeCheck.
	/// </summary>
	public class frmChangeCheck :CMSM.CMSMApp.frmBase
	{
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFillFee;
		private System.Windows.Forms.TextBox txtConsCount;
		private System.Windows.Forms.TextBox txtRetail;
		private System.Windows.Forms.TextBox txtAssCons;
		private System.Windows.Forms.TextBox txtCash;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtFillCount;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbOper;
		CommAccess ca=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.TextBox txtLargCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtRoll;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtRollSum;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtFillCountBank;
		private System.Windows.Forms.TextBox txtFillFeeBank;
		private System.Windows.Forms.TextBox txtRetailBank;
        private Button btChangeCheckPrint;
        CommAccess cs = new CommAccess(SysInitial.ConString);
        private Button sbtnOk;
        private Button sbtnClose;
		Exception err;

		public frmChangeCheck()
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
            this.btChangeCheckPrint = new System.Windows.Forms.Button();
            this.txtRetailBank = new System.Windows.Forms.TextBox();
            this.txtFillCountBank = new System.Windows.Forms.TextBox();
            this.txtFillFeeBank = new System.Windows.Forms.TextBox();
            this.txtRollSum = new System.Windows.Forms.TextBox();
            this.txtRoll = new System.Windows.Forms.TextBox();
            this.txtLargCount = new System.Windows.Forms.TextBox();
            this.txtFillCount = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtAssCons = new System.Windows.Forms.TextBox();
            this.txtRetail = new System.Windows.Forms.TextBox();
            this.txtConsCount = new System.Windows.Forms.TextBox();
            this.txtFillFee = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbOper = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btChangeCheckPrint
            // 
            this.btChangeCheckPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btChangeCheckPrint.Location = new System.Drawing.Point(120, 376);
            this.btChangeCheckPrint.Name = "btChangeCheckPrint";
            this.btChangeCheckPrint.Size = new System.Drawing.Size(75, 23);
            this.btChangeCheckPrint.TabIndex = 52;
            this.btChangeCheckPrint.Text = "打印";
            this.btChangeCheckPrint.UseVisualStyleBackColor = true;
            this.btChangeCheckPrint.Click += new System.EventHandler(this.btChangeCheckPrint_Click);
            // 
            // txtRetailBank
            // 
            this.txtRetailBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetailBank.Location = new System.Drawing.Point(120, 200);
            this.txtRetailBank.Name = "txtRetailBank";
            this.txtRetailBank.ReadOnly = true;
            this.txtRetailBank.Size = new System.Drawing.Size(112, 21);
            this.txtRetailBank.TabIndex = 0;
            this.txtRetailBank.Text = "0";
            // 
            // txtFillCountBank
            // 
            this.txtFillCountBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFillCountBank.Location = new System.Drawing.Point(120, 104);
            this.txtFillCountBank.MaxLength = 5;
            this.txtFillCountBank.Name = "txtFillCountBank";
            this.txtFillCountBank.ReadOnly = true;
            this.txtFillCountBank.Size = new System.Drawing.Size(112, 21);
            this.txtFillCountBank.TabIndex = 44;
            this.txtFillCountBank.Text = "0";
            // 
            // txtFillFeeBank
            // 
            this.txtFillFeeBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFillFeeBank.Location = new System.Drawing.Point(120, 128);
            this.txtFillFeeBank.Name = "txtFillFeeBank";
            this.txtFillFeeBank.ReadOnly = true;
            this.txtFillFeeBank.Size = new System.Drawing.Size(112, 21);
            this.txtFillFeeBank.TabIndex = 51;
            this.txtFillFeeBank.Text = "0";
            // 
            // txtRollSum
            // 
            this.txtRollSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRollSum.Location = new System.Drawing.Point(120, 272);
            this.txtRollSum.MaxLength = 5;
            this.txtRollSum.Name = "txtRollSum";
            this.txtRollSum.ReadOnly = true;
            this.txtRollSum.Size = new System.Drawing.Size(112, 21);
            this.txtRollSum.TabIndex = 42;
            this.txtRollSum.Text = "0";
            // 
            // txtRoll
            // 
            this.txtRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoll.Location = new System.Drawing.Point(120, 248);
            this.txtRoll.MaxLength = 5;
            this.txtRoll.Name = "txtRoll";
            this.txtRoll.ReadOnly = true;
            this.txtRoll.Size = new System.Drawing.Size(112, 21);
            this.txtRoll.TabIndex = 40;
            this.txtRoll.Text = "0";
            // 
            // txtLargCount
            // 
            this.txtLargCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLargCount.Location = new System.Drawing.Point(120, 296);
            this.txtLargCount.MaxLength = 5;
            this.txtLargCount.Name = "txtLargCount";
            this.txtLargCount.ReadOnly = true;
            this.txtLargCount.Size = new System.Drawing.Size(112, 21);
            this.txtLargCount.TabIndex = 38;
            this.txtLargCount.Text = "0";
            // 
            // txtFillCount
            // 
            this.txtFillCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFillCount.Location = new System.Drawing.Point(120, 56);
            this.txtFillCount.MaxLength = 5;
            this.txtFillCount.Name = "txtFillCount";
            this.txtFillCount.ReadOnly = true;
            this.txtFillCount.Size = new System.Drawing.Size(112, 21);
            this.txtFillCount.TabIndex = 0;
            this.txtFillCount.Text = "0";
            // 
            // txtCash
            // 
            this.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCash.Location = new System.Drawing.Point(120, 320);
            this.txtCash.MaxLength = 5;
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(112, 21);
            this.txtCash.TabIndex = 5;
            this.txtCash.Text = "0";
            // 
            // txtAssCons
            // 
            this.txtAssCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssCons.Location = new System.Drawing.Point(120, 224);
            this.txtAssCons.MaxLength = 5;
            this.txtAssCons.Name = "txtAssCons";
            this.txtAssCons.ReadOnly = true;
            this.txtAssCons.Size = new System.Drawing.Size(112, 21);
            this.txtAssCons.TabIndex = 4;
            this.txtAssCons.Text = "0";
            // 
            // txtRetail
            // 
            this.txtRetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetail.Location = new System.Drawing.Point(120, 176);
            this.txtRetail.MaxLength = 5;
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(112, 21);
            this.txtRetail.TabIndex = 3;
            this.txtRetail.Text = "0";
            // 
            // txtConsCount
            // 
            this.txtConsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsCount.Location = new System.Drawing.Point(120, 152);
            this.txtConsCount.MaxLength = 5;
            this.txtConsCount.Name = "txtConsCount";
            this.txtConsCount.ReadOnly = true;
            this.txtConsCount.Size = new System.Drawing.Size(112, 21);
            this.txtConsCount.TabIndex = 2;
            this.txtConsCount.Text = "0";
            // 
            // txtFillFee
            // 
            this.txtFillFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFillFee.Location = new System.Drawing.Point(120, 80);
            this.txtFillFee.MaxLength = 5;
            this.txtFillFee.Name = "txtFillFee";
            this.txtFillFee.ReadOnly = true;
            this.txtFillFee.Size = new System.Drawing.Size(112, 21);
            this.txtFillFee.TabIndex = 1;
            this.txtFillFee.Text = "0";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 16);
            this.label15.TabIndex = 50;
            this.label15.Text = "银行卡零售金额";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(232, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 48;
            this.label12.Text = "*不含赠款";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 47;
            this.label13.Text = "银行卡充值次数";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 45;
            this.label14.Text = "银行卡充值金额";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "回收卡退款金额";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(48, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "回收卡数";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(48, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "赠送次数";
            // 
            // cmbOper
            // 
            this.cmbOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOper.Location = new System.Drawing.Point(120, 24);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.Size = new System.Drawing.Size(112, 20);
            this.cmbOper.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(56, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "操作员";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(232, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "*不含赠款";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "现金充值次数";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "现金总额";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "会员消费金额";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "现金零售金额";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "消费次数";
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(40, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 16);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "现金充值金额";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(18, 375);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 53;
            this.sbtnOk.Text = "查询";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(229, 376);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 54;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmChangeCheck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(330, 420);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.btChangeCheckPrint);
            this.Controls.Add(this.txtRetailBank);
            this.Controls.Add(this.txtFillCountBank);
            this.Controls.Add(this.txtFillFeeBank);
            this.Controls.Add(this.txtRollSum);
            this.Controls.Add(this.txtRoll);
            this.Controls.Add(this.txtLargCount);
            this.Controls.Add(this.txtFillCount);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.txtAssCons);
            this.Controls.Add(this.txtRetail);
            this.Controls.Add(this.txtConsCount);
            this.Controls.Add(this.txtFillFee);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbOper);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "当天结帐";
            this.Load += new System.EventHandler(this.frmChangeCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChangeCheck_Load(object sender, System.EventArgs e)
		{
			label7.ForeColor=Color.Red;
			label12.ForeColor = Color.Red;
			lblTitle.ForeColor=Color.Red;
			err=null;
			DataTable dtoper=ca.GetOperToday(out err);
			if(err!=null)
			{
				clog.WriteLine(err);
			}
			this.FillComboBox(this.cmbOper,dtoper,"vcOperName","");
			if(dtoper==null||dtoper.Rows.Count<=0)
			{
				lblTitle.Text="今日没有任何消费和充值记录！";
				this.sbtnOk.Enabled=false;
				return;
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			DateTime dtnow=DateTime.Now;
			lblTitle.Text=dtnow.ToShortDateString()+"截止到"+dtnow.Hour+"点"+dtnow.Minute+"分结帐情况";
			err=null;
			DataTable dt=ca.GetChangeCheckQuery(this.cmbOper.Text.Trim(),out err);
			int consCount=0;
			int consCount1=0;
			double consFee=0;
			if(err!=null)
			{
				lblTitle.Text="计算时发生错误";
				clog.WriteLine(err);
				return;
			}
			if(dt==null||dt.Rows.Count<=0)
			{
				lblTitle.Text="今日没有任何消费和充值记录！";
				return;
			}
			for(int i=0;i<dt.Rows.Count;i++)
			{
				switch(dt.Rows[i]["vcConsType"].ToString())
				{
					case "PT001":
						consCount+=int.Parse(dt.Rows[i]["ConsCount"].ToString());
						this.txtAssCons.Text=dt.Rows[i]["ConsFee"].ToString();
						break;
					case "PT002":
						consCount+=int.Parse(dt.Rows[i]["ConsCount"].ToString());
						consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
						this.txtRetail.Text=dt.Rows[i]["ConsFee"].ToString();
						break;
					case "PT004":
						consCount1+=int.Parse(dt.Rows[i]["ConsCount"].ToString());
						this.txtLargCount.Text=consCount1.ToString();
						break;
					case "PT008":
						consCount+=int.Parse(dt.Rows[i]["ConsCount"].ToString());
						//consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
						this.txtRetailBank.Text=dt.Rows[i]["ConsFee"].ToString();
						break;
					case "Fill":
						this.txtFillCount.Text=dt.Rows[i]["ConsCount"].ToString();
						this.txtFillFee.Text=dt.Rows[i]["ConsFee"].ToString();
						consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
						break;
					case "FillBank":
						this.txtFillCountBank.Text=dt.Rows[i]["ConsCount"].ToString();
						this.txtFillFeeBank.Text=dt.Rows[i]["ConsFee"].ToString();
						//consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
						break;
					case "CradRoll":
						this.txtRoll.Text=dt.Rows[i]["ConsCount"].ToString();
						this.txtRollSum.Text=dt.Rows[i]["ConsFee"].ToString();
						consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
						break;
				}
			}
			this.txtConsCount.Text=consCount.ToString();
			this.txtCash.Text=Math.Round(consFee,2).ToString();	
		}



        private void btChangeCheckPrint_Click(object sender, EventArgs e)
        {
            CMSMData.CMSMStruct.DailyAccountStruct ffs = new CMSMData.CMSMStruct.DailyAccountStruct();
            ffs.strOper = this.cmbOper.Text.ToString();
            ffs.strFillCount = this.txtFillCount.Text.ToString();
            ffs.strFillFee = this.txtFillFee.Text.ToString();
            ffs.strFillCountBank = this.txtFillCountBank.Text.ToString();
            ffs.strFillFeeBank = this.txtFillFeeBank.Text.ToString();
            ffs.strConsCount = this.txtConsCount.Text.ToString();
            ffs.strRetail = this.txtRetail.Text.ToString();
            ffs.strRetailBank = this.txtRetailBank.Text.ToString();
            ffs.strAssCons = this.txtAssCons.Text.ToString();
            ffs.strRoll = this.txtRoll.Text.ToString();
            ffs.strRollSum = this.txtRollSum.Text.ToString();
            ffs.strLargCount = this.txtLargCount.Text.ToString();
            ffs.strCash = this.txtCash.Text.ToString();
            ffs.strDeptID = SysInitial.CurOps.strDeptID;
            //ffs.strOperDate=SysInitial.
            System.Windows.Forms.DialogResult diaRes1 = MessageBox.Show("是否打印当日结账？", "请确认", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            if (diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
            {
                this.ChangeCheckPrint(ffs, cs);
                this.OpenDrawer();
            }
        }

        private void sbtnOk_Click_1(object sender, EventArgs e)
        {
            DateTime dtnow = DateTime.Now;
            lblTitle.Text = dtnow.ToShortDateString() + "截止到" + dtnow.Hour + "点" + dtnow.Minute + "分结帐情况";
            err = null;
            DataTable dt = ca.GetChangeCheckQuery(this.cmbOper.Text.Trim(), out err);
            int consCount = 0;
            int consCount1 = 0;
            double consFee = 0;
            if (err != null)
            {
                lblTitle.Text = "计算时发生错误";
                clog.WriteLine(err);
                return;
            }
            if (dt == null || dt.Rows.Count <= 0)
            {
                lblTitle.Text = "今日没有任何消费和充值记录！";
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["vcConsType"].ToString())
                {
                    case "PT001":
                        consCount += int.Parse(dt.Rows[i]["ConsCount"].ToString());
                        this.txtAssCons.Text = dt.Rows[i]["ConsFee"].ToString();
                        break;
                    case "PT002":
                        consCount += int.Parse(dt.Rows[i]["ConsCount"].ToString());
                        consFee += double.Parse(dt.Rows[i]["ConsFee"].ToString());
                        this.txtRetail.Text = dt.Rows[i]["ConsFee"].ToString();
                        break;
                    case "PT004":
                        consCount1 += int.Parse(dt.Rows[i]["ConsCount"].ToString());
                        this.txtLargCount.Text = consCount1.ToString();
                        break;
                    case "PT008":
                        consCount += int.Parse(dt.Rows[i]["ConsCount"].ToString());
                        //consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
                        this.txtRetailBank.Text = dt.Rows[i]["ConsFee"].ToString();
                        break;
                    case "Fill":
                        this.txtFillCount.Text = dt.Rows[i]["ConsCount"].ToString();
                        this.txtFillFee.Text = dt.Rows[i]["ConsFee"].ToString();
                        consFee += double.Parse(dt.Rows[i]["ConsFee"].ToString());
                        break;
                    case "FillBank":
                        this.txtFillCountBank.Text = dt.Rows[i]["ConsCount"].ToString();
                        this.txtFillFeeBank.Text = dt.Rows[i]["ConsFee"].ToString();
                        //consFee+=double.Parse(dt.Rows[i]["ConsFee"].ToString());
                        break;
                    case "CradRoll":
                        this.txtRoll.Text = dt.Rows[i]["ConsCount"].ToString();
                        this.txtRollSum.Text = dt.Rows[i]["ConsFee"].ToString();
                        consFee += double.Parse(dt.Rows[i]["ConsFee"].ToString());
                        break;
                }
            }
            this.txtConsCount.Text = consCount.ToString();
            this.txtCash.Text = Math.Round(consFee, 2).ToString();	
        }

        private void sbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
