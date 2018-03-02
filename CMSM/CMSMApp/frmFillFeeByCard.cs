using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using CMSMData;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmFillFee ��ժҪ˵����
	/// </summary>
	public class frmFillFeeByCard : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAssName;
        private System.Windows.Forms.Label label3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFillFee;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPromFee;
		Exception err;
		private System.Windows.Forms.Label lblerr;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtIg;
		private System.Windows.Forms.CheckBox chkIsBank;
		private System.Windows.Forms.TextBox txtZeroFlag;
		private System.Windows.Forms.TextBox txtAssType;
        private Button sbtnRead;
        private Button sbtnFill;
        private Button sbtnClose;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

		public frmFillFeeByCard()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFillFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.txtPromFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblerr = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIg = new System.Windows.Forms.TextBox();
            this.chkIsBank = new System.Windows.Forms.CheckBox();
            this.txtZeroFlag = new System.Windows.Forms.TextBox();
            this.txtAssType = new System.Windows.Forms.TextBox();
            this.sbtnRead = new System.Windows.Forms.Button();
            this.sbtnFill = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 22);
            this.txtCardID.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "��Ա����";
            // 
            // txtAssName
            // 
            this.txtAssName.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssName.Location = new System.Drawing.Point(88, 56);
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(144, 22);
            this.txtAssName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "��Ա����";
            // 
            // txtFillFee
            // 
            this.txtFillFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFillFee.Location = new System.Drawing.Point(88, 216);
            this.txtFillFee.Name = "txtFillFee";
            this.txtFillFee.Size = new System.Drawing.Size(144, 22);
            this.txtFillFee.TabIndex = 11;
            this.txtFillFee.TextChanged += new System.EventHandler(this.txtFillFee_TextChanged);
            this.txtFillFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFillFee_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "��ֵ���";
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 96);
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(144, 22);
            this.txtLinkPhone.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "��ϵ�绰";
            // 
            // txtCharge
            // 
            this.txtCharge.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.Location = new System.Drawing.Point(88, 136);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(144, 22);
            this.txtCharge.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "��ǰ���";
            // 
            // txtAssID
            // 
            this.txtAssID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssID.Location = new System.Drawing.Point(0, 0);
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(88, 22);
            this.txtAssID.TabIndex = 18;
            this.txtAssID.Visible = false;
            // 
            // txtPromFee
            // 
            this.txtPromFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPromFee.Location = new System.Drawing.Point(88, 256);
            this.txtPromFee.Name = "txtPromFee";
            this.txtPromFee.Size = new System.Drawing.Size(144, 22);
            this.txtPromFee.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "������";
            // 
            // lblerr
            // 
            this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblerr.Location = new System.Drawing.Point(16, 128);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(232, 48);
            this.lblerr.TabIndex = 22;
            this.lblerr.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "��ǰ����";
            // 
            // txtIg
            // 
            this.txtIg.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIg.Location = new System.Drawing.Point(88, 176);
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(144, 22);
            this.txtIg.TabIndex = 27;
            // 
            // chkIsBank
            // 
            this.chkIsBank.Location = new System.Drawing.Point(88, 288);
            this.chkIsBank.Name = "chkIsBank";
            this.chkIsBank.Size = new System.Drawing.Size(88, 24);
            this.chkIsBank.TabIndex = 28;
            this.chkIsBank.Text = "���п�";
            // 
            // txtZeroFlag
            // 
            this.txtZeroFlag.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZeroFlag.Location = new System.Drawing.Point(0, 40);
            this.txtZeroFlag.Name = "txtZeroFlag";
            this.txtZeroFlag.ReadOnly = true;
            this.txtZeroFlag.Size = new System.Drawing.Size(88, 22);
            this.txtZeroFlag.TabIndex = 29;
            this.txtZeroFlag.Visible = false;
            // 
            // txtAssType
            // 
            this.txtAssType.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssType.Location = new System.Drawing.Point(0, 80);
            this.txtAssType.Name = "txtAssType";
            this.txtAssType.ReadOnly = true;
            this.txtAssType.Size = new System.Drawing.Size(88, 22);
            this.txtAssType.TabIndex = 30;
            this.txtAssType.Visible = false;
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(18, 320);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(56, 23);
            this.sbtnRead.TabIndex = 31;
            this.sbtnRead.Text = "ˢ��";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // sbtnFill
            // 
            this.sbtnFill.Location = new System.Drawing.Point(101, 320);
            this.sbtnFill.Name = "sbtnFill";
            this.sbtnFill.Size = new System.Drawing.Size(56, 23);
            this.sbtnFill.TabIndex = 32;
            this.sbtnFill.Text = "��ֵ";
            this.sbtnFill.UseVisualStyleBackColor = true;
            this.sbtnFill.Click += new System.EventHandler(this.sbtnFill_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(192, 320);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(56, 23);
            this.sbtnClose.TabIndex = 33;
            this.sbtnClose.Text = "ȡ��";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmFillFeeByCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(262, 356);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnFill);
            this.Controls.Add(this.sbtnRead);
            this.Controls.Add(this.lblerr);
            this.Controls.Add(this.txtAssType);
            this.Controls.Add(this.txtZeroFlag);
            this.Controls.Add(this.txtIg);
            this.Controls.Add(this.txtPromFee);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtFillFee);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.txtAssID);
            this.Controls.Add(this.chkIsBank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFillFeeByCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "��Ա����ֵ";
            this.Load += new System.EventHandler(this.frmFillFee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFillFeeByCard_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(txtCardID.Text=="")
			{
				this.Close();
			}
			else
			{
				this.ClearText();
				this.sbtnRead.Enabled=true;
				this.sbtnFill.Enabled=false;
				this.txtFillFee.ReadOnly=true;
			}
		}

		private void frmFillFee_Load(object sender, System.EventArgs e)
		{
			txtCharge.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtPromFee.ReadOnly=true;
			txtCardID.ReadOnly=true;
			sbtnFill.Enabled=false;
			txtFillFee.ReadOnly=true;
			lblerr.Visible=false;
			this.txtIg.ReadOnly=true;
		}

		private void sbtnFill_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ����ֵʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                this.ClearText();
                txtCardID.ReadOnly = true;
                this.txtFillFee.ReadOnly = true;
                this.sbtnFill.Enabled = false;
                this.sbtnRead.Enabled = true;
                this.chkIsBank.Checked = false;
                return;
            }
  
			string strCardID=txtCardID.Text.Trim();
			if(strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���Ϊ����С��10λ����������д��Ա���ţ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			if(txtFillFee.Text.Trim()=="")
			{
				MessageBox.Show("��ֵ����Ϊ�գ����������룡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			double dFee=Double.Parse(txtFillFee.Text.Trim());
			if(dFee<=0)
			{
				MessageBox.Show("��ֵ���Ӧ����0�����������룡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ�ȷ����ֵ" + dFee.ToString() + "Ԫ��","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					err=null;
					double dFeeLast=double.Parse(txtCharge.Text.Trim());
					int iIgLast=int.Parse(this.txtIg.Text.Trim());
					CMSMStruct.FillFeeStruct ffs=new CMSMData.CMSMStruct.FillFeeStruct();
					ffs.strAssID=txtAssID.Text.Trim();
					ffs.strCardID=strCardID;
					ffs.dFillFee=dFee;
					string strAssType=this.txtAssType.Text.Trim();
					string promrate="0";
					promrate = this.GetPromrate(ffs.dFillFee).ToString();

					int cc=(int)decimal.Parse(txtFillFee.Text.Trim());
					int dd=((int)decimal.Parse(txtFillFee.Text.Trim())*(int.Parse(promrate))/100);
					ffs.dFillProm=((int)decimal.Parse(txtFillFee.Text.Trim())*(int.Parse(promrate))/100);
					ffs.dFeeLast=dFeeLast;
					ffs.dFeeCur=System.Math.Round((dFee+dFeeLast),2) + System.Math.Round((ffs.dFillProm),0);
					double bb=System.Math.Round((ffs.dFillProm),0);
					double aa =ffs.dFeeCur;
					ffs.strDeptID=SysInitial.CurOps.strDeptID;
                    DateTime dtNow = DateTime.Now;
                    ffs.strFillDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
                    ffs.iSerial = Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
                    //ffs.iSerial = Int64.Parse(ffs.strFillDate.Substring(0, 4) + ffs.strFillDate.Substring(5, 2) + ffs.strFillDate.Substring(8, 2) + ffs.strFillDate.Substring(11, 2) + ffs.strFillDate.Substring(14, 2) + ffs.strFillDate.Substring(17, 2));
					if(chkIsBank.Checked)
					{
						ffs.strComments = "���п�";
					}
					else
					{
						ffs.strComments = "";
					}

					double dChargeBak=System.Math.Round((Double.Parse(txtCharge.Text.Trim())+Double.Parse(txtFillFee.Text.Trim())+Double.Parse(txtPromFee.Text.Trim())),2);
					if(ffs.dFeeCur!=dChargeBak)
					{
						MessageBox.Show("��ֵʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine("��ֵ����ֵ�����ֵ���ȣ�����ֵ��" + dChargeBak.ToString() + " ����ֵ" + ffs.dFeeCur.ToString());
						return;
					}

					string strresult=cs.FillFee(ffs,int.Parse(this.txtIg.Text.Trim()),dChargeBak,this.txtZeroFlag.Text.Trim(),out err);
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
					{
						System.Windows.Forms.DialogResult diaRes1=MessageBox.Show("��ֵ�ɹ����Ƿ��ӡ��","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
						if(diaRes1.Equals(System.Windows.Forms.DialogResult.Yes))
						{
							this.FillFeePrint(ffs,cs,this.txtAssName.Text);
							this.OpenDrawer();
						}
						
						//zhh 20100311
						clog.WriteLine(strresult);
					}
					else
					{
						MessageBox.Show("��ֵʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						lblerr.Text="��ֵʧ�ܣ����γ�ֵ��Ч����������Ƿ���ȷ��";
						lblerr.Visible=true;
						clog.WriteLine(err);
						clog.WriteLine(strresult);
					}
					this.ClearText();
					txtCardID.ReadOnly=true;
					this.txtFillFee.ReadOnly=true;
					this.sbtnFill.Enabled=false;
					this.sbtnRead.Enabled=true;
					this.chkIsBank.Checked = false;
				}
			}
		}

		private void txtFillFee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

		private void txtFillFee_TextChanged(object sender, EventArgs e)
		{
			if (this.txtFillFee.Text.Trim()!="" && this.txtFillFee.Text.Trim()!="0"&& this.txtFillFee.Text.Trim()!=".")
			{
				string strFillFee=txtFillFee.Text.Trim();
				int ifillfee= (int)decimal.Parse(strFillFee);
				int prom = this.GetPromrate(double.Parse(strFillFee));
				txtPromFee.Text = (ifillfee*prom/100).ToString();
//				if(ifillfee>=100&&ifillfee<200)
//				{
//					txtPromFee.Text=(ifillfee*(int.Parse(SysInitial.dsSys.Tables["FP1"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
//				}
//				else if(ifillfee>=200&&ifillfee<300)
//				{
//					txtPromFee.Text=(ifillfee*(int.Parse(SysInitial.dsSys.Tables["FP2"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
//				}
//				else if(ifillfee>=300&&ifillfee<400)
//				{
//					txtPromFee.Text=(ifillfee*(int.Parse(SysInitial.dsSys.Tables["FP3"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
//				}
//				else if(ifillfee>=400&&ifillfee<500)
//				{
//					txtPromFee.Text=(ifillfee*(int.Parse(SysInitial.dsSys.Tables["FP4"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
//				}
//				else if(ifillfee>=500)
//				{
//					txtPromFee.Text=(ifillfee*(int.Parse(SysInitial.dsSys.Tables["FP5"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
//				}
//				else
//				{
//					txtPromFee.Text="0";
//				}
			}
		}

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��VPN�����˻�������̫��,����vpn���ӣ�");
                return;
            }             

			string strresult="";
			lblerr.Visible=false;
			chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("�ÿ������ڱ�ϵͳʹ�õĿ������飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult!="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("ˢ��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(strresult!=null)
				{
					clog.WriteLine(strresult);
				}
				return;
			}
			string aaccc=chs.strCardID;
//			chs.strCardID="GY000011";
			if(chs.strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���ȷ�������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("�˿�ΪԱ���������ɽ��г�ֵ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
						MessageBox.Show("�û�Ա�Ѿ�ʧЧ����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					if(chs.dCurCharge==-1)
					{
						chs.dCurCharge=assres.dCharge;
					}
					if(int.Parse(SysInitial.Card)==8)
					{
						if(chs.dCurCharge<=2&&assres.strAssType=="AT001")
						{
							double dRate=0;
							if(!cs.AssTypeTrans(assres.strCardID,"AT002",out dRate,out err))
							{
								clog.WriteLine("���������ʧ�ܣ�"+assres.strCardID+"��\n"+err.ToString());
							}
							else
							{
								assres.strAssType="AT002";
								assres.dRate=dRate;
							}
						}
						if(assres.strAssType=="AT001")
						{
							MessageBox.Show("�Ͽ���Ա�������ֵ�����Ƚ�������������꣡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
					}
					if(assres.dtCreateDate.CompareTo(SysInitial.dtQLTime)<0&&!assres.setZeroFlag)
					{
						chs.iCurIg=0;
						this.txtZeroFlag.Text="1";
					}
					if(chs.iCurIg==-1)
					{
						chs.iCurIg=assres.iIgValue;
					}
					txtAssID.Text=assres.strAssID;
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					this.txtAssType.Text=assres.strAssType;
					txtLinkPhone.Text=assres.strLinkPhone;
					txtCharge.Text=chs.dCurCharge.ToString();
					this.txtIg.Text=chs.iCurIg.ToString();
					txtCardID.ReadOnly=true;
					sbtnFill.Enabled=true;
					sbtnRead.Enabled=false;
					txtFillFee.ReadOnly=false;
					txtFillFee.Focus();
				}
				else
				{
					MessageBox.Show("�޴˻�Ա����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
				}
			}
		}

		private void frmFillFeeByCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
//				case Keys.Add:   
//					this.OpenDrawer();
//					break;
			}  
		}
	}
}
