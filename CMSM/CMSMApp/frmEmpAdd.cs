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
	/// frmEmpAdd 的摘要说明。
	/// </summary>
	public class frmEmpAdd : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtLinkAddress;
		private System.Windows.Forms.TextBox txtComments;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmbSex;
		private System.Windows.Forms.ComboBox cmbDegree;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.TextBox txtEmpNbr;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbOfficer;
        private Button sbtnOk;
        private Button sbtnCancel;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmEmpAdd()
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
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpNbr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLinkAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbOfficer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.label1.Text = "员工卡号";
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 4;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(152, 21);
            this.txtCardID.TabIndex = 0;
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(328, 16);
            this.txtEmpName.MaxLength = 30;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(152, 21);
            this.txtEmpName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(264, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "员工姓名";
            // 
            // txtEmpNbr
            // 
            this.txtEmpNbr.Location = new System.Drawing.Point(88, 56);
            this.txtEmpNbr.MaxLength = 18;
            this.txtEmpNbr.Name = "txtEmpNbr";
            this.txtEmpNbr.Size = new System.Drawing.Size(152, 21);
            this.txtEmpNbr.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证号";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 96);
            this.txtLinkPhone.MaxLength = 25;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(152, 21);
            this.txtLinkPhone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 104);
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
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(288, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "学历";
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
            // cmbDegree
            // 
            this.cmbDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegree.Location = new System.Drawing.Point(328, 96);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(152, 20);
            this.cmbDegree.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(288, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "性别";
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Location = new System.Drawing.Point(328, 56);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(152, 20);
            this.cmbSex.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "入职时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 136);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // cmbOfficer
            // 
            this.cmbOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfficer.Location = new System.Drawing.Point(328, 136);
            this.cmbOfficer.Name = "cmbOfficer";
            this.cmbOfficer.Size = new System.Drawing.Size(152, 20);
            this.cmbOfficer.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(288, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "职务";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(116, 286);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 27;
            this.sbtnOk.Text = "确定发卡";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(317, 286);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 28;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // frmEmpAdd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(504, 321);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.cmbOfficer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtLinkAddress);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtEmpNbr);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDegree);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEmpAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工资料录入";
            this.Load += new System.EventHandler(this.frmAssAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAssAdd_Load(object sender, System.EventArgs e)
		{
			this.cmbSex.Items.Add("男");
			this.cmbSex.Items.Add("女");
			this.cmbSex.SelectedIndex=0;
			this.FillComboBox(cmbDegree,"DE","vcCommName");
			this.FillComboBox(cmbOfficer,"OF","vcCommName");
			this.dateTimePicker1.Value=DateTime.Now;
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==8)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			CMSMStruct.EmployeeStruct emp1=new CMSMData.CMSMStruct.EmployeeStruct();
			if(txtCardID.Text.Trim()==""||txtCardID.Text.Trim().Length!=4)
			{
				MessageBox.Show("员工卡号不可为空且为4位，请重新填写员工卡号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			else if(!cs.ChkEmpCardIDDup(txtCardID.Text.Trim(),out err))
			{
				emp1.strCardID=txtCardID.Text.Trim();
			}
			else
			{
				MessageBox.Show("该卡已经有其他员工使用，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;	
			}

			if(txtEmpName.Text.Trim()==""||txtEmpName.Text.Trim().Length>30)
			{
				MessageBox.Show("员工姓名不可为空且小于15个字，请重新填写员工姓名！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtEmpName.Focus();
				return;
			}
			else
			{
				emp1.strEmpName=txtEmpName.Text.Trim();
			}

			if(txtEmpNbr.Text.Trim()!=""&&txtEmpNbr.Text.Trim().Length!=15&&txtEmpNbr.Text.Trim().Length!=18)
			{
				MessageBox.Show("身份证号应为15或18位，请重新填写身份证号！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtEmpNbr.Focus();
				return;
			}
			else
			{
				emp1.strEmpNbr=txtEmpNbr.Text.Trim();
			}

			if(txtLinkPhone.Text.Trim()==""||txtLinkPhone.Text.Trim().Length>25)
			{
				MessageBox.Show("联系电话不可为空且小于25位，请重新填写联系电话！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtLinkPhone.Focus();
				return;
			}
			else
			{
				emp1.strLinkPhone=txtLinkPhone.Text.Trim();
			}

			emp1.strSex=cmbSex.Text.Trim();
			emp1.strInDate=this.dateTimePicker1.Value.ToShortDateString();
			emp1.strDegree=this.GetColEn(cmbDegree.Text.Trim(),"DE");
			emp1.strOfficer=this.GetColEn(cmbOfficer.Text.Trim(),"OF");
			emp1.strAddress=txtLinkAddress.Text.Trim();
			emp1.strDeptID=SysInitial.CurOps.strDeptID;
			emp1.strFlag="0";
			emp1.strPwd="";
			emp1.strComments=txtComments.Text.Trim();
			emp1.strOperDate=DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

			err=null;
			string strresult=cs.InsertEmployee(emp1,out err);
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("添加新员工失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null||strresult!=null)
				{
					clog.WriteLine(err + "\n" + strresult);
				}
			}
			else
			{
				MessageBox.Show("添加新员工成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.ClearText();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
