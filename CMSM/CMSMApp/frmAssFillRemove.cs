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
	/// frmAssConsRemove ��ժҪ˵����
	/// </summary>
	public class frmAssFillRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnRemove;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		Exception err;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCurCharge;
		private System.Windows.Forms.TextBox txtAssName;
		private System.Windows.Forms.TextBox txtAssID;
		private System.Windows.Forms.TextBox txtFillSerial;
		private System.Windows.Forms.TextBox txtFillFee;
		private System.Windows.Forms.TextBox txtFillDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPromFee;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		private string strOldDate="";

		public frmAssFillRemove()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.txtFillSerial = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRead = new System.Windows.Forms.Button();
			this.txtFillFee = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFillDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.txtCurCharge = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAssName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAssID = new System.Windows.Forms.TextBox();
			this.txtPromFee = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.AliceBlue;
			this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(40, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(440, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "��Ա��ֵ����ֻ�ܳ�����Ա1Сʱ���ڱ�������һ�γ�ֵ��֮��δ������";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "��Ա����";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(80, 80);
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(168, 22);
			this.txtCardID.TabIndex = 2;
			this.txtCardID.Text = "";
			// 
			// txtFillSerial
			// 
			this.txtFillSerial.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillSerial.Location = new System.Drawing.Point(336, 80);
			this.txtFillSerial.Name = "txtFillSerial";
			this.txtFillSerial.Size = new System.Drawing.Size(168, 22);
			this.txtFillSerial.TabIndex = 4;
			this.txtFillSerial.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(272, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "��ֵ��ˮ";
			// 
			// btnRead
			// 
			this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRead.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRead.Location = new System.Drawing.Point(144, 240);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(56, 24);
			this.btnRead.TabIndex = 5;
			this.btnRead.Text = "ˢ��";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// txtFillFee
			// 
			this.txtFillFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillFee.Location = new System.Drawing.Point(80, 160);
			this.txtFillFee.Name = "txtFillFee";
			this.txtFillFee.Size = new System.Drawing.Size(168, 22);
			this.txtFillFee.TabIndex = 8;
			this.txtFillFee.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "��ֵ���";
			// 
			// txtFillDate
			// 
			this.txtFillDate.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtFillDate.Location = new System.Drawing.Point(80, 200);
			this.txtFillDate.Name = "txtFillDate";
			this.txtFillDate.Size = new System.Drawing.Size(168, 22);
			this.txtFillDate.TabIndex = 10;
			this.txtFillDate.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(16, 208);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "��ֵʱ��";
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.ForeColor = System.Drawing.Color.Crimson;
			this.btnRemove.Location = new System.Drawing.Point(304, 240);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 24);
			this.btnRemove.TabIndex = 12;
			this.btnRemove.Text = "ȷ�ϳ���";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// txtCurCharge
			// 
			this.txtCurCharge.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCurCharge.Location = new System.Drawing.Point(336, 120);
			this.txtCurCharge.Name = "txtCurCharge";
			this.txtCurCharge.Size = new System.Drawing.Size(168, 22);
			this.txtCurCharge.TabIndex = 14;
			this.txtCurCharge.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(272, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "��Ա���";
			// 
			// txtAssName
			// 
			this.txtAssName.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssName.Location = new System.Drawing.Point(80, 120);
			this.txtAssName.Name = "txtAssName";
			this.txtAssName.Size = new System.Drawing.Size(168, 22);
			this.txtAssName.TabIndex = 16;
			this.txtAssName.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 128);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "��Ա����";
			// 
			// txtAssID
			// 
			this.txtAssID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssID.Location = new System.Drawing.Point(8, 232);
			this.txtAssID.Name = "txtAssID";
			this.txtAssID.Size = new System.Drawing.Size(96, 22);
			this.txtAssID.TabIndex = 17;
			this.txtAssID.Text = "";
			this.txtAssID.Visible = false;
			// 
			// txtPromFee
			// 
			this.txtPromFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPromFee.Location = new System.Drawing.Point(336, 160);
			this.txtPromFee.Name = "txtPromFee";
			this.txtPromFee.Size = new System.Drawing.Size(168, 22);
			this.txtPromFee.TabIndex = 19;
			this.txtPromFee.Text = "";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(272, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 18;
			this.label6.Text = "������";
			// 
			// frmAssFillRemove
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 274);
			this.Controls.Add(this.txtPromFee);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtAssID);
			this.Controls.Add(this.txtAssName);
			this.Controls.Add(this.txtCurCharge);
			this.Controls.Add(this.txtFillDate);
			this.Controls.Add(this.txtFillFee);
			this.Controls.Add(this.txtFillSerial);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmAssFillRemove";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "��Ա��ֵ����";
			this.Load += new System.EventHandler(this.frmAssConsRemove_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAssConsRemove_Load(object sender, System.EventArgs e)
		{
			this.txtCardID.ReadOnly=true;
			this.txtFillSerial.ReadOnly=true;
			this.txtAssName.ReadOnly=true;
			this.txtCurCharge.ReadOnly=true;
			this.txtFillFee.ReadOnly=true;
			this.txtFillDate.ReadOnly=true;
			this.txtPromFee.ReadOnly=true;
			this.btnRemove.Enabled=false;
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ����ʧʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }

			string strresult="";
			CMSMStruct.CardHardStruct chs=cs.ReadCardInfo("",out strresult);
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

			if(chs.strCardID!=txtCardID.Text.Trim())
			{
				MessageBox.Show("��ֵ���������״�ˢ������ͬһ�ſ�����ֵ����ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.ClearText();
				btnRead.Enabled=true;				
				return;
			}
			else
			{
				#region ��ʼ��ֵ����
				if(this.txtFillSerial.Text.Trim()=="")
				{
					MessageBox.Show("û���κο��Խ��г����ĳ�ֵ��¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					return;
				}

				CMSMData.CMSMStruct.FillFeeStruct refill=new CMSMData.CMSMStruct.FillFeeStruct();
				refill.strAssID=this.txtAssID.Text.Trim();
				refill.strCardID=this.txtCardID.Text.Trim();
				refill.dFillFee=Math.Round(-double.Parse(this.txtFillFee.Text.Trim()),2);
				refill.dFillProm=Math.Round(-double.Parse(this.txtPromFee.Text.Trim()),2);
				refill.dFeeLast=Math.Round(double.Parse(this.txtCurCharge.Text.Trim()),2);
				refill.dFeeCur=refill.dFillFee+refill.dFeeLast+refill.dFillProm;
				refill.strFillDate=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				refill.strComments="��ֵ������ԭ��ˮ�ţ�"+this.txtFillSerial.Text.Trim();
				refill.strOperName=SysInitial.CurOps.strOperName;
				refill.strDeptID=SysInitial.LocalDept;
				refill.strSerial=this.txtFillSerial.Text.Trim();
				if(refill.dFeeCur<0)
				{
					MessageBox.Show("����������Ѿ�С��0����ֵ����ʧ�ܣ������Ƿ��Ѿ������ѣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}

				chs.dCurCharge=refill.dFeeCur;
				double dCurChargeBak=System.Math.Round(double.Parse(txtCurCharge.Text.Trim())-double.Parse(this.txtFillFee.Text.Trim())-double.Parse(this.txtPromFee.Text.Trim()),2);

				if(chs.dCurCharge!=dCurChargeBak)
				{
					MessageBox.Show("��ֵ����ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("��ֵ��������ֵ�����ֵ���ȣ�����ֵ-- " + dCurChargeBak.ToString() + " ����ֵ-- " + chs.dCurCharge.ToString());
					return;
				}

				err=null;
				strresult="";
				strresult=cs.AssFillRemove(refill,chs.iCurIg,dCurChargeBak,strOldDate,out err);
				if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
				{
					MessageBox.Show("��ֵ�����ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					clog.WriteLine(strresult);
				}
				else
				{
					MessageBox.Show("��ֵ����ʧ�ܣ����γ�ֵ������Ч����������Ƿ���ȷ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err+ "\n" + strresult);
				}
				this.ClearText();
				btnRead.Enabled=true;
				this.btnRemove.Enabled=false;
				#endregion
			}		
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ����ʧʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }
			string strresult="";
			CMSMStruct.CardHardStruct chs=cs.ReadCardInfo("",out strresult);
			if(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK))
			{
				if(strresult==CardCommon.CardDef.ConstMsg.RFAUTHENTICATION_A_ERR)
				{
					MessageBox.Show("�ÿ������ڱ�ϵͳʹ�õĿ������飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return;
				}
				if(strresult.Substring(0,2)=="RF")
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("ˢ��ʧ�ܣ������ԣ�\n"+strresult,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				}
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
				MessageBox.Show("�˿�ΪԱ���������ɽ��г�ֵ������","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				err=null;
				CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
				assres=cs.GetAssociatorName(chs.strCardID,out err);
				if(assres!=null)
				{
					DataRow[] drn=SysInitial.dsSys.Tables["AS"].Select("vcCommCode='"+assres.strAssState+"'");
					if(drn==null||drn.Length==0)
					{
						MessageBox.Show("��Ա״̬�������������������������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						string strAssState=drn[0]["vcCommName"].ToString();
						if(assres.strAssState!="0")
						{
							MessageBox.Show("�û�Ա�Ѿ�ʧЧ�����ţ�" + chs.strCardID + "���ִ��ڡ�"+strAssState+"��״̬����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
					}
					
					err=null;
					DataTable dtFillFee=cs.GetAssFillLast(assres.strCardID,out err);
					if(dtFillFee==null||err!=null)
					{
						MessageBox.Show(err.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
						txtAssID.Text=assres.strAssID;
						txtCurCharge.Text=dtFillFee.Rows[0]["nFeeCur"].ToString();
						txtCardID.Text=assres.strCardID;
						txtAssName.Text=assres.strAssName;

						this.txtFillSerial.Text=dtFillFee.Rows[0]["iSerial"].ToString();
						this.txtFillFee.Text=dtFillFee.Rows[0]["nFillFee"].ToString();
						this.txtFillDate.Text=dtFillFee.Rows[0]["dtFillDate"].ToString();
						this.txtPromFee.Text=dtFillFee.Rows[0]["nFillProm"].ToString();
						strOldDate=dtFillFee.Rows[0]["dtFillDate"].ToString();

						btnRead.Enabled=false;
						this.btnRemove.Enabled=true;
					}
				}
				else
				{
					MessageBox.Show("�޻�Ա���ϣ��������Ա��ϵ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					return;
				}
			}
		}
	}
}
