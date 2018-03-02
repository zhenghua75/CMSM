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
	public class frmAssConsRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtBillNo;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtConsFee;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.TextBox txtConsDate;
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
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmAssConsRemove()
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
			this.txtBillNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRead = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtConsFee = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtConsDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.txtCurCharge = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAssName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAssID = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.AliceBlue;
			this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(568, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "��Ա���ѳ���ֻ�ܳ�����Ա4Сʱ���ڱ�������һ������";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "��Ա����";
			// 
			// txtCardID
			// 
			this.txtCardID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCardID.Location = new System.Drawing.Point(88, 56);
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(168, 22);
			this.txtCardID.TabIndex = 2;
			this.txtCardID.Text = "";
			// 
			// txtBillNo
			// 
			this.txtBillNo.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtBillNo.Location = new System.Drawing.Point(344, 56);
			this.txtBillNo.Name = "txtBillNo";
			this.txtBillNo.Size = new System.Drawing.Size(168, 22);
			this.txtBillNo.TabIndex = 4;
			this.txtBillNo.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(280, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "СƱ����";
			// 
			// btnRead
			// 
			this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRead.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRead.Location = new System.Drawing.Point(536, 56);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(56, 24);
			this.btnRead.TabIndex = 5;
			this.btnRead.Text = "ˢ��";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 200);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(592, 208);
			this.dataGrid1.TabIndex = 6;
			// 
			// txtConsFee
			// 
			this.txtConsFee.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtConsFee.Location = new System.Drawing.Point(88, 136);
			this.txtConsFee.Name = "txtConsFee";
			this.txtConsFee.Size = new System.Drawing.Size(168, 22);
			this.txtConsFee.TabIndex = 8;
			this.txtConsFee.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "���ѽ��";
			// 
			// txtConsDate
			// 
			this.txtConsDate.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtConsDate.Location = new System.Drawing.Point(344, 136);
			this.txtConsDate.Name = "txtConsDate";
			this.txtConsDate.Size = new System.Drawing.Size(168, 22);
			this.txtConsDate.TabIndex = 10;
			this.txtConsDate.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(280, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "����ʱ��";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(24, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(232, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "������Ʒ���£�";
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.ForeColor = System.Drawing.Color.Crimson;
			this.btnRemove.Location = new System.Drawing.Point(520, 168);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 24);
			this.btnRemove.TabIndex = 12;
			this.btnRemove.Text = "ȷ�ϳ���";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// txtCurCharge
			// 
			this.txtCurCharge.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCurCharge.Location = new System.Drawing.Point(344, 96);
			this.txtCurCharge.Name = "txtCurCharge";
			this.txtCurCharge.Size = new System.Drawing.Size(168, 22);
			this.txtCurCharge.TabIndex = 14;
			this.txtCurCharge.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(280, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "��Ա���";
			// 
			// txtAssName
			// 
			this.txtAssName.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssName.Location = new System.Drawing.Point(88, 96);
			this.txtAssName.Name = "txtAssName";
			this.txtAssName.Size = new System.Drawing.Size(168, 22);
			this.txtAssName.TabIndex = 16;
			this.txtAssName.Text = "";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(24, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "��Ա����";
			// 
			// txtAssID
			// 
			this.txtAssID.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtAssID.Location = new System.Drawing.Point(296, 168);
			this.txtAssID.Name = "txtAssID";
			this.txtAssID.Size = new System.Drawing.Size(168, 22);
			this.txtAssID.TabIndex = 17;
			this.txtAssID.Text = "";
			this.txtAssID.Visible = false;
			// 
			// frmAssConsRemove
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(608, 412);
			this.Controls.Add(this.txtAssID);
			this.Controls.Add(this.txtAssName);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtCurCharge);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtConsDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtConsFee);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.txtBillNo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCardID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmAssConsRemove";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "��Ա���ѳ���";
			this.Load += new System.EventHandler(this.frmAssConsRemove_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAssConsRemove_Load(object sender, System.EventArgs e)
		{
			this.txtCardID.ReadOnly=true;
			this.txtBillNo.ReadOnly=true;
			this.txtAssName.ReadOnly=true;
			this.txtCurCharge.ReadOnly=true;
			this.txtConsFee.ReadOnly=true;
			this.txtConsDate.ReadOnly=true;
			this.btnRemove.Enabled=false;
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��ˢ��ʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
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
				MessageBox.Show("���ѳ��������״�ˢ������ͬһ�ſ������ѳ���ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.ClearText();
				btnRead.Enabled=true;				
				return;
			}
			else
			{
				#region ��ʼ���ѳ���
				if(this.txtBillNo.Text.Trim()=="")
				{
					MessageBox.Show("û���κο��Խ��г��������Ѽ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					return;
				}

				CMSMData.CMSMStruct.FillFeeStruct refill=new CMSMData.CMSMStruct.FillFeeStruct();
				refill.strAssID=this.txtAssID.Text.Trim();
				refill.strCardID=this.txtCardID.Text.Trim();
				refill.dFillFee=Math.Round(double.Parse(this.txtConsFee.Text.Trim()),2);
				refill.dFillProm=0;
				refill.dFeeLast=Math.Round(double.Parse(this.txtCurCharge.Text.Trim()),2);
				refill.dFeeCur=refill.dFillFee+refill.dFeeLast;
                DateTime dtNow = DateTime.Now;
                refill.iSerial =Int64.Parse(dtNow.ToString("yyyyMMddHHmmss"));
                refill.strFillDate = dtNow.ToShortDateString() + " " + dtNow.ToLongTimeString();
				refill.strComments="���ѳ�����ԭСƱ�ţ�"+this.txtBillNo.Text.Trim();
				refill.strOperName=SysInitial.CurOps.strOperName;
				refill.strDeptID=SysInitial.LocalDept;

				
				chs.dCurCharge=refill.dFeeCur;
				double dCurChargeBak=System.Math.Round((double.Parse(txtConsFee.Text.Trim())+double.Parse(txtCurCharge.Text.Trim())),2);

				if(chs.dCurCharge!=dCurChargeBak)
				{
					MessageBox.Show("���ѳ���ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine("���ѳ�������ֵ�����ֵ���ȣ�����ֵ��" + dCurChargeBak.ToString() + " ����ֵ" + chs.dCurCharge.ToString());
					return;
				}

				err=null;
				strresult="";
				strresult=cs.AssConsRemove(this.txtBillNo.Text.Trim(),refill,chs.iCurIg,dCurChargeBak,out err);
				if(strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)||strresult.Substring(0,3)=="CMT")
				{
					MessageBox.Show("���ѳ����ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					clog.WriteLine(strresult);
				}
				else
				{
					MessageBox.Show("���ѳ���ʧ�ܣ��������ѳ�����Ч����������Ƿ���ȷ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					clog.WriteLine(err+ "\n" + strresult);
				}
				this.ClearText();
				btnRead.Enabled=true;
				this.btnRemove.Enabled=false;
				DataTable dtConsItem=new DataTable();
				dtConsItem.Columns.Add("GoodsID");
				dtConsItem.Columns.Add("GoodsName");
				dtConsItem.Columns.Add("Price");
				dtConsItem.Columns.Add("Count");
				dtConsItem.Columns.Add("Rate");
				dtConsItem.Columns.Add("Fee");
				dtConsItem.Columns.Add("Comments");
				dtConsItem.Columns["Comments"].DefaultValue="";
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("��Ʒ���,��Ʒ����,����,����,�ۿ۽��,Ӧ�ս��","80,130,70,50,60,70",dtConsItem,this.dataGrid1);
				#endregion
			}		
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��ˢ��ʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
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
				MessageBox.Show("�˿�ΪԱ���������ɽ������ѳ�����","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
						MessageBox.Show("�û�Ա�Ѿ�ʧЧ�����ţ�" + chs.strCardID + "����˲飡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					
					err=null;
					DataSet dsout=cs.GetAssConsLast(assres.strCardID,out err);
					if(dsout==null||err!=null)
					{
						MessageBox.Show(err.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					else
					{
#if !DEBUG
						if(chs.dCurCharge!=Math.Round(double.Parse(dsout.Tables["CurCharge"].Rows[0]["nFeeCur"].ToString()),2))
						{
							MessageBox.Show("��Ա���ϵ�ǰ������ϴ����Ѻ�����������ܳ�����","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
							return;
						}
						else
						{
#endif
							txtAssID.Text=assres.strAssID;
							txtCurCharge.Text=chs.dCurCharge.ToString();
							txtCardID.Text=assres.strCardID;
							txtAssName.Text=assres.strAssName;

							this.txtBillNo.Text=dsout.Tables["Bill"].Rows[0]["iSerial"].ToString();
							this.txtConsFee.Text=dsout.Tables["Bill"].Rows[0]["nPay"].ToString();
							this.txtConsDate.Text=dsout.Tables["Bill"].Rows[0]["dtTime"].ToString();
						
							this.dataGrid1.SetDataBinding(dsout.Tables["ConsItem"],"");
							this.EnToCh("��Ʒ���,��Ʒ����,����,����,�ۿ۽��,ʵ�ս��","80,130,70,50,60,70",dsout.Tables["ConsItem"],this.dataGrid1);

							btnRead.Enabled=false;
							this.btnRemove.Enabled=true;
#if !DEBUG
						}
#endif
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
