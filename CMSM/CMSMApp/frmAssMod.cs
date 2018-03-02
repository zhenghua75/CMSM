using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Data;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmAssMod.
	/// </summary>
	public class frmAssMod : frmBase
	{
        private System.Windows.Forms.ComboBox cmbAssType;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtLinkAddress;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtAssNbr;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.TextBox txtSpell;
		private System.Windows.Forms.Label label9;
        private Button sbtnOk1;
        private Button sbtnOk;
        private Button sbtnCancel;
		CMSMStruct.AssociatorStruct assOld=new CMSMData.CMSMStruct.AssociatorStruct();

		public frmAssMod()
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
            this.cmbAssType = new System.Windows.Forms.ComboBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLinkAddress = new System.Windows.Forms.TextBox();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.txtAssNbr = new System.Windows.Forms.TextBox();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSpell = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sbtnOk1 = new System.Windows.Forms.Button();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAssType
            // 
            this.cmbAssType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssType.Location = new System.Drawing.Point(328, 96);
            this.cmbAssType.Name = "cmbAssType";
            this.cmbAssType.Size = new System.Drawing.Size(152, 20);
            this.cmbAssType.TabIndex = 4;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(88, 232);
            this.txtComments.MaxLength = 200;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(392, 40);
            this.txtComments.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(328, 136);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 21);
            this.txtEmail.TabIndex = 6;
            // 
            // txtLinkAddress
            // 
            this.txtLinkAddress.Location = new System.Drawing.Point(88, 176);
            this.txtLinkAddress.MaxLength = 100;
            this.txtLinkAddress.Multiline = true;
            this.txtLinkAddress.Name = "txtLinkAddress";
            this.txtLinkAddress.Size = new System.Drawing.Size(392, 40);
            this.txtLinkAddress.TabIndex = 7;
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 136);
            this.txtLinkPhone.MaxLength = 25;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 5;
            // 
            // txtAssNbr
            // 
            this.txtAssNbr.Location = new System.Drawing.Point(88, 96);
            this.txtAssNbr.MaxLength = 18;
            this.txtAssNbr.Name = "txtAssNbr";
            this.txtAssNbr.Size = new System.Drawing.Size(152, 21);
            this.txtAssNbr.TabIndex = 3;
            // 
            // txtAssName
            // 
            this.txtAssName.Location = new System.Drawing.Point(88, 56);
            this.txtAssName.MaxLength = 30;
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(152, 21);
            this.txtAssName.TabIndex = 1;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(152, 21);
            this.txtCardID.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "备 注";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(264, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "会员类型";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "E-Mail";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "联系地址";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "联系电话";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "身份证号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "会员姓名";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "会员卡号";
            // 
            // txtSpell
            // 
            this.txtSpell.Location = new System.Drawing.Point(328, 56);
            this.txtSpell.MaxLength = 10;
            this.txtSpell.Name = "txtSpell";
            this.txtSpell.Size = new System.Drawing.Size(152, 21);
            this.txtSpell.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(264, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "拼音简写";
            // 
            // sbtnOk1
            // 
            this.sbtnOk1.Location = new System.Drawing.Point(0, 0);
            this.sbtnOk1.Name = "sbtnOk1";
            this.sbtnOk1.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk1.TabIndex = 38;
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(107, 288);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 37;
            this.sbtnOk.Text = "更新";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(250, 288);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 39;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // frmAssMod
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(504, 326);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.sbtnOk1);
            this.Controls.Add(this.txtSpell);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLinkAddress);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtAssNbr);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbAssType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAssMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员资料修改";
            this.Load += new System.EventHandler(this.frmAssMod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			CMSMStruct.AssociatorStruct ass1=new CMSMData.CMSMStruct.AssociatorStruct();
//			if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length!=int.Parse(SysInitial.Card))
			if (txtCardID.Text.Trim()=="" || txtCardID.Text.Trim().Length!=5)
			{
				if( txtCardID.Text.Trim().Length!=int.Parse(SysInitial.Card))
				{
					MessageBox.Show("会员卡号不可为空或者位数不对，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtCardID.Focus();
					return;
				}
			}
			else
			{
				ass1.strCardID=txtCardID.Text.Trim();
			}

			if(txtAssName.Text.Trim()==""||txtAssName.Text.Trim().Length>30)
			{
				MessageBox.Show("会员姓名不可为空且小于15个字，请重新填写会员姓名！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtAssName.Focus();
				return;
			}
			else
			{
				ass1.strAssName=txtAssName.Text.Trim();
			}

			if(txtAssNbr.Text.Trim()!=""&&txtAssNbr.Text.Trim().Length!=15&&txtAssNbr.Text.Trim().Length!=18)
			{
				MessageBox.Show("身份证号应为15或18位，请重新填写身份证号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtAssNbr.Focus();
				return;
			}
			else
			{
				ass1.strAssNbr=txtAssNbr.Text.Trim();
			}

			if(txtLinkPhone.Text.Trim()==""||txtLinkPhone.Text.Trim().Length>25)
			{
				MessageBox.Show("联系电话不可为空且小于25位，请重新填写联系电话！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtLinkPhone.Focus();
				return;
			}
			else
			{
				ass1.strLinkPhone=txtLinkPhone.Text.Trim();
			}

			ass1.strLinkAddress=txtLinkAddress.Text.Trim();
			ass1.strSpell=txtSpell.Text.Trim().ToLower();
			ass1.strEmail=txtEmail.Text.Trim();
			ass1.strAssState="0";
			ass1.strComments=txtComments.Text.Trim();
            DateTime dtNow = DateTime.Now;
            ass1.striSerial = dtNow.ToString("yyyyMMddHHmmss");
            ass1.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            //ass1.striSerial = ass1.strOperDate.Substring(0, 4) + ass1.strOperDate.Substring(5, 2) + ass1.strOperDate.Substring(8, 2) + ass1.strOperDate.Substring(11, 2) + ass1.strOperDate.Substring(14, 2) + ass1.strOperDate.Substring(17, 2);

			string strAssType=cmbAssType.Text.Trim();
			ass1.strAssType = GetColEn(strAssType,"AT");
			assOld.strAssType = GetColEn(assOld.strAssType,"AT");
			
			err=null;
			cs.UpdateAssociator(ass1,assOld,out err);
			if(err!=null)
			{
				MessageBox.Show("修改会员资料失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{
				MessageBox.Show("修改会员资料成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmAssMod_Load(object sender, System.EventArgs e)
		{
			if(this.Owner!=null)
			{
				this.FillComboBox(cmbAssType,"AT1","vcCommName");
				foreach(System.Windows.Forms.Control ctl in this.Owner.Controls)
				{
					if(ctl is System.Windows.Forms.DataGrid && ctl.Name=="dataGrid1")
					{
						DataGrid dg=ctl as DataGrid;
						if(dg.CurrentRowIndex>=0)
						{
							this.txtCardID.Text=dg[dg.CurrentRowIndex,1].ToString();
							this.txtAssName.Text =dg[dg.CurrentRowIndex,2].ToString();
							this.txtSpell.Text =dg[dg.CurrentRowIndex,15].ToString();
							this.txtAssNbr.Text =dg[dg.CurrentRowIndex,12].ToString();
							this.txtLinkPhone.Text =dg[dg.CurrentRowIndex,3].ToString();
							this.txtLinkAddress.Text =dg[dg.CurrentRowIndex,13].ToString();
							this.txtEmail.Text =dg[dg.CurrentRowIndex,14].ToString();
							this.cmbAssType.Text =dg[dg.CurrentRowIndex,4].ToString();
							this.txtComments.Text =dg[dg.CurrentRowIndex,11].ToString();

							assOld.strAssID=dg[dg.CurrentRowIndex,0].ToString();
							assOld.strCardID=dg[dg.CurrentRowIndex,1].ToString();
							assOld.strAssName =dg[dg.CurrentRowIndex,2].ToString();
							assOld.strSpell =dg[dg.CurrentRowIndex,15].ToString();
							assOld.strAssNbr =dg[dg.CurrentRowIndex,12].ToString();
							assOld.strLinkPhone=dg[dg.CurrentRowIndex,3].ToString();
							assOld.strLinkAddress =dg[dg.CurrentRowIndex,13].ToString();
							assOld.strEmail=dg[dg.CurrentRowIndex,14].ToString();
							assOld.strAssType=dg[dg.CurrentRowIndex,4].ToString();
							assOld.strComments=dg[dg.CurrentRowIndex,11].ToString();
						}
					}
				}
				txtCardID.ReadOnly=true;
				cmbAssType.Enabled=false;;
			}
			else
			{
				this.ClearText();
			}
		}

	}
}
