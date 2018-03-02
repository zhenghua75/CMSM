using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CMSMData.CMSMDataAccess;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmSaleBalance ��ժҪ˵����
	/// </summary>
	public class frmSaleBalance : CMSM.CMSMApp.frmBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBox1;
		CommAccess cs=new CommAccess(SysInitial.ConString);
		public frmSaleBalance()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "ƽ��",
            "��ƽ��"});
            this.comboBox1.Location = new System.Drawing.Point(217, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(512, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "�ر�";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(429, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "����EXCEL";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "��ѯ";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "����";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 64);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(960, 557);
            this.dataGrid1.TabIndex = 1;
            // 
            // frmSaleBalance
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(960, 621);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSaleBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����ƽ���";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleBalance_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void DgBind()
		{			
			Exception err=null;
			DataTable dt=new DataTable();
			dt=cs.GetSaleBalance(this.dateTimePicker1.Text,this.comboBox1.Text,out err);
			if(dt!=null&&dt.Rows.Count>=0)
			{
				this.dataGrid1.CaptionText="����ƽ���";
				this.dataGrid1.SetDataBinding(dt,"");
				this.EnToCh("�ŵ�,��Ʒ����,��Ʒ����,����,�ϴ��̵�����,�������,��������,�����̵�����,������,�Ƿ�ƽ��","150,180,80,150,120,80",dt,this.dataGrid1);
				if(dt.Rows.Count>0)
				{
					this.button2.Enabled=true;
				}
				else
				{
					this.button2.Enabled=false;
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


		private void button1_Click(object sender, System.EventArgs e)
		{
			//��ѯ
			DgBind();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
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

		private void button3_Click(object sender, System.EventArgs e)
		{
			//�ر�
			this.Close();
		}

		private void frmSaleBalance_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
