using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmNonAssConsRemove ��ժҪ˵����
	/// </summary>
	public class frmNonAssConsRemove : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtConsDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtConsFee;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtBillNo;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        CommAccess cs = new CommAccess(SysInitial.ConString);
        private Button sbtnQuery;
        private Button sbtnReset;
        private Button sbtnRemove;
		Exception err;

		public frmNonAssConsRemove()
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtConsDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConsFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.sbtnReset = new System.Windows.Forms.Button();
            this.sbtnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(24, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "������Ʒ���£�";
            // 
            // txtConsDate
            // 
            this.txtConsDate.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsDate.Location = new System.Drawing.Point(344, 104);
            this.txtConsDate.Name = "txtConsDate";
            this.txtConsDate.Size = new System.Drawing.Size(168, 22);
            this.txtConsDate.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(280, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "����ʱ��";
            // 
            // txtConsFee
            // 
            this.txtConsFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsFee.Location = new System.Drawing.Point(88, 104);
            this.txtConsFee.Name = "txtConsFee";
            this.txtConsFee.Size = new System.Drawing.Size(168, 22);
            this.txtConsFee.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "���ѽ��";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 168);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(592, 208);
            this.dataGrid1.TabIndex = 24;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBillNo.Location = new System.Drawing.Point(232, 56);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(168, 22);
            this.txtBillNo.TabIndex = 22;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(56, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "������Ҫ������СƱ����";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "�ǻ�Ա���ѳ���ֻ�ܳ���4Сʱ���ڱ��������";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(512, 64);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 39;
            this.sbtnQuery.Text = "��ѯ";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // sbtnReset
            // 
            this.sbtnReset.Location = new System.Drawing.Point(512, 103);
            this.sbtnReset.Name = "sbtnReset";
            this.sbtnReset.Size = new System.Drawing.Size(75, 23);
            this.sbtnReset.TabIndex = 40;
            this.sbtnReset.Text = "����";
            this.sbtnReset.UseVisualStyleBackColor = true;
            this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
            // 
            // sbtnRemove
            // 
            this.sbtnRemove.Location = new System.Drawing.Point(512, 139);
            this.sbtnRemove.Name = "sbtnRemove";
            this.sbtnRemove.Size = new System.Drawing.Size(75, 23);
            this.sbtnRemove.TabIndex = 41;
            this.sbtnRemove.Text = "ȷ�ϳ���";
            this.sbtnRemove.UseVisualStyleBackColor = true;
            this.sbtnRemove.Click += new System.EventHandler(this.sbtnRemove_Click);
            // 
            // frmNonAssConsRemove
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(608, 382);
            this.Controls.Add(this.sbtnRemove);
            this.Controls.Add(this.sbtnReset);
            this.Controls.Add(this.sbtnQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConsDate);
            this.Controls.Add(this.txtConsFee);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmNonAssConsRemove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�ǻ�Ա���ѳ���";
            this.Load += new System.EventHandler(this.frmNonAssConsRemove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNonAssConsRemove_Load(object sender, System.EventArgs e)
		{
			this.txtConsFee.ReadOnly=true;
			this.txtConsDate.ReadOnly=true;
			this.sbtnRemove.Enabled=false;
			this.txtBillNo.Focus();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			string strBillNo=this.txtBillNo.Text.Trim();
			if(strBillNo=="")
			{
				MessageBox.Show("������Ҫ�������ѵ�СƱ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.txtBillNo.Focus();
				return;
			}

			err=null;
			DataSet dsout=cs.GetNonAssConsLast(strBillNo,out err);
			if(dsout==null||err!=null)
			{
				MessageBox.Show(err.Message,"ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				this.txtConsFee.Text=dsout.Tables["Bill"].Rows[0]["nPay"].ToString();
				this.txtConsDate.Text=dsout.Tables["Bill"].Rows[0]["dtTime"].ToString();
			
				this.dataGrid1.SetDataBinding(dsout.Tables["ConsItem"],"");
				this.EnToCh("��Ʒ���,��Ʒ����,����,����,�ۿ۽��,Ӧ�ս��","80,130,70,50,60,70",dsout.Tables["ConsItem"],this.dataGrid1);

				sbtnQuery.Enabled=false;
				this.txtBillNo.ReadOnly=true;
				this.sbtnRemove.Enabled=true;
			}
		}

		private void sbtnRemove_Click(object sender, System.EventArgs e)
		{
			string strresult="";
			if(this.txtBillNo.Text.Trim()=="")
			{
				MessageBox.Show("û���κο��Խ��г��������Ѽ�¼��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			err=null;
			if(cs.NonAssConsRemove(this.txtBillNo.Text.Trim(),this.txtConsFee.Text.Trim(),out err))
			{
				MessageBox.Show("���ѳ����ɹ���","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				clog.WriteLine(strresult);
			}
			else
			{
				MessageBox.Show("���ѳ���ʧ�ܣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err+ "\n" + strresult);
			}
			this.ClearText();
			this.txtBillNo.ReadOnly=false;
			sbtnQuery.Enabled=true;
			this.sbtnRemove.Enabled=false;
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
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
			this.ClearText();
			this.txtBillNo.ReadOnly=false;
			sbtnQuery.Enabled=true;
			this.sbtnRemove.Enabled=false;
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
			this.txtBillNo.Focus();
		}

		private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
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
		}
	}
}
