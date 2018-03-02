using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmCardChargeUnion 的摘要说明。
	/// </summary>
    public class frmCardChargeUnionRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurOrgCharge;
        private System.Windows.Forms.TextBox txtOrgCardID;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		Exception err;
        private System.Windows.Forms.TextBox txtOrgAssID;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtUnionOutFee;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.TextBox txtCurOrgIG;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtUnionOutIG;
        private Button sbtnOrgRead;
        private Button sbtnUnionOut;
        private TextBox txtiSerial;
        private DataGrid dataGrid1;
        private Label label1;
        private Label label3;
        private TextBox txtAssID;
		bool finalflag=false;

		public frmCardChargeUnionRemove()
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
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtiSerial = new System.Windows.Forms.TextBox();
            this.sbtnOrgRead = new System.Windows.Forms.Button();
            this.txtUnionOutIG = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCurOrgIG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnionOutFee = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurOrgCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrgCardID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrgAssID = new System.Windows.Forms.TextBox();
            this.sbtnUnionOut = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAssID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtiSerial);
            this.groupBox1.Controls.Add(this.sbtnOrgRead);
            this.groupBox1.Controls.Add(this.txtUnionOutIG);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCurOrgIG);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtUnionOutFee);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCurOrgCharge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOrgCardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrgAssID);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 173);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "撤消会员信息";
            // 
            // txtAssID
            // 
            this.txtAssID.Enabled = false;
            this.txtAssID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssID.Location = new System.Drawing.Point(360, 24);
            this.txtAssID.MaxLength = 7;
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.Size = new System.Drawing.Size(144, 22);
            this.txtAssID.TabIndex = 34;
            this.txtAssID.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(10, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "确认撤消信息";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "流    水";
            // 
            // txtiSerial
            // 
            this.txtiSerial.Enabled = false;
            this.txtiSerial.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtiSerial.Location = new System.Drawing.Point(72, 128);
            this.txtiSerial.MaxLength = 7;
            this.txtiSerial.Name = "txtiSerial";
            this.txtiSerial.Size = new System.Drawing.Size(144, 22);
            this.txtiSerial.TabIndex = 31;
            // 
            // sbtnOrgRead
            // 
            this.sbtnOrgRead.Location = new System.Drawing.Point(653, 20);
            this.sbtnOrgRead.Name = "sbtnOrgRead";
            this.sbtnOrgRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnOrgRead.TabIndex = 26;
            this.sbtnOrgRead.Text = "刷卡";
            this.sbtnOrgRead.UseVisualStyleBackColor = true;
            this.sbtnOrgRead.Click += new System.EventHandler(this.sbtnOrgRead_Click);
            // 
            // txtUnionOutIG
            // 
            this.txtUnionOutIG.Enabled = false;
            this.txtUnionOutIG.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnionOutIG.Location = new System.Drawing.Point(520, 126);
            this.txtUnionOutIG.MaxLength = 7;
            this.txtUnionOutIG.Name = "txtUnionOutIG";
            this.txtUnionOutIG.Size = new System.Drawing.Size(143, 22);
            this.txtUnionOutIG.TabIndex = 30;
            this.txtUnionOutIG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnionOutIG_KeyPress);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(456, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "转出积分";
            // 
            // txtCurOrgIG
            // 
            this.txtCurOrgIG.Enabled = false;
            this.txtCurOrgIG.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurOrgIG.Location = new System.Drawing.Point(296, 62);
            this.txtCurOrgIG.MaxLength = 7;
            this.txtCurOrgIG.Name = "txtCurOrgIG";
            this.txtCurOrgIG.Size = new System.Drawing.Size(144, 22);
            this.txtCurOrgIG.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(232, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "当前积分";
            // 
            // txtUnionOutFee
            // 
            this.txtUnionOutFee.Enabled = false;
            this.txtUnionOutFee.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnionOutFee.Location = new System.Drawing.Point(296, 126);
            this.txtUnionOutFee.MaxLength = 7;
            this.txtUnionOutFee.Name = "txtUnionOutFee";
            this.txtUnionOutFee.Size = new System.Drawing.Size(143, 22);
            this.txtUnionOutFee.TabIndex = 26;
            this.txtUnionOutFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnionOutFee_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(232, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "转出金额";
            // 
            // txtCurOrgCharge
            // 
            this.txtCurOrgCharge.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurOrgCharge.Location = new System.Drawing.Point(72, 62);
            this.txtCurOrgCharge.MaxLength = 7;
            this.txtCurOrgCharge.Name = "txtCurOrgCharge";
            this.txtCurOrgCharge.Size = new System.Drawing.Size(144, 22);
            this.txtCurOrgCharge.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "当前余额";
            // 
            // txtOrgCardID
            // 
            this.txtOrgCardID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgCardID.Location = new System.Drawing.Point(72, 24);
            this.txtOrgCardID.MaxLength = 7;
            this.txtOrgCardID.Name = "txtOrgCardID";
            this.txtOrgCardID.Size = new System.Drawing.Size(144, 22);
            this.txtOrgCardID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "会员卡号";
            // 
            // txtOrgAssID
            // 
            this.txtOrgAssID.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrgAssID.Location = new System.Drawing.Point(235, 20);
            this.txtOrgAssID.MaxLength = 7;
            this.txtOrgAssID.Name = "txtOrgAssID";
            this.txtOrgAssID.Size = new System.Drawing.Size(144, 22);
            this.txtOrgAssID.TabIndex = 23;
            this.txtOrgAssID.Visible = false;
            // 
            // sbtnUnionOut
            // 
            this.sbtnUnionOut.ForeColor = System.Drawing.Color.Tomato;
            this.sbtnUnionOut.Location = new System.Drawing.Point(653, 452);
            this.sbtnUnionOut.Name = "sbtnUnionOut";
            this.sbtnUnionOut.Size = new System.Drawing.Size(75, 43);
            this.sbtnUnionOut.TabIndex = 26;
            this.sbtnUnionOut.Text = "撤销确认";
            this.sbtnUnionOut.UseVisualStyleBackColor = true;
            this.sbtnUnionOut.Click += new System.EventHandler(this.sbtnUnionOut_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 179);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(891, 255);
            this.dataGrid1.TabIndex = 25;
            this.dataGrid1.MouseCaptureChanged += new System.EventHandler(this.dataGrid1_MouseCaptureChanged);
            // 
            // frmCardChargeUnionRemove
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(895, 507);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sbtnUnionOut);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardChargeUnionRemove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转出错误撤消";
            this.Load += new System.EventHandler(this.frmCardChargeUnionRemove_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void frmCardChargeUnionRemove_Load(object sender, System.EventArgs e)
		{
			this.txtOrgCardID.ReadOnly=true;
			this.txtCurOrgCharge.ReadOnly=true;
			this.sbtnUnionOut.Enabled=false;
			this.txtUnionOutFee.ReadOnly=true;
			this.txtUnionOutIG.Enabled=false;
			finalflag=false;
		}

		private void sbtnOrgRead_Click(object sender, System.EventArgs e)
		{
            this.txtiSerial.Text = "";
            this.txtUnionOutIG.Text = "";
            this.txtUnionOutFee.Text = "";
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，刷卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			string strresult="";
			this.txtOrgAssID.Text="";
			this.txtOrgCardID.Text="";
			this.txtCurOrgCharge.Text="";
			this.txtCurOrgIG.Text="";

			CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult.Substring(0,2)=="RF")
				{
					MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("刷卡失败，请重试！\n"+strresult,"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			if(chs.strCardID=="")
			{
				MessageBox.Show("会员卡号不正确，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
                MessageBox.Show("此卡为员工卡，不可进行转出撤消！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				err=null;
                DataTable dsout = new DataTable();
                dsout = cs.GetMaterialOut(chs.strCardID, out err);
                if (dsout != null && dsout.Rows.Count > 0)
                {
                    this.DataTableConvert(dsout, "vcDeptID", "MD", "vcCommCode", "vcCommName");
                }
                else
                {
                    this.sbtnUnionOut.Enabled = false;
                }
                this.txtOrgCardID.Text = chs.strCardID.ToString();
                this.txtCurOrgCharge.Text = chs.dCurCharge.ToString();
                this.txtCurOrgIG.Text = chs.iCurIg.ToString();
                this.dataGrid1.CaptionText = "转出错误明细";
                this.dataGrid1.SetDataBinding(dsout, "");
                this.EnToCh("流水号,会员ID,会员卡号,转出金额,转出积分,操作员,门店,操作日期", "110,60,70,70,70,200,120,160", dsout, this.dataGrid1);
               
			}
		}

		private void txtUnionFee_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==8||e.KeyChar==46)
			{
				return;
			}
			if(e.KeyChar<48||e.KeyChar>57)
			{
				e.Handled=true;
				return;
			}
		}

		private void sbtnUnionOut_Click(object sender, System.EventArgs e)
		{
            DataTable dt = new DataTable();
            dt = (DataTable)this.dataGrid1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                if (this.txtiSerial.Text.Trim() == "" && this.txtUnionOutFee.Text.Trim() == "" && this.txtUnionOutIG.Text.Trim() == "")
                {
                    MessageBox.Show("选择要撤消的行！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }
                       
            try
            {
                CMSMStruct.FillFeeStruct ffsDes = new CMSMData.CMSMStruct.FillFeeStruct();
                DateTime dtNow = DateTime.Now;
                ffsDes.iSerial = Int64.Parse(this.txtiSerial.Text);
                ffsDes.strAssID = this.txtAssID.Text.Trim();
                ffsDes.strCardID = this.txtOrgCardID.Text.Trim();
                ffsDes.dFillFee = Math.Round(double.Parse(this.txtUnionOutFee.Text),2);
                ffsDes.dFillProm = 0;
                ffsDes.dFeeLast = Math.Round(double.Parse(this.txtCurOrgCharge.Text),2); 
                ffsDes.dIGLast = Math.Round(double.Parse(this.txtCurOrgIG.Text), 2);
                ffsDes.dFillFee = Math.Round(double.Parse(this.txtUnionOutFee.Text),2);
                ffsDes.dFeeCur = ffsDes.dFeeLast + ffsDes.dFillFee;
                ffsDes.dFillProm = 0;
                ffsDes.dIG = Math.Round(double.Parse(this.txtUnionOutIG.Text),2);
                ffsDes.dIGCur = ffsDes.dIGLast + ffsDes.dIG;
                ffsDes.strComments = "转出撤消,原流水为：" + ffsDes.iSerial + " ";
                ffsDes.strOperName = SysInitial.CurOps.strOperName;
                ffsDes.strDeptID = SysInitial.LocalDept;
                ffsDes.strType = "OP019";
                ffsDes.strFillDate = dtNow.ToString();

                string strresult = "";
                CMSMStruct.CardHardStruct chsDes = new CMSMData.CMSMStruct.CardHardStruct();
                chsDes = cs.ReadCardInfo("", out strresult);
                while (chsDes.strCardID != ffsDes.strCardID)
                {
                    MessageBox.Show("目标卡不正确，请将要撤消的目标卡放在读卡器上。", "请放卡", MessageBoxButtons.OK);
                    return;
                }
                err = null;
                strresult = cs.CardChargeUnionOutRoll(ffsDes, out err);
                if (strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK) || strresult.IndexOf("CMT", 0) >= 0)
                {
                    finalflag = false;
                    MessageBox.Show("会员卡转出撤消成功！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    this.ClearText();
                    this.dataGrid1.DataSource = null;
                    this.sbtnOrgRead.Enabled = true;
                    this.sbtnUnionOut.Enabled = false;
                    this.txtUnionOutIG.Enabled = false;
                }
                else
                {
                    MessageBox.Show("会员卡转出撤消失败，请重试！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    this.ClearText();
                    this.dataGrid1.DataSource = null;
                    this.sbtnOrgRead.Enabled = true;
                    this.sbtnUnionOut.Enabled = false;
                    this.txtUnionOutIG.Enabled = false;
                    if (err != null)
                    {
                        clog.WriteLine(err.ToString() + strresult);
                    }
                    else
                    {
                        clog.WriteLine(strresult);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("会员卡转出撤消失败！", "系统提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                clog.WriteLine(ex);
            }
		}

		

        private void txtUnionOutIG_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                return;
            }
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
                return;
            }
        }
        private void txtUnionOutFee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                return;
            }
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
                return;
            }
        }
        private void dataGrid1_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.txtAssID.Text = dataGrid1[dataGrid1.CurrentRowIndex, 1].ToString();
            double dOutFee = -double.Parse(dataGrid1[dataGrid1.CurrentRowIndex, 3].ToString());
            this.txtiSerial.Text = dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString();
            this.txtUnionOutFee.Text = dOutFee.ToString();
            this.txtUnionOutIG.Text = dataGrid1[dataGrid1.CurrentRowIndex, 4].ToString();
            this.sbtnUnionOut.Enabled = true;
        }

	}
}
