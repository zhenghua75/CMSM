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
	/// Summary description for frmOperFirst.
	/// </summary>
	public class frmOperFirst : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtOperID;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOperName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLimit;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
        private Button sbtnAdd;
		CommAccess cs=new CommAccess(SysInitial.ConString);


		public frmOperFirst()
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
            this.txtOperID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOperName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLimit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOperID
            // 
            this.txtOperID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperID.Location = new System.Drawing.Point(64, 16);
            this.txtOperID.MaxLength = 10;
            this.txtOperID.Name = "txtOperID";
            this.txtOperID.Size = new System.Drawing.Size(136, 22);
            this.txtOperID.TabIndex = 95;
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(64, 136);
            this.txtPwd.MaxLength = 6;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(136, 22);
            this.txtPwd.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 102;
            this.label1.Text = "密码";
            // 
            // txtOperName
            // 
            this.txtOperName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperName.Location = new System.Drawing.Point(64, 56);
            this.txtOperName.MaxLength = 10;
            this.txtOperName.Name = "txtOperName";
            this.txtOperName.Size = new System.Drawing.Size(136, 22);
            this.txtOperName.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 101;
            this.label2.Text = "名称";
            // 
            // cmbLimit
            // 
            this.cmbLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimit.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLimit.ItemHeight = 13;
            this.cmbLimit.Location = new System.Drawing.Point(64, 96);
            this.cmbLimit.Name = "cmbLimit";
            this.cmbLimit.Size = new System.Drawing.Size(136, 21);
            this.cmbLimit.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 100;
            this.label3.Text = "权限";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 99;
            this.label4.Text = "编号";
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(78, 171);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 104;
            this.sbtnAdd.Text = "添加";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // frmOperFirst
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(216, 206);
            this.Controls.Add(this.sbtnAdd);
            this.Controls.Add(this.txtOperID);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtOperName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOperFirst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建第一个操作员";
            this.Load += new System.EventHandler(this.frmOperFirst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmOperFirst_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbLimit,"LM2","vcCommName");
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			if(cmbLimit.Items.Count==0)
			{
				MessageBox.Show("权限参数有误，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			err=null;
			CMSMData.CMSMStruct.OperStruct ops1=new CMSMData.CMSMStruct.OperStruct();
			if(txtOperID.Text.Trim()==""||txtOperID.Text.Trim().Length>10)
			{
				MessageBox.Show("操作员编号不能为空且小于10位！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtOperID.Focus();
				return;
			}
			else if(!cs.ChkOperIDDup(txtOperID.Text.Trim(),out err))
			{
				ops1.strOperID=txtOperID.Text.Trim();
			}
			else
			{
				MessageBox.Show("该操作员编号已经存在！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

			err=null;
			if(txtOperName.Text.Trim()==""||txtOperName.Text.Trim().Length>5)
			{
				MessageBox.Show("操作员名称不能为空且小于5个字！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtOperName.Focus();
				return;
			}
			else if(!cs.ChkOperNameDup(txtOperName.Text.Trim(),out err))
			{
				ops1.strOperName=txtOperName.Text.Trim();
			}
			else
			{
				MessageBox.Show("该操作员名称已经存在！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

			if(txtPwd.Text.Trim()==""||txtPwd.Text.Trim().Length>6)
			{
				MessageBox.Show("密码小于等于6位字符！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtPwd.Focus();
				return;
			}
			else
			{
				ops1.strPwd=txtPwd.Text.Trim();
			}
			ops1.strLimit=this.GetColEn(cmbLimit.Text.Trim(),"LM");
			ops1.strDeptID=SysInitial.LocalDept;
			err=null;
			cs.InsertOper(ops1,out err);
			if(err!=null)
			{
				MessageBox.Show("添加操作员失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{
				DataRow dr=SysInitial.dsSys.Tables["Oper"].NewRow();
				dr["vcOperID"]=ops1.strOperID;
				dr["vcOperName"]=ops1.strOperName;
				dr["vcLimit"]=ops1.strLimit;
				dr["vcPwd"]=ops1.strPwd;
				dr["vcDeptID"]=ops1.strDeptID;
				SysInitial.dsSys.Tables["Oper"].Rows.Add(dr);

				MessageBox.Show("添加操作员成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.Close();
			}
		}
	}
}
