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
	/// Summary description for frmBespeakLog.
	/// </summary>
	public class frmBespeakLog : CMSM.CMSMApp.frmBase
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DateTimePicker dtpBes;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.ComboBox cmbFlag;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtphone;
		private System.Windows.Forms.TextBox txtBesCom;
		private System.Windows.Forms.TextBox txtCount;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid dataGrid1;
        private Button sbtnBes;
        private Button sbtnCancel;
        private Button sbtnExcel;
        private Button sbtnQuery;
        private Button sbtnClose;

		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmBespeakLog()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.sbtnBes = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBesCom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFlag = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpBes = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnBes);
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtBesCom);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbFlag);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtpBes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 136);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(801, 108);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 57;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // sbtnBes
            // 
            this.sbtnBes.Location = new System.Drawing.Point(691, 108);
            this.sbtnBes.Name = "sbtnBes";
            this.sbtnBes.Size = new System.Drawing.Size(75, 23);
            this.sbtnBes.TabIndex = 56;
            this.sbtnBes.Text = "下订(F5)";
            this.sbtnBes.UseVisualStyleBackColor = true;
            this.sbtnBes.Click += new System.EventHandler(this.sbtnBes_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(213, 108);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 55;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(122, 108);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 54;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(30, 108);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 53;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(632, 80);
            this.txtCount.MaxLength = 3;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(40, 22);
            this.txtCount.TabIndex = 49;
            this.txtCount.Text = "1";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(592, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "数量";
            // 
            // txtBesCom
            // 
            this.txtBesCom.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBesCom.Location = new System.Drawing.Point(656, 48);
            this.txtBesCom.MaxLength = 200;
            this.txtBesCom.Name = "txtBesCom";
            this.txtBesCom.Size = new System.Drawing.Size(280, 22);
            this.txtBesCom.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(592, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "订购内容";
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtphone.Location = new System.Drawing.Point(456, 80);
            this.txtphone.MaxLength = 20;
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(120, 22);
            this.txtphone.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(392, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "联系电话";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(456, 48);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 22);
            this.txtName.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(528, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "非会员输入：0";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Location = new System.Drawing.Point(312, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "下订栏目";
            // 
            // cmbFlag
            // 
            this.cmbFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlag.Location = new System.Drawing.Point(80, 80);
            this.cmbFlag.Name = "cmbFlag";
            this.cmbFlag.Size = new System.Drawing.Size(128, 20);
            this.cmbFlag.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "订购状态";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(80, 48);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(128, 21);
            this.dtpEnd.TabIndex = 38;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(80, 16);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(128, 21);
            this.dtpBegin.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "结束日期";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(16, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 35;
            this.label12.Text = "开始日期";
            // 
            // dtpBes
            // 
            this.dtpBes.Location = new System.Drawing.Point(752, 80);
            this.dtpBes.Name = "dtpBes";
            this.dtpBes.Size = new System.Drawing.Size(124, 21);
            this.dtpBes.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(688, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "送货日期";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(392, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "会员姓名";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(456, 16);
            this.txtCardID.MaxLength = 5;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(64, 22);
            this.txtCardID.TabIndex = 17;
            this.txtCardID.Text = "0";
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(392, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "会员卡号";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 136);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(944, 342);
            this.dataGrid1.TabIndex = 6;
            // 
            // frmBespeakLog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 478);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBespeakLog";
            this.Text = "订购日志";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBespeakLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmBespeakLog_Load(object sender, System.EventArgs e)
		{
//			this.cmbFlag.Text="全部";
//			this.cmbFlag.Items.Add("全部");
//			this.cmbFlag.Items.Add("已下订");
//			this.cmbFlag.Items.Add("已完成");
//			this.cmbFlag.Items.Add("已取消");
			this.FillComboBox(this.cmbFlag,"BF","vcCommName","all");
			this.sbtnExcel.Enabled=false;
			this.DgBind();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void DgBind()
		{
			Hashtable htPara=new Hashtable();
			string strBesFlag=cmbFlag.Text.Trim();
			if(cmbFlag.Text=="全部" || cmbFlag.Text.Trim()=="")
			{
				strBesFlag="";
			}
			else if(cmbFlag.Text=="已下订")
			{
				strBesFlag="0";
			}
			else if(cmbFlag.Text=="已完成")
			{
				strBesFlag="2";
			}
			else if(cmbFlag.Text=="已取消")
			{
				strBesFlag="1";
			}
//			else
//			{
//				strBesFlag=this.GetColEn(strBesFlag,"BF");
//			}
			htPara.Add("strBesFlag",strBesFlag);
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			htPara.Add("strBegin",strBegin);
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			htPara.Add("strEnd",strEnd);

			Exception err=null;
			DataTable dt=new DataTable();
			dt=cs.GetBespeaksQuery(htPara,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");

				this.dataGrid1.CaptionText="订购日志";
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("流水号,会员卡号,订购人,联系电话,订购内容,数量,下订日期,送货日期,操作员,操作员门店,订购状态,完成日期","50,50,80,100,150,50,80,80,80,80,80,80",dt,this.dataGrid1);
				if(dt.Rows.Count>0)
				{
					this.sbtnExcel.Enabled=true;
				}
				else
				{
					this.sbtnExcel.Enabled=false;
				}
			}
			else
			{
				MessageBox.Show("查询出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnExcel_Click(object sender, System.EventArgs e)
		{
			DataTable dt=new DataTable();
			dt=(DataTable)this.dataGrid1.DataSource;
			string table="";
			if(dt!=null && dt.Rows.Count>0)
			{							
				for(int i=0;i<dt.Columns.Count;i++)
				{
					if(dataGrid1.TableStyles[0].GridColumnStyles[i].Width>0)
					{
						table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
					}		
				}
			}
			else
			{
				MessageBox.Show("表格没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}

		private void sbtnOK_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("没有选中要订购任务！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			string strBesFlag=dataGrid1[dataGrid1.CurrentRowIndex,10].ToString();
			if(strBesFlag!="已下订")
			{
				MessageBox.Show("所选任务必须是已下订状态！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			string strSerialNo=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
			Exception err=null;
			string strresult=cs.BespeakOk(strSerialNo,out err);
			if(err!=null)
			{
				MessageBox.Show("订购完成失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err + "\n" + strresult);
			}
			else
			{
				MessageBox.Show("订购完成成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("没有选中要订购任务！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			string strBesFlag=dataGrid1[dataGrid1.CurrentRowIndex,10].ToString();
			if(strBesFlag!="已下订")
			{
				MessageBox.Show("所选任务必须是已下订状态！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			string strSerialNo=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
			Exception err=null;
			string strresult=cs.BespeakCancel(strSerialNo,out err);
			if(err!=null)
			{
				MessageBox.Show("订购取消失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err + "\n" + strresult);
			}
			else
			{
				MessageBox.Show("订购取消成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.DgBind();
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnBes_Click(object sender, System.EventArgs e)
		{
			Hashtable htPara=new Hashtable();
			string strCardID=txtCardID.Text.Trim();
			if(strCardID=="")
			{
				MessageBox.Show("卡号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(strCardID=="0")
			{
				strCardID="V9999";
			}
			htPara.Add("strCardID",strCardID);

			string strName=txtName.Text.Trim();
			if(strName=="")
			{
				MessageBox.Show("订购人姓名不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			htPara.Add("strName",strName);

			string strPhone=txtphone.Text.Trim();
			if(strPhone=="")
			{
				MessageBox.Show("联系电话不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			htPara.Add("strPhone",strPhone);

			string strComments=txtBesCom.Text.Trim();
			if(strComments=="")
			{
				MessageBox.Show("订购内容不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			htPara.Add("strComments",strComments);

			string strCount=txtCount.Text.Trim();
			if(strCount=="")
			{
				MessageBox.Show("订购数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			htPara.Add("strCount",strCount);

			string strFinal=dtpBes.Value.ToShortDateString();
			htPara.Add("strFinal",strFinal);

			Exception err=null;
			string strresult=cs.BespeakInsert(htPara,out err);
			if(err!=null)
			{
				MessageBox.Show("订购下订失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err + "\n" + strresult);
			}
			else
			{
				MessageBox.Show("订购下订成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.DgBind();
			}
		}

		private void txtCardID_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strCardID=txtCardID.Text.Trim();
				if(strCardID=="0")
				{
					txtName.Text="";
					txtphone.Text="";
				}
				else
				{
					Exception err=null;
					CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
					assres=cs.GetAssociatorName(strCardID,out err);
					if(assres==null||err!=null)
					{
						txtName.Text=assres.strAssName;
						txtphone.Text=assres.strLinkPhone;
					}
					else
					{
						txtName.Text="";
						txtphone.Text="";
					}
				}
			}
		}
	}
}
