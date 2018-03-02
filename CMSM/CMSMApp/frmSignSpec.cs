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
	/// Summary description for frmSignSpec.
	/// </summary>
	public class frmSignSpec : frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbSpec;
        private System.Windows.Forms.TextBox txtComments;
		private System.ComponentModel.IContainer components;

		CommAccess ca=new CommAccess(SysInitial.ConString);
        private Button sbtnSign;
		Exception err=null;

		public frmSignSpec()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSpec = new System.Windows.Forms.ComboBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sbtnSign = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 176);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(480, 432);
            this.dataGrid1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 33;
            this.label4.Text = "特殊情况";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(312, 40);
            this.txtEmpName.MaxLength = 4;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(136, 21);
            this.txtEmpName.TabIndex = 31;
            this.txtEmpName.Visible = false;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(80, 40);
            this.txtCardID.MaxLength = 4;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(136, 21);
            this.txtCardID.TabIndex = 1;
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(248, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "员工姓名";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "员工卡号";
            // 
            // cmbSpec
            // 
            this.cmbSpec.Location = new System.Drawing.Point(80, 8);
            this.cmbSpec.Name = "cmbSpec";
            this.cmbSpec.Size = new System.Drawing.Size(136, 20);
            this.cmbSpec.TabIndex = 0;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(80, 72);
            this.txtComments.MaxLength = 100;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(368, 64);
            this.txtComments.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "备注";
            // 
            // sbtnSign
            // 
            this.sbtnSign.Location = new System.Drawing.Point(188, 147);
            this.sbtnSign.Name = "sbtnSign";
            this.sbtnSign.Size = new System.Drawing.Size(75, 23);
            this.sbtnSign.TabIndex = 39;
            this.sbtnSign.Text = "确定";
            this.sbtnSign.UseVisualStyleBackColor = true;
            this.sbtnSign.Click += new System.EventHandler(this.sbtnSign_Click);
            // 
            // frmSignSpec
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(498, 616);
            this.Controls.Add(this.sbtnSign);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSpec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignSpec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊情况考勤";
            this.Load += new System.EventHandler(this.frmSignSpec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSignSpec_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbSpec,"SFlag","vcCommName");
			this.DgBind();
		}

		private void sbtnSign_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			string EName=txtEmpName.Text.Trim();
			string strcomments=txtComments.Text.Trim();
			if(strcomments.Length>75)
			{
				MessageBox.Show("备注信息不得大于75个汉字！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
				err=null;
				if(ca.ChkEmpSign(strCardID,"3','4",out err))
				{
					DialogResult dradd=MessageBox.Show("该员工今日已经有特殊记录，是否还要添加新的特殊内容！","系统提示",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
					if(dradd==DialogResult.Yes)
					{
						CMSMStruct.EmpSignStruct esign=new CMSMStruct.EmpSignStruct();
						esign.strCardID=strCardID;
						esign.strEmpName=EName;
						esign.strSignDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
						esign.strClass="";
						esign.strSignFlag=this.GetColEn(cmbSpec.Text.Trim(),"SFlag");
						esign.strComments=strcomments;
						esign.strDeptID=SysInitial.LocalDept;
						err=null;
						if(ca.InsertEmpSign(esign,out err))
						{
							MessageBox.Show("员工特殊情况考勤记录成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
							this.txtCardID.Text="";
							this.txtEmpName.Text="";
							txtComments.Text="";
							this.DgBind();
							return;
						}
						else
						{
							MessageBox.Show("员工特殊情况考勤记录失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							this.txtCardID.Text="";
							this.txtEmpName.Text="";
							if(err!=null)
							{
								clog.WriteLine(err);
							}
							return;
						}
					}
					else
					{
						txtCardID.Text="";
						txtEmpName.Text="";
						txtComments.Text="";
					}
				}
				else
				{
					CMSMStruct.EmpSignStruct esign=new CMSMStruct.EmpSignStruct();
					esign.strCardID=strCardID;
					esign.strEmpName=EName;
					esign.strSignDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
					esign.strClass="";
					esign.strSignFlag=this.GetColEn(cmbSpec.Text.Trim(),"SFlag");
					esign.strComments=strcomments;
					esign.strDeptID=SysInitial.LocalDept;
					err=null;
					if(ca.InsertEmpSign(esign,out err))
					{
						MessageBox.Show("员工特殊情况考勤记录成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						this.txtCardID.Text="";
						this.txtEmpName.Text="";
						txtComments.Text="";
						this.DgBind();
						return;
					}
					else
					{
						MessageBox.Show("员工特殊情况考勤记录失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.txtCardID.Text="";
						this.txtEmpName.Text="";
						if(err!=null)
						{
							clog.WriteLine(err);
						}
						return;
					}
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

		private void DgBind()
		{		
			Exception err=null;
			DataTable dt=new DataTable();
			dt=ca.GetSignSpecQuery(out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcSignFlag","SFlag","vcCommCode","vcCommName");

				this.dataGrid1.CaptionText="今日特殊记录情况";
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("员工卡号,记录时间,类型,备注","100,150,80,180",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询特殊记录出错！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}
	}
}
