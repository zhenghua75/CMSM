using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmSpecialCons.
	/// </summary>
	public class frmSpecialCons : CMSM.CMSMApp.frmBase
	{
		static public SqlConnection con=new SqlConnection();
		static public string TP="";
        static public string ConString = SysInitial.ConString;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtTolCharge;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtBalance;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtPay;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblNotice;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataTable dtConsItem;
        CommAccess cs = new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label17;
		Exception err;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbSepcialType;
        private Button sbtnOk;
        private Button sbtnRollback;
        private Button sbtnAdd;
        private Button sbtnCancel;
		private int SpecTypeIndex=-10;

		public frmSpecialCons()
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTolCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.cmbSepcialType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGoodsID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(232, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(672, 514);
            this.dataGrid1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTolCharge);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTolCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(232, 514);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 64);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消耗合计：";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(512, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "元";
            // 
            // txtTolCharge
            // 
            this.txtTolCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCharge.Location = new System.Drawing.Point(416, 24);
            this.txtTolCharge.MaxLength = 10;
            this.txtTolCharge.Name = "txtTolCharge";
            this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
            this.txtTolCharge.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(352, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "总金额：";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(152, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(88, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "总数量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.sbtnOk);
            this.groupBox1.Controls.Add(this.cmbSepcialType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.txtAssID);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPay);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 578);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消耗栏目";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(141, 288);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 33;
            this.sbtnCancel.Text = "关闭";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(141, 224);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 32;
            this.sbtnAdd.Text = "添加";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(18, 224);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 31;
            this.sbtnRollback.Text = "<<撤消";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(18, 288);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(110, 23);
            this.sbtnOk.TabIndex = 30;
            this.sbtnOk.Text = "特殊处理确定(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // cmbSepcialType
            // 
            this.cmbSepcialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSepcialType.Location = new System.Drawing.Point(80, 32);
            this.cmbSepcialType.Name = "cmbSepcialType";
            this.cmbSepcialType.Size = new System.Drawing.Size(136, 20);
            this.cmbSepcialType.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 29;
            this.label1.Text = "特殊处理类型";
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(112, 424);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(64, 21);
            this.txtCardID.TabIndex = 27;
            // 
            // txtAssID
            // 
            this.txtAssID.Location = new System.Drawing.Point(16, 424);
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.Size = new System.Drawing.Size(64, 21);
            this.txtAssID.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(192, 344);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "元";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(80, 376);
            this.txtBalance.MaxLength = 10;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(136, 21);
            this.txtBalance.TabIndex = 6;
            this.txtBalance.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(32, 384);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "找零";
            this.label16.Visible = false;
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(80, 336);
            this.txtPay.MaxLength = 10;
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(112, 21);
            this.txtPay.TabIndex = 5;
            this.txtPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPay_KeyPress);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 344);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "付费金额";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(192, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "元";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(80, 184);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 21);
            this.txtCount.TabIndex = 2;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "数量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 144);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 21);
            this.txtPrice.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "单价";
            // 
            // lblNotice
            // 
            this.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Location = new System.Drawing.Point(24, 464);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(192, 120);
            this.lblNotice.TabIndex = 13;
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(80, 104);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
            this.cmbGoodsName.TabIndex = 0;
            this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(80, 64);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 21);
            this.txtGoodsID.TabIndex = 15;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "商品编号";
            // 
            // frmSpecialCons
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(904, 578);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmSpecialCons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品特殊消耗处理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSpecialCons_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSpecialCons_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSpecialCons_Load(object sender, System.EventArgs e)
		{
			cmbGoodsName.Text="请输入...";
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtBalance.ReadOnly=true;
			txtGoodsID.ReadOnly=true;
			txtPay.ReadOnly=true;
			txtPrice.ReadOnly=true;

			this.label15.Visible=false;
			this.label17.Visible=false;
			this.txtPay.Visible=false;

			this.txtAssID.Visible=false;
			this.txtCardID.Visible=false;

			txtCount.Text="1";
			txtPay.Text="0";
			txtBalance.Text="0";
			txtPrice.Text="0";

			groupBox3.BackColor=Color.Snow;

			this.cmbSepcialType.Items.Add("门店报损");
			this.cmbSepcialType.Items.Add("门店品尝");
			this.cmbSepcialType.Items.Add("门店退货");
			this.cmbSepcialType.SelectedIndex=0;
			SpecTypeIndex=-10;

			err=null;
			CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
			assres=cs.GetAssociatorName("VMaster",out err);
			if(assres!=null)
			{
				txtCardID.Text=assres.strCardID;
				txtAssID.Text=assres.strAssID;
			}
			else
			{
				MessageBox.Show("无门店特殊客户，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

			dtConsItem=new DataTable();
			dtConsItem.Columns.Add("GoodsID");
			dtConsItem.Columns.Add("GoodsName");
			dtConsItem.Columns.Add("Price");
			dtConsItem.Columns.Add("Count");
			dtConsItem.Columns.Add("Rate");
			dtConsItem.Columns.Add("Fee");
			dtConsItem.Columns.Add("Comments");
			dtConsItem.Columns["Comments"].DefaultValue="";
			DgBind();
		}



		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())-1).ToString();
						dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())-double.Parse(dtConsItem.Rows[i]["Price"].ToString())).ToString();
						if(dtConsItem.Rows[i]["Count"].ToString()=="0")
						{
							dtConsItem.Rows.Remove(dtConsItem.Rows[i]);
						}
					}
				}
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbGoodsName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13&&cmbGoodsName.Text.Trim()!="")
			{
				string strSpell=cmbGoodsName.Text.Trim();
				this.FillComboBoxBySpell(cmbGoodsName,"GoodsSpell","vcGoodsName","vcSpell",strSpell);
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;

				gs=cs.GetGoodsByName(cmbGoodsName.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtCount.Text="1";
					
					if (SysInitial.TP=="1")
					{
						txtPrice.Text=gs.dPrice.ToString();
					}
					else
					{
						txtPrice.Text="0";
					}
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
					return;
				}
			}
		}

		private void txtGoodsID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13&&txtGoodsID.Text.Trim()!="")
			{
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					txtCount.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					txtGoodsID.Focus();
					return;
				}
			}
		}

		private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
				if(e.KeyChar==8)
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
				if(SpecTypeIndex>-10&&SpecTypeIndex!=this.cmbSepcialType.SelectedIndex)
				{
					MessageBox.Show("你所选择的特殊处理类型以之前录入商品的处理类型不一致！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				double dCount=0;
				if(txtCount.Text.Trim()=="")
				{
					MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dCount=int.Parse(txtCount.Text.Trim());
				}

				double dPrice=0;
				if (SysInitial.TP=="1")
				{
					if(txtPrice.Text.Trim()=="")
					{
						MessageBox.Show("单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						dPrice=Double.Parse(txtPrice.Text.Trim());
					}

				}

				if(txtGoodsID.Text.Trim()=="")
				{
					MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtGoodsID.Text="";
					cmbGoodsName.Items.Clear();
					cmbGoodsName.Refresh();
					txtPrice.Text="0";
					txtCount.Text="";
				}
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					bool sumflag=false;
					for(int i=0;i<dtConsItem.Rows.Count;i++)
					{
						if(gs.strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
						{
							dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
							dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+(dPrice*dCount)).ToString();
							sumflag=true;
							break;
						}
					}
					if(!sumflag)
					{
						DataRow dr=dtConsItem.NewRow();
						dr[0]=gs.strGoodsID;
						dr[1]=gs.strGoodsName;
						dr[2]=dPrice.ToString();
						dr[3]=dCount.ToString();
						dr[4]="0";
						dr[5]=(dPrice*dCount).ToString();
						dtConsItem.Rows.Add(dr);
					}
					if(SpecTypeIndex==-10)
					{
						SpecTypeIndex=this.cmbSepcialType.SelectedIndex;
					}
					if(this.cmbSepcialType.Enabled==true)
					{
						this.cmbSepcialType.Enabled=false;
					}
					this.DgBind();
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			if(dtConsItem.Rows.Count<=0)
			{
				MessageBox.Show("没有进行任何消费！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			double dPay=0;
			double dTolCharge=0;
			if (SysInitial.TP=="1")
			{
				dPay=double.Parse(txtPay.Text.Trim());
				dTolCharge=double.Parse(txtTolCharge.Text.Trim());
			}

			
			double dBalance=dPay-dTolCharge;
			if(dPay<dTolCharge)
			{
				MessageBox.Show("付款金额不能小于总消费金额！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			string strOperType=this.GetColEn(this.cmbSepcialType.Text,"OP");
			string strConsBillType="";
			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			if(strOperType==null||strOperType=="")
			{
				MessageBox.Show("操作类型代码转换错误！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				switch(strOperType)
				{
					case "OP010":
						//门店报损
						strConsBillType="PT005";
						cis.strComments="门店报损";
						break;
					case "OP011":
						//门店品尝
						strConsBillType="PT006";
						cis.strComments="门店品尝";
						break;
					case "OP012":
						//门店退货
						strConsBillType="PT007";
						cis.strComments="门店退货";
						break;
				}
			}
            double dDiscount = 1;
			cis.strAssID=txtAssID.Text.Trim();
			cis.strCardID=txtCardID.Text.Trim();
			cis.dChargeLast=0;
			cis.dTolCharge=dTolCharge;
            DateTime dtNow = DateTime.Now;
            cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            cis.iSerial = Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
            //cis.iSerial = Int64.Parse(cis.strOperDate.Substring(0, 4) + cis.strOperDate.Substring(5, 2) + cis.strOperDate.Substring(8, 2) + cis.strOperDate.Substring(11, 2) + cis.strOperDate.Substring(14, 2) + cis.strOperDate.Substring(17, 2));
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.dTRate=0;
			cis.dPay=dPay;
			cis.dBalance=dBalance;
			cis.strConsType=strConsBillType;
			cis.dtItem=dtConsItem;
			cis.strDeptID=SysInitial.CurOps.strDeptID;
			err=null;
			string strSerialok=cs.SpecialCons(cis,strOperType,out err);
            strSerialok = cis.iSerial.ToString();
			if(err!=null)
			{
				MessageBox.Show("特殊商品消耗失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{
				System.Windows.Forms.DialogResult diaRes1=MessageBox.Show("特殊商品消耗成功！是否打印？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					if(strSerialok=="")
					{
						MessageBox.Show("打印小票出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.Close();
					}
					else
					{
                        this.RetailConsPrint(cis, cs, strSerialok, dtConsItem, dTolCharge, dPay, dBalance, dDiscount);
					}
				}
				
				cmbGoodsName.Text="请输入...";
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="0";
				txtCount.Text="";
				txtPay.Text="";
				txtBalance.Text="";
				txtTolCount.Text="0";
				txtTolCharge.Text="0";
				dtConsItem=new DataTable();
				dtConsItem.Columns.Add("GoodsID");
				dtConsItem.Columns.Add("GoodsName");
				dtConsItem.Columns.Add("Price");
				dtConsItem.Columns.Add("Count");
				dtConsItem.Columns.Add("Rate");
				dtConsItem.Columns.Add("Fee");
				dtConsItem.Columns.Add("Comments");
				dtConsItem.Columns["Comments"].DefaultValue="";
				SpecTypeIndex=-10;
				this.cmbSepcialType.Enabled=true;
				this.cmbSepcialType.SelectedIndex=0;
				this.DgBind();
			}
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;
				double dTolFee=0;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
					dTolFee+=double.Parse(dtConsItem.Rows[i]["Fee"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolCharge.Text=dTolFee.ToString();
				txtPay.Text=dTolFee.ToString();
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("商品编号,商品名称,单价,数量,折扣金额,应收金额","100,170,100,100,60,100",dtConsItem,this.dataGrid1);
			}
		}

		private void PrintBill(string strCardID,string strSerial,string strCharge,string strIG,string strDeptName,string strDeptID)
		{
            //Hashtable hspara=new Hashtable();
            //hspara.Add("strSerial",strSerial);
            //hspara.Add("strCharge",strCharge);
            //hspara.Add("strIG",strIG);
            //hspara.Add("strDeptName",strDeptName);
            //hspara.Add("strDeptID",strDeptID);
            //hspara.Add("strCon",SysInitial.ConString);
            //hspara.Add("strCardID",strCardID);
            //hspara.Add("strOperName",SysInitial.CurOps.strOperName);
            ////DevExpress.XtraPrinting.PrintingSystem ps=new DevExpress.XtraPrinting.PrintingSystem();
            ////DevExpress.XtraReports.UI.XtraReport report1=new CMSM.Report.xrConsTiny(hspara);
            //report1.PrintingSystem=ps;
            //report1.CreateDocument();

            //ps.PageSettings.TopMargin=0;
            //ps.PageSettings.LeftMargin=-5;
            //ps.PageSettings.RightMargin=0;
            //ps.PageSettings.BottomMargin=0;
            //report1.Print();
		}

		private void txtPay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
//			if(e.KeyChar==13)
//			{
//				double dpay=double.Parse(txtPay.Text.Trim());
//				double dTFee=double.Parse(txtTolCharge.Text.Trim());
//				if(dpay<dTFee)
//				{
//					MessageBox.Show("付款金额不能小于总消费金额！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//					return;
//				}
//				else
//				{
//					txtBalance.Text=(dpay-dTFee).ToString();
//					this.sbtnOk.Focus();
//				}
//			}
		}

		private void frmSpecialCons_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
				case Keys.F6:   
					sbtnOk.PerformClick();   
					break;
                //case Keys.F7:
                //    sbtnAdd.PerformClick();
                //    break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			if(SpecTypeIndex>-10&&SpecTypeIndex!=this.cmbSepcialType.SelectedIndex)
			{
				MessageBox.Show("你所选择的特殊处理类型以之前录入商品的处理类型不一致！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			double dCount=0;
			if(txtCount.Text.Trim()=="")
			{
				MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dCount=int.Parse(txtCount.Text.Trim());
			}

			double dPrice=0;
			if (SysInitial.TP=="1")
			{
				if(txtPrice.Text.Trim()=="")
				{
					MessageBox.Show("单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dPrice=Double.Parse(txtPrice.Text.Trim());
				}

			}

			if(txtGoodsID.Text.Trim()=="")
			{
				MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="0";
				txtCount.Text="";
			}
			CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			err=null;
			gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
			if(gs!=null)
			{
				txtGoodsID.Text=gs.strGoodsID;
				cmbGoodsName.Text=gs.strGoodsName;
				bool sumflag=false;
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(gs.strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						dtConsItem.Rows[i]["Count"]=(double.Parse(dtConsItem.Rows[i]["Count"].ToString())+dCount).ToString();
						dtConsItem.Rows[i]["Fee"]=(double.Parse(dtConsItem.Rows[i]["Fee"].ToString())+(dPrice*dCount)).ToString();
						sumflag=true;
						break;
					}
				}
				if(!sumflag)
				{
					DataRow dr=dtConsItem.NewRow();
					dr[0]=gs.strGoodsID;
					dr[1]=gs.strGoodsName;
					dr[2]=dPrice.ToString();
					dr[3]=dCount.ToString();
					dr[4]="0";
					dr[5]=(dPrice*dCount).ToString();
					dtConsItem.Rows.Add(dr);
				}
				if(SpecTypeIndex==-10)
				{
					SpecTypeIndex=this.cmbSepcialType.SelectedIndex;
				}
				if(this.cmbSepcialType.Enabled==true)
				{
					this.cmbSepcialType.Enabled=false;
				}
				this.DgBind();
				cmbGoodsName.Focus();
			}
			else
			{
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbGoodsName.Text.Trim()!="")
			{
				string strSpell=cmbGoodsName.Text.Trim();
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByName(cmbGoodsName.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtCount.Text="1";
					if (SysInitial.TP=="1")
					{
						txtPrice.Text=gs.dPrice.ToString();
					}
					else
					{
						txtPrice.Text="0";
					}
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("无此商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="请输入...";
					cmbGoodsName.Focus();
					return;
				}
			}
		}
	}
}
