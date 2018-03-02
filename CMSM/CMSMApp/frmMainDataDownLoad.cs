using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;
using cc;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmMainDataDownLoad.
	/// </summary>
	public class frmMainDataDownLoad : frmBase
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.ComponentModel.IContainer components=null;

		CommAccess ca=new CommAccess(SysInitial.ConString);
        Exception err = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private Button sbtnOk;
		StructToString sts=new StructToString();

		public frmMainDataDownLoad()
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(8, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(416, 280);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "下载时间：从";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(251, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "到现在";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "提示：总店只会下载会员资料";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(283, 40);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 26;
            this.sbtnOk.Text = "开始下载";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // frmMainDataDownLoad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(432, 392);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainDataDownLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "总店数据下载";
            this.Load += new System.EventHandler(this.frmMainDataDownLoad_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMainDataDownLoad_Load(object sender, System.EventArgs e)
		{
			this.label3.ForeColor=Color.Red;
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();

			string downFileName="down" + SysInitial.LocalDept + ".L00";
			string filePath=@"E:\\BreadWorksDataBak\\DownLoad\\";
			string strYDate=this.dateTimePicker1.Value.Year.ToString();
			string strMDate=this.dateTimePicker1.Value.Month.ToString();
			string strDDate=this.dateTimePicker1.Value.Day.ToString();
			if(strMDate.Length<2)
			{
				strMDate="0"+strMDate;
			}
			if(strDDate.Length<2)
			{
				strDDate="0"+strDDate;
			}
			string strBeginDate=strYDate+"-"+strMDate+"-"+strDDate;

//			ArrayList alDown=new ArrayList();

			if(!System.IO.Directory.Exists(filePath))
			{
				System.IO.Directory.CreateDirectory(filePath);
			}
			else
			{
				string[] fileall=Directory.GetFiles(filePath);
				if(fileall.Length>0)
				{
					for(int i=0;i<fileall.Length;i++)
					{
						System.IO.File.Delete(fileall[i]);
					}
				}
			}

			#region 下载
			this.listBox1.Items.Add("开始下载...");
			this.listBox1.Items.Add("\n");
//			err=null;
//			ca.DownMainDeptData(strBeginDate,downFileName,out err);

			#region 加载会员资料
			this.listBox1.Items.Add("加载会员资料...");
			this.Refresh();
			ArrayList alDownUser=new ArrayList();
			err=null;
			alDownUser=ca.DownAssData(strBeginDate,out err);
			if(alDownUser==null||err!=null)
			{
				MessageBox.Show("加载会员资料错误，请重试！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}
			#endregion

//			#region 加载会员资料变更记录
//			this.listBox1.Items.Add("加载会员资料变更记录...");
//			this.Refresh();
//			ArrayList alDownUserAlter=new ArrayList();
//			err=null;
//			alDownUserAlter=ca.DownAssChange(strBeginDate,out err);
//			if(alDownUserAlter==null||err!=null)
//			{
//				MessageBox.Show("加载会员资料变更记录错误，请重试！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
//				if(err!=null)
//				{
//					clog.WriteLine(err);
//				}
//				return;
//			}
//			#endregion

			StreamWriter swFile = new StreamWriter(filePath+downFileName+".tmp",true);

			#region 写会员资料
			CMSMStruct.AssociatorStruct asstmp=null;
			swFile.WriteLine("USERTOL=" + alDownUser.Count.ToString());
			for(int i=0;i<alDownUser.Count;i++)
			{
				asstmp=alDownUser[i] as CMSMStruct.AssociatorStruct;
				swFile.WriteLine(sts.ToAssString(asstmp));
			}
			swFile.WriteLine("END");
			this.listBox1.Items.Add("下载会员资料记录数：" + alDownUser.Count.ToString());
			#endregion

//			#region 写会员资料变更记录
//			CMSMStruct.AssChangeStruct assChange=null;
//			swFile.WriteLine("ALTETOL=" + alDownUserAlter.Count.ToString());
//			for(int i=0;i<alDownUserAlter.Count;i++)
//			{
//				assChange=alDownUserAlter[i] as CMSMStruct.AssChangeStruct;
//				swFile.WriteLine(sts.ToAssChangeString(assChange));
//			}
//			swFile.WriteLine("END");
//			this.listBox1.Items.Add("下载会员资料变更记录数：" + alDownUserAlter.Count.ToString());
//			#endregion

			swFile.Close();

			//加密
			DESEncryptor dese=new DESEncryptor();
			dese.InputFilePath=filePath+downFileName+".tmp";
			dese.OutFilePath=filePath+downFileName;
			dese.EncryptKey="cmsmyykx";
			dese.FileDesEncrypt();
			if(dese.NoteMessage!=null)
			{
				MessageBox.Show("下载文件处理出错，请重试！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				this.clog.WriteLine(dese.NoteMessage);
				return;
			}
			dese=null;
			if(System.IO.File.Exists(filePath+downFileName+".tmp"))
				System.IO.File.Delete(filePath+downFileName+".tmp");

//			if(err!=null)
//			{
//				this.listBox1.Items.Add("下载数据失败，请重试！");
//				this.listBox1.Items.Add(err.ToString());
//				return;
//			}
			this.listBox1.Items.Add("\n");
			this.listBox1.Items.Add(strBeginDate + "以后的数据已经下载完成！");
			this.Refresh();
			#endregion

		}
	}
}
