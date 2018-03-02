using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmOperQuery.
	/// </summary>
	public class frmOperQuery : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbOper;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label12;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnClose;

		CMSMData.CMSMDataAccess.CommAccess cs=new CMSMData.CMSMDataAccess.CommAccess(SysInitial.ConString);

		public frmOperQuery()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOper = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbOper);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 96);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(658, 57);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 40;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(569, 56);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 39;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(67, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(168, 20);
            this.cmbDept.TabIndex = 37;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(18, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "门店";
            // 
            // cmbOper
            // 
            this.cmbOper.Location = new System.Drawing.Point(67, 56);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.Size = new System.Drawing.Size(168, 20);
            this.cmbOper.TabIndex = 34;
            this.cmbOper.Text = "*";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(19, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 33;
            this.label11.Text = "操作员";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(363, 56);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(363, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(299, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(299, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "开始日期";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 96);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(848, 414);
            this.dataGrid1.TabIndex = 7;
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(749, 56);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 41;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmOperQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 510);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmOperQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作员记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOperQuery_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmOperQuery_Load(object sender, System.EventArgs e)
		{
			this.sbtnExcel.Enabled=false;
			if(SysInitial.CurOps.strLimit=="LM003")
			{
				this.FillComboBox(this.cmbDept,"MD","vcCommName","all");
				this.cmbDept.SelectedIndex=0;
			}
			else
			{
				string strDeptName=this.GetColCh(SysInitial.LocalDept,"MD");
				this.cmbDept.Items.Add(strDeptName);
				this.cmbDept.SelectedIndex=0;
				this.cmbDept.Enabled=false;
			}
			this.DgBind();
		}

		private void DgBind()
		{
			string strOperName=cmbOper.Text.Trim();
			if(strOperName=="全部")
			{
				strOperName="";
			}
			string strDeptID=cmbDept.Text.Trim();
			if(strDeptID=="全部")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";

			Exception err=null;
			DataTable dt=new DataTable();
			dt=cs.GetBusiLogQuery(strDeptID,strOperName,strBegin,strEnd,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");

				this.dataGrid1.CaptionText="操作员日志";
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("流水号,会员名称,会员类型,会员卡号,操作类型,操作员,操作日期,操作员门店,备注","120,100,80,80,100,100,120,180,200",dt,this.dataGrid1);
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
				MessageBox.Show("查询时出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
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

		private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(SysInitial.CurOps.strLimit=="LM003")
			{
				this.cmbOper.Items.Clear();
				DataTable dtOperList;
				Exception err=null;
				string strDeptID=this.cmbDept.Text;
				if(strDeptID=="全部")
				{
					this.cmbOper.Items.Add("全部");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
					dtOperList=cs.GetConsOperList("all",out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>=0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","");
					}
					this.cmbOper.SelectedIndex=0;
				}
				else if(this.GetColEn(strDeptID,"MD")==SysInitial.LocalDept)
				{
					this.cmbOper.Items.Add("全部");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
				}
				else
				{
					this.cmbOper.Items.Add("全部");
					strDeptID=this.GetColEn(this.cmbDept.Text,"MD");
					dtOperList=cs.GetConsOperList(strDeptID,out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName",strDeptID);
					}
					else
					{
						if(err!=null)
						{
							MessageBox.Show("系统错误，请重试！","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
							clog.WriteLine(err);
						}
						return;
					}
					this.cmbOper.SelectedIndex=0;
				}
			}
			else if(SysInitial.CurOps.strLimit=="LM001")
			{
				this.FillComboBox(this.cmbOper,"Oper","vcOperName","all");
			}
		}

	}
}
