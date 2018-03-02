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
	/// frmGoods 的摘要说明。
	/// </summary>
	public class frmGoods : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtGoodsName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSpell;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComments;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		CommAccess cs=new CommAccess(SysInitial.ConString);
        Exception err;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtIgValue;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGoodsType;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnCancel;
        private Button sbtnMod;
        private Button sbtnAdd;
        private Button sbtnDel;
		CMSMData.CMSMStruct.GoodsStruct gsold;

		public frmGoods()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnMod = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.cmbGoodsType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIgValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpell = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoodsID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.sbtnDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnDel);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnMod);
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbGoodsType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIgValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtComments);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSpell);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGoodsName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 566);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品信息录入";
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.ForeColor = System.Drawing.Color.Black;
            this.sbtnAdd.Location = new System.Drawing.Point(81, 288);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 38;
            this.sbtnAdd.Text = "添加";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnMod
            // 
            this.sbtnMod.ForeColor = System.Drawing.Color.Black;
            this.sbtnMod.Location = new System.Drawing.Point(5, 288);
            this.sbtnMod.Name = "sbtnMod";
            this.sbtnMod.Size = new System.Drawing.Size(75, 23);
            this.sbtnMod.TabIndex = 37;
            this.sbtnMod.Text = "修改";
            this.sbtnMod.UseVisualStyleBackColor = true;
            this.sbtnMod.Click += new System.EventHandler(this.sbtnMod_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ForeColor = System.Drawing.Color.Black;
            this.sbtnCancel.Location = new System.Drawing.Point(157, 168);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 36;
            this.sbtnCancel.Text = "取消";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.ForeColor = System.Drawing.Color.Black;
            this.sbtnExcel.Location = new System.Drawing.Point(81, 168);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 35;
            this.sbtnExcel.Text = "导出";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.ForeColor = System.Drawing.Color.Black;
            this.sbtnQuery.Location = new System.Drawing.Point(5, 168);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 34;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // cmbGoodsType
            // 
            this.cmbGoodsType.Location = new System.Drawing.Point(80, 64);
            this.cmbGoodsType.Name = "cmbGoodsType";
            this.cmbGoodsType.Size = new System.Drawing.Size(152, 23);
            this.cmbGoodsType.TabIndex = 23;
            this.cmbGoodsType.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(16, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "商品类型";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(72, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "无兑换分值请填：-1";
            this.label7.Visible = false;
            // 
            // txtIgValue
            // 
            this.txtIgValue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIgValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtIgValue.Location = new System.Drawing.Point(72, 496);
            this.txtIgValue.MaxLength = 10;
            this.txtIgValue.Name = "txtIgValue";
            this.txtIgValue.Size = new System.Drawing.Size(152, 21);
            this.txtIgValue.TabIndex = 4;
            this.txtIgValue.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(16, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 32);
            this.label6.TabIndex = 16;
            this.label6.Text = "兑换积分分值";
            this.label6.Visible = false;
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtComments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtComments.Location = new System.Drawing.Point(72, 536);
            this.txtComments.MaxLength = 100;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(152, 40);
            this.txtComments.TabIndex = 5;
            this.txtComments.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(16, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "备注";
            this.label5.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrice.Location = new System.Drawing.Point(72, 456);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(152, 21);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(16, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "单价";
            this.label4.Visible = false;
            // 
            // txtSpell
            // 
            this.txtSpell.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSpell.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSpell.Location = new System.Drawing.Point(72, 416);
            this.txtSpell.MaxLength = 10;
            this.txtSpell.Name = "txtSpell";
            this.txtSpell.Size = new System.Drawing.Size(152, 21);
            this.txtSpell.TabIndex = 2;
            this.txtSpell.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "拼音简写";
            this.label3.Visible = false;
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGoodsName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGoodsName.Location = new System.Drawing.Point(80, 104);
            this.txtGoodsName.MaxLength = 20;
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(152, 21);
            this.txtGoodsName.TabIndex = 1;
            this.txtGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsName_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGoodsID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGoodsID.Location = new System.Drawing.Point(80, 24);
            this.txtGoodsID.MaxLength = 4;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(152, 21);
            this.txtGoodsID.TabIndex = 0;
            this.txtGoodsID.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "商品编号";
            this.label2.Visible = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(248, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(544, 566);
            this.dataGrid1.TabIndex = 4;
            // 
            // sbtnDel
            // 
            this.sbtnDel.ForeColor = System.Drawing.Color.Black;
            this.sbtnDel.Location = new System.Drawing.Point(157, 288);
            this.sbtnDel.Name = "sbtnDel";
            this.sbtnDel.Size = new System.Drawing.Size(75, 23);
            this.sbtnDel.TabIndex = 39;
            this.sbtnDel.Text = "删除";
            this.sbtnDel.UseVisualStyleBackColor = true;
            this.sbtnDel.Click += new System.EventHandler(this.sbtnDel_Click);
            // 
            // frmGoods
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品信息管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGoods_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmGoods_Load(object sender, System.EventArgs e)
		{
			this.sbtnAdd.Enabled=false;
			this.sbtnMod.Enabled=false;
			this.sbtnDel.Enabled=false;
			groupBox1.Font=new Font("宋体",11);
			this.label7.ForeColor=Color.Red;
			txtIgValue.Text="-1";
			this.FillComboBox(cmbGoodsType,"GoodsGT","vcCommName");
			this.DgBind();
		}

		private void DgBind()
		{
			string strGoodsID=txtGoodsID.Text.Trim();
			string strGoodsName=txtGoodsName.Text.Trim();
			Exception err=null;
			DataTable dt=new DataTable();

//			dt=cs.GetGoods(strGoodsID,strGoodsName,out err);
			dt=cs.GetGoods(strGoodsName,out err);
			if(dt!=null)
			{
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("商品编号,商品名称,拼音简写,单价,兑换分值,是否打折","100,150,80,70,70,120",dt,this.dataGrid1);
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

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			err=null;
			gs.strGoodsType=this.cmbGoodsType.Text.Trim();
		    if(!cs.ChkGoodsIDDup(txtGoodsID.Text.Trim(),out err))
				{
					gs.strGoodsID=txtGoodsID.Text.Trim();
				}
			else
			{
				MessageBox.Show("该编号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				txtGoodsID.Focus();
				return;	
			}

			if(txtGoodsName.Text.Trim()=="")
			{
				MessageBox.Show("商品名称不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(!cs.ChkGoodsNameDup(txtGoodsName.Text.Trim(),out err))
			{
				gs.strGoodsName=txtGoodsName.Text.Trim();
			}
			else
			{
				MessageBox.Show("该商品名称已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				txtGoodsName.Focus();
				return;	
			}

			if(txtPrice.Text.Trim()=="")
			{
				MessageBox.Show("商品单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				gs.dPrice=Double.Parse(txtPrice.Text.Trim());
			}

			if(txtIgValue.Text.Trim()==""||txtIgValue.Text.Trim()=="0"||int.Parse(txtIgValue.Text.Trim())<-1)
			{
				MessageBox.Show("兑换分值不正确！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				gs.iIgValue=int.Parse(txtIgValue.Text.Trim());
			}

			gs.strSpell=txtSpell.Text.Trim().ToLower();
			gs.strComments=txtComments.Text.Trim();

			err=null;
			cs.InsertGoods(gs,out err);
			if(err!=null)
			{
				MessageBox.Show("添加商品信息失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{
				MessageBox.Show("添加商品信息成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				err=null;
				SysInitial.CreatDS(out err);
				if(err!=null)
				{
					MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					Application.Exit();
				}
				this.ClearText();
				txtIgValue.Text="-1";
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			if(txtGoodsID.Text.Trim()=="")
			{
				this.Close();
			}
			else
			{
				this.ClearText();
				txtIgValue.Text="-1";
				txtGoodsID.ReadOnly=false;
				txtGoodsName.ReadOnly=false;
				sbtnMod.Text="修改";
				sbtnDel.Enabled=true;
				sbtnAdd.Enabled=true;
			}
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void sbtnMod_Click(object sender, System.EventArgs e)
		{
			if(sbtnMod.Text=="修改")
			{
				if(this.dataGrid1.CurrentRowIndex>=0)
				{
					this.ClearText();
					txtGoodsID.Text=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
					txtGoodsName.Text=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
					txtSpell.Text=dataGrid1[dataGrid1.CurrentRowIndex,2].ToString();
					txtPrice.Text=dataGrid1[dataGrid1.CurrentRowIndex,3].ToString();
					txtIgValue.Text=dataGrid1[dataGrid1.CurrentRowIndex,4].ToString();
					txtComments.Text=dataGrid1[dataGrid1.CurrentRowIndex,5].ToString();

					gsold=new CMSMData.CMSMStruct.GoodsStruct();
					gsold.strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
					gsold.strGoodsName=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
					gsold.strSpell=dataGrid1[dataGrid1.CurrentRowIndex,2].ToString();
					gsold.dPrice=Double.Parse(dataGrid1[dataGrid1.CurrentRowIndex,3].ToString());
					gsold.iIgValue=int.Parse(dataGrid1[dataGrid1.CurrentRowIndex,4].ToString());
					gsold.strComments=dataGrid1[dataGrid1.CurrentRowIndex,5].ToString();
					sbtnMod.Text="保存";
					this.cmbGoodsType.Enabled=false;
					txtGoodsID.ReadOnly=true;
					sbtnDel.Enabled=false;
					txtGoodsName.ReadOnly=true;
					sbtnAdd.Enabled=false;
				}
				else
				{
					MessageBox.Show("没有选中要修改的商品信息！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				}
			}
			else
			{
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				if(txtGoodsName.Text.Trim()=="")
				{
					MessageBox.Show("商品名称不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					gs.strGoodsName=txtGoodsName.Text.Trim();
				}

				if(txtPrice.Text.Trim()=="")
				{
					MessageBox.Show("商品单价不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					gs.dPrice=Double.Parse(txtPrice.Text.Trim());
				}
				if(txtIgValue.Text.Trim()==""||txtIgValue.Text.Trim()=="0"||int.Parse(txtIgValue.Text.Trim())<-1)
				{
					MessageBox.Show("兑换分值不正确！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					gs.iIgValue=int.Parse(txtIgValue.Text.Trim());
				}

				gs.strSpell=txtSpell.Text.Trim();
				gs.strComments=txtComments.Text.Trim();

				err=null;
				cs.UpdateGoods(gs,gsold,out err);
				if(err!=null)
				{
					MessageBox.Show("修改商品信息失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					sbtnMod.Text="修改";
					txtGoodsID.ReadOnly=false;
					sbtnDel.Enabled=true;
					sbtnAdd.Enabled=true;
					this.ClearText();
					this.DgBind();
					clog.WriteLine(err);
				}
				else
				{
					MessageBox.Show("修改商品信息成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					err=null;
					SysInitial.CreatDS(out err);
					if(err!=null)
					{
						MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err);
						Application.Exit();
					}
					sbtnMod.Text="修改";
					txtGoodsID.ReadOnly=false;
					sbtnDel.Enabled=true;
					sbtnAdd.Enabled=true;
					this.ClearText();
					txtIgValue.Text="-1";
					this.DgBind();
				}
			}
		}

		private void sbtnDel_Click(object sender, System.EventArgs e)
		{
			if(this.dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				DialogResult strRes=MessageBox.Show("确定要删除“" + strGoodsID + "”吗？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(strRes==DialogResult.Yes)
				{
					err=null;
					cs.DeleteGoods(strGoodsID,out err);
					if(err!=null)
					{
						MessageBox.Show("删除商品信息失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err);
						this.DgBind();
					}
					else
					{
						MessageBox.Show("删除商品信息成功！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						err=null;
						SysInitial.CreatDS(out err);
						if(err!=null)
						{
							MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							Application.Exit();
						}
						this.DgBind();
					}
				}
			}
		}

		private void txtGoodsName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar.ToString()=="'")
			{
				e.Handled=true;
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
				MessageBox.Show("没有数据可以导出!","系统提示",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}
	}
}
