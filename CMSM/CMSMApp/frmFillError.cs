using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using CMSMData;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmFillFee ��ժҪ˵����
	/// </summary>
	public class frmFillError : CMSM.CMSMApp.frmBase
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
        private Button sbtnRead;
        private Button sbtnFill;
        private Button sbtnClose;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();

		public frmFillError()
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
            this.sbtnRead = new System.Windows.Forms.Button();
            this.sbtnFill = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 5;
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
            this.txtFillFee.Location = new System.Drawing.Point(88, 176);
            this.txtFillFee.Name = "txtFillFee";
            this.txtFillFee.Size = new System.Drawing.Size(144, 22);
            this.txtFillFee.TabIndex = 11;
            this.txtFillFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFillFee_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 184);
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
            this.txtPromFee.Location = new System.Drawing.Point(88, 216);
            this.txtPromFee.Name = "txtPromFee";
            this.txtPromFee.Size = new System.Drawing.Size(144, 22);
            this.txtPromFee.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(24, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "�˹���ֻ������Ѵ��󣬽��в��䡣";
            // 
            // lblerr
            // 
            this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblerr.Location = new System.Drawing.Point(16, 112);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(232, 48);
            this.lblerr.TabIndex = 22;
            this.lblerr.Visible = false;
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(13, 256);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 23;
            this.sbtnRead.Text = "ˢ��";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // sbtnFill
            // 
            this.sbtnFill.Location = new System.Drawing.Point(94, 256);
            this.sbtnFill.Name = "sbtnFill";
            this.sbtnFill.Size = new System.Drawing.Size(75, 23);
            this.sbtnFill.TabIndex = 24;
            this.sbtnFill.Text = "��ֵ";
            this.sbtnFill.UseVisualStyleBackColor = true;
            this.sbtnFill.Click += new System.EventHandler(this.sbtnFill_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(175, 256);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 25;
            this.sbtnClose.Text = "ȡ��";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmFillError
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(262, 296);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnFill);
            this.Controls.Add(this.sbtnRead);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblerr);
            this.Controls.Add(this.txtPromFee);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtFillFee);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.txtAssID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFillError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ա������ֵ";
            this.Load += new System.EventHandler(this.frmFillFee_Load);
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
			txtPromFee.Text="0";
			txtPromFee.Visible=false;
		}

		private void sbtnFill_Click(object sender, System.EventArgs e)
		{
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
					double dFeeLast=Double.Parse(txtCharge.Text.Trim());
					CMSMStruct.FillFeeStruct ffs=new CMSMData.CMSMStruct.FillFeeStruct();
					ffs.strAssID=txtAssID.Text.Trim();
					ffs.strCardID=strCardID;
					ffs.dFillFee=dFee;
					string promrate="0";
					ffs.dFillProm=(double.Parse(txtFillFee.Text.Trim())*(double.Parse(promrate))/100);
					ffs.dFeeLast=dFeeLast;
					ffs.dFeeCur=System.Math.Round((dFee+ffs.dFillProm+dFeeLast),2);
					ffs.strDeptID=SysInitial.CurOps.strDeptID;
                    DateTime dtNow = DateTime.Now;
                    ffs.iSerial =Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
                    ffs.strFillDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
					double dChargeBak=Double.Parse(txtCharge.Text.Trim())+Double.Parse(txtFillFee.Text.Trim())+Double.Parse(txtPromFee.Text.Trim());
					if(ffs.dFeeCur!=dChargeBak)
					{
						MessageBox.Show("��ֵʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						clog.WriteLine("��ֵ����ֵ�����ֵ���ȣ�����ֵ��" + dChargeBak.ToString() + " ����ֵ" + ffs.dFeeCur.ToString());
						return;
					}

					string strresult=cs.FillFeeError(ffs,chs.iCurIg,dChargeBak,out err);
					if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
					{
						MessageBox.Show("��ֵ�ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
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
					this.sbtnFill.Enabled=false;
					this.sbtnRead.Enabled=true;
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

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ������ֵʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
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
			if(chs.strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���ȷ�������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else if(chs.strCardID.Substring(0,1)=="F")
			{
				MessageBox.Show("�˿�ΪԱ���������ɽ������ѣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
					if(chs.iCurIg==-1)
					{
						chs.iCurIg=assres.iIgValue;
					}
					txtAssID.Text=assres.strAssID;
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;
					txtCharge.Text=chs.dCurCharge.ToString();
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
	}
}
