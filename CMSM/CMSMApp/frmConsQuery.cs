using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmConsQuery ��ժҪ˵����
	/// </summary>
	public class frmConsQuery : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAssName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbAssType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtFee;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbOper;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbConsFlag;
		private System.Windows.Forms.ComboBox cmbConsType;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtTolRate;
        private Button sbtnQuery;
        private Button sbtnExcel;
        private Button sbtnClose;
		CommAccess cs=new CommAccess(SysInitial.ConString);

		public frmConsQuery()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnExcel = new System.Windows.Forms.Button();
            this.sbtnQuery = new System.Windows.Forms.Button();
            this.cmbConsType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbConsFlag = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbOper = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAssType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAssName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTolRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sbtnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnClose);
            this.groupBox1.Controls.Add(this.sbtnExcel);
            this.groupBox1.Controls.Add(this.sbtnQuery);
            this.groupBox1.Controls.Add(this.cmbConsType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbConsFlag);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbOper);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAssType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbAssName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // sbtnExcel
            // 
            this.sbtnExcel.Location = new System.Drawing.Point(720, 59);
            this.sbtnExcel.Name = "sbtnExcel";
            this.sbtnExcel.Size = new System.Drawing.Size(75, 23);
            this.sbtnExcel.TabIndex = 41;
            this.sbtnExcel.Text = "����";
            this.sbtnExcel.UseVisualStyleBackColor = true;
            this.sbtnExcel.Click += new System.EventHandler(this.sbtnExcel_Click);
            // 
            // sbtnQuery
            // 
            this.sbtnQuery.Location = new System.Drawing.Point(720, 25);
            this.sbtnQuery.Name = "sbtnQuery";
            this.sbtnQuery.Size = new System.Drawing.Size(75, 23);
            this.sbtnQuery.TabIndex = 40;
            this.sbtnQuery.Text = "��ѯ";
            this.sbtnQuery.UseVisualStyleBackColor = true;
            this.sbtnQuery.Click += new System.EventHandler(this.sbtnQuery_Click);
            // 
            // cmbConsType
            // 
            this.cmbConsType.Location = new System.Drawing.Point(568, 88);
            this.cmbConsType.Name = "cmbConsType";
            this.cmbConsType.Size = new System.Drawing.Size(144, 20);
            this.cmbConsType.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(496, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 38;
            this.label13.Text = "��������";
            // 
            // cmbConsFlag
            // 
            this.cmbConsFlag.Location = new System.Drawing.Point(328, 24);
            this.cmbConsFlag.Name = "cmbConsFlag";
            this.cmbConsFlag.Size = new System.Drawing.Size(168, 20);
            this.cmbConsFlag.TabIndex = 37;
            this.cmbConsFlag.Text = "ȫ��";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(264, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "��Ч״̬";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(568, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(144, 20);
            this.cmbDept.TabIndex = 33;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(522, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "�ŵ�";
            // 
            // cmbOper
            // 
            this.cmbOper.Location = new System.Drawing.Point(568, 56);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.Size = new System.Drawing.Size(144, 20);
            this.cmbOper.TabIndex = 32;
            this.cmbOper.Text = "*";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(520, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "����Ա";
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(896, 64);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(168, 20);
            this.cmbGoodsName.TabIndex = 29;
            this.cmbGoodsName.Text = "*";
            this.cmbGoodsName.Visible = false;
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(832, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "��Ʒ����";
            this.label9.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(328, 88);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(168, 21);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(328, 56);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(168, 21);
            this.dtpBegin.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(264, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "��������";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(264, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "��ʼ����";
            // 
            // cmbAssType
            // 
            this.cmbAssType.Location = new System.Drawing.Point(80, 24);
            this.cmbAssType.Name = "cmbAssType";
            this.cmbAssType.Size = new System.Drawing.Size(168, 20);
            this.cmbAssType.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "��Ա����";
            // 
            // cmbAssName
            // 
            this.cmbAssName.Location = new System.Drawing.Point(80, 88);
            this.cmbAssName.Name = "cmbAssName";
            this.cmbAssName.Size = new System.Drawing.Size(168, 20);
            this.cmbAssName.TabIndex = 20;
            this.cmbAssName.Text = "*";
            this.cmbAssName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAssName_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "��Ա����";
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(80, 56);
            this.txtCardID.MaxLength = 8;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(168, 22);
            this.txtCardID.TabIndex = 17;
            this.txtCardID.Text = "*";
            this.txtCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardID_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "��Ա����";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 120);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1028, 302);
            this.dataGrid1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTolRate);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFee);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1028, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "��������";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(880, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "Ԫ";
            // 
            // txtTolRate
            // 
            this.txtTolRate.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTolRate.Location = new System.Drawing.Point(744, 24);
            this.txtTolRate.Name = "txtTolRate";
            this.txtTolRate.Size = new System.Drawing.Size(136, 22);
            this.txtTolRate.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(664, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "���ۿ۽��";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(560, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Ԫ";
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFee.Location = new System.Drawing.Point(424, 24);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(136, 22);
            this.txtFee.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(344, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "�����ѽ��";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(128, 24);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 22);
            this.txtCount.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(40, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "���Ѽ�¼����";
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(720, 89);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 42;
            this.sbtnClose.Text = "�ر�";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmConsQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 478);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����ͳ�Ʋ�ѯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmConsQuery_Load(object sender, System.EventArgs e)
		{
			this.FillComboBox(cmbAssType,"AT","vcCommName","all");
			this.FillComboBox(cmbConsType,"PT","vcCommName","all");
			this.sbtnExcel.Enabled=false;
			this.cmbGoodsName.Enabled=false;
			this.cmbConsFlag.Items.Add("ȫ��");
			this.cmbConsFlag.Items.Add("��������");
			this.cmbConsFlag.Items.Add("�ѳ���");
			if(SysInitial.CurOps.strLimit=="LM003")
			{
				this.FillComboBox(this.cmbDept,"MD","vcCommName","all");
				this.cmbDept.SelectedIndex=0;
				Exception err=null;
				this.cmbOper.Items.Clear();
				DataTable dtOperList=cs.GetConsOperList("all",out err);
				if(dtOperList!=null&&dtOperList.Rows.Count>=0)
				{
					this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","all");
					this.cmbOper.SelectedIndex=0;
				}
			}
			else
			{
				string strDeptName=this.GetColCh(SysInitial.LocalDept,"MD");
				this.cmbDept.Items.Add(strDeptName);
				this.cmbDept.SelectedIndex=0;
				this.cmbDept.Enabled=false;
				Exception err=null;
				this.cmbOper.Items.Clear();
				DataTable dtOperList=cs.GetConsOperList("all",out err);
				if(dtOperList!=null&&dtOperList.Rows.Count>=0)
				{
					this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","all");
					this.cmbOper.SelectedIndex=0;
				}

			}
			this.DgBind();
		}

		private void cmbAssName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strAssName=cmbAssName.Text.Trim();
				if(strAssName=="")
				{
					this.DgBind();
				}
				else
				{
					this.FillComboBoxBySpell(cmbAssName,"AssSpell","vcAssName","vcSpell",strAssName);
					if(cmbAssName.Text.Trim()==strAssName)
					{
						MessageBox.Show("�޴˻�Ա��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					this.DgBind();
				}
			}
		}

		private void cmbGoodsName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				string strGoodsName=cmbGoodsName.Text.Trim();
				if(strGoodsName=="")
				{
					this.DgBind();
				}
				else
				{
					this.FillComboBoxBySpell(cmbGoodsName,"GoodsSpell","vcGoodsName","vcSpell",strGoodsName);
					if(cmbGoodsName.Text.Trim()==strGoodsName)
					{
						MessageBox.Show("�޴���Ʒ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
						return;
					}
					this.DgBind();
				}
			}
		}

		private void DgBind()
		{
			Hashtable htPara=new Hashtable();
			string strCardID=txtCardID.Text.Trim();
			htPara.Add("strCardID",strCardID);
			string strAssName=cmbAssName.Text.Trim();
			htPara.Add("strAssName",strAssName);
			string strAssType=cmbAssType.Text.Trim();
			string strOperName=cmbOper.Text.Trim();
			string strDeptID=cmbDept.Text.Trim();
			string strConsType=this.cmbConsFlag.Text.Trim();
			string strPTType = this.cmbConsType.Text.Trim();
			if(strAssType=="ȫ��")
			{
				strAssType="";
			}
			else
			{
				strAssType=this.GetColEn(strAssType,"AT");
			}
			if (strConsType=="ȫ��")
			{
				strConsType="";
			}
			if (strConsType=="��������")
			{
				strConsType="0";
			}
			if (strConsType=="�ѳ���")
			{
				strConsType="9";
			}
			if(strPTType == "ȫ��")
			{
				strPTType = "";
			}
			else
			{
				strPTType = this.GetColEn(strPTType,"PT");
			}
			htPara.Add("strConsType",strConsType);
			htPara.Add("strAssType",strAssType);
			htPara.Add("strPTType",strPTType);
			if(strOperName=="ȫ��")
			{
				strOperName="";
			}
			htPara.Add("strOperName",strOperName);
			if(strDeptID=="ȫ��")
			{
				strDeptID="";
			}
			else
			{
				strDeptID=this.GetColEn(strDeptID,"MD");
			}
			htPara.Add("strDeptID",strDeptID);
			string strGoodsName=cmbGoodsName.Text.Trim();
			htPara.Add("strGoodsName",strGoodsName);
			string strBegin=dtpBegin.Value.ToShortDateString()+" 00:00:00";
			htPara.Add("strBegin",strBegin);
			string strEnd=dtpEnd.Value.ToShortDateString()+" 23:59:59";
			htPara.Add("strEnd",strEnd);
			
			Exception err=null;
			DataTable dt=new DataTable();
			dt=cs.GetConsQuery(htPara,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.DataTableConvert(dt,"vcAssType","AT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcConsType","PT","vcCommCode","vcCommName");
				this.DataTableConvert(dt,"vcDeptID","MD","vcCommCode","vcCommName");

				int iCount=dt.Rows.Count;
				double dFee=0;
				double dRate=0;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					dFee+=double.Parse(dt.Rows[i]["nFee"].ToString());
					dRate+=double.Parse(dt.Rows[i]["nTRate"].ToString());
//					if(dt.Rows[i]["Flag"].ToString()=="��������")
//					{
//						dFee+=double.Parse(dt.Rows[i]["nFee"].ToString());
//					}
				}
				txtCount.Text=iCount.ToString();
				txtFee.Text=Math.Round(dFee,2).ToString();
				txtTolRate.Text=Math.Round(dRate,2).ToString();
				this.dataGrid1.CaptionText="��Ա������ϸ����";
				this.dataGrid1.SetDataBinding(dt,"");
                this.EnToCh("��ˮ��,��Ա����,��Ա����,��Ա����,��Ʒ����,����,����,Ӧ��,�ۿ�,ʵ��,��������,�������,��������,����Ա,�ŵ�,��ע", "120,100,80,80,120,80,80,80,80,80,80,80,140,80,160,100", dt, this.dataGrid1);
				if(dt.Rows.Count>0)
				{
					this.sbtnExcel.Enabled=true;
				}
				else
				{
					this.sbtnExcel.Enabled=false;
				}
			}
			else
			{
				MessageBox.Show("��ѯ���������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				if(err!=null)
				{
					clog.WriteLine(err);
				}
			}
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void sbtnQuery_Click(object sender, System.EventArgs e)
		{
			this.DgBind();
		}

		private void txtCardID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)
			{
//				if(e.KeyChar==8||e.KeyChar==42)
//				{
//					return;
//				}
//				if(e.KeyChar<48||e.KeyChar>57)
//				{
//					e.Handled=true;
//					return;
//				}
			}
			else
			{
				this.DgBind();
			}
		}

		private void sbtnExcel_Click(object sender, System.EventArgs e)
		{
			DataTable dt=new DataTable();
			dt=(DataTable)this.dataGrid1.DataSource;
			string table="";
			if(dt!=null && dt.Rows.Count>0)
			{							
				for(int i=0;i<dt.Columns.Count;i++)
				{
					if(dataGrid1.TableStyles[0].GridColumnStyles[i].Width>0)
					{
						if(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="����"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="����"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="Ӧ��"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="�ۿ�"||dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText=="ʵ��")
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "double,";
						}
						else
						{
							table+=this.replace(dataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText) + " " + "varchar,";
						}
					}		
				}
			}
			else
			{
				MessageBox.Show("���û�����ݿ��Ե���!","ϵͳ��ʾ",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
				return;
			}
			this.ExportToExcel(table);
		}

		private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(SysInitial.CurOps.strLimit=="LM003")
			{
				this.cmbOper.Items.Clear();
				DataTable dtOperList;
				Exception err=null;
				string strDeptID=this.cmbDept.Text;
				if(strDeptID=="ȫ��")
				{
					this.cmbOper.Items.Add("ȫ��");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
					dtOperList=cs.GetConsOperList("all",out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>=0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName","");
					}
					this.cmbOper.SelectedIndex=0;
				}
				else if(this.GetColEn(strDeptID,"MD")==SysInitial.LocalDept)
				{
					this.cmbOper.Items.Add("ȫ��");
					this.FillOperComboBox(this.cmbOper,"Oper","vcOperName");
				}
				else
				{
					this.cmbOper.Items.Add("ȫ��");
					strDeptID=this.GetColEn(this.cmbDept.Text,"MD");
					dtOperList=cs.GetConsOperList(strDeptID,out err);
					if(dtOperList!=null&&dtOperList.Rows.Count>0)
					{
						this.FillComboBox(this.cmbOper,dtOperList,"vcOperName",strDeptID);
					}
					else
					{
						if(err!=null)
						{
							MessageBox.Show("ϵͳ���������ԣ�","ϵͳ��ʾ",MessageBoxButtons.OK ,System.Windows.Forms.MessageBoxIcon.Information );
							clog.WriteLine(err);
						}
						return;
					}
					this.cmbOper.SelectedIndex=0;
				}
			}
			else if(SysInitial.CurOps.strLimit=="LM001")
			{
				this.FillComboBox(this.cmbOper,"Oper","vcOperName","all");
			}
		}
	}
}
