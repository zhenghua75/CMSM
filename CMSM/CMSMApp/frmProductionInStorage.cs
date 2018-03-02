using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	public enum FormType
	{
		ProductionInStorage=0,//�������
		SaleCheck=1,//�����̵�
	}
	/// <summary>
	/// Summary description for frmProductionInStorage.
	/// </summary>
	public class frmProductionInStorage : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtTolCount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblNotice;
		private System.Windows.Forms.ComboBox cmbGoodsName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGoodsID;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataTable dtConsItem=null;
        CommAccess cs = new CommAccess(SysInitial.ConString);
        private System.Windows.Forms.DateTimePicker dtpInDate;
		private System.Windows.Forms.Label lblInDate;
		private System.Windows.Forms.GroupBox gbTotal;
		Exception err;
        private Button btnQuery;
        private Button sbtnCancel;
        private Button sbtnRollback;
        private Button sbtnAdd;
        private Button sbtnOk;

		private FormType formType;
		public frmProductionInStorage(FormType ft)
		{
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");
			this.formType = ft;
            switch (this.formType)
            {
                case FormType.ProductionInStorage:
                    this.Text = "�������";
                    this.lblInDate.Text = "�������";
                    this.gbTotal.Text = "���ϼ�";
                    this.groupBox1.Text = "�����Ŀ";
                    this.sbtnOk.Text = "���(F6)";
                    break;
                case FormType.SaleCheck:
                    this.Text = "�����̵�";
                    this.lblInDate.Text = "�̵�����";
                    this.gbTotal.Text = "�̵�ϼ�";
                    this.groupBox1.Text = "�̵���Ŀ";
                    this.sbtnOk.Text = "�̵�(F6)";
                    break;
            }
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
            this.gbTotal = new System.Windows.Forms.GroupBox();
            this.txtTolCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnAdd = new System.Windows.Forms.Button();
            this.sbtnRollback = new System.Windows.Forms.Button();
            this.sbtnCancel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dtpInDate = new System.Windows.Forms.DateTimePicker();
            this.lblInDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGoodsID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sbtnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.gbTotal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(288, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(616, 526);
            this.dataGrid1.TabIndex = 6;
            // 
            // gbTotal
            // 
            this.gbTotal.Controls.Add(this.txtTolCount);
            this.gbTotal.Controls.Add(this.label9);
            this.gbTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTotal.Location = new System.Drawing.Point(288, 526);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.Size = new System.Drawing.Size(616, 64);
            this.gbTotal.TabIndex = 7;
            this.gbTotal.TabStop = false;
            this.gbTotal.Text = "���ϼƣ�";
            // 
            // txtTolCount
            // 
            this.txtTolCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTolCount.Location = new System.Drawing.Point(120, 24);
            this.txtTolCount.MaxLength = 10;
            this.txtTolCount.Name = "txtTolCount";
            this.txtTolCount.Size = new System.Drawing.Size(96, 21);
            this.txtTolCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(56, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "��������";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbtnOk);
            this.groupBox1.Controls.Add(this.sbtnAdd);
            this.groupBox1.Controls.Add(this.sbtnRollback);
            this.groupBox1.Controls.Add(this.sbtnCancel);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.dtpInDate);
            this.groupBox1.Controls.Add(this.lblInDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGoodsID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 590);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�����Ŀ";
            // 
            // sbtnAdd
            // 
            this.sbtnAdd.Location = new System.Drawing.Point(160, 192);
            this.sbtnAdd.Name = "sbtnAdd";
            this.sbtnAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtnAdd.TabIndex = 27;
            this.sbtnAdd.Text = "ȷ��(F7)";
            this.sbtnAdd.UseVisualStyleBackColor = true;
            this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
            // 
            // sbtnRollback
            // 
            this.sbtnRollback.Location = new System.Drawing.Point(40, 192);
            this.sbtnRollback.Name = "sbtnRollback";
            this.sbtnRollback.Size = new System.Drawing.Size(75, 23);
            this.sbtnRollback.TabIndex = 26;
            this.sbtnRollback.Text = "<<����";
            this.sbtnRollback.UseVisualStyleBackColor = true;
            this.sbtnRollback.Click += new System.EventHandler(this.sbtnRollback_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Location = new System.Drawing.Point(40, 240);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 25;
            this.sbtnCancel.Text = "�ر�";
            this.sbtnCancel.UseVisualStyleBackColor = true;
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(226, 33);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(56, 23);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "��ѯ";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtpInDate
            // 
            this.dtpInDate.CustomFormat = "yyyy-MM-dd";
            this.dtpInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInDate.Location = new System.Drawing.Point(80, 32);
            this.dtpInDate.Name = "dtpInDate";
            this.dtpInDate.Size = new System.Drawing.Size(136, 21);
            this.dtpInDate.TabIndex = 22;
            // 
            // lblInDate
            // 
            this.lblInDate.Location = new System.Drawing.Point(16, 40);
            this.lblInDate.Name = "lblInDate";
            this.lblInDate.Size = new System.Drawing.Size(64, 16);
            this.lblInDate.TabIndex = 21;
            this.lblInDate.Text = "�������";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(192, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "Ԫ";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(80, 160);
            this.txtCount.MaxLength = 10;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(136, 21);
            this.txtCount.TabIndex = 2;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "����";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 128);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 21);
            this.txtPrice.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "����";
            // 
            // lblNotice
            // 
            this.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Location = new System.Drawing.Point(24, 392);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(192, 192);
            this.lblNotice.TabIndex = 13;
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.Location = new System.Drawing.Point(80, 96);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(136, 20);
            this.cmbGoodsName.TabIndex = 0;
            this.cmbGoodsName.SelectedIndexChanged += new System.EventHandler(this.cmbGoodsName_SelectedIndexChanged);
            this.cmbGoodsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGoodsName_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "��Ʒ����";
            // 
            // txtGoodsID
            // 
            this.txtGoodsID.Location = new System.Drawing.Point(80, 64);
            this.txtGoodsID.MaxLength = 10;
            this.txtGoodsID.Name = "txtGoodsID";
            this.txtGoodsID.Size = new System.Drawing.Size(136, 21);
            this.txtGoodsID.TabIndex = 15;
            this.txtGoodsID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoodsID_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "��Ʒ���";
            // 
            // sbtnOk
            // 
            this.sbtnOk.Location = new System.Drawing.Point(160, 240);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(75, 23);
            this.sbtnOk.TabIndex = 28;
            this.sbtnOk.Text = "���(F6)";
            this.sbtnOk.UseVisualStyleBackColor = true;
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // frmProductionInStorage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(904, 590);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.gbTotal);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmProductionInStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductionInStorage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductionInStorage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.gbTotal.ResumeLayout(false);
            this.gbTotal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmProductionInStorage_Load(object sender, System.EventArgs e)
		{
			txtPrice.ReadOnly=true;
			cmbGoodsName.Text="������...";
			txtTolCount.ReadOnly=true;
			txtGoodsID.ReadOnly=true;
			txtCount.Text="1";
			dtpInDate.Text = DateTime.Now.ToString("yyyy-MM-dd");		
			InitConsItemDataTable();
			
			DgBind();
		}
		private void InitConsItemDataTable()
		{
			dtConsItem=new DataTable();
			dtConsItem.Columns.Add("Id");
			dtConsItem.Columns.Add("GoodsID");
			dtConsItem.Columns.Add("GoodsName");
			dtConsItem.Columns.Add("Price");
			dtConsItem.Columns.Add("Count");
		}
		private void sbtnRollback_Click(object sender, System.EventArgs e)
		{
			if(dataGrid1.CurrentRowIndex>=0)
			{
				string strGoodsID=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					if(strGoodsID==dtConsItem.Rows[i]["GoodsID"].ToString())
					{
						double count = double.Parse(dtConsItem.Rows[i]["Count"].ToString());
						if(count>0)
						{
							dtConsItem.Rows[i]["Count"]=(count-1).ToString();
						}
					}
				}
				this.DgBind();
			}
		}

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("�޴���Ʒ��Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="������...";
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
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					txtCount.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("�޴���Ʒ��Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="������...";
					txtGoodsID.Focus();
					return;
				}
			}
		}

		private void AddGoodsToDataGrid()
		{
			double dCount=0;
			if(txtCount.Text.Trim()=="")
			{
				MessageBox.Show("��������Ϊ�գ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dCount=int.Parse(txtCount.Text.Trim());
			}

			double dPrice=0;
			if(txtPrice.Text.Trim()=="")
			{
				MessageBox.Show("���۲���Ϊ�գ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
			else
			{
				dPrice=Double.Parse(txtPrice.Text.Trim());
			}
			
			if(txtGoodsID.Text.Trim()=="")
			{
				MessageBox.Show("��Ʒ��Ϣ����������ѡ����Ʒ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="";
				txtCount.Text="";
			}
			CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
			err=null;
			gs=cs.GetGoodsByID(txtGoodsID.Text.Trim(),out err);
			if(gs!=null)
			{
				txtGoodsID.Text=gs.strGoodsID;
				cmbGoodsName.Text=gs.strGoodsName;
				bool sumflag=false;
				foreach(DataRow dr in dtConsItem.Rows)
				{
					if(gs.strGoodsID==dr["GoodsID"].ToString())
					{
						dr["Count"]=(double.Parse(dr["Count"].ToString())+dCount).ToString();
						sumflag=true;
						break;
					}
				}
				
				if(!sumflag)
				{
					switch(this.formType)
					{
						case FormType.ProductionInStorage:
							if(cs.ProductionInStorageExist(SysInitial.CurOps.strDeptID,dtpInDate.Text,txtGoodsID.Text))
							{
								MessageBox.Show("����Ʒ�����","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
								return;
							}
							break;
						case FormType.SaleCheck:
							if(cs.SaleCheckExist(SysInitial.CurOps.strDeptID,dtpInDate.Text,txtGoodsID.Text))
							{
								MessageBox.Show("����Ʒ���̵�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
								return;
							}
							break;
					}
					
					DataRow dr=dtConsItem.NewRow();
					dr[0] = "0";
					dr[1]=gs.strGoodsID;
					dr[2]=gs.strGoodsName;
					dr[3]=dPrice.ToString();
					dr[4]=dCount.ToString();					
					dtConsItem.Rows.Add(dr);
				}
				this.DgBind();
				cmbGoodsName.Focus();
			}
			else
			{
				if(err!=null)
				{
					clog.WriteLine(err);
				}
				MessageBox.Show("�޴���Ʒ��Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}
		}

		private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=13)//�س���
			{
				if(e.KeyChar==8)//�˸�
				{
					return;
				}
				if(e.KeyChar<48||e.KeyChar>57)//����
				{
					e.Handled=true;
					return;
				}
			}
			else
			{
				AddGoodsToDataGrid();
			}
		}

		private void sbtnOk_Click(object sender, System.EventArgs e)
		{
			if(dtConsItem.Rows.Count<=0)
			{
				MessageBox.Show("û�н����κ����ѣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				return;
			}

			CMSMData.CMSMStruct.ConsItemStruct cis=new CMSMData.CMSMStruct.ConsItemStruct();
			cis.strOperDate=dtpInDate.Text;
			cis.strOperName=SysInitial.CurOps.strOperName;
			cis.dtItem=dtConsItem;
			cis.strDeptID=SysInitial.CurOps.strDeptID;
			cis.strTolCount=txtTolCount.Text;			
			err=null;
			switch(this.formType)
			{
				case FormType.ProductionInStorage:
					cs.ProductionInStorage(cis,out err);
					break;
				case FormType.SaleCheck:
					cs.SaleCheck(cis,out err);
					break;
			}
			
			if(err!=null)
			{
				MessageBox.Show("����ʧ�ܣ������ԣ�","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				clog.WriteLine(err);
			}
			else
			{				
				cmbGoodsName.Text="������...";
				txtGoodsID.Text="";
				cmbGoodsName.Items.Clear();
				cmbGoodsName.Refresh();
				txtPrice.Text="";
				txtCount.Text="";				
				txtTolCount.Text="0";
				InitConsItemDataTable();
				this.DgBind();
			}
		}

		private void DgBind()
		{
			if(dtConsItem!=null)
			{
				double dTolCount=0;		
				for(int i=0;i<dtConsItem.Rows.Count;i++)
				{
					dTolCount+=double.Parse(dtConsItem.Rows[i]["Count"].ToString());
				}
				txtTolCount.Text=dTolCount.ToString();
				
				this.dataGrid1.SetDataBinding(dtConsItem,"");
				this.EnToCh("���,��Ʒ���,��Ʒ����,����,����","100,100,170,100,100",dtConsItem,this.dataGrid1);
			}
		}

		private void frmProductionInStorage_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)   
			{   
				case Keys.F6:   
					sbtnOk.PerformClick();   
					break;
				case Keys.F7:
					sbtnAdd.PerformClick();
					break;
			}  
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			AddGoodsToDataGrid();
		}

		private void cmbGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbGoodsName.Text.Trim()!="")
			{
				string strSpell=cmbGoodsName.Text.Trim();
				CMSMData.CMSMStruct.GoodsStruct gs=new CMSMData.CMSMStruct.GoodsStruct();
				err=null;
				gs=cs.GetGoodsByName(cmbGoodsName.Text.Trim(),out err);
				if(gs!=null)
				{
					txtGoodsID.Text=gs.strGoodsID;
					cmbGoodsName.Text=gs.strGoodsName;
					txtPrice.Text=gs.dPrice.ToString();
					txtCount.Text="1";
					cmbGoodsName.Focus();
				}
				else
				{
					if(err!=null)
					{
						clog.WriteLine(err);
					}
					MessageBox.Show("�޴���Ʒ��Ϣ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					cmbGoodsName.Text="������...";
					cmbGoodsName.Focus();
					return;
				}
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//��ѯ
			InitConsItemDataTable();
			DataTable dt = new DataTable();
			switch(this.formType)
			{
				case FormType.ProductionInStorage:
					dt = cs.GetProductionInStorage(SysInitial.CurOps.strDeptID,dtpInDate.Text);
					break;
				case FormType.SaleCheck:
					dt = cs.GetSaleCheck(SysInitial.CurOps.strDeptID,dtpInDate.Text);
					break;
			}

			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					DataRow dr1=dtConsItem.NewRow();
					dr1[0] = dr["Id"].ToString();
					dr1[1]=dr["vcGoodsId"].ToString();
					dr1[2]=dr["vcGoodsName"].ToString();
					dr1[3]=dr["nPrice"].ToString();
					dr1[4]=dr["Quantity"].ToString();					
					dtConsItem.Rows.Add(dr1);
				}
			}
			this.DgBind();
		}
	}
}
