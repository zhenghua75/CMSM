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
	/// Summary description for frmIntegralChange.
	/// </summary>
	public class frmIntegralChange : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtTolCharge;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbGoodsName;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtIgCur;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtAssType;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.TextBox txtIgPay;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.TextBox txtCharge;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		DataTable dtIgItem;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label1;
		Exception err;
        private Button sbtnRead;
        private Button sbtnRollback;
        private Button sbtnCancel;
        private Button sbtnOk;
		
		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();		

		public frmIntegralChange()
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTolCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnOk = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.sbtnRead = new System.Windows.Forms.Button();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.txtIgCur = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAssType = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIgPay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.dataGrid1.Location = new System.Drawing.Point(272, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(528, 528);
            this.dataGrid1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTolCharge);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTolCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(272, 528);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 50);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "兑换积分合计：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(472, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "分";
            // 
            // txtTolCharge
            // 
            this.txtTolCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCharge.Location = new System.Drawing.Point(376, 24);
            this.txtTolCharge.MaxLength = 10;
            this.txtTolCharge.Name = "txtTolCharge";
            this.txtTolCharge.Size = new System.Drawing.Size(96, 21);
            this.txtTolCharge.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(288, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "总兑换积分：";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(128, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(64, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "总数量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnOk);
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.sbtnRead);
            this.groupBox1.Controls.Add(this.txtCharge);
            this.groupBox1.Controls.Add(this.txtAssID);
            this.groupBox1.Controls.Add(this.txtIgCur);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtLinkPhone);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtAssType);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtAssName);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtIgPay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 578);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "兑换积分栏目";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(183, 408);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 41;
            this.sbtnOk.Text = "确定(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(97, 408);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 40;
            this.sbtnCancel.Text = "关闭";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(12, 408);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 39;
            this.sbtnRollback.Text = "<<撤消";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(149, 20);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 38;
            this.sbtnRead.Text = "刷卡(F5)";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // txtCharge
            // 
            this.txtCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharge.Location = new System.Drawing.Point(104, 520);
            this.txtCharge.MaxLength = 10;
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.Size = new System.Drawing.Size(104, 21);
            this.txtCharge.TabIndex = 37;
            this.txtCharge.Visible = false;
            // 
            // txtAssID
            // 
            this.txtAssID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssID.Location = new System.Drawing.Point(40, 512);
            this.txtAssID.MaxLength = 10;
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(104, 21);
            this.txtAssID.TabIndex = 36;
            this.txtAssID.Visible = false;
            // 
            // txtIgCur
            // 
            this.txtIgCur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIgCur.Location = new System.Drawing.Point(88, 176);
            this.txtIgCur.MaxLength = 10;
            this.txtIgCur.Name = "txtIgCur";
            this.txtIgCur.Size = new System.Drawing.Size(104, 21);
            this.txtIgCur.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(24, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 33;
            this.label18.Text = "当前积分";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 136);
            this.txtLinkPhone.MaxLength = 25;
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(104, 21);
            this.txtLinkPhone.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(24, 144);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 16);
            this.label19.TabIndex = 32;
            this.label19.Text = "联系电话";
            // 
            // txtAssType
            // 
            this.txtAssType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssType.Location = new System.Drawing.Point(88, 216);
            this.txtAssType.MaxLength = 10;
            this.txtAssType.Name = "txtAssType";
            this.txtAssType.Size = new System.Drawing.Size(104, 21);
            this.txtAssType.TabIndex = 30;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(24, 224);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 29;
            this.label20.Text = "会员类型";
            // 
            // txtAssName
            // 
            this.txtAssName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssName.Location = new System.Drawing.Point(88, 96);
            this.txtAssName.MaxLength = 30;
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(104, 21);
            this.txtAssName.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(24, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 16);
            this.label21.TabIndex = 28;
            this.label21.Text = "会员姓名";
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Location = new System.Drawing.Point(88, 56);
            this.txtCardID.MaxLength = 10;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(104, 21);
            this.txtCardID.TabIndex = 26;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(24, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 16);
            this.label22.TabIndex = 25;
            this.label22.Text = "会员卡号";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(200, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "分";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(88, 376);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 21);
            this.txtCount.TabIndex = 4;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(40, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "数量";
            // 
            // txtIgPay
            // 
            this.txtIgPay.Location = new System.Drawing.Point(88, 336);
            this.txtIgPay.MaxLength = 10;
            this.txtIgPay.Name = "txtIgPay";
            this.txtIgPay.Size = new System.Drawing.Size(112, 21);
            this.txtIgPay.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "需要积分";
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(88, 296);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
            this.cmbGoodsName.TabIndex = 2;
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "商品名称";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(88, 256);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 21);
            this.txtGoodsID.TabIndex = 1;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "商品编号";
            // 
            // frmIntegralChange
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmIntegralChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "积分兑换";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIntegralChange_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIntegralChange_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmIntegralChange_Load(object sender, System.EventArgs e)
		{
			cmbGoodsName.Text="请输入...";
			txtCardID.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtAssType.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCharge.ReadOnly=true;
			txtIgCur.ReadOnly=true;
			txtTolCount.ReadOnly=true;
			txtTolCharge.ReadOnly=true;
			txtCount.ReadOnly=true;

			txtGoodsID.ReadOnly=true;
			cmbGoodsName.Enabled=false;
			txtIgPay.ReadOnly=true;
			txtCount.Text="1";

			groupBox3.BackColor=Color.Snow;


			dtIgItem=new DataTable();
			dtIgItem.Columns.Add("GoodsID");
			dtIgItem.Columns.Add("GoodsName");
			dtIgItem.Columns.Add("IgValue");
			dtIgItem.Columns.Add("Count");
			dtIgItem.Columns.Add("IgPay");
			DgBind();
		}

		private void DgBind()
		{
			if(dtIgItem!=null)
			{
				double dTolCount=0;
				double dTolIgPay=0;
				for(int i=0;i<dtIgItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtIgItem.Rows[i]["Count"].ToString());
					dTolIgPay+=double.Parse(dtIgItem.Rows[i]["IgPay"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				txtTolCharge.Text=dTolIgPay.ToString();
				this.dataGrid1.SetDataBinding(dtIgItem,"");
				this.EnToCh("商品编号,商品名称,所需积分,数量,兑换积分","100,170,100,100,60",dtIgItem,this.dataGrid1);
			}
		}

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，刷卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			string strresult="";
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("该卡不属于本系统使用的卡，请检查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("刷卡失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
				MessageBox.Show("此卡为员工卡，不可进行积分兑换！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					string strAssState=assres.strAssState;
					if(strAssState!="0")
					{
						MessageBox.Show("该会员已经失效，卡号：" + chs.strCardID + "，请核查！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					if(assres.dtCreateDate.CompareTo(SysInitial.dtQLTime)<0&&!assres.setZeroFlag)
					{
						chs.iCurIg=0;
						chs.needZeroFlag=true;
					}
					if(chs.iCurIg<=0)
					{
						MessageBox.Show("当前积分不足，不能兑换！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;
					txtCharge.Text=chs.dCurCharge.ToString();
					txtAssType.Text=GetColCh(assres.strAssType,"AT");
					txtAssID.Text=assres.strAssID;
					txtIgCur.Text=chs.iCurIg.ToString();
					txtGoodsID.ReadOnly=false;
					cmbGoodsName.Enabled=true;
					txtCount.ReadOnly=false;
					sbtnRead.Enabled=false;
					cmbGoodsName.Focus();
				}
				else
				{
					MessageBox.Show("无会员资料，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
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
					if(gs.iIgValue.ToString()=="-1")
					{
						MessageBox.Show("该商品无兑换积分值，不能兑换！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						txtGoodsID.Text="";
						txtIgPay.Text="";
						cmbGoodsName.Text="请输入...";
						cmbGoodsName.Focus();
						return;
					}
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtIgPay.Text=gs.iIgValue.ToString();
					txtIgPay.ReadOnly=true;
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
					if(gs.iIgValue.ToString()=="-1")
					{
						MessageBox.Show("该商品无兑换积分值，不能兑换！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						txtGoodsID.Text="";
						txtIgPay.Text="";
						cmbGoodsName.Text="请输入...";
						txtGoodsID.Focus();
						return;
					}
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtIgPay.Text=gs.iIgValue.ToString();
					txtIgPay.ReadOnly=true;
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
				int dCount=0;
				int LastIg=int.Parse(this.txtIgCur.Text.Trim());
				if(txtCount.Text.Trim()=="")
				{
					MessageBox.Show("数量不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dCount=int.Parse(txtCount.Text.Trim());
				}

				int dIgPay=0;
				if(txtIgPay.Text.Trim()=="")
				{
					MessageBox.Show("需要的积分不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				else
				{
					dIgPay=int.Parse(txtIgPay.Text.Trim());
				}

				if(txtGoodsID.Text.Trim()=="")
				{
					MessageBox.Show("商品信息有误，请重新选择商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					txtGoodsID.Text="";
					cmbGoodsName.Items.Clear();
					cmbGoodsName.Refresh();
					txtIgPay.Text="";
					txtCount.Text="";
				}
				if((int.Parse(txtTolCharge.Text.Trim())+dIgPay)>LastIg)
				{
					MessageBox.Show("所剩积分不能再兑换此商品！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                    return;
				}
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					bool sumflag=false;
					for(int i=0;i<dtIgItem.Rows.Count;i++)
					{
						if(gs.strGoodsID==dtIgItem.Rows[i]["GoodsID"].ToString())
						{
							dtIgItem.Rows[i]["Count"]=(int.Parse(dtIgItem.Rows[i]["Count"].ToString())+dCount).ToString();
							dtIgItem.Rows[i]["IgPay"]=(int.Parse(dtIgItem.Rows[i]["IgPay"].ToString())+(dIgPay*dCount)).ToString();
							sumflag=true;
							break;
						}
					}
					if(!sumflag)
					{
						DataRow dr=dtIgItem.NewRow();
						dr[0]=gs.strGoodsID;
						dr[1]=gs.strGoodsName;
						dr[2]=dIgPay.ToString();
						dr[3]=dCount.ToString();
						dr[4]=(dIgPay*dCount).ToString();
						dtIgItem.Rows.Add(dr);
					}
					this.DgBind();
					txtCount.Focus();
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
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("童鞋，刷卡失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }

			if(dtIgItem.Rows.Count<=0)
			{
				MessageBox.Show("没有进行任何兑换操作！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			int dTolCharge=int.Parse(txtTolCharge.Text.Trim());
			if(double.Parse(txtIgCur.Text.Trim())<dTolCharge)
			{
				MessageBox.Show("当前积分不足，不能兑换！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strAssID=txtAssID.Text.Trim();
			cis.strCardID=txtCardID.Text.Trim();
			cis.dChargeLast=double.Parse(txtIgCur.Text.Trim());
			cis.dTolCharge=(double)dTolCharge;
			string strIG=(cis.dChargeLast-dTolCharge).ToString()+"分";
			string strCharge=this.txtCharge.Text.Trim()+"元";
            DateTime dtNow = DateTime.Now;
            cis.iSerial =Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
            cis.strOperDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
            //cis.iSerial = Int64.Parse(cis.strOperDate.Substring(0, 4) + cis.strOperDate.Substring(5, 2) + cis.strOperDate.Substring(8, 2) + cis.strOperDate.Substring(11, 2) + cis.strOperDate.Substring(14, 2) + cis.strOperDate.Substring(17, 2));
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.dTRate=0;
			cis.dPay=dTolCharge;
			cis.dBalance=0;
			cis.strConsType="PT003";
			cis.dtItem=dtIgItem;
			cis.iIgLast=int.Parse(txtIgCur.Text.Trim());
			cis.strIgType="IGT02";
			cis.strDeptID=SysInitial.CurOps.strDeptID;
			DataTable dtIG=SysInitial.dsSys.Tables["IG"];
			cis.iIgValue=-dTolCharge;
			chs.iCurIg=cis.iIgLast+cis.iIgValue;

			string strSerialok="";
			err=null;
			string strresult=cs.IntegralChange(cis,chs,out err,out strSerialok);
            strSerialok = cis.iSerial.ToString();
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(err!=null)
				{
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
					{
						MessageBox.Show("积分兑换失败，请重试！\n" + err.Message,"系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err);
					}
					else
					{
						MessageBox.Show("积分兑换失败，请重试！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine(err + " " + strresult);
					}
				}
				else
				{
					if(strresult!="")
					{
						strresult=this.GetColCh(strresult,"ERR");
						MessageBox.Show("积分兑换失败，请重试！\n","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine("card:" + cis.strCardID + " " + strresult);
					}
				}
			}
			else
			{
				System.Windows.Forms.DialogResult diaRes1=MessageBox.Show("积分兑换成功！是否打印？","请确认",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					if(strSerialok=="")
					{
						MessageBox.Show("打印小票出错，请与管理员联系！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						this.Close();
					}
					else
					{

						//this.PrintBill(chs.strCardID,strSerialok,strCharge,strIG,this.GetColCh(cis.strDeptID,"MD"),cis.strDeptID);
						this.AssIgPrint(chs,cis,cs,strSerialok,dtIgItem,dTolCharge);
					}
				}
				this.ClearText();
				txtGoodsID.ReadOnly=true;
				cmbGoodsName.Enabled=false;
				txtCount.ReadOnly=true;
				sbtnRead.Enabled=true;
				txtTolCount.Text="0";
				txtTolCharge.Text="0";
				dtIgItem=new DataTable();
				dtIgItem.Columns.Add("GoodsID");
				dtIgItem.Columns.Add("GoodsName");
				dtIgItem.Columns.Add("IgValue");
				dtIgItem.Columns.Add("Count");
				dtIgItem.Columns.Add("IgPay");
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				for(int i=0;i<dtIgItem.Rows.Count;i++)
				{
					if(strGoodsID==dtIgItem.Rows[i]["GoodsID"].ToString())
					{
						dtIgItem.Rows[i]["Count"]=(double.Parse(dtIgItem.Rows[i]["Count"].ToString())-1).ToString();
						dtIgItem.Rows[i]["IgPay"]=(double.Parse(dtIgItem.Rows[i]["IgPay"].ToString())-double.Parse(dtIgItem.Rows[i]["IgValue"].ToString())).ToString();
						if(dtIgItem.Rows[i]["Count"].ToString()=="0")
						{
							dtIgItem.Rows.Remove(dtIgItem.Rows[i]);
						}
					}
				}
				this.DgBind();
			}
		}

		private void PrintBill(string strCardID,string strSerial,string strCharge,string strIG,string strDeptName,string strDeptID)
		{
			try
			{
    //            Hashtable hspara=new Hashtable();
    //            hspara.Add("strSerial",strSerial);
    //            hspara.Add("strCharge",strCharge);
    //            hspara.Add("strIG",strIG);
    //            hspara.Add("strDeptName",strDeptName);
    //            hspara.Add("strDeptID",strDeptID);
    //            hspara.Add("strCon",SysInitial.ConString);
    //            hspara.Add("strCardID",strCardID);
    //            hspara.Add("strOperName",SysInitial.CurOps.strOperName);
    //            DevExpress.XtraPrinting.PrintingSystem ps=new DevExpress.XtraPrinting.PrintingSystem();
    //            DevExpress.XtraReports.UI.XtraReport report1=new CMSM.Report.xrConsTiny(hspara);
    //            report1.PrintingSystem=ps;
    //            report1.CreateDocument();

    //            //ps.PageSettings.PaperKind= System.Drawing.Printing.PaperKind.Custom;
    //            ps.PageSettings.TopMargin=0;
    //            ps.PageSettings.LeftMargin=-5;
    //            ps.PageSettings.RightMargin=0;
    //            ps.PageSettings.BottomMargin=0;
    ////			report1.ShowPreview();
    //            report1.Print();
			}
			catch(Exception e)
			{
				MessageBox.Show("打印机设置有误，无法打印！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(e.ToString());
			}
			finally
			{
							
			}
		}

		private void frmIntegralChange_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
				case Keys.F5:   
					sbtnRead.PerformClick(); 
					break;
				case Keys.F6:   
					sbtnOk.PerformClick();   
					break;   
			}  
		}
        
	}
}
