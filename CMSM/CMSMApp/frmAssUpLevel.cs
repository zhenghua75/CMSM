using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CMSMData.CMSMDataAccess;
using System.Data;
using CMSMData;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmAssUpLevel ��ժҪ˵����
	/// </summary>
	public class frmAssUpLevel : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.TextBox txtIg;
		private System.Windows.Forms.TextBox txtLinkPhone;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.TextBox txtAssID;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContent;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		CMSMStruct.CardHardStruct chs=new CMSMData.CMSMStruct.CardHardStruct();
		Exception err;
		private System.Windows.Forms.TextBox txtZeroFlag;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAssType;
		private System.Windows.Forms.TextBox txtAssTypeCode;
        private Button sbtnToGold;
        private Button sbtnRead;
        private Button sbtnToSilver;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmAssUpLevel()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

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
            this.txtIg = new System.Windows.Forms.TextBox();
            this.txtLinkPhone = new System.Windows.Forms.TextBox();
            this.txtAssName = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.txtAssID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtZeroFlag = new System.Windows.Forms.TextBox();
            this.txtAssType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssTypeCode = new System.Windows.Forms.TextBox();
            this.sbtnToGold = new System.Windows.Forms.Button();
            this.sbtnRead = new System.Windows.Forms.Button();
            this.sbtnToSilver = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIg
            // 
            this.txtIg.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIg.Location = new System.Drawing.Point(88, 136);
            this.txtIg.Name = "txtIg";
            this.txtIg.Size = new System.Drawing.Size(144, 22);
            this.txtIg.TabIndex = 48;
            // 
            // txtLinkPhone
            // 
            this.txtLinkPhone.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLinkPhone.Location = new System.Drawing.Point(88, 96);
            this.txtLinkPhone.Name = "txtLinkPhone";
            this.txtLinkPhone.Size = new System.Drawing.Size(144, 22);
            this.txtLinkPhone.TabIndex = 39;
            // 
            // txtAssName
            // 
            this.txtAssName.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssName.Location = new System.Drawing.Point(88, 56);
            this.txtAssName.Name = "txtAssName";
            this.txtAssName.Size = new System.Drawing.Size(144, 22);
            this.txtAssName.TabIndex = 34;
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(88, 16);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 22);
            this.txtCardID.TabIndex = 31;
            // 
            // txtAssID
            // 
            this.txtAssID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssID.Location = new System.Drawing.Point(0, 0);
            this.txtAssID.Name = "txtAssID";
            this.txtAssID.ReadOnly = true;
            this.txtAssID.Size = new System.Drawing.Size(88, 22);
            this.txtAssID.TabIndex = 42;
            this.txtAssID.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 47;
            this.label8.Text = "��ǰ����";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "��Ա����";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "��ϵ�绰";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "��Ա����";
            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.ForeColor = System.Drawing.Color.Red;
            this.lblContent.Location = new System.Drawing.Point(8, 216);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(256, 80);
            this.lblContent.TabIndex = 51;
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZeroFlag
            // 
            this.txtZeroFlag.Location = new System.Drawing.Point(0, 40);
            this.txtZeroFlag.Name = "txtZeroFlag";
            this.txtZeroFlag.ReadOnly = true;
            this.txtZeroFlag.Size = new System.Drawing.Size(88, 21);
            this.txtZeroFlag.TabIndex = 53;
            this.txtZeroFlag.Visible = false;
            // 
            // txtAssType
            // 
            this.txtAssType.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssType.Location = new System.Drawing.Point(88, 176);
            this.txtAssType.Name = "txtAssType";
            this.txtAssType.Size = new System.Drawing.Size(144, 22);
            this.txtAssType.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "��Ա����";
            // 
            // txtAssTypeCode
            // 
            this.txtAssTypeCode.Location = new System.Drawing.Point(0, 80);
            this.txtAssTypeCode.Name = "txtAssTypeCode";
            this.txtAssTypeCode.ReadOnly = true;
            this.txtAssTypeCode.Size = new System.Drawing.Size(88, 21);
            this.txtAssTypeCode.TabIndex = 56;
            this.txtAssTypeCode.Visible = false;
            // 
            // sbtnToGold
            // 
            this.sbtnToGold.Location = new System.Drawing.Point(93, 343);
            this.sbtnToGold.Name = "sbtnToGold";
            this.sbtnToGold.Size = new System.Drawing.Size(75, 23);
            this.sbtnToGold.TabIndex = 57;
            this.sbtnToGold.Text = "������";
            this.sbtnToGold.UseVisualStyleBackColor = true;
            this.sbtnToGold.Click += new System.EventHandler(this.sbtnToGold_Click);
            // 
            // sbtnRead
            // 
            this.sbtnRead.Location = new System.Drawing.Point(11, 304);
            this.sbtnRead.Name = "sbtnRead";
            this.sbtnRead.Size = new System.Drawing.Size(75, 23);
            this.sbtnRead.TabIndex = 58;
            this.sbtnRead.Text = "ˢ��";
            this.sbtnRead.UseVisualStyleBackColor = true;
            this.sbtnRead.Click += new System.EventHandler(this.sbtnRead_Click);
            // 
            // sbtnToSilver
            // 
            this.sbtnToSilver.Location = new System.Drawing.Point(93, 304);
            this.sbtnToSilver.Name = "sbtnToSilver";
            this.sbtnToSilver.Size = new System.Drawing.Size(75, 23);
            this.sbtnToSilver.TabIndex = 59;
            this.sbtnToSilver.Text = "��������";
            this.sbtnToSilver.UseVisualStyleBackColor = true;
            this.sbtnToSilver.Click += new System.EventHandler(this.sbtnToSilver_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(189, 304);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 60;
            this.sbtnClose.Text = "ȡ��";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmAssUpLevel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(272, 378);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnToSilver);
            this.Controls.Add(this.sbtnRead);
            this.Controls.Add(this.sbtnToGold);
            this.Controls.Add(this.txtAssTypeCode);
            this.Controls.Add(this.txtAssType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtZeroFlag);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtIg);
            this.Controls.Add(this.txtLinkPhone);
            this.Controls.Add(this.txtAssName);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.txtAssID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmAssUpLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ա����";
            this.Load += new System.EventHandler(this.frmAssUpLevel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAssUpLevel_Load(object sender, System.EventArgs e)
		{
			this.txtCardID.ReadOnly=true;
			this.txtAssName.ReadOnly=true;
			this.txtLinkPhone.ReadOnly=true;
			this.txtIg.ReadOnly=true;
			this.txtAssType.ReadOnly=true;
			this.sbtnToSilver.Enabled=false;
			this.sbtnToGold.Enabled=false;
			this.lblContent.Font=new Font("����",12);
		}

		private void sbtnRead_Click(object sender, System.EventArgs e)
		{
			this.sbtnToSilver.Enabled=false;
			this.sbtnToGold.Enabled=false;
			this.lblContent.Text="";
			string strresult="";
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
					txtLinkPhone.Text=assres.strLinkPhone;
					this.txtIg.Text=chs.iCurIg.ToString();
					this.txtAssTypeCode.Text=assres.strAssType;
					this.txtAssType.Text=this.GetColCh(assres.strAssType,"AT");
					if(assres.strAssType=="AT001")
					{
						if(chs.iCurIg<1000)
						{
							this.lblContent.Text="�û�Ա�������ֲ���";
						}
						else
						{
							if(chs.iCurIg>=1000)
							{
								this.lblContent.Text="�û�Ա������ͨ��Ա������������Ա";
								this.sbtnToSilver.Enabled=true;
							}
							if(chs.iCurIg>=2000)
							{
								this.lblContent.Text="�û�Ա������ͨ��Ա������������Ա��𿨻�Ա";
								this.sbtnToGold.Enabled=true;
							}
						}
					}
					if(assres.strAssType=="AT003")
					{
						if(chs.iCurIg<1500)
						{
							this.lblContent.Text="�û�Ա�������ֲ���";
						}
						else
						{
							this.lblContent.Text="�û�Ա����������Ա�������𿨻�Ա";
							this.sbtnToGold.Enabled=true;
						}
					}
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

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnToSilver_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			if(strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���Ϊ����С��10λ����������д��Ա���ţ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}

			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ�ȷ��������������Ա��","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				int ilastig=int.Parse(this.txtIg.Text.Trim());
				int icurig=ilastig-1000;
				err=null;
				string strresult=cs.AssUpToSilverType(this.txtAssID.Text.Trim(),strCardID,icurig,ilastig,out err);
				if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
				{
					if(err!=null)
					{
						if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
						{
							MessageBox.Show("����������ʧ�ܣ������ԣ�\n" + err.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err);
						}
						else
						{
							MessageBox.Show("����������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err + " " + strresult);
						}
					}
					else
					{
						if(strresult!="")
						{
							strresult=this.GetColCh(strresult,"ERR");
							MessageBox.Show("����������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine("card:" + strCardID + " " + strresult);
						}
					}
				}
				else
				{
					MessageBox.Show("�����������ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				}
				this.ClearText();
				this.sbtnToSilver.Enabled=false;
				this.sbtnToGold.Enabled=false;
			}
		}

		private void sbtnToGold_Click(object sender, System.EventArgs e)
		{
			string strCardID=txtCardID.Text.Trim();
			if(strCardID=="")
			{
				MessageBox.Show("��Ա���Ų���Ϊ����С��10λ����������д��Ա���ţ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtCardID.Focus();
				return;
			}

			System.Windows.Forms.DialogResult diaRes=MessageBox.Show("�Ƿ�ȷ��������������Ա��","��ȷ��",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
			if(diaRes.Equals(System.Windows.Forms.DialogResult.Yes))
			{
				int ilastig=int.Parse(this.txtIg.Text.Trim());
				int icurig=0;
				if(this.txtAssTypeCode.Text.Trim()=="AT001")
					icurig=ilastig-2000;
				else
					icurig=ilastig-1500;
				err=null;
				string strresult=cs.AssUpToGoldType(this.txtAssTypeCode.Text.Trim(),this.txtAssID.Text.Trim(),strCardID,icurig,ilastig,out err);
				if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
				{
					if(err!=null)
					{
						if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
						{
							MessageBox.Show("��������ʧ�ܣ������ԣ�\n" + err.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err);
						}
						else
						{
							MessageBox.Show("��������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine(err + " " + strresult);
						}
					}
					else
					{
						if(strresult!="")
						{
							strresult=this.GetColCh(strresult,"ERR");
							MessageBox.Show("��������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							clog.WriteLine("card:" + strCardID + " " + strresult);
						}
					}
				}
				else
				{
					MessageBox.Show("�������𿨳ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				}
				this.ClearText();
				this.sbtnToSilver.Enabled=false;
				this.sbtnToGold.Enabled=false;
			}
		}
	}
}
