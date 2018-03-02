using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmSignOut.
	/// </summary>
	public class frmSignOut : frmBase
	{
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbtmanu;
		private System.Windows.Forms.RadioButton rbtCard;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components;

		CommAccess ca=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label lblpromt;
		Exception err;
        private Button sbtnSignout;
		bool IsTimeActive=false;

		public frmSignOut()
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
            this.components = new System.ComponentModel.Container();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtmanu = new System.Windows.Forms.RadioButton();
            this.rbtCard = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lblpromt = new System.Windows.Forms.Label();
            this.sbtnSignout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(80, 80);
            this.txtEmpName.MaxLength = 4;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(136, 21);
            this.txtEmpName.TabIndex = 25;
            this.txtEmpName.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "员工姓名";
            this.label2.Visible = false;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(80, 40);
            this.txtCardID.MaxLength = 4;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(136, 21);
            this.txtCardID.TabIndex = 23;
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "员工卡号";
            // 
            // rbtmanu
            // 
            this.rbtmanu.Location = new System.Drawing.Point(160, 8);
            this.rbtmanu.Name = "rbtmanu";
            this.rbtmanu.Size = new System.Drawing.Size(64, 24);
            this.rbtmanu.TabIndex = 31;
            this.rbtmanu.Text = "手动";
            this.rbtmanu.CheckedChanged += new System.EventHandler(this.rbtmanu_CheckedChanged);
            // 
            // rbtCard
            // 
            this.rbtCard.Location = new System.Drawing.Point(88, 8);
            this.rbtCard.Name = "rbtCard";
            this.rbtCard.Size = new System.Drawing.Size(64, 24);
            this.rbtCard.TabIndex = 30;
            this.rbtCard.Text = "刷卡";
            this.rbtCard.CheckedChanged += new System.EventHandler(this.rbtCard_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "签退形式";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 120);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(480, 488);
            this.dataGrid1.TabIndex = 32;
            // 
            // lblpromt
            // 
            this.lblpromt.ForeColor = System.Drawing.Color.Red;
            this.lblpromt.Location = new System.Drawing.Point(240, 16);
            this.lblpromt.Name = "lblpromt";
            this.lblpromt.Size = new System.Drawing.Size(248, 56);
            this.lblpromt.TabIndex = 33;
            // 
            // sbtnSignout
            // 
            this.sbtnSignout.Location = new System.Drawing.Point(303, 79);
            this.sbtnSignout.Name = "sbtnSignout";
            this.sbtnSignout.Size = new System.Drawing.Size(75, 23);
            this.sbtnSignout.TabIndex = 34;
            this.sbtnSignout.Text = "签退";
            this.sbtnSignout.UseVisualStyleBackColor = true;
            this.sbtnSignout.Click += new System.EventHandler(this.sbtnSignout_Click);
            // 
            // frmSignOut
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(496, 614);
            this.Controls.Add(this.sbtnSignout);
            this.Controls.Add(this.lblpromt);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.rbtmanu);
            this.Controls.Add(this.rbtCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工签退";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSignOut_Closing);
            this.Load += new System.EventHandler(this.frmSignOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSignOut_Load(object sender, System.EventArgs e)
		{
			this.timer1.Interval=5000;
			this.lblpromt.Font=new Font("宋体",12);
			this.txtEmpName.ReadOnly=true;
			if(SysInitial.CurOps.strLimit=="LM001"||SysInitial.CurOps.strLimit=="LM003")
			{
				this.rbtmanu.Enabled=true;
				this.rbtmanu.Visible=true;
				this.sbtnSignout.Enabled=true;
				this.sbtnSignout.Visible=true;
			}
			else
			{
				this.rbtmanu.Enabled=false;
				this.rbtmanu.Visible=false;
				this.sbtnSignout.Enabled=false;
				this.sbtnSignout.Visible=false;
			}
			this.rbtCard.Checked=true;
			this.lblpromt.Text="自动刷卡签退模式开启";
			this.DgBind();
		}

		private void sbtnSignout_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			string EName=txtEmpName.Text.Trim();
			err=null;
			if(ca.ChkEmpSign(strCardID,"2",out err))
			{
				MessageBox.Show("该员工已经签退！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			CMSMStruct.EmpSignStruct esign=new CMSMStruct.EmpSignStruct();
			esign.strCardID=strCardID;
			esign.strEmpName=EName;
			esign.strSignDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
			esign.strClass="";
			esign.strSignFlag="2";
			esign.strComments="";
			esign.strDeptID=SysInitial.LocalDept;
			err=null;
			if(ca.InsertEmpSign(esign,out err))
			{
				MessageBox.Show("员工签退成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				txtCardID.Text="";
				txtEmpName.Text="";
				this.DgBind();
				return;
			}
			else
			{
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}
		}

		private void rbtCard_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtCard.Checked)
			{
				this.txtCardID.ReadOnly=true;
				this.txtCardID.Text="";
				this.txtEmpName.Text="";
				this.timer1.Enabled=true;
				this.timer1.Start();
				this.lblpromt.Text="自动刷卡签退模式开启";
			}
			else
			{
				this.timer1.Stop();
				this.timer1.Enabled=false;
			}
		}

		private void rbtmanu_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtmanu.Checked)
			{
				this.txtCardID.ReadOnly=false;
				txtCardID.Text="";
				txtEmpName.Text="";
				this.lblpromt.Text="手动签退";
			}
		}

		private void txtCardID_KeyPress(object sender, KeyPressEventArgs e)
		{
//			if(e.KeyChar==13)
//			{
//				err=null;
//				string strEmpName=ca.getEmpName(txtCardID.Text.Trim(),out err);
//				if(strEmpName!="")
//				{
//					txtEmpName.Text=strEmpName;
//				}
//				else
//				{
//					MessageBox.Show("无员工资料，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					if(err!=null)
//					{
//						clog.WriteLine(err);
//					}
//					return;
//				}
//			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(!IsTimeActive)
			{
				IsTimeActive=true;
				string strresult="";
				try
				{
					CMSMStruct.CardHardStruct cardhs=ca.ReadCardInfo("Emp",out strresult);
					if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						IsTimeActive=false;
						if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
						{
							this.lblpromt.Text="该卡不属于本系统使用的卡，请检查！";
							return;
						}
						else
						{
							return;
						}
					}

					if(cardhs.strCardID=="")
					{
						this.lblpromt.Text="员工卡号不正确，请重试！";
						IsTimeActive=false;
						return;
					}
					else if(cardhs.strCardID.Substring(0,1)!="F")
					{
						this.lblpromt.Text="此卡不是员工卡，请检查！";
						IsTimeActive=false;
						return;
					}
					else
					{
						err=null;
						cardhs.strCardID=cardhs.strCardID.Substring(1,4);
						string strEmpName=ca.getEmpName(cardhs.strCardID,out err);
							txtCardID.Text=cardhs.strCardID;
							txtEmpName.Text=strEmpName;
							CMSMStruct.EmpSignStruct esign=new CMSMStruct.EmpSignStruct();
							esign.strCardID=cardhs.strCardID;
							esign.strEmpName=strEmpName;
							esign.strSignDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
							esign.strClass="";
							esign.strSignFlag="2";
							esign.strComments="";
							esign.strDeptID=SysInitial.LocalDept;
							err=null;
							if(ca.InsertEmpSign(esign,out err))
							{
								IsTimeActive=false;
								this.txtCardID.Text="";
								this.txtEmpName.Text="";
								this.DgBind();
							}
							else
							{
								IsTimeActive=false;
								if(err!=null)
								{
									clog.WriteLine(err);
								}
							}
					}
				}
				catch(Exception er)
				{
					IsTimeActive=false;
					clog.WriteLine(er);
				}
			}
		}

		private void DgBind()
		{		
			Exception err=null;
			DataTable dt=new DataTable();
			dt=ca.GetSignOutQuery(out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.dataGrid1.CaptionText="今日签退记录情况";
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("员工卡号,签退时间","150,200",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询签到记录出错！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void frmSignOut_Closing(object sender, CancelEventArgs e)
		{
			this.timer1.Stop();
			this.timer1.Enabled=false;
		}
	}
}
