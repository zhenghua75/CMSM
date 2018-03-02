using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CMSMData.CMSMDataAccess;
using System.Windows.Forms;
using System.Data;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmCardLose.
	/// </summary>
	public class frmCardLose : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
		private System.Windows.Forms.TextBox txtAssID;
        private Button sbtnLose;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmCardLose()
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
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.sbtnLose = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCharge
            // 
            this.txtCharge.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.Location = new System.Drawing.Point(88, 136);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(144, 22);
            this.txtCharge.TabIndex = 29;
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 96);
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(144, 22);
            this.txtLinkPhone.TabIndex = 27;
            // 
            // txtAssName
            // 
            this.txtAssName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssName.Location = new System.Drawing.Point(88, 56);
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(144, 22);
            this.txtAssName.TabIndex = 22;
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 22);
            this.txtCardID.TabIndex = 19;
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "当前余额";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "联系电话";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "会员姓名";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "会员卡号";
            // 
            // txtAssID
            // 
            this.txtAssID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssID.Location = new System.Drawing.Point(0, 0);
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(80, 22);
            this.txtAssID.TabIndex = 30;
            this.txtAssID.Visible = false;
            // 
            // sbtnLose
            // 
            this.sbtnLose.Location = new System.Drawing.Point(27, 179);
            this.sbtnLose.Name = "sbtnLose";
            this.sbtnLose.Size = new System.Drawing.Size(75, 23);
            this.sbtnLose.TabIndex = 31;
            this.sbtnLose.Text = "挂失";
            this.sbtnLose.UseVisualStyleBackColor = true;
            this.sbtnLose.Click += new System.EventHandler(this.sbtnLose_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(157, 179);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 32;
            this.sbtnClose.Text = "取消";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmCardLose
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(256, 214);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnLose);
            this.Controls.Add(this.txtAssID);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardLose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员卡挂失";
            this.Load += new System.EventHandler(this.frmCardLose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCardLose_Load(object sender, System.EventArgs e)
		{
			txtAssName.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCharge.ReadOnly=true;
			sbtnLose.Enabled=false;
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
                Ping ping = new Ping();
                PingReply pr = ping.Send("10.10.10.203");
                if (pr.Status != IPStatus.Success)
                {
                    MessageBox.Show("童鞋！vpn掉线了或者网速太慢！,请检查vpn连接！");
                    return;
                }

				err=null;
				string strCardID=txtCardID.Text.Trim();
				if(strCardID=="")
				{
					MessageBox.Show("会员卡号不可为空且小于10位，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(strCardID,out err);
				if(assres!=null)
				{
					string strAssState=assres.strAssState;
					if(strAssState!="0")
					{
						MessageBox.Show("该会员已经失效，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					txtAssID.Text=assres.strAssID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;
					txtCharge.Text=assres.dCharge.ToString();
					txtCardID.ReadOnly=true;
					sbtnLose.Enabled=true;
				}
				else
				{
					MessageBox.Show("你输入的会员卡有误或者不是正常在用会员！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(txtCardID.Text=="")
			{
				this.Close();
			}
			else
			{
				this.ClearText();
				txtCardID.ReadOnly=false;
			}
		}

		private void sbtnLose_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，挂失失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                this.ClearText();
                txtCardID.ReadOnly = false;
                sbtnLose.Enabled = false;
                return;
            }

			string strCardID=txtCardID.Text.Trim();
			if(txtCardID.Text.Trim()=="")
			{
				MessageBox.Show("会员卡号异常，请重新填写会员卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("是否确定挂失该会员卡？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				err=null;
				cs.CardLose(txtAssID.Text.Trim(),strCardID,out err);
				if(err!=null)
				{
					MessageBox.Show("挂失失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err);
				}
				else
				{
					MessageBox.Show("挂失成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					this.ClearText();
					txtCardID.ReadOnly=false;
					sbtnLose.Enabled=false;
				}
			}
		}
	}
}
