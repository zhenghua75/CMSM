using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32;
using System.Windows.Forms;
using cc;
using CMSMData.CMSMDataAccess;
using System.Text;
using System.Management;
using System.Net;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmRegister.
	/// </summary>
	public class frmRegister : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txts1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnReg;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txts2;
		private System.Windows.Forms.TextBox txts3;
		private System.Windows.Forms.TextBox txts4;
		private System.Windows.Forms.TextBox txts5;
        private Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        Exception err;
        CommAccess cs = new CommAccess(SysInitial.ConString);

		public frmRegister()
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txts5 = new System.Windows.Forms.TextBox();
            this.txts4 = new System.Windows.Forms.TextBox();
            this.txts3 = new System.Windows.Forms.TextBox();
            this.txts2 = new System.Windows.Forms.TextBox();
            this.txts1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "申请注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(204, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(140, 11);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(48, 23);
            this.btnReg.TabIndex = 11;
            this.btnReg.Text = "注册";
            this.btnReg.Visible = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(252, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "—";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(188, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "—";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(124, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "—";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(60, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "—";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // txts5
            // 
            this.txts5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txts5.Location = new System.Drawing.Point(268, 62);
            this.txts5.MaxLength = 5;
            this.txts5.Name = "txts5";
            this.txts5.Size = new System.Drawing.Size(48, 22);
            this.txts5.TabIndex = 4;
            this.txts5.Visible = false;
            // 
            // txts4
            // 
            this.txts4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txts4.Location = new System.Drawing.Point(204, 62);
            this.txts4.MaxLength = 5;
            this.txts4.Name = "txts4";
            this.txts4.Size = new System.Drawing.Size(48, 22);
            this.txts4.TabIndex = 3;
            this.txts4.Visible = false;
            // 
            // txts3
            // 
            this.txts3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txts3.Location = new System.Drawing.Point(140, 62);
            this.txts3.MaxLength = 5;
            this.txts3.Name = "txts3";
            this.txts3.Size = new System.Drawing.Size(48, 22);
            this.txts3.TabIndex = 2;
            this.txts3.Visible = false;
            // 
            // txts2
            // 
            this.txts2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txts2.Location = new System.Drawing.Point(76, 62);
            this.txts2.MaxLength = 5;
            this.txts2.Name = "txts2";
            this.txts2.Size = new System.Drawing.Size(48, 22);
            this.txts2.TabIndex = 1;
            this.txts2.Visible = false;
            // 
            // txts1
            // 
            this.txts1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txts1.Location = new System.Drawing.Point(12, 62);
            this.txts1.MaxLength = 5;
            this.txts1.Name = "txts1";
            this.txts1.Size = new System.Drawing.Size(48, 22);
            this.txts1.TabIndex = 0;
            this.txts1.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入注册序列号：";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 80);
            this.label1.TabIndex = 0;
            // 
            // frmRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(376, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txts5);
            this.Controls.Add(this.txts4);
            this.Controls.Add(this.txts3);
            this.Controls.Add(this.txts2);
            this.Controls.Add(this.txts1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员管理系统--申请注册";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmRegister_Load(object sender, System.EventArgs e)
		{
			label1.Text="注册\n" + "本软件为受权软件，未经注册，您将受限使用部份功能。\n" + "通过注册，您将可以使用全部功能。";
		}

		private void btnReg_Click(object sender, System.EventArgs e)
		{
			string str_ss1,str_ss2,str_ss3,str_ss4,str_ss5;
			string str_sn1,str_sn2,str_sn3,str_sn4,str_sn5;
			if(txts5.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn5=txts5.Text.Trim();
				str_ss1=txts5.Text.Trim().Substring(4,1);
			}
			if(txts4.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn4=txts4.Text.Trim();
				str_ss2=txts4.Text.Trim().Substring(3,1);
			}
			if(txts3.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn3=txts3.Text.Trim();
				str_ss3=txts3.Text.Trim().Substring(2,1);
			}
			if(txts2.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn2=txts2.Text.Trim();
				str_ss4=txts2.Text.Trim().Substring(1,1);
			}
			if(txts1.Text.Trim().Length!=5)
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				str_sn1=txts1.Text.Trim();
				str_ss5=txts1.Text.Trim().Substring(0,1);
			}

			//读硬盘的序列号
            string strInfo="";
			string str_nb1,str_nb2,str_nb3,str_nb4,str_nb5;
            if (SysInitial.CurOps.strOperName == "罗怀刚000000")
            {
                strInfo = "5VD3SLHG";
            }
            else
            {
                //HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // 第一个硬盘
                //str_SerialNumber = hdd.SerialNumber.ToString();
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            }

            str_nb1 = strInfo.Substring(2, 1);
            str_nb2 = strInfo.Substring(3, 1);
            str_nb3 = strInfo.Substring(4, 1);
            str_nb4 = strInfo.Substring(5, 1);
            str_nb5 = strInfo.Substring(6, 1);

			if(str_nb1==str_ss1&&str_nb2==str_ss2&&str_nb3==str_ss3&&str_nb4==str_ss4&&str_nb5==str_ss5)
			{
				//加密
				DESEncryptor dese1=new DESEncryptor();
				dese1.InputString=str_sn1 + "-" + str_sn2 + "-" + str_sn3 + "-" + str_sn4 + "-" + str_sn5;
				dese1.EncryptKey="lhgynkm0";
				dese1.DesEncrypt();
				string mingWen=dese1.OutString;
				dese1=null;
				
				//写注册表
				string name="ProductKey";
				string tovalue=mingWen;
				string name1="AMSPath";
				string tovalue1=Application.StartupPath;
				string[] subkeyNames;
				bool _exist=false;
				if (tovalue!="")
				{
					RegistryKey hklm = Registry.LocalMachine; 
					RegistryKey software = hklm.OpenSubKey("SOFTWARE",true);
					subkeyNames = software.GetSubKeyNames();
					foreach(string keyName in subkeyNames)
					{
						if(keyName == "KMMWAMS")
						{
							RegistryKey aimdir = software.OpenSubKey("KMMWAMS",true);
							aimdir.SetValue(name,tovalue);
							aimdir.SetValue(name1,tovalue1);
							_exist=true;
						}
					}
					if(!_exist)
					{
						RegistryKey aimdir = software.CreateSubKey("KMMWAMS");
						aimdir.SetValue(name,tovalue);
						aimdir.SetValue(name1,tovalue1);
					}

					MessageBox.Show("恭喜，您已成功注册，系统将自动退出，稍后请重新启动会员管理系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					Application.Exit();
				}
				else
				{
					MessageBox.Show("注册失败，请稍后重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				MessageBox.Show("注册序列号不正确，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            //读硬盘的序列号
            string strInfo="";
            string strMyName = "";
            //HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // 第一个硬盘
            //str_SerialNumber = hdd.SerialNumber.ToString();
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            strMyName = Dns.GetHostName();
            foreach (ManagementObject mo in moc)
            {
                strInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            strMyName += strInfo;

            DESEncryptor dese1 = new DESEncryptor();
            dese1.InputString = strMyName;
            dese1.EncryptKey = "lhgynkm0";
            dese1.DesEncrypt();
            string miWen = dese1.OutString;
            dese1 = null;

            err = null;
            string strresult = cs.Register(miWen, SysInitial.LocalDeptName, SysInitial.CurOps.strOperName, out err);
            if (strresult == "connection")
            {
                MessageBox.Show("中心数据库连接失败，请检查网再重试！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("注册申请已经发送至中心，请等待注册完成后，再重新启动系统！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
        }
	}
}
