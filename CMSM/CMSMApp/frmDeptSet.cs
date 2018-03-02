using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using CMSMData;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmDeptSet.
	/// </summary>
	public class frmDeptSet : frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Button sbtnOk;

		CommAccess ca=new CommAccess(SysInitial.ConString);

		public frmDeptSet()
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "店名";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "本设置是确定本店店名信息，只设置一次";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(72, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 20);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "comboBox1";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(137, 79);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 22;
            this.sbtnOk.Text = "确定";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // frmDeptSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(272, 110);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeptSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置本门店信息";
            this.Load += new System.EventHandler(this.frmDeptSet_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDeptSet_Load(object sender, System.EventArgs e)
		{
			this.label3.ForeColor=Color.Red;
			this.FillComboBox(comboBox1,"MD","vcCommName");
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			string strDeptName=this.comboBox1.Text;
			string strDeptID=this.GetColEn(strDeptName,"MD");
			Exception err=null;
			ca.SetLocalDept(strDeptName,strDeptID,out err);
			if(err!=null)
			{
				MessageBox.Show("设置本地门店出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				Application.Exit();
			}
			else
			{
				SysInitial.LocalDept=strDeptID;
				this.Close();
			}
		}
	}
}
