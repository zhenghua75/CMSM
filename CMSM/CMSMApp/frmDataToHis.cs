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
	/// Summary description for frmDataToHis.
	/// </summary>
	public class frmDataToHis : frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		CommAccess ca=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label3;
        private Button simpleButton1;
		Exception err;

		public frmDataToHis()
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "本功能将数据转移至历史信息库";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "现有数据月份";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(120, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(104, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "正在转移数据，请稍后......";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(268, 56);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "转移";
            this.simpleButton1.UseVisualStyleBackColor = true;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmDataToHis
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(408, 126);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDataToHis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据转移";
            this.Load += new System.EventHandler(this.frmDataToHis_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDataToHis_Load(object sender, System.EventArgs e)
		{
			this.label3.Visible=false;
			DataTable dtmonth=new DataTable();
			err=null;
			dtmonth=ca.GetCurrentMonth(out err);
			if(err!=null||dtmonth.Rows.Count>0)
			{
				this.FillComboBox(this.comboBox1,dtmonth,"curmonth","");
			}
			else
			{
				MessageBox.Show("加裁当前数据月份出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.label3.Visible=true;
			this.simpleButton1.Enabled=false;
			this.Refresh();
			string strmonth=this.comboBox1.Text.Trim();
			if(strmonth=="")
			{
				MessageBox.Show("加裁当前数据月份出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			bool flag=ca.AllDataToHis(strmonth,out err);
			if(err!=null||!flag)
			{
				MessageBox.Show("转移出错，请重试！\n" + err.ToString(),"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				MessageBox.Show("数据转移成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.comboBox1.Items.Clear();
				DataTable dtmonth=new DataTable();
				err=null;
				dtmonth=ca.GetCurrentMonth(out err);
				if(err!=null||dtmonth.Rows.Count>0)
				{
					this.FillComboBox(this.comboBox1,dtmonth,"curmonth","");
				}
				else
				{
					MessageBox.Show("刷新当前数据月份出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					this.Close();
				}
				this.label3.Visible=false;
				this.simpleButton1.Enabled=true;
				this.Refresh();
				return;
			}
		}

	}
}
