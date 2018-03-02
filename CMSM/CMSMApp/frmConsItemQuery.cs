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
	public class frmConsItemQuery : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbAssType;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbGoodsType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTolRate;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmConsItemQuery()
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTolRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGoodsType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAssType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTolRate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFee);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 56);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "汇总数据";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(816, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "元";
            // 
            // txtTolRate
            // 
            this.txtTolRate.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTolRate.Location = new System.Drawing.Point(680, 24);
            this.txtTolRate.Name = "txtTolRate";
            this.txtTolRate.Size = new System.Drawing.Size(136, 22);
            this.txtTolRate.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(616, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "折扣总计";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(528, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "元";
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFee.Location = new System.Drawing.Point(392, 24);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(136, 22);
            this.txtFee.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(328, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "金额总计";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(96, 24);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 22);
            this.txtCount.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "数量总计";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 152);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(908, 278);
            this.dataGrid1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbGoodsType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAssType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 152);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(781, 60);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 40;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(696, 60);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 39;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(611, 60);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 38;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(40, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 48);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择要查询的列";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(36, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "门店";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(191, 16);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(112, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "商品类型";
            // 
            // checkBox2
            // 
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(120, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "会员类型";
            this.checkBox2.Visible = false;
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(656, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(144, 20);
            this.cmbDept.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(608, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "门店";
            // 
            // cmbGoodsType
            // 
            this.cmbGoodsType.Location = new System.Drawing.Point(104, 64);
            this.cmbGoodsType.Name = "cmbGoodsType";
            this.cmbGoodsType.Size = new System.Drawing.Size(168, 20);
            this.cmbGoodsType.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(40, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "商品类型";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(392, 56);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(392, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(328, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(328, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "开始日期";
            // 
            // cmbAssType
            // 
            this.cmbAssType.Enabled = false;
            this.cmbAssType.Location = new System.Drawing.Point(104, 24);
            this.cmbAssType.Name = "cmbAssType";
            this.cmbAssType.Size = new System.Drawing.Size(168, 20);
            this.cmbAssType.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "会员类型";
            // 
            // frmConsItemQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(908, 486);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsItemQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消费分类统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsItemQuery_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmConsItemQuery_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbAssType,"AT","vcCommName","all");
			this.FillComboBox(cmbGoodsType,"GT","vcCommName","all");
			this.sbtnExcel.Enabled=false;
//			if(SysInitial.CurOps.strLimit=="LM003"&&SysInitial.MainDept)
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

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void DgBind()
		{
			string strAssType=cmbAssType.Text.Trim();
			if(strAssType=="全部")
			{
				strAssType="";
			}
			else
			{
				strAssType=this.GetColEn(strAssType,"AT");
			}

			string strGoodsType=cmbGoodsType.Text.Trim();
			if(strGoodsType=="全部")
			{
				strGoodsType="";
			}
			else
			{
				strGoodsType=this.GetColEn(strGoodsType,"GT");
			}
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			string strDeptID=this.cmbDept.Text.Trim();
			if(strDeptID=="全部")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			Hashtable htPara=new Hashtable();
			htPara.Add("strAssType",strAssType);
			htPara.Add("strGoodsType",strGoodsType);
			htPara.Add("strBegin",strBegin);
			htPara.Add("strEnd",strEnd);
			htPara.Add("strDeptID",strDeptID);

			Exception err=null;
			DataTable dt=new DataTable();
			string strType1="";

			if (checkBox1.Checked==true && checkBox2.Checked==true &&checkBox3.Checked==true)
			{
                //dt=cs.GetConsItemQuery(htPara,out err);
                //strType1="0";
                return;
			}
			if (checkBox1.Checked==true && checkBox2.Checked==false &&checkBox3.Checked==false)
			{
				dt=cs.GetConsItemQuery1(htPara,out err);
				strType1="1";
			}
			if (checkBox1.Checked==false && checkBox2.Checked==true &&checkBox3.Checked==false)
			{
				dt=cs.GetConsItemQuery2(htPara,out err);
				strType1="2";
			}
			if (checkBox1.Checked==false && checkBox2.Checked==false &&checkBox3.Checked==true)
			{
				dt=cs.GetConsItemQuery3(htPara,out err);
				strType1="3";
			}
			if (checkBox1.Checked==false && checkBox2.Checked==true &&checkBox3.Checked==true)
			{
				dt=cs.GetConsItemQuery4(htPara,out err);
				strType1="4";
			}
			if (checkBox1.Checked==true && checkBox2.Checked==true &&checkBox3.Checked==false)
			{
				dt=cs.GetConsItemQuery5(htPara,out err);
				strType1="5";
			}
			if (checkBox1.Checked==true && checkBox2.Checked==false &&checkBox3.Checked==true)
			{
				dt=cs.GetConsItemQuery6(htPara,out err);
				strType1="6";
			}
			if (checkBox1.Checked==false && checkBox2.Checked==false &&checkBox3.Checked==false)
			{
                //dt=cs.GetConsItemQuery(htPara,out err);
                //strType1="0";
                return;
			}

			if(dt!=null&&dt.Rows.Count>=0)
			{
				int iCount=0;
				double dFee=0;
				double dRate=0;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					iCount+=int.Parse(dt.Rows[i]["tolcount"].ToString());
					dFee+=double.Parse(dt.Rows[i]["tolfee"].ToString());
					dRate+=double.Parse(dt.Rows[i]["tolrate"].ToString());
				}
				txtCount.Text=iCount.ToString();
				txtFee.Text=Math.Round(dFee,2).ToString();
				txtTolRate.Text=Math.Round(dRate,2).ToString();
				this.dataGrid1.CaptionText="会员消费分类统计报表";
				this.dataGrid1.SetDataBinding(dt,"");
				if (strType1=="0")
				{
					this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
					this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
					this.EnToCh("门店,会员类型,商品类型,商品名称,数量合计,金额合计,折扣合计","100,100,100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="1")
				{
					this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
					this.EnToCh("门店,商品名称,数量合计,金额合计,折扣合计","100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="2")
				{
					this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
					this.EnToCh("会员类型,商品类型,数量合计,金额合计,折扣合计","100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="3")
				{
					this.EnToCh("商品类型,商品名称,数量合计,金额合计,折扣合计","100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="4")
				{
					this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
					this.EnToCh("会员类型,商品类型,商品名称,数量合计,金额合计,折扣合计","100,100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="5")
				{
					this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
					this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
					this.EnToCh("门店,会员类型,商品名称,数量合计,金额合计,折扣合计","100,100,100,100,100",dt,this.dataGrid1);
				}
				if (strType1=="6")
				{
					this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
					this.EnToCh("门店,商品类型,商品名称,数量合计,金额合计,折扣合计","100,100,100,100,100",dt,this.dataGrid1);
				}
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
						if(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="数量合计"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="金额合计"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="折扣合计")
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
