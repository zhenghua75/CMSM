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
	/// Summary description for frmConsItemQuery.
	/// </summary>
	public class frmLargQuery : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAssCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtAssCount;
		private System.Windows.Forms.TextBox txtLCount;
		private System.Windows.Forms.TextBox txtGoodsCount;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmLargQuery()
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.txtAssCode = new System.Windows.Forms.TextBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGoodsCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sbtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 96);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(832, 326);
            this.dataGrid1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.txtAssCode);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(649, 53);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 39;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(568, 53);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 38;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // txtAssCode
            // 
            this.txtAssCode.Location = new System.Drawing.Point(78, 24);
            this.txtAssCode.MaxLength = 7;
            this.txtAssCode.Name = "txtAssCode";
            this.txtAssCode.Size = new System.Drawing.Size(128, 21);
            this.txtAssCode.TabIndex = 37;
            this.txtAssCode.Text = "*";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(78, 56);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(136, 20);
            this.cmbDept.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(14, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "门店";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(366, 56);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(366, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(302, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(302, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "开始日期";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "会员卡号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGoodsCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtLCount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAssCount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 64);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "汇总统计";
            // 
            // txtGoodsCount
            // 
            this.txtGoodsCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGoodsCount.Location = new System.Drawing.Point(552, 24);
            this.txtGoodsCount.Name = "txtGoodsCount";
            this.txtGoodsCount.Size = new System.Drawing.Size(100, 22);
            this.txtGoodsCount.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(464, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "赠送商品数：";
            // 
            // txtLCount
            // 
            this.txtLCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLCount.Location = new System.Drawing.Point(320, 24);
            this.txtLCount.Name = "txtLCount";
            this.txtLCount.Size = new System.Drawing.Size(100, 22);
            this.txtLCount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(232, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "赠送总次数：";
            // 
            // txtAssCount
            // 
            this.txtAssCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssCount.Location = new System.Drawing.Point(96, 24);
            this.txtAssCount.Name = "txtAssCount";
            this.txtAssCount.Size = new System.Drawing.Size(100, 22);
            this.txtAssCount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "赠送会员数：";
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(730, 53);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 40;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmLargQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(832, 486);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLargQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员赠送查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLargQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmLargQuery_Load(object sender, System.EventArgs e)
		{
			this.sbtnExcel.Enabled=false;
			if(SysInitial.CurOps.strLimit=="LM003"&&SysInitial.MainDept)
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
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void DgBind()
		{
            string strAssCode=txtAssCode.Text.ToString();
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			string strDeptID=this.cmbDept.Text.Trim();
			if (strAssCode=="*")
			{
				strAssCode="";
			}
			if(strDeptID=="全部")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			Hashtable htPara=new Hashtable();
			htPara.Add("strAssCode",strAssCode);
			htPara.Add("strBegin",strBegin);
			htPara.Add("strEnd",strEnd);
			htPara.Add("strDeptID",strDeptID);

			Exception err=null;
			DataSet dsout=new DataSet();
			this.txtAssCount.Text="0";
			this.txtLCount.Text="0";
			this.txtGoodsCount.Text="0";

			dsout=cs.GetLargQuery(htPara,out err);
			if(dsout.Tables["cons1"]!=null&&dsout.Tables["cons1"].Rows.Count>=0)
			{
				this.dataGrid1.CaptionText="赠送会员消费统计报表";
				this.dataGrid1.SetDataBinding(dsout.Tables["cons1"],"");
				this.DataTableConvert(dsout.Tables["cons1"],"VcGoodsID","Goods","VcGoodsID","vcGoodsName");
				this.DataTableConvert(dsout.Tables["cons1"],"vcDeptID","MD","vcCommCode","vcCommName");
				this.EnToCh("会员姓名,会员卡号,商品名称,数量,赠送日期,操作员,部门","100,100,100,100,150,100,100",dsout.Tables["cons1"],this.dataGrid1);
				
				if(dsout.Tables["cons1"].Rows.Count>0)
				{
					this.sbtnExcel.Enabled=true;
				}
				else
				{
					this.sbtnExcel.Enabled=false;
				}

				if(dsout.Tables["cons2"]!=null&&dsout.Tables["cons2"].Rows.Count>=0)
				{
					this.txtAssCount.Text=dsout.Tables["cons2"].Rows[0]["asscount"].ToString();
					this.txtLCount.Text=dsout.Tables["cons1"].Rows.Count.ToString();
					this.txtGoodsCount.Text=dsout.Tables["cons2"].Rows[0]["goodscount"].ToString();
				}
			}
			else
			{
				MessageBox.Show("赠送会员查询出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}
		private void txtAssCard_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8||e.KeyChar==42)
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)
				{
					e.Handled=true;
					return;
				}
			}
			else
			{
				this.DgBind();
			}
		}


		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
						if(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="数量合计"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="金额合计")
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "double,";
						}
						else
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
						}
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
	}
}
