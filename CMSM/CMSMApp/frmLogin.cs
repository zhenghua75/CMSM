using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using System.Web.Security;

namespace CMSM.CMSMApp
{    
    /// <summary>
    /// frmLogin 的摘要说明。
    /// </summary>
    public class frmLogin : CMSM.CMSMApp.frmBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.ComboBox cmbOper;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Button btOK;
        private Button btCancel;
        int incount = 0;

        public frmLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.cmbOper = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.cmbOper);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 200);
            this.panel1.TabIndex = 26;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point(141, 150);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 36;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.Location = new System.Drawing.Point(34, 150);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 35;
            this.btOK.Text = "登录";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 50);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(64, 112);
            this.txtPwd.MaxLength = 6;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(152, 21);
            this.txtPwd.TabIndex = 26;
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // cmbOper
            // 
            this.cmbOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOper.Location = new System.Drawing.Point(64, 72);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.Size = new System.Drawing.Size(152, 20);
            this.cmbOper.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(32, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "用户";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "密码";
            // 
            // frmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(255, 205);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员系统登录";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLogin_Closing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            this.FillOperComboBox(cmbOper, "Oper", "vcOperName");
            txtPwd.Text = "";
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btOK.PerformClick();
            }
        }

        private void sbtnCancel_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Process[] proSync = System.Diagnostics.Process.GetProcessesByName("AMSSync");
            if (proSync.Length > 0)
            {
                foreach (System.Diagnostics.Process p in proSync)
                {
                    p.Kill();
                }
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            incount++;
            if (incount == 4)
            {
                MessageBox.Show("密码错误次数超过3次，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Application.Exit();
            }
            string strOperName = cmbOper.Text.Trim();
            string strPwd = txtPwd.Text.Trim();
            DataRow[] drs = SysInitial.dsSys.Tables["Oper"].Select("vcOperName='" + strOperName + "'");
            if (drs == null || drs.Length == 0)
            {
                MessageBox.Show("请同步数据！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            DataRow dr = drs[0];
            bool validate = false;
            try
            {
                validate = System.Web.Security.Membership.ValidateUser(strOperName, strPwd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

            if (dr["vcLimit"].ToString() == "")
            {
                MessageBox.Show("对不起，你没有任何权限，请与管理员联系！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            if (validate)
            {
                incount = 0;
                bool IsDiscount = dr["IsDiscount"].ToString().ToLower() == "true";
                if (SysInitial.CurOps.strOperName == null)
                {
                    SysInitial.NewOps.strOperID = dr["vcOperID"].ToString();
                    SysInitial.NewOps.strOperName = dr["vcOperName"].ToString();
                    SysInitial.NewOps.strLimit = dr["vcLimit"].ToString();
                    SysInitial.NewOps.strDeptID = dr["vcDeptID"].ToString();
                    SysInitial.NewOps.IsDiscount = IsDiscount;
                }
                else
                {
                    SysInitial.ReLoginFlag = true;
                }
                SysInitial.CurOps.strOperID = dr["vcOperID"].ToString();
                SysInitial.CurOps.strOperName = dr["vcOperName"].ToString();
                SysInitial.CurOps.strLimit = dr["vcLimit"].ToString();
                SysInitial.CurOps.strDeptID = dr["vcDeptID"].ToString();
                SysInitial.CurOps.IsDiscount = IsDiscount;

                this.Close();
            }            
            else
            {
                MessageBox.Show("密码错误！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                txtPwd.Text = "";
                return;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
