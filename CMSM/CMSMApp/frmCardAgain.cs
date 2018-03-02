using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;
using CMSMData;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmCardAgain.
	/// </summary>
	public class frmCardAgain : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.ComboBox cmbAssName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		CommAccess cs=new CommAccess(SysInitial.ConString);
        private Button sbtnQuery;
        private Button sbtnAgain;
        private Button sbtnClose;
		Exception err;

		public frmCardAgain()
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
            this.cmbAssName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnAgain = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 82);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(888, 372);
            this.dataGrid1.TabIndex = 4;
            // 
            // cmbAssName
            // 
            this.cmbAssName.ItemHeight = 12;
            this.cmbAssName.Location = new System.Drawing.Point(330, 40);
            this.cmbAssName.Name = "cmbAssName";
            this.cmbAssName.Size = new System.Drawing.Size(144, 20);
            this.cmbAssName.TabIndex = 15;
            this.cmbAssName.Text = "*";
            this.cmbAssName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAssName_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(266, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "��Ա����";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(74, 40);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(144, 22);
            this.txtCardID.TabIndex = 1;
            this.txtCardID.Text = "*";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "��Ա����";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnAgain);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbAssName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // sbtnAgain
            // 
            this.sbtnAgain.Location = new System.Drawing.Point(594, 39);
            this.sbtnAgain.Name = "sbtnAgain";
            this.sbtnAgain.Size = new System.Drawing.Size(75, 23);
            this.sbtnAgain.TabIndex = 18;
            this.sbtnAgain.Text = "����";
            this.sbtnAgain.UseVisualStyleBackColor = true;
            this.sbtnAgain.Click += new System.EventHandler(this.sbtnAgain_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(492, 40);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 17;
            this.sbtnQuery.Text = "��ѯ";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(689, 38);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 19;
            this.sbtnClose.Text = "�ر�";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmCardAgain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(888, 454);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCardAgain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ա����";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ,��ѯʧ�ܣ�vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }
			this.DgBind();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void DgBind()
		{
			string strCardID=txtCardID.Text.Trim();
			string strAssName=cmbAssName.Text.Trim();
			Exception err=null;
			DataTable dt=new DataTable();

			dt=cs.GetAssLost(strCardID,strAssName,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcAssState","AS","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("��ԱID,��Ա����,��Ա����,ƴ����д,���֤��,��ϵ�绰,��ϵ��ַ,Email,��Ա����,��Ա״̬,��ǰ���,��ǰ����,��ע,�ŵ�,��������,��������","100,150,120,80,80,120,80",dt,this.dataGrid1);
			}
			else
			{
				MessageBox.Show("��ѯ�ѹ�ʧ��Ա���ϳ��������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnAgain_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex<0)
			{
				MessageBox.Show("û��ѡ���ѹ�ʧ�Ļ�Ա��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}
			err=null;
			string strCardID=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
			CMSMData.CMSMStruct.AssociatorStruct assres=new CMSMData.CMSMStruct.AssociatorStruct();
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ,���ܲ�����vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }

			assres=cs.GetAssociatorLost(strCardID,out err);
			if(assres==null||err!=null)
			{
				MessageBox.Show("��ȡ��Ա���ϴ��������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				return;
			}

			frmInputBox frmInput=new frmInputBox();
			frmInput.Text="���������¿���";
			frmInput.label1.Text="�������»�Ա���Ŀ��ţ�";
			frmInput.label2.Text="Again";
			frmInput.ShowDialog();
			if(SysInitial.strTmp=="CanCel")
			{
				return;
			}
			while(SysInitial.strTmp=="")
			{
				MessageBox.Show("����Ļ�Ա���Ų���ȷ�����������룡","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				frmInput=new frmInputBox();
				frmInput.ShowDialog();
				if(SysInitial.strTmp=="CanCel")
				{
					return;
				}
			}
            
			string strNewCardID=SysInitial.strTmp;
			SysInitial.strTmp="";

			if(assres.dtCreateDate.CompareTo(SysInitial.dtQLTime)<0&&!assres.setZeroFlag)
			{
				assres.iIgValue=0;
				assres.needZeroFlag=true;
			}
            
			err=null;
			string strresult=cs.CardAgain(strNewCardID,assres,out err);
			if(err!=null||(!strresult.Equals(CardCommon.CardDef.ConstMsg.RFOK)))
			{
				if(strresult=="")
				{
					strresult=this.GetColCh(strresult,"ERR");
				}
				MessageBox.Show("������ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null||strresult!=null)
				{
					clog.WriteLine(err + "\n" + strresult);
				}
			}
			else
			{
				MessageBox.Show("�������ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				this.DgBind();
			}
		}

		private void cmbAssName_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strAssName=cmbAssName.Text.Trim();
				this.FillComboBoxBySpell(cmbAssName,"AssSpell","vcAssName","vcSpell",strAssName);
				this.DgBind();
			}
		}
	}
}
