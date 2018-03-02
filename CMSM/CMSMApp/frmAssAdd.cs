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
	/// frmAssAdd 的摘要说明。
	/// </summary>
	public class frmAssAdd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtAssNbr;
		private System.Windows.Forms.ComboBox cmbAssType;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtLinkAddress;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtComments;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSpell;
        private Button sbtnOk;
        private Button sbtnCancel;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmAssAdd()
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssNbr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLinkAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAssType = new System.Windows.Forms.ComboBox();
            this.txtSpell = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡号";
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(152, 21);
            this.txtCardID.TabIndex = 0;
            // 
            // txtAssName
            // 
            this.txtAssName.Location = new System.Drawing.Point(88, 56);
            this.txtAssName.MaxLength = 30;
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(152, 21);
            this.txtAssName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "会员姓名";
            // 
            // txtAssNbr
            // 
            this.txtAssNbr.Location = new System.Drawing.Point(88, 96);
            this.txtAssNbr.MaxLength = 18;
            this.txtAssNbr.Name = "txtAssNbr";
            this.txtAssNbr.Size = new System.Drawing.Size(152, 21);
            this.txtAssNbr.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证号";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 136);
            this.txtLinkPhone.MaxLength = 25;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "联系电话";
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
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "联系地址";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(328, 136);
            this.txtEmail.MaxLength = 30;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 21);
            this.txtEmail.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "E-Mail";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(264, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "会员类型";
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
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "备 注";
            // 
            // cmbAssType
            // 
            this.cmbAssType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssType.Location = new System.Drawing.Point(328, 96);
            this.cmbAssType.Name = "cmbAssType";
            this.cmbAssType.Size = new System.Drawing.Size(152, 20);
            this.cmbAssType.TabIndex = 4;
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
            this.label9.TabIndex = 16;
            this.label9.Text = "拼音简写";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(104, 288);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 22;
            this.sbtnOk.Text = "确定发卡";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(304, 288);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 23;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // frmAssAdd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(504, 326);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
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
            this.Name = "frmAssAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员资料录入";
            this.Load += new System.EventHandler(this.frmAssAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAssAdd_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbAssType,"AT1","vcCommName");
		}

//		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			if(e.KeyChar==8)
//			{
//				return;
//			}
//			if(e.KeyChar<48||e.KeyChar>57)
//			{
//				e.Handled=true;
//			}
//		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，发卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			CMSMStruct.AssociatorStruct ass1=new CMSMData.CMSMStruct.AssociatorStruct();
			if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length!=int.Parse(SysInitial.Card))
			{
				MessageBox.Show("会员卡号不可为空或者位数不对，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			else if(!cs.ChkCardIDDup(txtCardID.Text.Trim(),out err))
			{
				ass1.strCardID=txtCardID.Text.Trim();
			}
			else
			{
				MessageBox.Show("该卡已经有其他会员使用，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;	
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
//			CardCommon.CardRef.CardM1 cm = new CardCommon.CardRef.CardM1(SysInitial.intCom);
//			cm.ReadCardSnr("");
			ass1.strSpell=txtSpell.Text.Trim().ToLower();
			ass1.strLinkAddress=txtLinkAddress.Text.Trim();
			ass1.strEmail=txtEmail.Text.Trim();
			ass1.strAssState="0";
			ass1.dCharge=0;
			ass1.iIgValue=0;
			ass1.strCardFlag="1";
			ass1.strComments=txtComments.Text.Trim();
            DateTime dtNow = DateTime.Now;
            ass1.striSerial = dtNow.ToString("yyyyMMddHHmmss");
            ass1.strCreateDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            //ass1.striSerial = ass1.strCreateDate.Substring(0, 4) + ass1.strCreateDate.Substring(5, 2) + ass1.strCreateDate.Substring(8, 2) + ass1.strCreateDate.Substring(11, 2) + ass1.strCreateDate.Substring(14, 2) + ass1.strCreateDate.Substring(17, 2);
			ass1.strOperDate=ass1.strCreateDate;
			ass1.strDeptID=SysInitial.CurOps.strDeptID;

			string strAssType=cmbAssType.Text.Trim();
			ass1.strAssType = GetColEn(strAssType,"AT");
			
			err=null;
			string strresult=cs.InsertAssociator(ass1,out err);
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("添加新会员失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null||strresult!=null)
				{
					clog.WriteLine(err + "\n" + strresult);
				}
			}
			else
			{
				MessageBox.Show("添加新会员成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.ClearText();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
