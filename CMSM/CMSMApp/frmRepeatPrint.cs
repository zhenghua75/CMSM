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
	/// Summary description for frmRepeatPrint.
	/// </summary>
	public class frmRepeatPrint : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSerial;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CommAccess cs = new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTolFee;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbDept;
        private Button sbtnQuery;
        private Button sbtnPrint;
        private Button sbtnClose;
        private Button sbtnPrintEnd;
		Exception err;

		public frmRepeatPrint()
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
            this.sbtnPrintEnd = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.sbtnPrint = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTolFee = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.dataGrid1.Size = new System.Drawing.Size(1135, 492);
            this.dataGrid1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnPrintEnd);
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnPrint);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1135, 96);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // sbtnPrintEnd
            // 
            this.sbtnPrintEnd.Location = new System.Drawing.Point(818, 63);
            this.sbtnPrintEnd.Name = "sbtnPrintEnd";
            this.sbtnPrintEnd.Size = new System.Drawing.Size(127, 23);
            this.sbtnPrintEnd.TabIndex = 27;
            this.sbtnPrintEnd.Text = "打印最后一条(F7)";
            this.sbtnPrintEnd.UseVisualStyleBackColor = true;
            this.sbtnPrintEnd.Click += new System.EventHandler(this.sbtnPrintEnd_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(712, 62);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 26;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // sbtnPrint
            // 
            this.sbtnPrint.Location = new System.Drawing.Point(621, 62);
            this.sbtnPrint.Name = "sbtnPrint";
            this.sbtnPrint.Size = new System.Drawing.Size(75, 23);
            this.sbtnPrint.TabIndex = 25;
            this.sbtnPrint.Text = "打印";
            this.sbtnPrint.UseVisualStyleBackColor = true;
            this.sbtnPrint.Click += new System.EventHandler(this.sbtnPrint_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(531, 62);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 24;
            this.sbtnQuery.Text = "查询";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(576, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(144, 20);
            this.cmbDept.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(528, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "门店";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(272, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "结束日期";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(272, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "开始日期";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(344, 64);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(136, 21);
            this.dtpEnd.TabIndex = 18;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(344, 24);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpBegin.TabIndex = 16;
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(80, 64);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 22);
            this.txtCardID.TabIndex = 15;
            this.txtCardID.Text = "*";
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "会员卡号";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSerial.Location = new System.Drawing.Point(80, 24);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(144, 22);
            this.txtSerial.TabIndex = 1;
            this.txtSerial.Text = "*";
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "流水号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTolFee);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 588);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1135, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "汇总数据";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(496, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "元";
            // 
            // txtTolFee
            // 
            this.txtTolFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTolFee.Location = new System.Drawing.Point(384, 24);
            this.txtTolFee.Name = "txtTolFee";
            this.txtTolFee.Size = new System.Drawing.Size(104, 22);
            this.txtTolFee.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(320, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "消费金额";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(160, 24);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(96, 22);
            this.txtCount.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(80, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "总消费次数";
            // 
            // frmRepeatPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1135, 644);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frmRepeatPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重新打印小票";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepeatPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRepeatPrint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        private void frmRepeatPrint_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    sbtnPrintEnd.PerformClick();
                    break;
            }
        }
		private void frmRepeatPrint_Load(object sender, System.EventArgs e)
		{
			this.txtCount.Text="0";
			this.txtTolFee.Text="0";
			if(SysInitial.CurOps.strLimit=="LM001"&&SysInitial.MainDept)
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

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();			
		}

		private void DgBind()
		{
			string strCardID=txtCardID.Text.Trim();
			string strSerial=txtSerial.Text.Trim();
			string strBegin=dtpBegin.Value.ToShortDateString() + " 00:00:00";
			string strEnd=dtpEnd.Value.ToShortDateString() + " 23:59:59";
			string strDeptID=SysInitial.LocalDept;
			if(this.cmbDept.Text=="全部")
			{
				strDeptID="all";
			}
			else
			{
				strDeptID=this.GetColEn(this.cmbDept.Text,"MD");
			}
			DataTable dt=new DataTable();
			err=null;
			dt=cs.GetConsRepeat(strCardID,strSerial,strBegin,strEnd,strDeptID,out err);
			if(dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
			}
			if(dt!=null)
			{
				int consCount=dt.Rows.Count;
				double consfee=0;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					consfee+=double.Parse(dt.Rows[i]["nFee"].ToString());
				}
				this.txtCount.Text=consCount.ToString();
				this.txtTolFee.Text=consfee.ToString();
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("流水号,会员卡号,会员名称,总折扣,总金额,付款金额,找零,收银员,消费日期,门店","120,80,100,50,50,60,50,80,150,150",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("查询小票出错，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void RepeatPrint(string strSerial)
		{
			CommAccess cs=new CommAccess(SysInitial.ConString);
			Exception err;
			DataTable dtConsItem = cs.GetConsItemBySerial(out err,strSerial);
			if(err!=null)
			{
				MessageBox.Show("查询消费明细出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtConsItem = new DataTable();
			}

			DataTable dtBill = cs.GetBillBySerial(out err,strSerial);
			if(err!=null)
			{
				MessageBox.Show("查询小票信息出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
				dtBill = new DataTable();
			}
			DataRow dr = dtBill.Rows[0];
			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strCardID = dr["vcCardId"].ToString();
			string strConsType = dr["vcConsType"].ToString();
            cis.strConsType = strConsType;
			cis.dTRate = Convert.ToDouble(dr["nTRate"].ToString());
			cis.dFee = Convert.ToDouble(dr["nFee"].ToString());
			cis.dPay = Convert.ToDouble(dr["nPay"].ToString());
			cis.dBalance = Convert.ToDouble(dr["nBalance"].ToString());
			cis.iIgValue = Convert.ToInt32(dr["iIgValue"].ToString());
			cis.strOperName = dr["vcOperName"].ToString();
			cis.strOperDate = dr["dtConsDate"].ToString();
			cis.strDeptID = dr["vcDeptId"].ToString();

			CMSMData.CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

			switch(strConsType)
			{
				case "PT001"://会员刷卡
					this.AssConsPrint(chs,cis,cs,strSerial,dtConsItem,cis.dFee);
					break;
				case "PT002"://支付现金
					this.RetailConsPrint(cis,cs,strSerial,dtConsItem,cis.dFee,cis.dPay,cis.dBalance,cis.dTRate);
					break;
				case "PT003"://积分兑换
					dtConsItem.Columns["Price"].ColumnName="IgValue";
					dtConsItem.Columns["Fee"].ColumnName="IgPay";
					this.AssIgPrint(chs,cis,cs,strSerial,dtConsItem,cis.dFee);
					break;
				case "PT004"://赠送商品
					this.AssGiftPrint(chs,cis,cs,strSerial,dtConsItem,cis.dFee);
					break;
                case "PT005":
                    this.RetailConsPrint(cis, cs, strSerial, dtConsItem, cis.dFee, cis.dPay, cis.dBalance, cis.dTRate);
                    break;
                case "PT006":
                    this.RetailConsPrint(cis, cs, strSerial, dtConsItem, cis.dFee, cis.dPay, cis.dBalance, cis.dTRate);
                    break;
                case "PT007":
                    this.RetailConsPrint(cis, cs, strSerial, dtConsItem, cis.dFee, cis.dPay, cis.dBalance, cis.dTRate);
                    break;
				case "PT008":
                    this.RetailConsPrint(cis, cs, strSerial, dtConsItem, cis.dFee, cis.dPay, cis.dBalance, cis.dTRate);
					break;
			}
		}
		private void sbtnPrint_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				this.RepeatPrint(dataGrid1[dataGrid1.CurrentRowIndex,0].ToString());
			}
			else
			{
				MessageBox.Show("请选择要重打的小票！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void txtCardID_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
		{
//			if(e.KeyChar!=13)
//			{
//				if(e.KeyChar==8||e.KeyChar==42)
//				{
//					return;
//				}
//				if(e.KeyChar<48||e.KeyChar>57)
//				{
//					e.Handled=true;
//					return;
//				}
//			}
//			else
//			{
//				this.DgBind();
//			}
		}
		private void txtSerial_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
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

        private void sbtnPrintEnd_Click(object sender, EventArgs e)
        {
            string strCardID = txtCardID.Text.Trim();
            string strSerial = txtSerial.Text.Trim();
            string strBegin = dtpBegin.Value.ToShortDateString() + " 00:00:00";
            string strEnd = dtpEnd.Value.ToShortDateString() + " 23:59:59";
            string strDeptID = SysInitial.LocalDept;
            if (this.cmbDept.Text == "全部")
            {
                strDeptID = "all";
            }
            else
            {
                strDeptID = this.GetColEn(this.cmbDept.Text, "MD");
            }
            DataTable dt = new DataTable();
            err = null;
            dt = cs.GetConsRepeatEnd(strCardID, strSerial, strBegin, strEnd, strDeptID, out err);
            if (dt.Rows.Count >= 0)
            {
                this.DataTableConvert(dt, "vcDeptID", "MD", "vcCommCode", "vcCommName");
            }
            if (dt != null)
            {
                int consCount = dt.Rows.Count;
                double consfee = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    consfee += double.Parse(dt.Rows[i]["nFee"].ToString());
                }
                this.txtCount.Text = consCount.ToString();
                this.txtTolFee.Text = consfee.ToString();
                this.dataGrid1.SetDataBinding(dt, "");
                this.EnToCh("流水号,会员卡号,会员名称,总折扣,总金额,付款金额,找零,收银员,消费日期,门店", "120,80,100,50,50,60,50,80,150,150", dt, this.dataGrid1);
            }
            else
            {
                MessageBox.Show("查询小票出错，请重试！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (err != null)
                {
                    clog.WriteLine(err);
                }
            }
            if (dataGrid1.CurrentRowIndex >= 0)
            {
                this.RepeatPrint(dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString());
            }
            else
            {
                MessageBox.Show("请选择要重打的小票！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
	}
}
