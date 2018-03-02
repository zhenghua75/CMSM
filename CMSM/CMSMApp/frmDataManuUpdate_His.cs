using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using CMSMData.CMSMDataAccess;
using System.Threading;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// frmDataManuUpdate_His ��ժҪ˵����
	/// </summary>
	public class frmDataManuUpdate_His : frmBase
	{
		private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Threading.Thread threadDown;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;

		bool threadFin=false;
		Hashtable hsMessage;
        private Button sbtnUpdate;
        private Button sbtnClose;
		int mesindex=0;

		public frmDataManuUpdate_His()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataManuUpdate_His));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sbtnUpdate = new System.Windows.Forms.Button();
            this.sbtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(600, 256);
            this.listBox1.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(216, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "��ʼʱ��";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sbtnUpdate
            // 
            this.sbtnUpdate.Location = new System.Drawing.Point(146, 384);
            this.sbtnUpdate.Name = "sbtnUpdate";
            this.sbtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.sbtnUpdate.TabIndex = 37;
            this.sbtnUpdate.Text = "��ʼͬ��";
            this.sbtnUpdate.UseVisualStyleBackColor = true;
            this.sbtnUpdate.Click += new System.EventHandler(this.sbtnUpdate_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(378, 384);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 38;
            this.sbtnClose.Text = "�ر�";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmDataManuUpdate_His
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(632, 428);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDataManuUpdate_His";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ͬ����ʷ��������";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDataManuUpdate_His_Closing);
            this.Load += new System.EventHandler(this.frmDataManuUpdate_His_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateData()
		{
			mesindex=0;
			hsMessage=new Hashtable();
			SqlConnection conLocal=new SqlConnection(SysInitial.ConString);
			SqlConnection conCenter=new SqlConnection(SysInitial.CenterConString);
			try
			{
				conCenter.Open();
				conLocal.Open();
			}
			catch(Exception conerr)
			{
				if(conCenter.State==ConnectionState.Open)
				{
					conCenter.Close();
				}
				if(conLocal.State==ConnectionState.Open)
				{
					conLocal.Close();
				}
				clog.WriteLine(conerr);
				hsMessage.Add(hsMessage.Count,"--------------------------------");
				hsMessage.Add(hsMessage.Count,"�����������ݿ�ʧ�ܣ��������磡");
				this.sbtnClose.Enabled=true;
				this.Refresh();
				return;
			}

			SqlDataAdapter daTmp;
			SqlCommand cmd;
			SqlDataAdapter daTmp1;
			SqlCommand cmd1;
			SqlDataReader drr;
			string sql="";
			string sqlDeal="";
			int i=0;
			int recCount=0;
			int rowindex=0;
			int UpdatedCount=0;

			DataSet dstmp=new DataSet();
			string strBeginDate=this.dateTimePicker1.Value.ToShortDateString();
			string strTransferDate="";
			if(this.dateTimePicker1.Value.CompareTo(DateTime.Today.AddDays(-3))<0)
			{
				strTransferDate=this.dateTimePicker1.Value.AddDays(-12).ToShortDateString();
			}
			else
			{
				strTransferDate=DateTime.Today.AddDays(-15).ToShortDateString();
			}

			#region ��Ա��Ϣͬ������ע��
			//			using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
			//			{
			//				using(SqlTransaction tranLocal=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
			//				{
			//					try
			//					{
			//						this.listBox1.Items.Add("--------------------------------");
			//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  ��ʼͬ����Ա����������...");
			//						this.Refresh();
			//						#region ���ػ�Ա����
			//						//���ػ�Ա����
			//						sql="select * from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' and dtOperDate>='" + strBeginDate + "' order by iAssID,vcCardID";
			//						cmd=new SqlCommand(sql,conLocal,tranLocal);
			//						daTmp=new SqlDataAdapter(cmd);
			//						daTmp.Fill(dstmp,"LocaltbAssociator");
			//
			//						sql="select vcCardID,dtOperDate from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' order by vcCardID";
			//						cmd=new SqlCommand(sql,conLocal,tranLocal);
			//						daTmp=new SqlDataAdapter(cmd);
			//						daTmp.Fill(dstmp,"LocalCardID");
			//						Hashtable htLocal=new Hashtable();
			//						foreach(DataRow dr in dstmp.Tables["LocalCardID"].Rows)
			//						{
			//							htLocal.Add(dr["vcCardID"].ToString(),(DateTime)dr["dtOperDate"]);
			//						}
			//
			//						//���Ļ�Ա����
			//						sql="select * from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' and dtOperDate>='" + strBeginDate + "' order by iAssID,vcCardID";
			//						cmd=new SqlCommand(sql,conCenter,tranCenter);
			//						daTmp=new SqlDataAdapter(cmd);
			//						daTmp.Fill(dstmp,"CentertbAssociator");
			//
			//						sql="select vcCardID,dtOperDate from tbAssociator where vcCardID<>'V9999' and vcAssType<>'AT999' order by vcCardID";
			//						cmd=new SqlCommand(sql,conCenter,tranCenter);
			//						daTmp=new SqlDataAdapter(cmd);
			//						daTmp.Fill(dstmp,"CenterCardID");
			//						Hashtable htCenter=new Hashtable();
			//						foreach(DataRow dr in dstmp.Tables["CenterCardID"].Rows)
			//						{
			//							htCenter.Add(dr["vcCardID"].ToString(),(DateTime)dr["dtOperDate"]);
			//						}
			//						#endregion
			//
			//						UpdatedCount=0;
			//						#region ����������ͬ����Ա����--����
			//						SqlDataAdapter sd = new SqlDataAdapter();
			//						sd.SelectCommand = new SqlCommand("select [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID], [vcCardSerial] from tbAssociator where 1=2",conCenter,tranCenter);
			//						sd.InsertCommand = new SqlCommand("insert into tbAssociator ([vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID], [vcCardSerial])"
			//							+ " values (@CardID,@AssName,@Spell,@AssNbr,@LinkPhone,@LinkAddress,@Email,@AssType,@AssState,@Charge,@IgValue,@CardFlag,@Comments,@CreateDate,@OperDate,@DeptID,@CardSerial);",conCenter,tranCenter);
			//						sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
			//						sd.InsertCommand.Parameters.Add("@AssName", SqlDbType.VarChar, 30, "vcAssName");
			//						sd.InsertCommand.Parameters.Add("@Spell", SqlDbType.VarChar, 10, "vcSpell");
			//						sd.InsertCommand.Parameters.Add("@AssNbr", SqlDbType.VarChar, 20, "vcAssNbr");
			//						sd.InsertCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
			//						sd.InsertCommand.Parameters.Add("@LinkAddress", SqlDbType.VarChar, 100, "vcLinkAddress");
			//						sd.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 30, "vcEmail");
			//						sd.InsertCommand.Parameters.Add("@AssType", SqlDbType.VarChar, 5, "vcAssType");
			//						sd.InsertCommand.Parameters.Add("@AssState", SqlDbType.VarChar, 1, "vcAssState");
			//						sd.InsertCommand.Parameters.Add("@Charge", SqlDbType.Float, 10, "nCharge");
			//						sd.InsertCommand.Parameters.Add("@IgValue", SqlDbType.Int, 8, "iIgValue");
			//						sd.InsertCommand.Parameters.Add("@CardFlag", SqlDbType.Char, 1, "vcCardFlag");
			//						sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 200, "vcComments");
			//						sd.InsertCommand.Parameters.Add("@CreateDate", SqlDbType.DateTime, 8, "dtCreateDate");
			//						sd.InsertCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
			//						sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
			//						sd.InsertCommand.Parameters.Add("@CardSerial", SqlDbType.VarChar, 40, "vcCardSerial");
			//						sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
			//						//					sd.UpdateBatchSize = 0;
			//
			//						DataSet dsAssOperSync = new DataSet();
			//						sd.Fill(dsAssOperSync);
			//						rowindex=0;
			//						for (i = 0; i < dstmp.Tables["LocaltbAssociator"].Rows.Count; i++)
			//						{
			//							if(!htCenter.ContainsKey(dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardID"].ToString()))
			//							{
			//								object[] row = {dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardID"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcAssName"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcSpell"].ToString(),
			//												   dstmp.Tables["LocaltbAssociator"].Rows[i]["vcAssNbr"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcLinkPhone"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcLinkAddress"].ToString(),
			//												   dstmp.Tables["LocaltbAssociator"].Rows[i]["vcEmail"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcAssType"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcAssState"].ToString(),
			//												   dstmp.Tables["LocaltbAssociator"].Rows[i]["nCharge"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["iIgValue"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardFlag"].ToString(),
			//												   dstmp.Tables["LocaltbAssociator"].Rows[i]["vcComments"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["dtCreateDate"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["dtOperDate"].ToString(),
			//												   dstmp.Tables["LocaltbAssociator"].Rows[i]["vcDeptID"].ToString(),dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardSerial"].ToString()};
			//								dsAssOperSync.Tables[0].Rows.Add(row);
			//								if(dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardSerial"].ToString()=="NULL"||dstmp.Tables["LocaltbAssociator"].Rows[i]["vcCardSerial"].ToString()=="")
			//								{
			//									dsAssOperSync.Tables[0].Rows[rowindex]["vcCardSerial"]=null;
			//								}
			//								UpdatedCount++;
			//								rowindex++;
			//							}
			//							if (dsAssOperSync.Tables[0].Rows.Count>0&&dsAssOperSync.Tables[0].Rows.Count % 300 == 0)
			//							{
			//								sd.Update(dsAssOperSync.Tables[0]);
			//								dsAssOperSync.Tables[0].Clear();
			//								rowindex=0;
			//							}
			//						}
			//						sd.Update(dsAssOperSync.Tables[0]);
			//						dsAssOperSync.Tables[0].Clear();
			//						sd.Dispose();
			//						dsAssOperSync.Dispose();
			//						#endregion
			//						this.listBox1.Items.Add("�����������ݣ���Ա����������������"+UpdatedCount.ToString()+"����¼.");
			//						UpdatedCount=0;
			//						#region ����������ͬ����Ա����--����
			//						sd = new SqlDataAdapter();
			//						sd.SelectCommand = new SqlCommand("select top 200 vcCardID,vcAssName,vcSpell,vcAssNbr,vcLinkPhone,vcLinkAddress,vcEmail,vcAssType,vcAssState,nCharge,iIgValue,vcCardFlag,vcComments,dtOperDate,vcCardSerial from tbAssociator", conCenter,tranCenter);
			//						dsAssOperSync = new DataSet();
			//						sd.Fill(dsAssOperSync);
			//						sd.UpdateCommand = new SqlCommand("update tbAssociator "
			//							+ " set vcAssName = @AssName,vcSpell = @Spell,vcAssNbr=@AssNbr,vcLinkPhone=@LinkPhone,vcLinkAddress=@LinkAddress,vcEmail=@Email,vcAssType=@AssType,vcAssState=@AssState,nCharge=@Charge,iIgValue=@IgValue,vcCardFlag=@CardFlag,vcComments=@Comments,dtOperDate=@OperDate,vcCardSerial=@CardSerial where vcCardID = @CardID", conCenter,tranCenter);
			//						sd.UpdateCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
			//						sd.UpdateCommand.Parameters.Add("@AssName", SqlDbType.VarChar, 30, "vcAssName");
			//						sd.UpdateCommand.Parameters.Add("@Spell", SqlDbType.VarChar, 10, "vcSpell");
			//						sd.UpdateCommand.Parameters.Add("@AssNbr", SqlDbType.VarChar, 20, "vcAssNbr");
			//						sd.UpdateCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
			//						sd.UpdateCommand.Parameters.Add("@LinkAddress", SqlDbType.VarChar, 100, "vcLinkAddress");
			//						sd.UpdateCommand.Parameters.Add("@Email", SqlDbType.VarChar, 30, "vcEmail");
			//						sd.UpdateCommand.Parameters.Add("@AssType", SqlDbType.VarChar, 5, "vcAssType");
			//						sd.UpdateCommand.Parameters.Add("@AssState", SqlDbType.VarChar, 1, "vcAssState");
			//						sd.UpdateCommand.Parameters.Add("@Charge", SqlDbType.Float, 10, "nCharge");
			//						sd.UpdateCommand.Parameters.Add("@IgValue", SqlDbType.Int, 8, "iIgValue");
			//						sd.UpdateCommand.Parameters.Add("@CardFlag", SqlDbType.Char, 1, "vcCardFlag");
			//						sd.UpdateCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 200, "vcComments");
			//						sd.UpdateCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
			//						sd.UpdateCommand.Parameters.Add("@CardSerial", SqlDbType.VarChar, 40, "vcCardSerial");
			//						sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
			//						//					sd.UpdateBatchSize = 0;
			//						int updateflag=0;
			//						for (int count = 0; count < dstmp.Tables["LocaltbAssociator"].Rows.Count;count++)
			//						{
			//							if(htCenter.ContainsKey(dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardID"].ToString()))
			//							{
			//								DateTime dtTimeAssCenter=(DateTime)htCenter[dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardID"].ToString()];
			//								DateTime dtTimeAssLocal=(DateTime)dstmp.Tables["LocaltbAssociator"].Rows[count]["dtOperDate"];
			//								if(dtTimeAssCenter.CompareTo(dtTimeAssLocal)<0)
			//								{
			//									dsAssOperSync.Tables[0].Rows[updateflag].BeginEdit();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssName"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcAssName"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcSpell"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcSpell"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssNbr"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcAssNbr"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcLinkPhone"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcLinkPhone"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcLinkAddress"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcLinkAddress"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcEmail"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcEmail"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssType"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcAssType"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssState"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcAssState"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["nCharge"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["nCharge"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["iIgValue"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["iIgValue"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcCardFlag"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardFlag"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcComments"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["vcComments"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["dtOperDate"] = dstmp.Tables["LocaltbAssociator"].Rows[count]["dtOperDate"].ToString();
			//									if(dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardSerial"].ToString()=="NULL"||dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardSerial"].ToString()=="")
			//									{
			//										dsAssOperSync.Tables[0].Rows[updateflag]["vcCardSerial"] =null;
			//									}
			//									else
			//									{
			//										dsAssOperSync.Tables[0].Rows[updateflag]["vcCardSerial"] =dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardSerial"].ToString();
			//									}
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcCardID"] =dstmp.Tables["LocaltbAssociator"].Rows[count]["vcCardID"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag].EndEdit();
			//									updateflag++;
			//									UpdatedCount++;
			//								}
			//							}
			//							if(updateflag>=200||(updateflag>0&&count==dstmp.Tables["LocaltbAssociator"].Rows.Count-1))
			//							{
			//								sd.Update(dsAssOperSync.Tables[0]);
			//								updateflag=0;
			//							}
			//						}
			//						dsAssOperSync.Tables[0].Clear();
			//						sd.Dispose();
			//						dsAssOperSync.Dispose();
			//						#endregion
			//						this.listBox1.Items.Add("�����������ݣ���Ա�����޸ġ����޸�"+UpdatedCount.ToString()+"����¼.");
			//						this.listBox1.Items.Add("--------------------------------");
			//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  ��ʼͬ����Ա����������...");
			//						this.Refresh();
			//						UpdatedCount=0;
			//						#region �����򱾵�ͬ����Ա����--����
			//						sd = new SqlDataAdapter();
			//						sd.SelectCommand = new SqlCommand("select [vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID],[vcCardSerial] from tbAssociator where 1=2",conLocal,tranLocal);
			//						sd.InsertCommand = new SqlCommand("insert into tbAssociator ([vcCardID], [vcAssName], [vcSpell], [vcAssNbr], [vcLinkPhone], [vcLinkAddress], [vcEmail], [vcAssType], [vcAssState], [nCharge], [iIgValue], [vcCardFlag], [vcComments], [dtCreateDate], [dtOperDate], [vcDeptID],[vcCardSerial])"
			//							+ " values (@CardID,@AssName,@Spell,@AssNbr,@LinkPhone,@LinkAddress,@Email,@AssType,@AssState,@Charge,@IgValue,@CardFlag,@Comments,@CreateDate,@OperDate,@DeptID,@CardSerial);",conLocal,tranLocal);
			//						sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
			//						sd.InsertCommand.Parameters.Add("@AssName", SqlDbType.VarChar, 30, "vcAssName");
			//						sd.InsertCommand.Parameters.Add("@Spell", SqlDbType.VarChar, 10, "vcSpell");
			//						sd.InsertCommand.Parameters.Add("@AssNbr", SqlDbType.VarChar, 20, "vcAssNbr");
			//						sd.InsertCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
			//						sd.InsertCommand.Parameters.Add("@LinkAddress", SqlDbType.VarChar, 100, "vcLinkAddress");
			//						sd.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 30, "vcEmail");
			//						sd.InsertCommand.Parameters.Add("@AssType", SqlDbType.VarChar, 5, "vcAssType");
			//						sd.InsertCommand.Parameters.Add("@AssState", SqlDbType.VarChar, 1, "vcAssState");
			//						sd.InsertCommand.Parameters.Add("@Charge", SqlDbType.Float, 10, "nCharge");
			//						sd.InsertCommand.Parameters.Add("@IgValue", SqlDbType.Int, 8, "iIgValue");
			//						sd.InsertCommand.Parameters.Add("@CardFlag", SqlDbType.Char, 1, "vcCardFlag");
			//						sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 200, "vcComments");
			//						sd.InsertCommand.Parameters.Add("@CreateDate", SqlDbType.DateTime, 8, "dtCreateDate");
			//						sd.InsertCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
			//						sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
			//						sd.InsertCommand.Parameters.Add("@CardSerial", SqlDbType.VarChar, 40, "vcCardSerial");
			//						sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
			//						//					sd.UpdateBatchSize = 0;
			//
			//						dsAssOperSync = new DataSet();
			//						sd.Fill(dsAssOperSync);
			//						rowindex=0;
			//						for (i = 0; i < dstmp.Tables["CentertbAssociator"].Rows.Count; i++)
			//						{
			//							if(!htLocal.ContainsKey(dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardID"].ToString()))
			//							{
			//								object[] row = {dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardID"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcAssName"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcSpell"].ToString(),
			//												   dstmp.Tables["CentertbAssociator"].Rows[i]["vcAssNbr"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcLinkPhone"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcLinkAddress"].ToString(),
			//												   dstmp.Tables["CentertbAssociator"].Rows[i]["vcEmail"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcAssType"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcAssState"].ToString(),
			//												   dstmp.Tables["CentertbAssociator"].Rows[i]["nCharge"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["iIgValue"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardFlag"].ToString(),
			//												   dstmp.Tables["CentertbAssociator"].Rows[i]["vcComments"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["dtCreateDate"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["dtOperDate"].ToString(),
			//												   dstmp.Tables["CentertbAssociator"].Rows[i]["vcDeptID"].ToString(),dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardSerial"].ToString()};
			//								dsAssOperSync.Tables[0].Rows.Add(row);
			//								if(dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardSerial"].ToString()=="NULL"||dstmp.Tables["CentertbAssociator"].Rows[i]["vcCardSerial"].ToString()=="")
			//								{
			//									dsAssOperSync.Tables[0].Rows[rowindex]["vcCardSerial"]=null;
			//								}
			//								UpdatedCount++;
			//								rowindex++;
			//							}
			//							if (dsAssOperSync.Tables[0].Rows.Count>0&&dsAssOperSync.Tables[0].Rows.Count % 300 == 0)
			//							{
			//								sd.Update(dsAssOperSync.Tables[0]);
			//								dsAssOperSync.Tables[0].Clear();
			//								rowindex=0;
			//							}
			//						}
			//						sd.Update(dsAssOperSync.Tables[0]);
			//						dsAssOperSync.Tables[0].Clear();
			//						sd.Dispose();
			//						dsAssOperSync.Dispose();
			//						#endregion
			//						this.listBox1.Items.Add("���±������ݣ���Ա����������������"+UpdatedCount.ToString()+"����¼.");
			//						UpdatedCount=0;
			//						#region ����������ͬ����Ա����--����
			//						sd = new SqlDataAdapter();
			//						sd.SelectCommand = new SqlCommand("select top 200 vcCardID,vcAssName,vcSpell,vcAssNbr,vcLinkPhone,vcLinkAddress,vcEmail,vcAssType,vcAssState,nCharge,iIgValue,vcCardFlag,vcComments,dtOperDate,vcCardSerial from tbAssociator", conLocal,tranLocal);
			//						dsAssOperSync = new DataSet();
			//						sd.Fill(dsAssOperSync);
			//						sd.UpdateCommand = new SqlCommand("update tbAssociator "
			//							+ " set vcAssName = @AssName,vcSpell = @Spell,vcAssNbr=@AssNbr,vcLinkPhone=@LinkPhone,vcLinkAddress=@LinkAddress,vcEmail=@Email,vcAssType=@AssType,vcAssState=@AssState,nCharge=@Charge,iIgValue=@IgValue,vcCardFlag=@CardFlag,vcComments=@Comments,dtOperDate=@OperDate,vcCardSerial=@CardSerial where vcCardID = @CardID", conLocal,tranLocal);
			//						sd.UpdateCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
			//						sd.UpdateCommand.Parameters.Add("@AssName", SqlDbType.VarChar, 30, "vcAssName");
			//						sd.UpdateCommand.Parameters.Add("@Spell", SqlDbType.VarChar, 10, "vcSpell");
			//						sd.UpdateCommand.Parameters.Add("@AssNbr", SqlDbType.VarChar, 20, "vcAssNbr");
			//						sd.UpdateCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
			//						sd.UpdateCommand.Parameters.Add("@LinkAddress", SqlDbType.VarChar, 100, "vcLinkAddress");
			//						sd.UpdateCommand.Parameters.Add("@Email", SqlDbType.VarChar, 30, "vcEmail");
			//						sd.UpdateCommand.Parameters.Add("@AssType", SqlDbType.VarChar, 5, "vcAssType");
			//						sd.UpdateCommand.Parameters.Add("@AssState", SqlDbType.VarChar, 1, "vcAssState");
			//						sd.UpdateCommand.Parameters.Add("@Charge", SqlDbType.Float, 10, "nCharge");
			//						sd.UpdateCommand.Parameters.Add("@IgValue", SqlDbType.Int, 8, "iIgValue");
			//						sd.UpdateCommand.Parameters.Add("@CardFlag", SqlDbType.Char, 1, "vcCardFlag");
			//						sd.UpdateCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 200, "vcComments");
			//						sd.UpdateCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
			//						sd.UpdateCommand.Parameters.Add("@CardSerial", SqlDbType.VarChar, 40, "vcCardSerial");
			//						sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
			//						//					sd.UpdateBatchSize = 0;
			//						updateflag=0;
			//						for (int count = 0; count < dstmp.Tables["CentertbAssociator"].Rows.Count;count++)
			//						{
			//							if(htLocal.ContainsKey(dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardID"].ToString()))
			//							{
			//								DateTime dtTimeAssLocal=(DateTime)htLocal[dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardID"].ToString()];
			//								DateTime dtTimeAssCenter=(DateTime)dstmp.Tables["CentertbAssociator"].Rows[count]["dtOperDate"];
			//								if(dtTimeAssLocal.CompareTo(dtTimeAssCenter)<0)
			//								{
			//									dsAssOperSync.Tables[0].Rows[updateflag].BeginEdit();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssName"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcAssName"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcSpell"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcSpell"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssNbr"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcAssNbr"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcLinkPhone"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcLinkPhone"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcLinkAddress"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcLinkAddress"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcEmail"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcEmail"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssType"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcAssType"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcAssState"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcAssState"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["nCharge"] = dstmp.Tables["CentertbAssociator"].Rows[count]["nCharge"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["iIgValue"] = dstmp.Tables["CentertbAssociator"].Rows[count]["iIgValue"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcCardFlag"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardFlag"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcComments"] = dstmp.Tables["CentertbAssociator"].Rows[count]["vcComments"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag]["dtOperDate"] = dstmp.Tables["CentertbAssociator"].Rows[count]["dtOperDate"].ToString();
			//									if(dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardSerial"].ToString()=="NULL"||dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardSerial"].ToString()=="")
			//									{
			//										dsAssOperSync.Tables[0].Rows[updateflag]["vcCardSerial"] =null;
			//									}
			//									else
			//									{
			//										dsAssOperSync.Tables[0].Rows[updateflag]["vcCardSerial"] =dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardSerial"].ToString();
			//									}
			//									dsAssOperSync.Tables[0].Rows[updateflag]["vcCardID"] =dstmp.Tables["CentertbAssociator"].Rows[count]["vcCardID"].ToString();
			//									dsAssOperSync.Tables[0].Rows[updateflag].EndEdit();
			//									updateflag++;
			//									UpdatedCount++;
			//								}
			//							}
			//							if(updateflag>=200||(updateflag>0&&count==dstmp.Tables["LocaltbAssociator"].Rows.Count-1))
			//							{
			//								sd.Update(dsAssOperSync.Tables[0]);
			//								updateflag=0;
			//							}
			//						}
			//						dsAssOperSync.Tables[0].Clear();
			//						sd.Dispose();
			//						dsAssOperSync.Dispose();
			//						#endregion
			//						this.listBox1.Items.Add("���±������ݣ���Ա�����޸ġ����޸�"+UpdatedCount.ToString()+"����¼.");
			//
			//						tranLocal.Commit();
			//						tranCenter.Commit();
			//
			//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"ͬ����Ա���ϳɹ�!");
			//						this.listBox1.Items.Add("--------------------------------");
			//						this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
			//						this.Refresh();
			//					}
			//					catch(Exception ex)
			//					{
			//						if(conCenter.State==ConnectionState.Open)
			//						{
			//							conCenter.Close();
			//						}
			//						if(conLocal.State==ConnectionState.Open)
			//						{
			//							conLocal.Close();
			//						}
			//						clog.WriteLine(ex);
			//						this.listBox1.Items.Add("----------------------------------------------------------------------");
			//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  ���¹����з���������󣬸���δ��ȫ��");
			//						this.listBox1.Items.Add("----------------------------------------------------------------------");
			//						MessageBox.Show("���¹����з���������󣬸���δ��ȫ��������ѡ���ֹ����»���������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
			//						this.sbtnClose.Enabled=true;
			//						this.pictureBox1.Visible=false;
			//						this.sbtnUpdate.Enabled=true;
			//						return;
			//					}
			//				}
			//			}
			#endregion

			#region Ա������ͬ������ע��
//			dstmp=new DataSet();
//			using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				using(SqlTransaction tranLocal=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
//				{
//					try
//					{
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼͬ��Ա������...");
//						#region ����Ա������
//						//����Ա������
//						sql="select * from tbEmployee";
//						cmd=new SqlCommand(sql,conLocal,tranLocal);
//						daTmp=new SqlDataAdapter(cmd);
//						daTmp.Fill(dstmp,"LocaltbEmployee");
//
//						Hashtable htLocal=new Hashtable();
//						foreach(DataRow dr in dstmp.Tables["LocaltbEmployee"].Rows)
//						{
//							htLocal.Add(dr["vcCardID"].ToString(),dr["vcFlag"].ToString());
//						}
//
//						//����Ա������
//						sql="select * from tbEmployee where vcFlag<>'1'";
//						cmd=new SqlCommand(sql,conCenter,tranCenter);
//						daTmp=new SqlDataAdapter(cmd);
//						daTmp.Fill(dstmp,"CentertbEmployee");
//
//						sql="select * from tbEmployee where vcFlag='1'";
//						cmd=new SqlCommand(sql,conCenter,tranCenter);
//						daTmp=new SqlDataAdapter(cmd);
//						daTmp.Fill(dstmp,"CentertbEmployeeQuit");
//
//						Hashtable htCenter=new Hashtable();
//						foreach(DataRow dr in dstmp.Tables["CentertbEmployee"].Rows)
//						{
//							if(!htCenter.ContainsKey(dr["vcCardID"].ToString()))
//								htCenter.Add(dr["vcCardID"].ToString(),dr["vcFlag"].ToString());
//						}
//						Hashtable htCenterQuit=new Hashtable();
//						foreach(DataRow dr in dstmp.Tables["CentertbEmployeeQuit"].Rows)
//						{
//							if(!htCenterQuit.ContainsKey(dr["vcCardID"].ToString()))
//								htCenterQuit.Add(dr["vcCardID"].ToString(),dr["vcFlag"].ToString());
//						}
//						#endregion
//
//						UpdatedCount=0;
//						#region ����������ͬ��Ա������--����
//						DataTable dtInsertEmp=dstmp.Tables["CentertbEmployee"].Clone();
//						SqlDataAdapter sd = new SqlDataAdapter();
//						sd.SelectCommand = new SqlCommand("select top 200 vcCardID,vcFlag,dtOperDate from tbEmployee", conCenter,tranCenter);
//						DataSet dsEmpOperSync = new DataSet();
//						sd.Fill(dsEmpOperSync);
//						sd.UpdateCommand = new SqlCommand("update tbEmployee "
//							+ " set vcFlag = @Flag,dtOperDate = @OperDate where vcCardID = @CardID", conCenter,tranCenter);
//						sd.UpdateCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
//						sd.UpdateCommand.Parameters.Add("@Flag", SqlDbType.VarChar, 30, "vcFlag");
//						sd.UpdateCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
//						sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
//						//					sd.UpdateBatchSize = 0;
//						int updateflag=0;
//						for (int count = 0; count < dstmp.Tables["LocaltbEmployee"].Rows.Count;count++)
//						{
//							if(htCenter.ContainsKey(dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString()))
//							{
//								if(htCenter[dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString()].ToString()!=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcFlag"].ToString())
//								{
//									dsEmpOperSync.Tables[0].Rows[updateflag].BeginEdit();
//									dsEmpOperSync.Tables[0].Rows[updateflag]["vcFlag"] = dstmp.Tables["LocaltbEmployee"].Rows[count]["vcFlag"].ToString();
//									dsEmpOperSync.Tables[0].Rows[updateflag]["dtOperDate"] = dstmp.Tables["LocaltbEmployee"].Rows[count]["dtOperDate"].ToString();
//									dsEmpOperSync.Tables[0].Rows[updateflag]["vcCardID"] =dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString();
//									dsEmpOperSync.Tables[0].Rows[updateflag].EndEdit();
//
//									for(int rdrow=0;rdrow<dstmp.Tables["CentertbEmployee"].Rows.Count;rdrow++)
//									{
//										if(dstmp.Tables["CentertbEmployee"].Rows[rdrow]["vcCardID"].ToString()==dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString())
//										{
//											dstmp.Tables["CentertbEmployee"].Rows[rdrow]["vcFlag"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcFlag"].ToString();
//											dstmp.Tables["CentertbEmployee"].Rows[rdrow]["dtOperDate"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["dtOperDate"].ToString();
//											break;
//										}
//									}
//									updateflag++;
//									UpdatedCount++;
//								}
//							}
//							else
//							{
//								if(!htCenterQuit.ContainsKey(dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString()))
//								{
//									DataRow drnew=dstmp.Tables["CentertbEmployee"].NewRow();
//									drnew["vcCardID"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString();
//									drnew["vcEmpName"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcEmpName"].ToString();
//									drnew["vcSex"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcSex"].ToString();
//									drnew["vcEmpNbr"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcEmpNbr"].ToString();
//									drnew["dtInDate"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["dtInDate"].ToString();
//									drnew["vcDegree"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcDegree"].ToString();
//									drnew["vcLinkPhone"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcLinkPhone"].ToString();
//									drnew["vcAddress"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcAddress"].ToString();
//									drnew["vcPwd"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcPwd"].ToString();
//									drnew["vcOfficer"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcOfficer"].ToString();
//									drnew["vcDeptID"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcDeptID"].ToString();
//									drnew["vcFlag"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcFlag"].ToString();
//									drnew["vcComments"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcComments"].ToString();
//									drnew["dtOperDate"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["dtOperDate"].ToString();
//									dstmp.Tables["CentertbEmployee"].Rows.Add(drnew);
//
//									DataRow drnew1=dtInsertEmp.NewRow();
//									drnew1["vcCardID"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcCardID"].ToString();
//									drnew1["vcEmpName"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcEmpName"].ToString();
//									drnew1["vcSex"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcSex"].ToString();
//									drnew1["vcEmpNbr"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcEmpNbr"].ToString();
//									drnew1["dtInDate"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["dtInDate"].ToString();
//									drnew1["vcDegree"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcDegree"].ToString();
//									drnew1["vcLinkPhone"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcLinkPhone"].ToString();
//									drnew1["vcAddress"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcAddress"].ToString();
//									drnew1["vcPwd"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcPwd"].ToString();
//									drnew1["vcOfficer"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcOfficer"].ToString();
//									drnew1["vcDeptID"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcDeptID"].ToString();
//									drnew1["vcFlag"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcFlag"].ToString();
//									drnew1["vcComments"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["vcComments"].ToString();
//									drnew1["dtOperDate"]=dstmp.Tables["LocaltbEmployee"].Rows[count]["dtOperDate"].ToString();
//									dtInsertEmp.Rows.Add(drnew1);
//								}
//							}
//							if(updateflag>=200||(updateflag>0&&count==dstmp.Tables["LocaltbEmployee"].Rows.Count-1))
//							{
//								sd.Update(dsEmpOperSync.Tables[0]);
//								updateflag=0;
//							}
//						}
//						dsEmpOperSync.Tables[0].Clear();
//						dsEmpOperSync.Dispose();
//						#endregion
//						hsMessage.Add(hsMessage.Count,"�����������ݣ�Ա�������޸ġ����޸�"+UpdatedCount.ToString()+"����¼.");
//						UpdatedCount=0;
//						#region ����������ͬ��Ա������--����
//						sd = new SqlDataAdapter();
//						sd.SelectCommand = new SqlCommand("select [vcCardID], [vcEmpName], [vcSex], [vcEmpNbr], [dtInDate], [vcDegree], [vcLinkPhone], [vcAddress], [vcPwd], [vcOfficer], [vcDeptID], [vcFlag], [vcComments], [dtOperDate] from tbEmployee where 1=2",conCenter,tranCenter);
//						sd.InsertCommand = new SqlCommand("insert into tbEmployee ([vcCardID], [vcEmpName], [vcSex], [vcEmpNbr], [dtInDate], [vcDegree], [vcLinkPhone], [vcAddress], [vcPwd], [vcOfficer], [vcDeptID], [vcFlag], [vcComments], [dtOperDate])"
//							+ " values (@CardID,@EmpName,@Sex,@EmpNbr,@InDate,@Degree,@LinkPhone,@Address,@Pwd,@Officer,@DeptID,@Flag,@Comments,@OperDate);",conCenter,tranCenter);
//						sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
//						sd.InsertCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 30, "vcEmpName");
//						sd.InsertCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 5, "vcSex");
//						sd.InsertCommand.Parameters.Add("@EmpNbr", SqlDbType.VarChar, 20, "vcEmpNbr");
//						sd.InsertCommand.Parameters.Add("@InDate", SqlDbType.DateTime, 8, "dtInDate");
//						sd.InsertCommand.Parameters.Add("@Degree", SqlDbType.VarChar, 2, "vcDegree");
//						sd.InsertCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
//						sd.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100, "vcAddress");
//						sd.InsertCommand.Parameters.Add("@Pwd", SqlDbType.VarChar, 20, "vcPwd");
//						sd.InsertCommand.Parameters.Add("@Officer", SqlDbType.VarChar, 5, "vcOfficer");
//						sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
//						sd.InsertCommand.Parameters.Add("@Flag", SqlDbType.VarChar, 2, "vcFlag");
//						sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 256, "vcComments");
//						sd.InsertCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
//						sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
//						//					sd.UpdateBatchSize = 0;
//
//						DataSet dsEmpInsertSync = new DataSet();
//						sd.Fill(dsEmpInsertSync);
//						rowindex=0;
//						for (i = 0; i < dtInsertEmp.Rows.Count; i++)
//						{
//							object[] row = {dtInsertEmp.Rows[i]["vcCardID"].ToString(),dtInsertEmp.Rows[i]["vcEmpName"].ToString(),dtInsertEmp.Rows[i]["vcSex"].ToString(),
//											   dtInsertEmp.Rows[i]["vcEmpNbr"].ToString(),dtInsertEmp.Rows[i]["dtInDate"].ToString(),dtInsertEmp.Rows[i]["vcDegree"].ToString(),
//											   dtInsertEmp.Rows[i]["vcLinkPhone"].ToString(),dtInsertEmp.Rows[i]["vcAddress"].ToString(),dtInsertEmp.Rows[i]["vcPwd"].ToString(),
//											   dtInsertEmp.Rows[i]["vcOfficer"].ToString(),dtInsertEmp.Rows[i]["vcDeptID"].ToString(),dtInsertEmp.Rows[i]["vcFlag"].ToString(),
//											   dtInsertEmp.Rows[i]["vcComments"].ToString(),dtInsertEmp.Rows[i]["dtOperDate"].ToString()};
//							dsEmpInsertSync.Tables[0].Rows.Add(row);
//							UpdatedCount++;
//							rowindex++;
//							if (dsEmpInsertSync.Tables[0].Rows.Count>=300)
//							{
//								sd.Update(dsEmpInsertSync.Tables[0]);
//								dsEmpInsertSync.Tables[0].Clear();
//								rowindex=0;
//							}
//						}
//						if(rowindex>0)
//							sd.Update(dsEmpInsertSync.Tables[0]);
//						dsEmpInsertSync.Tables[0].Clear();
//						dsEmpInsertSync.Dispose();
//						#endregion
//						hsMessage.Add(hsMessage.Count,"�����������ݣ�Ա������������������"+UpdatedCount.ToString()+"����¼.");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼͬ��Ա������������...");
//						UpdatedCount=0;
//						#region �����򱾵�ͬ��Ա������--����
//						//ɾ������Ա������
//						cmd=new SqlCommand("truncate table tbEmployee",conLocal,tranLocal);
//						cmd.ExecuteNonQuery();
//
//						//���¼�������Ա������
//						htCenter=new Hashtable();
//						DataTable dtInsertEmpNew=dstmp.Tables["CentertbEmployee"].Clone();
//						foreach(DataRow dr in dstmp.Tables["CentertbEmployee"].Rows)
//						{
//							if(!htCenter.ContainsKey(dr["vcCardID"].ToString()))
//							{
//								if(dr["vcFlag"].ToString()!="1")
//								{
//									htCenter.Add(dr["vcCardID"].ToString(),dr["vcFlag"].ToString());
//									DataRow drnew=dtInsertEmpNew.NewRow();
//									drnew["vcCardID"]=dr["vcCardID"].ToString();
//									drnew["vcEmpName"]=dr["vcEmpName"].ToString();
//									drnew["vcSex"]=dr["vcSex"].ToString();
//									drnew["vcEmpNbr"]=dr["vcEmpNbr"].ToString();
//									drnew["dtInDate"]=dr["dtInDate"].ToString();
//									drnew["vcDegree"]=dr["vcDegree"].ToString();
//									drnew["vcLinkPhone"]=dr["vcLinkPhone"].ToString();
//									drnew["vcAddress"]=dr["vcAddress"].ToString();
//									drnew["vcPwd"]=dr["vcPwd"].ToString();
//									drnew["vcOfficer"]=dr["vcOfficer"].ToString();
//									drnew["vcDeptID"]=dr["vcDeptID"].ToString();
//									drnew["vcFlag"]=dr["vcFlag"].ToString();
//									drnew["vcComments"]=dr["vcComments"].ToString();
//									drnew["dtOperDate"]=dr["dtOperDate"].ToString();
//									dtInsertEmpNew.Rows.Add(drnew);
//								}
//							}
//						}
//
//						sd = new SqlDataAdapter();
//						sd.SelectCommand = new SqlCommand("select [vcCardID], [vcEmpName], [vcSex], [vcEmpNbr], [dtInDate], [vcDegree], [vcLinkPhone], [vcAddress], [vcPwd], [vcOfficer], [vcDeptID], [vcFlag], [vcComments], [dtOperDate] from tbEmployee where 1=2",conLocal,tranLocal);
//						sd.InsertCommand = new SqlCommand("insert into tbEmployee ([vcCardID], [vcEmpName], [vcSex], [vcEmpNbr], [dtInDate], [vcDegree], [vcLinkPhone], [vcAddress], [vcPwd], [vcOfficer], [vcDeptID], [vcFlag], [vcComments], [dtOperDate])"
//							+ " values (@CardID,@EmpName,@Sex,@EmpNbr,@InDate,@Degree,@LinkPhone,@Address,@Pwd,@Officer,@DeptID,@Flag,@Comments,@OperDate);",conLocal,tranLocal);
//						sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
//						sd.InsertCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 30, "vcEmpName");
//						sd.InsertCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 5, "vcSex");
//						sd.InsertCommand.Parameters.Add("@EmpNbr", SqlDbType.VarChar, 20, "vcEmpNbr");
//						sd.InsertCommand.Parameters.Add("@InDate", SqlDbType.DateTime, 8, "dtInDate");
//						sd.InsertCommand.Parameters.Add("@Degree", SqlDbType.VarChar, 2, "vcDegree");
//						sd.InsertCommand.Parameters.Add("@LinkPhone", SqlDbType.VarChar, 25, "vcLinkPhone");
//						sd.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100, "vcAddress");
//						sd.InsertCommand.Parameters.Add("@Pwd", SqlDbType.VarChar, 20, "vcPwd");
//						sd.InsertCommand.Parameters.Add("@Officer", SqlDbType.VarChar, 5, "vcOfficer");
//						sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
//						sd.InsertCommand.Parameters.Add("@Flag", SqlDbType.VarChar, 2, "vcFlag");
//						sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 256, "vcComments");
//						sd.InsertCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
//						sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
//						//					sd.UpdateBatchSize = 0;
//
//						dsEmpInsertSync = new DataSet();
//						sd.Fill(dsEmpInsertSync);
//						rowindex=0;
//						for (i = 0; i < dtInsertEmpNew.Rows.Count; i++)
//						{
//							object[] row = {dtInsertEmpNew.Rows[i]["vcCardID"].ToString(),dtInsertEmpNew.Rows[i]["vcEmpName"].ToString(),dtInsertEmpNew.Rows[i]["vcSex"].ToString(),
//											   dtInsertEmpNew.Rows[i]["vcEmpNbr"].ToString(),dtInsertEmpNew.Rows[i]["dtInDate"].ToString(),dtInsertEmpNew.Rows[i]["vcDegree"].ToString(),
//											   dtInsertEmpNew.Rows[i]["vcLinkPhone"].ToString(),dtInsertEmpNew.Rows[i]["vcAddress"].ToString(),dtInsertEmpNew.Rows[i]["vcPwd"].ToString(),
//											   dtInsertEmpNew.Rows[i]["vcOfficer"].ToString(),dtInsertEmpNew.Rows[i]["vcDeptID"].ToString(),dtInsertEmpNew.Rows[i]["vcFlag"].ToString(),
//											   dtInsertEmpNew.Rows[i]["vcComments"].ToString(),dtInsertEmpNew.Rows[i]["dtOperDate"].ToString()};
//							dsEmpInsertSync.Tables[0].Rows.Add(row);
//							UpdatedCount++;
//							rowindex++;
//							if (dsEmpInsertSync.Tables[0].Rows.Count>=300)
//							{
//								sd.Update(dsEmpInsertSync.Tables[0]);
//								dsEmpInsertSync.Tables[0].Clear();
//								rowindex=0;
//							}
//						}
//						if(rowindex>0)
//							sd.Update(dsEmpInsertSync.Tables[0]);
//						dsEmpInsertSync.Tables[0].Clear();
//						dsEmpInsertSync.Dispose();
//						#endregion
//						hsMessage.Add(hsMessage.Count,"���±������ݣ�Ա�������������ء�������"+UpdatedCount.ToString()+"����¼.");
//
//						tranLocal.Commit();
//						tranCenter.Commit();
//
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"ͬ��Ա�����ϳɹ�!");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//					}
//					catch(Exception ex)
//					{
//						if(conCenter.State==ConnectionState.Open)
//						{
//							conCenter.Close();
//						}
//						if(conLocal.State==ConnectionState.Open)
//						{
//							conLocal.Close();
//						}
//						clog.WriteLine(ex);
//						hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ���¹����з���������󣬸���δ��ȫ��");
//						hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
//						MessageBox.Show("���¹����з���������󣬸���δ��ȫ��������ѡ���ֹ����»���������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						this.sbtnClose.Enabled=true;
//						this.pictureBox1.Visible=false;
//						this.sbtnUpdate.Enabled=true;
//						return;
//					}
//				}
//			}
//
//			conLocal.Close();
//			conCenter.Close();
			#endregion

			#region ������ͬ�����ѵ���Ϣ
			hsMessage.Add(hsMessage.Count,"");
			hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ���ر������ݿ�����...");
			hsMessage.Add(hsMessage.Count,"--------------------------------");
			dstmp=new DataSet();
			DataSet dshashtmp=new DataSet();

			try
			{
				#region ��ȡ������Ҫ�ϴ������ϣ�ֻȡ��3�������	��ͬʱȡ���ĸ���������hashtable	
				//������ϸ
				sql="select * from tbConsItemHis where dtConsDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbConsItem");

				sql="select distinct iSerial,vcDeptID from tbConsItemOther where vcDeptID='"+SysInitial.LocalDept+"' and dtConsDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsConsItem");
				Hashtable htCenterConsItem=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsConsItem"].Rows)
				{
					htCenterConsItem.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//���ѳ���
				sql="select iSerial from tbConsItemHis where vcDeptID='"+SysInitial.LocalDept+"' and dtConsDate>='" + strBeginDate + "' and cFlag='9'";
				cmd1=new SqlCommand(sql,conLocal);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsConsItemRemove");
				string strConsRemoveSerial="";
				foreach(DataRow dr in dshashtmp.Tables["hsConsItemRemove"].Rows)
				{
					strConsRemoveSerial+=dr["iSerial"].ToString()+",";
				}
				if (strConsRemoveSerial!="")
				{
					strConsRemoveSerial=strConsRemoveSerial.Substring(0,strConsRemoveSerial.Length-1);
				}

				//СƱ
				sql="select * from tbBillHis where dtConsDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbBill");

				sql="select distinct iSerial,vcDeptID from tbBillOther where vcDeptID='"+SysInitial.LocalDept+"' and dtConsDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsBill");
				Hashtable htCenterBill=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsBill"].Rows)
				{
					htCenterBill.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//������־
				sql="select * from tbIntegralLogHis where dtIgDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbIntegralLog");

				sql="select distinct iSerial,vcDeptID from tbIntegralLogOther where vcDeptID='"+SysInitial.LocalDept+"' and dtIgDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsIntegralLog");
				Hashtable htCenterIntegralLog=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsIntegralLog"].Rows)
				{
					htCenterIntegralLog.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//��ֵ
				sql="select * from tbFillFeeHis where dtFillDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbFillFee");

				sql="select distinct iSerial,vcDeptID from tbFillFeeOther where vcDeptID='"+SysInitial.LocalDept+"' and dtFillDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsFillFee");
				Hashtable htCenterFillFee=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsFillFee"].Rows)
				{
					htCenterFillFee.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//��ֵ����
				sql="select iSerial from tbFillFeeHis where vcDeptID='"+SysInitial.LocalDept+"' and dtFillDate>='" + strBeginDate + "' and vcComments='��ֵ����'";
				cmd1=new SqlCommand(sql,conLocal);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsFillFeeRemove");
				string strFillRemoveSerial="";
				foreach(DataRow dr in dshashtmp.Tables["hsFillFeeRemove"].Rows)
				{
					strFillRemoveSerial+=dr["iSerial"].ToString()+",";
				}
				if (strFillRemoveSerial!="")
				{
					strFillRemoveSerial=strFillRemoveSerial.Substring(0,strFillRemoveSerial.Length-1);
				}

				//Ӫҵ��־
				sql="select * from tbBusiLogHis where dtOperDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbBusiLog");

				sql="select distinct iSerial,vcDeptID from tbBusiLogOther where vcDeptID='"+SysInitial.LocalDept+"' and dtOperDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsBusiLog");
				Hashtable htCenterBusiLog=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsBusiLog"].Rows)
				{
					htCenterBusiLog.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//ϵͳ������־
				sql="select * from tbSysErrorLog where dtErrDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbSysErrorLog");

				sql="select distinct iSerial,vcDeptID from tbSysErrorLog where vcDeptID='"+SysInitial.LocalDept+"' and dtErrDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsSysErrorLog");
				Hashtable htCenterSysErrorLog=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsSysErrorLog"].Rows)
				{
					htCenterSysErrorLog.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}

				//����
				sql="select * from tbEmpSign where dtSignDate>='" + strBeginDate + "'";
				cmd=new SqlCommand(sql,conLocal);
				cmd.CommandTimeout=600;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"LocaltbEmpSign");

				sql="select distinct iSerial,vcDeptID from tbEmpSign where vcDeptID='"+SysInitial.LocalDept+"' and dtSignDate>='" + strBeginDate + "'";
				cmd1=new SqlCommand(sql,conCenter);
				cmd1.CommandTimeout=600;
				daTmp1=new SqlDataAdapter(cmd1);
				daTmp1.Fill(dshashtmp,"hsEmpSign");
				Hashtable htCenterEmpSign=new Hashtable();
				foreach(DataRow dr in dshashtmp.Tables["hsEmpSign"].Rows)
				{
					htCenterEmpSign.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
				}
				#endregion
				hsMessage.Add(hsMessage.Count,"���ر������ݿ����ϳɹ���");
				hsMessage.Add(hsMessage.Count,"--------------------------------");
                
				conCenter.Close();
				conCenter.Open();
				using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�������ϸ��Ϣ...");

					UpdatedCount=0;
					#region ������ͬ������������ϸ
					SqlDataAdapter sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [vcGoodsID], [iAssID], [vcCardID], [nPrice], [iCount], [nTRate], [nFee], [vcComments], [cFlag], [dtConsDate], [vcOperName], [vcDeptID] from tbConsItemHis where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbConsItemOther ([iSerial], [vcGoodsID], [iAssID], [vcCardID], [nPrice], [iCount], [nTRate], [nFee], [vcComments], [cFlag], [dtConsDate], [vcOperName], [vcDeptID])"
						+ " values (@Serial,@GoodsID,@AssID,@CardID,@Price,@Count,@TRate,@Fee,@Comments,@Flag,@ConsDate,@OperName,@DeptID);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@GoodsID", SqlDbType.VarChar, 10, "vcGoodsID");
					sd.InsertCommand.Parameters.Add("@AssID", SqlDbType.BigInt, 8, "iAssID");
					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
					sd.InsertCommand.Parameters.Add("@Price", SqlDbType.Float, 10, "nPrice");
					sd.InsertCommand.Parameters.Add("@Count", SqlDbType.Int, 4, "iCount");
					sd.InsertCommand.Parameters.Add("@TRate", SqlDbType.Float, 10, "nTRate");
					sd.InsertCommand.Parameters.Add("@Fee", SqlDbType.Float, 10, "nFee");
					sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 50, "vcComments");
					sd.InsertCommand.Parameters.Add("@Flag", SqlDbType.Char, 1, "cFlag");
					sd.InsertCommand.Parameters.Add("@ConsDate", SqlDbType.DateTime, 8, "dtConsDate");
					sd.InsertCommand.Parameters.Add("@OperName", SqlDbType.VarChar, 10, "vcOperName");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					DataSet dsConsItemSync = new DataSet();
					sd.Fill(dsConsItemSync);
					for (i = 0; i < dstmp.Tables["LocaltbConsItem"].Rows.Count; i++)
					{
						if(!htCenterConsItem.ContainsKey(dstmp.Tables["LocaltbConsItem"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbConsItem"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbConsItem"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["vcGoodsID"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["iAssID"].ToString(),
											   dstmp.Tables["LocaltbConsItem"].Rows[i]["vcCardID"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["nPrice"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["iCount"].ToString(),
											   dstmp.Tables["LocaltbConsItem"].Rows[i]["nTRate"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["nFee"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["vcComments"].ToString(),
											   dstmp.Tables["LocaltbConsItem"].Rows[i]["cFlag"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["dtConsDate"].ToString(),dstmp.Tables["LocaltbConsItem"].Rows[i]["vcOperName"].ToString(),
											   dstmp.Tables["LocaltbConsItem"].Rows[i]["vcDeptID"].ToString()};
							dsConsItemSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsConsItemSync.Tables[0].Rows.Count>0&&dsConsItemSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsConsItemSync.Tables[0]);
							dsConsItemSync.Tables[0].Clear();
						}
					}
					sd.Update(dsConsItemSync.Tables[0]);
					dsConsItemSync.Tables[0].Clear();
					sd.Dispose();
					dsConsItemSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ�������ϸ��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�СƱ��Ϣ...");

					UpdatedCount=0;
					#region ������ͬ������СƱ
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [nTRate], [nFee], [nPay], [nBalance], [iIgValue], [vcConsType], [vcOperName], [dtConsDate], [vcDeptID] from tbBillHis where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbBillOther ([iSerial], [iAssID], [vcCardID], [nTRate], [nFee], [nPay], [nBalance], [iIgValue], [vcConsType], [vcOperName], [dtConsDate], [vcDeptID])"
						+ " values (@Serial,@AssID,@CardID,@TRate,@Fee,@Pay,@Balance,@IgValue,@ConsType,@OperName,@ConsDate,@DeptID);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@AssID", SqlDbType.BigInt, 8, "iAssID");
					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
					sd.InsertCommand.Parameters.Add("@TRate", SqlDbType.Float, 10, "nTRate");
					sd.InsertCommand.Parameters.Add("@Fee", SqlDbType.Float, 10, "nFee");
					sd.InsertCommand.Parameters.Add("@Pay", SqlDbType.Float, 10, "nPay");
					sd.InsertCommand.Parameters.Add("@Balance", SqlDbType.Float, 10, "nBalance");
					sd.InsertCommand.Parameters.Add("@IgValue", SqlDbType.Int, 4, "iIgValue");
					sd.InsertCommand.Parameters.Add("@ConsType", SqlDbType.VarChar, 10, "vcConsType");
					sd.InsertCommand.Parameters.Add("@OperName", SqlDbType.VarChar, 10, "vcOperName");
					sd.InsertCommand.Parameters.Add("@ConsDate", SqlDbType.DateTime, 8, "dtConsDate");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					DataSet dsBillSync = new DataSet();
					sd.Fill(dsBillSync);
					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					for (i = 0; i < dstmp.Tables["LocaltbBill"].Rows.Count; i++)
					{
						if(!htCenterBill.ContainsKey(dstmp.Tables["LocaltbBill"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbBill"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbBill"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["iAssID"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["vcCardID"].ToString(),
											   dstmp.Tables["LocaltbBill"].Rows[i]["nTRate"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["nFee"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["nPay"].ToString(),
											   dstmp.Tables["LocaltbBill"].Rows[i]["nBalance"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["iIgValue"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["vcConsType"].ToString(),
											   dstmp.Tables["LocaltbBill"].Rows[i]["vcOperName"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["dtConsDate"].ToString(),dstmp.Tables["LocaltbBill"].Rows[i]["vcDeptID"].ToString()};
							dsBillSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsBillSync.Tables[0].Rows.Count>0&&dsBillSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsBillSync.Tables[0]);
							dsBillSync.Tables[0].Clear();
						}
					}
					sd.Update(dsBillSync.Tables[0]);
					dsBillSync.Tables[0].Clear();
					sd.Dispose();
					dsBillSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ�СƱ��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�������־��Ϣ...");

					UpdatedCount=0;
					#region ������ͬ�����������־
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [vcIgType], [iIgLast], [iIgGet], [iIgArrival], [iLinkCons], [dtIgDate], [vcOperName], [vcComments], [vcDeptID] from tbIntegralLogHis where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbIntegralLogOther ([iSerial], [iAssID], [vcCardID], [vcIgType], [iIgLast], [iIgGet], [iIgArrival], [iLinkCons], [dtIgDate], [vcOperName], [vcComments], [vcDeptID])"
						+ " values (@Serial,@AssID,@CardID,@IgType,@IgLast,@IgGet,@IgArrival,@LinkCons,@IgDate,@OperName,@Comments,@DeptID);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@AssID", SqlDbType.BigInt, 8, "iAssID");
					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
					sd.InsertCommand.Parameters.Add("@IgType", SqlDbType.VarChar, 5, "vcIgType");
					sd.InsertCommand.Parameters.Add("@IgLast", SqlDbType.Int, 4, "iIgLast");
					sd.InsertCommand.Parameters.Add("@IgGet", SqlDbType.Int, 4, "iIgGet");
					sd.InsertCommand.Parameters.Add("@IgArrival", SqlDbType.Int, 4, "iIgArrival");
					sd.InsertCommand.Parameters.Add("@LinkCons", SqlDbType.BigInt, 8, "iLinkCons");
					sd.InsertCommand.Parameters.Add("@IgDate", SqlDbType.DateTime, 8, "dtIgDate");
					sd.InsertCommand.Parameters.Add("@OperName", SqlDbType.VarChar, 10, "vcOperName");
					sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 100, "vcComments");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					DataSet dsIntegralLogSync = new DataSet();
					sd.Fill(dsIntegralLogSync);
					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					for (i = 0; i < dstmp.Tables["LocaltbIntegralLog"].Rows.Count; i++)
					{
						if(!htCenterIntegralLog.ContainsKey(dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iAssID"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcCardID"].ToString(),
											   dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcIgType"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iIgLast"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iIgGet"].ToString(),
											   dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iIgArrival"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["iLinkCons"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["dtIgDate"].ToString(),
											   dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcOperName"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcComments"].ToString(),dstmp.Tables["LocaltbIntegralLog"].Rows[i]["vcDeptID"].ToString()};
							dsIntegralLogSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsIntegralLogSync.Tables[0].Rows.Count>0&&dsIntegralLogSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsIntegralLogSync.Tables[0]);
							dsIntegralLogSync.Tables[0].Clear();
						}
					}
					sd.Update(dsIntegralLogSync.Tables[0]);
					dsIntegralLogSync.Tables[0].Clear();
					sd.Dispose();
					dsIntegralLogSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ�������־��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ���ֵ��Ϣ...");

					UpdatedCount=0;
					#region ������ͬ�������ֵ
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [nFillFee], [nFillProm], [nFeeLast], [nFeeCur], [dtFillDate], [vcComments], [vcOperName], [vcDeptID] from tbFillFeeHis where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbFillFeeOther ([iSerial], [iAssID], [vcCardID], [nFillFee], [nFillProm], [nFeeLast], [nFeeCur], [dtFillDate], [vcComments], [vcOperName], [vcDeptID])"
						+ " values (@Serial,@AssID,@CardID,@FillFee,@FillProm,@FeeLast,@FeeCur,@FillDate,@Comments,@OperName,@DeptID);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@AssID", SqlDbType.BigInt, 8, "iAssID");
					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
					sd.InsertCommand.Parameters.Add("@FillFee", SqlDbType.Float, 10, "nFillFee");
					sd.InsertCommand.Parameters.Add("@FillProm", SqlDbType.Float, 10, "nFillProm");
					sd.InsertCommand.Parameters.Add("@FeeLast", SqlDbType.Float, 10, "nFeeLast");
					sd.InsertCommand.Parameters.Add("@FeeCur", SqlDbType.Float, 10, "nFeeCur");
					sd.InsertCommand.Parameters.Add("@FillDate", SqlDbType.DateTime, 8, "dtFillDate");
					sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 100, "vcComments");
					sd.InsertCommand.Parameters.Add("@OperName", SqlDbType.VarChar, 10, "vcOperName");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					DataSet dsFillFeeSync = new DataSet();
					sd.Fill(dsFillFeeSync);
					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					for (i = 0; i < dstmp.Tables["LocaltbFillFee"].Rows.Count; i++)
					{
						if(!htCenterFillFee.ContainsKey(dstmp.Tables["LocaltbFillFee"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbFillFee"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbFillFee"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["iAssID"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["vcCardID"].ToString(),
											   dstmp.Tables["LocaltbFillFee"].Rows[i]["nFillFee"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["nFillProm"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["nFeeLast"].ToString(),
											   dstmp.Tables["LocaltbFillFee"].Rows[i]["nFeeCur"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["dtFillDate"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["vcComments"].ToString(),
											   dstmp.Tables["LocaltbFillFee"].Rows[i]["vcOperName"].ToString(),dstmp.Tables["LocaltbFillFee"].Rows[i]["vcDeptID"].ToString()};
							dsFillFeeSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsFillFeeSync.Tables[0].Rows.Count>0&&dsFillFeeSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsFillFeeSync.Tables[0]);
							dsFillFeeSync.Tables[0].Clear();
						}
					}
					sd.Update(dsFillFeeSync.Tables[0]);
					dsFillFeeSync.Tables[0].Clear();
					sd.Dispose();
					dsFillFeeSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ���ֵ��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�Ӫҵ��־��Ϣ...");

					UpdatedCount=0;
					#region ������ͬ������Ӫҵ��־
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [vcOperType], [vcOperName], [dtOperDate], [vcComments], [vcDeptID] from tbBusiLogHis where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbBusiLogOther ([iSerial], [iAssID], [vcCardID], [vcOperType], [vcOperName], [dtOperDate], [vcComments], [vcDeptID])"
						+ " values (@Serial,@AssID,@CardID,@OperType,@OperName,@OperDate,@Comments,@DeptID);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@AssID", SqlDbType.BigInt, 8, "iAssID");
					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 10, "vcCardID");
					sd.InsertCommand.Parameters.Add("@OperType", SqlDbType.VarChar, 5, "vcOperType");
					sd.InsertCommand.Parameters.Add("@OperName", SqlDbType.VarChar, 10, "vcOperName");
					sd.InsertCommand.Parameters.Add("@OperDate", SqlDbType.DateTime, 8, "dtOperDate");
					sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 100, "vcComments");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					DataSet dsBusiLogSync = new DataSet();
					sd.Fill(dsBusiLogSync);
					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					for (i = 0; i < dstmp.Tables["LocaltbBusiLog"].Rows.Count; i++)
					{
						if(!htCenterBusiLog.ContainsKey(dstmp.Tables["LocaltbBusiLog"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbBusiLog"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbBusiLog"].Rows[i]["iAssID"].ToString(),dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcCardID"].ToString(),
											   dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcOperType"].ToString(),dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcOperName"].ToString(),dstmp.Tables["LocaltbBusiLog"].Rows[i]["dtOperDate"].ToString(),
											   dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcComments"].ToString(),dstmp.Tables["LocaltbBusiLog"].Rows[i]["vcDeptID"].ToString()};
							dsBusiLogSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsBusiLogSync.Tables[0].Rows.Count>0&&dsBusiLogSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsBusiLogSync.Tables[0]);
							dsBusiLogSync.Tables[0].Clear();
						}
					}
					sd.Update(dsBusiLogSync.Tables[0]);
					dsBusiLogSync.Tables[0].Clear();
					sd.Dispose();
					dsBusiLogSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ�Ӫҵ��־��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�������Ϣ...");

					UpdatedCount=0;
					#region ������ͬ�����꿼��_��ע��
//					sd = new SqlDataAdapter();
//					sd.SelectCommand = new SqlCommand("select [iSerial], [vcCardID], [vcEmpName], [dtSignDate], [vcClass], [vcSignFlag], [vcComments], [vcDeptID] from tbEmpSign where 1=2",conCenter,tranCenter);
//					sd.InsertCommand = new SqlCommand("insert into tbEmpSign ([iSerial], [vcCardID], [vcEmpName], [dtSignDate], [vcClass], [vcSignFlag], [vcComments], [vcDeptID])"
//						+ " values (@Serial,@CardID,@EmpName,@SignDate,@Class,@SignFlag,@Comments,@DeptID);",conCenter,tranCenter);
//					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
//					sd.InsertCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 5, "vcCardID");
//					sd.InsertCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 30, "vcEmpName");
//					sd.InsertCommand.Parameters.Add("@SignDate", SqlDbType.DateTime, 8, "dtSignDate");
//					sd.InsertCommand.Parameters.Add("@Class", SqlDbType.VarChar, 5, "vcClass");
//					sd.InsertCommand.Parameters.Add("@SignFlag", SqlDbType.VarChar, 5, "vcSignFlag");
//					sd.InsertCommand.Parameters.Add("@Comments", SqlDbType.VarChar, 150, "vcComments");
//					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
//					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
//										sd.UpdateBatchSize = 0;
//
//					DataSet dsEmpSignSync = new DataSet();
//					sd.Fill(dsEmpSignSync);
//					for (i = 0; i < dstmp.Tables["LocaltbEmpSign"].Rows.Count; i++)
//					{
//						if(!htCenterEmpSign.ContainsKey(dstmp.Tables["LocaltbEmpSign"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcDeptID"].ToString()))
//						{
//							object[] row = {dstmp.Tables["LocaltbEmpSign"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcCardID"].ToString(),dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcEmpName"].ToString(),
//											   dstmp.Tables["LocaltbEmpSign"].Rows[i]["dtSignDate"].ToString(),dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcClass"].ToString(),dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcSignFlag"].ToString(),
//											   dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcComments"].ToString(),dstmp.Tables["LocaltbEmpSign"].Rows[i]["vcDeptID"].ToString()};
//							dsEmpSignSync.Tables[0].Rows.Add(row);
//							UpdatedCount++;
//						}
//						if (dsEmpSignSync.Tables[0].Rows.Count>0&&dsEmpSignSync.Tables[0].Rows.Count % 300 == 0)
//						{
//							sd.Update(dsEmpSignSync.Tables[0]);
//							dsEmpSignSync.Tables[0].Clear();
//						}
//					}
//					sd.Update(dsEmpSignSync.Tables[0]);
//					dsEmpSignSync.Tables[0].Clear();
//					sd.Dispose();
//					dsEmpSignSync.Dispose();
					#endregion
//					hsMessage.Add(hsMessage.Count,"�����������ݣ�������Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//					hsMessage.Add(hsMessage.Count,"--------------------------------");
//					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�Ա��������Ϣ...");
				
					UpdatedCount=0;
					#region ������ͬ������ϵͳ������־
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select iSerial,vcDeptID,dtErrDate,vcErrorDes from tbSysErrorLog where 1=2",conCenter,tranCenter);
					sd.InsertCommand = new SqlCommand("insert into tbSysErrorLog (iSerial,vcDeptID,dtErrDate,vcErrorDes)"
						+ " values (@Serial,@DeptID,@ErrDate,@ErrorDes);",conCenter,tranCenter);
					sd.InsertCommand.Parameters.Add("@Serial", SqlDbType.BigInt, 8, "iSerial");
					sd.InsertCommand.Parameters.Add("@DeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.InsertCommand.Parameters.Add("@ErrDate", SqlDbType.DateTime, 8, "dtErrDate");
					sd.InsertCommand.Parameters.Add("@ErrorDes", SqlDbType.VarChar, 3000, "vcErrorDes");
					sd.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
					//					sd.UpdateBatchSize = 0;

					DataSet dsSysErrorLogSync = new DataSet();
					sd.Fill(dsSysErrorLogSync);
					sd.SelectCommand.CommandTimeout=600;
					sd.InsertCommand.CommandTimeout=600;
					for (i = 0; i < dstmp.Tables["LocaltbSysErrorLog"].Rows.Count; i++)
					{
						if(!htCenterSysErrorLog.ContainsKey(dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["iSerial"].ToString()+dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["vcDeptID"].ToString()))
						{
							object[] row = {dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["iSerial"].ToString(),dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["vcDeptID"].ToString(),dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["dtErrDate"].ToString(),dstmp.Tables["LocaltbSysErrorLog"].Rows[i]["vcErrorDes"].ToString()};
							dsSysErrorLogSync.Tables[0].Rows.Add(row);
							UpdatedCount++;
						}
						if (dsSysErrorLogSync.Tables[0].Rows.Count>0&&dsSysErrorLogSync.Tables[0].Rows.Count % 300 == 0)
						{
							sd.Update(dsSysErrorLogSync.Tables[0]);
							dsSysErrorLogSync.Tables[0].Clear();
						}
					}
					sd.Update(dsSysErrorLogSync.Tables[0]);
					dsSysErrorLogSync.Tables[0].Clear();
					sd.Dispose();
					dsSysErrorLogSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"�����������ݣ�ϵͳ������־��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");

					tranCenter.Commit();

					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼת�Ʊ�����������ʷ��...");
					#region ת�Ʊ�����������ʷ����ע��
//					conLocal.Open();
//					sql="insert into tbConsItemHis select * from tbConsItem where dtConsDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;					
//					cmd.ExecuteNonQuery();
//
//					sql="insert into tbBillHis select * from tbBill where dtConsDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="insert into tbIntegralLogHis select * from tbIntegralLog where dtIgDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="insert into tbFillFeeHis select * from tbFillFee where dtFillDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="insert into tbBusiLogHis select * from tbBusiLog where dtOperDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbConsItem where dtConsDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbBill where dtConsDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbIntegralLog where dtIgDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbFillFee where dtFillDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbBusiLog where dtOperDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//
//					sql="delete from tbSysErrorLog where dtErrDate<'"+strTransferDate+"'";
//					cmd=new SqlCommand(sql,conLocal);
//					cmd.CommandTimeout=600;
//					cmd.ExecuteNonQuery();
//					conLocal.Close();
					#endregion

					#region �������ĳ�ֵ���������ѳ���
					if(strConsRemoveSerial!="")
					{
						sql="update tbConsItemOther set cFlag='9' where cFlag<>'9' and vcDeptID='"+SysInitial.LocalDept+"' and iSerial in("+strConsRemoveSerial+")";;
						cmd=new SqlCommand(sql,conCenter,tranCenter);
						cmd.CommandTimeout=600;
						cmd.ExecuteNonQuery();
					}

					if(strFillRemoveSerial!="")
					{
						sql="update tbFillFeeOther set vcComments='��ֵ����' where vcComments<>'��ֵ����' and vcDeptID='"+SysInitial.LocalDept+"' and iSerial in("+strFillRemoveSerial+")";
						cmd=new SqlCommand(sql,conCenter,tranCenter);
						cmd.CommandTimeout=600;
						cmd.ExecuteNonQuery();
					}
					#endregion
//					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ת�Ʊ�����������ʷ��ɹ���");
//					hsMessage.Add(hsMessage.Count,"--------------------------------");

					hsMessage.Add(hsMessage.Count,"");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ������ͬ�������ݸ��³ɹ���");
					hsMessage.Add(hsMessage.Count,"");
				}
			}
			catch(Exception ex)
			{
				if(conCenter.State==ConnectionState.Open)
				{
					conCenter.Close();
				}
				if(conLocal.State==ConnectionState.Open)
				{
					conLocal.Close();
				}
				clog.WriteLine(ex);
				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
				hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ���¹����з���������󣬸���δ��ȫ��");
				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
				MessageBox.Show("���¹����з���������󣬸���δ��ȫ��������ѡ���ֹ����»���������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.sbtnClose.Enabled=true;
				this.pictureBox1.Visible=false;
				this.sbtnUpdate.Enabled=true;
				return;
			}
			conLocal.Close();
			conCenter.Close();
			#endregion

			#region �����򱾱���ͬ����������Ϣ����ע��
//			hsMessage.Add(hsMessage.Count,"--------------------------------");
//			hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݿ�����...");
//			#region ��ȡ������Ҫ���ص����ϣ�������Ϣ
//			//��Ʒ
//			sql="select * from tbGoods order by vcGoodsID";
//			cmd=new SqlCommand(sql,conCenter);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"CentertbGoods");
//			//ϵͳ����
//			sql="select * from tbCommCode where vcCommSign<>'LOCAL' and vcCommCode<>'CEN00' order by vcCommSign,vcCommCode";
//			cmd=new SqlCommand(sql,conCenter);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"CentertbCommCode");
//			//���Ŀͻ��˲���Ա
//			sql="select * from tbOper where vcDeptID='"+SysInitial.LocalDept+"' or vcDeptID='*' order by vcOperID";
//			cmd=new SqlCommand(sql,conCenter);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"CentertbOper");
//			//���ؿͻ��˲���Ա
//			sql="select * from tbOper order by vcOperID";
//			cmd=new SqlCommand(sql,conLocal);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"LocaltbOper");
//			//�ͻ��˲���ԱȨ��
//			sql="select * from tbFunc where cnvcFuncType='CS'";
//			cmd=new SqlCommand(sql,conCenter);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"CentertbFunc");
//			//�ͻ��˲���ԱȨ��
//			sql="select * from tbOperFunc where vcFuncAddress in(select cnvcFuncAddress from tbFunc where cnvcFuncType='CS')";
//			cmd=new SqlCommand(sql,conCenter);
//			cmd.CommandTimeout=600;
//			daTmp=new SqlDataAdapter(cmd);
//			daTmp.Fill(dstmp,"CentertbOperFunc");
//			//֪ͨ
//			//			sql="select * from tbNotice where vcActiveFlag='2' and dtCreateDate>='"+strBeginDate+"' order by id";
//			//			cmd=new SqlCommand(sql,conCenter);
//			//			daTmp=new SqlDataAdapter(cmd);
//			//			daTmp.Fill(dstmp,"CentertbNotice");
//			#endregion
//			hsMessage.Add(hsMessage.Count,"�����������ݿ����ϳɹ���");
//			hsMessage.Add(hsMessage.Count,"--------------------------------");
//			conLocal.Open();
//			conCenter.Open();
//			try
//			{
//				using(SqlTransaction tranLocal=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
//				{
//					using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
//					{
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ���Ʒ��Ϣ...");
//						UpdatedCount=0;
//						#region �򱾵�ͬ��������Ʒ��Ϣ
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["CentertbGoods"].Rows.Count;i++)
//						{
//							sqlDeal+="insert into tbGoods values('"+dstmp.Tables["CentertbGoods"].Rows[i]["vcGoodsID"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcGoodsName"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcSpell"].ToString()+"',"+dstmp.Tables["CentertbGoods"].Rows[i]["nPrice"].ToString()+",";
//							sqlDeal+=dstmp.Tables["CentertbGoods"].Rows[i]["nRate"].ToString()+","+dstmp.Tables["CentertbGoods"].Rows[i]["iIgValue"].ToString()+",'"+dstmp.Tables["CentertbGoods"].Rows[i]["cNewFlag"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcComments"].ToString()+"');";
//							UpdatedCount++;
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand("truncate table tbGoods",conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//
//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//						#endregion
//						hsMessage.Add(hsMessage.Count,"���±������ݣ���Ʒ��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�ϵͳ������Ϣ...");
//						UpdatedCount=0;
//						#region �򱾵�ͬ������ϵͳ����
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["CentertbCommCode"].Rows.Count;i++)
//						{
//							if(dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommSign"].ToString()!="LOCAL")
//							{
//								sqlDeal+="insert into tbCommCode values('"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommName"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommCode"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommSign"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcComments"].ToString()+"');";
//								UpdatedCount++;
//							}
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand("delete from tbCommCode where vcCommSign<>'LOCAL'",conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//
//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//						#endregion
//						hsMessage.Add(hsMessage.Count,"���±������ݣ�ϵͳ������Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ��ͻ��˲���ԱȨ����Ϣ...");
//						UpdatedCount=0;
//						#region �򱾵�ͬ���ͻ��˲���ԱȨ��
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["CentertbFunc"].Rows.Count;i++)
//						{
//							sqlDeal+="insert into tbFunc values('"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncParentName"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncType"].ToString()+"');";
//							UpdatedCount++;
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand("truncate table tbFunc",conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//
//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["CentertbOperFunc"].Rows.Count;i++)
//						{
//							sqlDeal+="insert into tbOperFunc values('"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcOperID"].ToString()+"','"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcFuncName"].ToString()+"','"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcFuncAddress"].ToString()+"');";
//							UpdatedCount++;
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand("truncate table tbOperFunc",conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//
//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//						#endregion
//						hsMessage.Add(hsMessage.Count,"���±������ݣ��ͻ��˲���ԱȨ����Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ��ͻ��˲���Ա��Ϣ...");
//						UpdatedCount=0;
//						#region ͬ���ͻ��˲���Ա
//						//����������ͬ�������ģ��жϸò���Ա������û�б���ʼ�������ұ��ص����������Ĳ�һ��
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["LocaltbOper"].Rows.Count;i++)
//						{
//							for(int j=0;j<dstmp.Tables["CentertbOper"].Rows.Count;j++)
//							{
//								if(dstmp.Tables["CentertbOper"].Rows[j]["vcPwdBeginFlag"].ToString()=="0"&&dstmp.Tables["CentertbOper"].Rows[j]["vcOperID"].ToString()==dstmp.Tables["LocaltbOper"].Rows[i]["vcOperID"].ToString()&&dstmp.Tables["CentertbOper"].Rows[j]["vcPwd"].ToString()!=dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString())
//								{
//									sqlDeal+="update tbOper set vcPwd='"+dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString()+"' where vcOperID='"+dstmp.Tables["CentertbOper"].Rows[j]["vcOperID"].ToString()+"' and vcDeptID='"+SysInitial.LocalDept+"';";
//									dstmp.Tables["CentertbOper"].Rows[j]["vcPwd"]=dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString();
//								}
//							}
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand(sqlDeal,conCenter,tranCenter);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//
//						//ͨ�����沽�裬���������Ѿ����µ����ģ��������ļ���Ĳ���Աȫ��ͬ��������
//						sqlDeal="";
//						for(i=0;i<dstmp.Tables["CentertbOper"].Rows.Count;i++)
//						{
//							if(dstmp.Tables["CentertbOper"].Rows[i]["vcActiveFlag"].ToString()=="1")
//							{
//								sqlDeal+="insert into tbOper values('"+dstmp.Tables["CentertbOper"].Rows[i]["vcOperID"].ToString()+"','"+dstmp.Tables["CentertbOper"].Rows[i]["vcOperName"].ToString()+"','"+dstmp.Tables["CentertbOper"].Rows[i]["vcLimit"].ToString()+"','"+dstmp.Tables["CentertbOper"].Rows[i]["vcPwd"].ToString()+"','"+SysInitial.LocalDept+"');";
//							}
//							UpdatedCount++;
//						}
//						if(sqlDeal!="")
//						{
//							cmd=new SqlCommand("truncate table tbOper",conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//	
//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//
//							cmd=new SqlCommand("update tbOper set vcPwdBeginFlag='0' where vcPwdBeginFlag='1' and vcDeptID='"+SysInitial.LocalDept+"'",conCenter,tranCenter);
//							cmd.CommandTimeout=600;
//							cmd.ExecuteNonQuery();
//						}
//						#endregion
//						hsMessage.Add(hsMessage.Count,"���±������ݣ��ͻ��˲���Ա��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ��ʼ�����������ݣ�֪ͨ��Ϣ...");
//						//						UpdatedCount=0;
//						#region �򱾵�ͬ������֪ͨ
//						//						sqlDeal="";
//						//						for(i=0;i<dstmp.Tables["CentertbNotice"].Rows.Count;i++)
//						//						{
//						//							if(dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()=="all"||dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()==SysInitial.LocalDept)
//						//							{
//						//								recCount=0;
//						//								sql="select count(*) from tbNotice where id="+dstmp.Tables["CentertbNotice"].Rows[i]["id"].ToString();
//						//								cmd=new SqlCommand(sql,conLocal,tranLocal);
//						//								drr=cmd.ExecuteReader();
//						//								drr.Read();
//						//								recCount=int.Parse(drr[0].ToString());
//						//								drr.Close();
//						//
//						//								if(recCount==0)
//						//								{
//						//									sqlDeal+="insert into tbNotice values("+dstmp.Tables["CentertbNotice"].Rows[i]["id"].ToString()+",'"+dstmp.Tables["CentertbNotice"].Rows[i]["vcComments"].ToString()+"','"+dstmp.Tables["CentertbNotice"].Rows[i]["dtCreateDate"].ToString()+"','0','"+dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()+"');";
//						//									UpdatedCount++;
//						//								}
//						//							}
//						//						}
//						//						if(sqlDeal!="")
//						//						{
//						//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
//						//							cmd.ExecuteNonQuery();
//						//						}
//						#endregion
//						//						hsMessage.Add(hsMessage.Count,"���±������ݣ�֪ͨ��Ϣ���³ɹ���������"+UpdatedCount.ToString()+"����¼.");
//						//						hsMessage.Add(hsMessage.Count,"--------------------------------");
//						hsMessage.Add(hsMessage.Count,"");
//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  �����Ļ�ȡ�����ݸ��³ɹ���");
//
//						tranCenter.Commit();
//						tranLocal.Commit();
//					}
//				}
//			}
//			catch(Exception ex)
//			{
//				if(conCenter.State==ConnectionState.Open)
//				{
//					conCenter.Close();
//				}
//				if(conLocal.State==ConnectionState.Open)
//				{
//					conLocal.Close();
//				}
//				clog.WriteLine(ex);
//				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
//				hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  ���¹����з���������󣬸���δ��ȫ��");
//				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
//				MessageBox.Show("���¹����з���������󣬸���δ��ȫ��������ѡ���ֹ����»���������ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				this.sbtnClose.Enabled=true;
//				return;
//			}
//			conLocal.Close();
//			conCenter.Close();
			#endregion

			hsMessage.Add(hsMessage.Count,"");
			hsMessage.Add(hsMessage.Count,"���������ϴ��ɹ���");

			Exception err=null;
			SysInitial.CreatDS(out err);
			if(err!=null)
			{
				MessageBox.Show("ϵͳ�������Զ��رգ��Ժ������µ�¼ϵͳ��","ϵͳ��ʾ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				Application.Exit();
			}

			threadFin=true;
		}
		private void sbtnUpdate_Click(object sender, System.EventArgs e)
		{
            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("ͯЬ��vpn�����˻�������̫����,����vpn���ӣ�");
                return;
            }
            this.pictureBox1.Visible = true;
            this.sbtnUpdate.Enabled = false;
			threadFin=false;
			threadDown=new Thread(new ThreadStart(UpdateData));
			threadDown.IsBackground = true;
			threadDown.Start();
			this.sbtnClose.Enabled=false;
			this.timer1.Start();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(threadDown!=null&&threadDown.IsAlive)
			{
				if(DialogResult.Yes != MessageBox.Show(this,"����ͬ�����ڸ��£��Ƿ�رգ�","�ر�ȷ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
				{					
					return;			
				}
				threadDown.Abort();
				threadDown = null;		
			}
			this.Close();
		}

		private void frmDataManuUpdate_His_Load(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=false;
			this.dateTimePicker1.Value=DateTime.Today.AddDays(-3);
			this.timer1.Interval=3000;
			this.timer1.Enabled=true;
		}

		private void frmDataManuUpdate_His_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(threadDown!=null&&threadDown.IsAlive)
			{
				if(DialogResult.Yes == MessageBox.Show(this,"����ͬ�����ڸ��£��Ƿ�رգ�","�ر�ȷ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
				{
					threadDown.Abort();
					threadDown = null;
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
				}				
				
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(threadFin)
			{
				threadFin=false;
				this.sbtnClose.Enabled=true;
				this.sbtnUpdate.Enabled=true;
				this.pictureBox1.Visible=false;
				this.timer1.Stop();
			}

			if(hsMessage!=null&&hsMessage.Count>0)
			{
				for(int i=mesindex;i<hsMessage.Count;i++)
				{
					this.listBox1.Items.Add(hsMessage[i].ToString());
					this.listBox1.SelectedIndex=this.listBox1.Items.Count-1;
					this.Refresh();
					mesindex++;
				}
			}
		}
	}
}
