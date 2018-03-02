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
	public class frmRollCard : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssName;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtCharge;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssID;
		Exception err;
		private System.Windows.Forms.Label lblerr;
		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtRollFill;
		private System.Windows.Forms.TextBox txtRollP;
		private System.Windows.Forms.TextBox txtIG;
		private System.Windows.Forms.Label label7;
        private Button sbtnRead;
        private BackgroundWorker backgroundWorker1;
        private Button sbtnFill;
        private Button sbtnClose;
		double promrate=0;

		public frmRollCard()
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
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.lblerr = new System.Windows.Forms.Label();
            this.txtRollFill = new System.Windows.Forms.TextBox();
            this.txtRollP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sbtnRead = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            // lblerr
            // 
            this.lblerr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblerr.Location = new System.Drawing.Point(8, 48);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(224, 48);
            this.lblerr.TabIndex = 22;
            this.lblerr.Visible = false;
            // 
            // txtRollFill
            // 
            this.txtRollFill.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRollFill.ForeColor = System.Drawing.Color.Red;
            this.txtRollFill.Location = new System.Drawing.Point(88, 232);
            this.txtRollFill.Name = "txtRollFill";
            this.txtRollFill.Size = new System.Drawing.Size(144, 22);
            this.txtRollFill.TabIndex = 26;
            // 
            // txtRollP
            // 
            this.txtRollP.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRollP.Location = new System.Drawing.Point(88, 200);
            this.txtRollP.Name = "txtRollP";
            this.txtRollP.Size = new System.Drawing.Size(144, 22);
            this.txtRollP.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(24, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "�����˿�";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "���ձ���";
            // 
            // txtIG
            // 
            this.txtIG.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIG.Location = new System.Drawing.Point(88, 168);
            this.txtIG.Name = "txtIG";
            this.txtIG.Size = new System.Drawing.Size(144, 22);
            this.txtIG.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(24, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "��ǰ����";
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(8, 288);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 29;
            this.sbtnRead.Text = "ˢ��";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // sbtnFill
            // 
            this.sbtnFill.Location = new System.Drawing.Point(91, 288);
            this.sbtnFill.Name = "sbtnFill";
            this.sbtnFill.Size = new System.Drawing.Size(75, 23);
            this.sbtnFill.TabIndex = 30;
            this.sbtnFill.Text = "����";
            this.sbtnFill.UseVisualStyleBackColor = true;
            this.sbtnFill.Click += new System.EventHandler(this.sbtnFill_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(174, 288);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 31;
            this.sbtnClose.Text = "ȡ��";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmRollCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(258, 327);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnFill);
            this.Controls.Add(this.sbtnRead);
            this.Controls.Add(this.txtIG);
            this.Controls.Add(this.txtRollFill);
            this.Controls.Add(this.txtRollP);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.txtAssID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblerr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRollCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ա������";
            this.Load += new System.EventHandler(this.frmRollCard_Load);
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
			}
		}

		private void frmRollCard_Load(object sender, System.EventArgs e)
		{
			txtCharge.ReadOnly=true;
			txtAssName.ReadOnly=true;
			txtLinkPhone.ReadOnly=true;
			txtCardID.ReadOnly=true;
			this.txtIG.Enabled=false;
			sbtnFill.Enabled=false;
			lblerr.Visible=false;
			this.txtRollP.Enabled=false;
			this.txtRollFill.Enabled=false;
		}

		private void sbtnFill_Click(object sender, System.EventArgs e)
		{
			promrate=double.Parse(SysInitial.dsSys.Tables["FP6"].Rows[0]["vcCommCode"].ToString());
			if (promrate==0)
			{
				promrate=100;
			}
		    string strCardID=txtCardID.Text.Trim();
			string strCharge=txtCharge.Text.Trim();
			string strAssID=txtAssID.Text.Trim();
		    int iIG=int.Parse(txtIG.Text.Trim());
			string strOperDate=System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
			if(strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���Ϊ����С��10λ����������д��Ա���ţ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}
			if (strCardID!="")
			{
				System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ�ȷ������,����Ϊ��"+ strCardID +"�����ս��Ϊ�� " + strCharge +" Ԫ","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
				if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
				{
					string strresult=cs.CardRollback(strCardID,strCharge,strAssID,strOperDate,promrate,iIG,out err);
					if (strresult!="")
					{
						if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="000")
						{
							MessageBox.Show("���ջ�Ա���ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
							this.txtCardID.Text="";
							this.txtCharge.Text="";
							this.txtAssName.Text="";
							this.txtLinkPhone.Text="";
							this.sbtnFill.Enabled=false;
							this.sbtnRead.Enabled=true;
							clog.WriteLine(strresult);
						}
						else
						{
							MessageBox.Show("���ջ�Ա��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							lblerr.Text="���ջ�Ա��ʧ�ܣ����λ�����Ч����������Ƿ���ȷ��";
							this.txtCardID.Text="";
							this.txtCharge.Text="";
							this.txtAssName.Text="";
							this.txtLinkPhone.Text="";
							lblerr.Visible=true;
							clog.WriteLine(err);
							clog.WriteLine(strresult);
						}
					}
					else 
					{
						MessageBox.Show("���ջ�Ա��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						lblerr.Text="���ջ�Ա��ʧ�ܣ����λ�����Ч����������Ƿ���ȷ��";
						this.txtCardID.Text="";
						this.txtCharge.Text="";
						this.txtAssName.Text="";
						this.txtLinkPhone.Text="";
						lblerr.Visible=true;
						sbtnFill.Enabled=false;
						sbtnRead.Enabled=true;
						clog.WriteLine(err);
						clog.WriteLine(strresult);
					}
				}
			}
			else 
			{
				MessageBox.Show("���ջ�Ա��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				lblerr.Text="���ջ�Ա��ʧ�ܣ����λ�����Ч����������Ƿ���ȷ��";
				lblerr.Visible=true;
				clog.WriteLine(err);
			}
		}

		private void txtFillFee_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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


		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��ˢ��ʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
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
					if(chs.iCurIg==-1)
					{
						chs.iCurIg=assres.iIgValue;
					}
                    if (assres.dCharge>0)
                    {
                        MessageBox.Show("�û�Ա���������㣬�봦�����Ϊ���ٻ��գ�", "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
					txtAssID.Text=assres.strAssID;
					txtCardID.Text=assres.strCardID;
					txtAssName.Text=assres.strAssName;
					txtLinkPhone.Text=assres.strLinkPhone;
					txtIG.Text=chs.iCurIg.ToString();
					txtCharge.Text=chs.dCurCharge.ToString();
					this.txtRollP.Text=SysInitial.dsSys.Tables["FP6"].Rows[0]["vcCommCode"].ToString();
					this.txtRollFill.Text=(double.Parse(this.txtCharge.Text)*(100-double.Parse(SysInitial.dsSys.Tables["FP6"].Rows[0]["vcCommCode"].ToString()))/100).ToString();
					txtCardID.ReadOnly=true;
					sbtnFill.Enabled=true;
					sbtnRead.Enabled=false;
				}
				else
				{
					MessageBox.Show("�޴�������Ա����˲�˿�״̬��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
				}
			}
		}
	}
}
