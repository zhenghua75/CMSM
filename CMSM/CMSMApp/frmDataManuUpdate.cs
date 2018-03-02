using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using CMSMData.CMSMDataAccess;
using System.Threading;
using System.Text;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	
	/// <summary>
	/// frmDataManuUpdate 的摘要说明。
	/// </summary>
	public class frmDataManuUpdate : frmBase
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

		public frmDataManuUpdate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			clog=new CMSM.log.CMSMLog(Application.StartupPath+"\\log\\");

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataManuUpdate));
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
            this.label1.Text = "开始时间";
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
            this.sbtnUpdate.Text = "开始同步";
            this.sbtnUpdate.UseVisualStyleBackColor = true;
            this.sbtnUpdate.Click += new System.EventHandler(this.sbtnUpdate_Click);
            // 
            // sbtnClose
            // 
            this.sbtnClose.Location = new System.Drawing.Point(378, 384);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(75, 23);
            this.sbtnClose.TabIndex = 38;
            this.sbtnClose.Text = "关闭";
            this.sbtnClose.UseVisualStyleBackColor = true;
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // frmDataManuUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(632, 428);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.sbtnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDataManuUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动数据同步";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDataManuUpdate_Closing);
            this.Load += new System.EventHandler(this.frmDataManuUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private int Sync(AnchorType at,SqlConnection conLocal,SqlConnection conCenter,SqlTransaction tranCenter)
		{
			//同步
			if(conLocal.State!= ConnectionState.Open)
			{
				conLocal.Open();
			}
			string strsql1 = "select cast(Anchor as int) from SyncAnchor where Id={0}";
			string strsql2 = "";
			string strsql3 = "";
			string strsql4="";
			string strsql5 = "";
			string strsql6="";//更新
			switch(at)
			{
				case AnchorType.ProductionInStorage:
					strsql2 = "select vcDeptId,InDate,vcGoodsId,Quantity,vcOperId,CreateDate,OperType from ProductionInStorage where VerCol>{0} order by Id";
					strsql3 = "insert into ProductionInStorage (vcDeptId,InDate,vcGoodsId,Quantity,vcOperId,CreateDate)values('{0}','{1}','{2}',{3},'{4}','{5}');";
					strsql4 = "select max(VerCol) from ProductionInStorage";
					strsql5 = "delete from ProductionInStorage where Quantity=0";
					strsql6 = "update ProductionInStorage set Quantity={3} where vcDeptId='{0}' and InDate='{1}' and vcGoodsId='{2}';";
					break;
				case AnchorType.SaleCheck:
					strsql2 = "select vcDeptId,CheckDate,vcGoodsId,Quantity,vcOperId,CreateDate,OperType from SaleCheck where VerCol>{0} order by Id";
					strsql3 = "insert into SaleCheck (vcDeptId,CheckDate,vcGoodsId,Quantity,vcOperId,CreateDate)values('{0}','{1}','{2}',{3},'{4}','{5}');";
					strsql4 = "select max(VerCol) from SaleCheck";
					strsql5 = "delete from SaleCheck where Quantity=0";
					strsql6 = "update SaleCheck set Quantity={3} where vcDeptId='{0}' and CheckDate='{1}' and vcGoodsId='{2}';";
					break;
			}
			SqlCommand cmd=new SqlCommand(string.Format(strsql1,(int)at),conLocal);
			object obj = cmd.ExecuteScalar();
			int anchor = 0;			
			bool IsAnchor=false;
			if(obj!=null)
			{
				anchor = Convert.ToInt32(obj);
				IsAnchor = true;
			}
			cmd=new SqlCommand(string.Format(strsql2,anchor),conLocal);
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			int ret = 0;
			if(dt!=null && dt.Rows.Count>0)
			{
				
				string strsql7 = "";
				foreach(DataRow dr in dt.Rows)
				{
					ret++;
					//int operType = Convert.ToInt32(dr["OperType"]);
					switch(at)
					{
						case AnchorType.ProductionInStorage:
							//switch(operType)
							//{
								//case (int)TableOperType.Insert:
							strsql7+=string.Format("if not exists(select 1 from ProductionInStorage where vcDeptId='{0}' and InDate='{1}' and vcGoodsId='{2}')",dr["vcDeptId"].ToString(),
										dr["InDate"].ToString(),
										dr["vcGoodsId"].ToString());
									strsql7+=string.Format(strsql3,
										dr["vcDeptId"].ToString(),
										dr["InDate"].ToString(),
										dr["vcGoodsId"].ToString(),
										dr["Quantity"].ToString(),
										dr["vcOperId"].ToString(),
										dr["CreateDate"].ToString());
									//break;
								//case (int)TableOperType.Update:
							strsql7+=" else ";
									strsql7+=string.Format(strsql6,
										dr["vcDeptId"].ToString(),
										dr["InDate"].ToString(),
										dr["vcGoodsId"].ToString(),
										dr["Quantity"].ToString());
									//break;
							//}							
							break;
						case AnchorType.SaleCheck:
//							switch(operType)
//							{
//								case (int)TableOperType.Insert:
							strsql7+=string.Format("if not exists(select 1 from SaleCheck where vcDeptId='{0}' and CheckDate='{1}' and vcGoodsId='{2}')",dr["vcDeptId"].ToString(),
										dr["CheckDate"].ToString(),
										dr["vcGoodsId"].ToString());
									strsql7+=string.Format(strsql3,
										dr["vcDeptId"].ToString(),
										dr["CheckDate"].ToString(),
										dr["vcGoodsId"].ToString(),
										dr["Quantity"].ToString(),
										dr["vcOperId"].ToString(),
										dr["CreateDate"].ToString());
//									break;
//								case (int)TableOperType.Update:
							strsql7+=" else ";
									strsql7+=string.Format(strsql6,
										dr["vcDeptId"].ToString(),
										dr["CheckDate"].ToString(),
										dr["vcGoodsId"].ToString(),
										dr["Quantity"].ToString());
//									break;
//							}			
							
							break;
					}					
				}
				if(strsql7.Length>0)
				{
					cmd=new SqlCommand(strsql7,conCenter,tranCenter);
					cmd.ExecuteNonQuery();
					//更新锚点
					cmd=new SqlCommand(strsql4,conLocal);
					object obj1 = cmd.ExecuteScalar();
					ulong anchor1 = 0;
					if(obj1!=null)
					{
						byte[] bAnchor1 = (byte[])obj1;
						string strsql8 = "insert into SyncAnchor(Id,Anchor)values({0},@Anchor)";
						if(IsAnchor)
						{
							strsql8 = "update SyncAnchor set Anchor=@Anchor where Id={0}";
						}
						cmd=new SqlCommand(string.Format(strsql8,(int)at,anchor1),conLocal);
						cmd.Parameters.Add("@Anchor", SqlDbType.Binary);
						cmd.Parameters["@Anchor"].Value = bAnchor1;
						cmd.ExecuteNonQuery();
					}					
				}
			}
			//删除0数据
			cmd=new SqlCommand(strsql5,conCenter,tranCenter);
			cmd.ExecuteNonQuery();

			cmd=new SqlCommand(strsql5,conLocal);
			cmd.ExecuteNonQuery();

			if(conLocal.State== ConnectionState.Open)
			{
				conLocal.Close();
			}
			return ret;
		}
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
				hsMessage.Add(hsMessage.Count,"连接AS数据库失败，请检查网络！");
				this.sbtnClose.Enabled=true;
				this.Refresh();
				return;
			}

			SqlDataAdapter daTmp;
			SqlCommand cmd;
			SqlDataAdapter daTmp1;
			SqlCommand cmd1;
			string sql="";
			string sqlDeal="";
			int i=0;
			int UpdatedCount=0;

			DataSet dstmp=new DataSet();
			string strBeginDate=this.dateTimePicker1.Value.ToShortDateString();
			string strTransferDate="";
			if(this.dateTimePicker1.Value.CompareTo(DateTime.Today.AddDays(-3))<0)
			{
				strTransferDate=this.dateTimePicker1.Value.AddDays(-2).ToShortDateString();
			}
			else
			{
				strTransferDate=DateTime.Today.AddDays(-5).ToShortDateString();
			}
			#region 会员信息同步，已注释
//			using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
//			{
//				using(SqlTransaction tranLocal=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
//				{
//					try
//					{
//						this.listBox1.Items.Add("--------------------------------");
//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  开始同步会员资料至中心...");
//						this.Refresh();
//						#region 加载会员资料
//						//本地会员资料
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
//						//中心会员资料
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
//						#region 本地向中心同步会员资料--插入
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
//						this.listBox1.Items.Add("更新中心数据：会员资料新增。共新增"+UpdatedCount.ToString()+"条记录.");
//						UpdatedCount=0;
//						#region 本地向中心同步会员资料--更新
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
//						this.listBox1.Items.Add("更新中心数据：会员资料修改。共修改"+UpdatedCount.ToString()+"条记录.");
//						this.listBox1.Items.Add("--------------------------------");
//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  开始同步会员资料至本地...");
//						this.Refresh();
//						UpdatedCount=0;
//						#region 中心向本地同步会员资料--插入
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
//						this.listBox1.Items.Add("更新本地数据：会员资料新增。共新增"+UpdatedCount.ToString()+"条记录.");
//						UpdatedCount=0;
//						#region 本地向中心同步会员资料--更新
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
//						this.listBox1.Items.Add("更新本地数据：会员资料修改。共修改"+UpdatedCount.ToString()+"条记录.");
//
//						tranLocal.Commit();
//						tranCenter.Commit();
//
//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"同步会员资料成功!");
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
//						this.listBox1.Items.Add(DateTime.Now.ToLongTimeString()+"  更新过程中发生意外错误，更新未完全！");
//						this.listBox1.Items.Add("----------------------------------------------------------------------");
//						MessageBox.Show("更新过程中发生意外错误，更新未完全，请重新选择手工更新或重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						this.sbtnClose.Enabled=true;
//						this.pictureBox1.Visible=false;
//						this.sbtnUpdate.Enabled=true;
//						return;
//					}
//				}
//			}
			#endregion
			conLocal.Close();
			conCenter.Close();

			#region 向中心同步消费等信息
			hsMessage.Add(hsMessage.Count,"");
			hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始加载本地数据库资料...");
			hsMessage.Add(hsMessage.Count,"--------------------------------");
			dstmp=new DataSet();
			DataSet dshashtmp=new DataSet();

			try
			{
				#region 获取本地需要上传的资料，只取近3天的数据	，同时取中心各表主键至hashtable	
				//消费明细
				sql="select * from tbConsItem where dtConsDate>='" + strBeginDate + "'";
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

				//小票
				sql="select * from tbBill where dtConsDate>='" + strBeginDate + "'";
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

				//积分日志
				sql="select * from tbIntegralLog where dtIgDate>='" + strBeginDate + "'";
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

				//充值
				sql="select * from tbFillFee where dtFillDate>='" + strBeginDate + "'";
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

				//营业日志
				sql="select * from tbBusiLog where dtOperDate>='" + strBeginDate + "'";
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

				//系统错误日志
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

//				//考勤
//				sql="select * from tbEmpSign where dtSignDate>='" + strBeginDate + "'";
//				cmd=new SqlCommand(sql,conLocal);
//				daTmp=new SqlDataAdapter(cmd);
//				daTmp.Fill(dstmp,"LocaltbEmpSign");
//
//				sql="select distinct iSerial,vcDeptID from tbEmpSign where vcDeptID='"+SysInitial.LocalDept+"' and dtSignDate>='" + strBeginDate + "'";
//				cmd1=new SqlCommand(sql,conCenter);
//				cmd1.CommandTimeout=300;
//				daTmp1=new SqlDataAdapter(cmd1);
//				daTmp1.Fill(dshashtmp,"hsEmpSign");
//				Hashtable htCenterEmpSign=new Hashtable();
//				foreach(DataRow dr in dshashtmp.Tables["hsEmpSign"].Rows)
//				{
//					htCenterEmpSign.Add(dr["iSerial"].ToString()+dr["vcDeptID"].ToString(),"1");
//				}
//
//				//员工资料
//				sql="select * from tbEmployee where dtOperDate>='" + strBeginDate + "'";
//				cmd=new SqlCommand(sql,conLocal);
//				daTmp=new SqlDataAdapter(cmd);
//				daTmp.Fill(dstmp,"LocaltbEmployee");
				#endregion
				hsMessage.Add(hsMessage.Count,"加载AC据库资料成功！");
				hsMessage.Add(hsMessage.Count,"--------------------------------");

				conCenter.Open();
				using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：消费明细信息...");

					UpdatedCount=0;
					#region 向中心同步本店消费明细 添加修改同步zhh20140315
					SqlDataAdapter sd = new SqlDataAdapter();
					//查询中心4个小时内的数据
					sd.SelectCommand = new SqlCommand("select [iSerial], [vcGoodsID], [iAssID], [vcCardID], [nPrice], [iCount], [nTRate], [nFee], [vcComments], [cFlag], [dtConsDate], [vcOperName], [vcDeptID] from tbConsItemOther where vcDeptID='"+SysInitial.LocalDept+"' and convert(char(10),dtConsDate,121)=convert(char(10),getdate(),121) ",conCenter,tranCenter);
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

					sd.UpdateCommand = new SqlCommand("update tbConsItemOther set cFlag=@cFlag where iSerial=@iSerial and vcDeptID=@vcDeptID",conCenter,tranCenter);
					sd.UpdateCommand.Parameters.Add("@iSerial", SqlDbType.BigInt, 8, "iSerial");
					sd.UpdateCommand.Parameters.Add("@vcDeptID", SqlDbType.VarChar, 5, "vcDeptID");
					sd.UpdateCommand.Parameters.Add("@cFlag", SqlDbType.Char, 1, "cFlag");
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
						else//修改同步
						{
							foreach(DataRow dr in dsConsItemSync.Tables[0].Rows)
							{
								if(dr["iSerial"].ToString() == dstmp.Tables["LocaltbConsItem"].Rows[i]["iSerial"].ToString() &&
									dr["vcDeptID"].ToString() == dstmp.Tables["LocaltbConsItem"].Rows[i]["vcDeptID"].ToString())
								{
									dr["cFlag"] = dstmp.Tables["LocaltbConsItem"].Rows[i]["cFlag"];
								}
							}
						}
//						if (dsConsItemSync.Tables[0].Rows.Count>0&&dsConsItemSync.Tables[0].Rows.Count % 300 == 0)
//						{
//							sd.Update(dsConsItemSync.Tables[0]);
//							dsConsItemSync.Tables[0].Clear();
//						}
					}
					sd.Update(dsConsItemSync.Tables[0]);
					dsConsItemSync.Tables[0].Clear();
					sd.Dispose();
					dsConsItemSync.Dispose();
					#endregion
					hsMessage.Add(hsMessage.Count,"更新中心数据：消费明细信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：小票信息...");

					UpdatedCount=0;
					#region 向中心同步本店小票
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [nTRate], [nFee], [nPay], [nBalance], [iIgValue], [vcConsType], [vcOperName], [dtConsDate], [vcDeptID] from tbBill where 1=2",conCenter,tranCenter);
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
					hsMessage.Add(hsMessage.Count,"更新中心数据：小票信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：积分日志信息...");

					UpdatedCount=0;
					#region 向中心同步本店积分日志
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [vcIgType], [iIgLast], [iIgGet], [iIgArrival], [iLinkCons], [dtIgDate], [vcOperName], [vcComments], [vcDeptID] from tbIntegralLog where 1=2",conCenter,tranCenter);
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
					hsMessage.Add(hsMessage.Count,"更新中心数据：积分日志信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：充值信息...");

					UpdatedCount=0;
					#region 向中心同步本店充值
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [nFillFee], [nFillProm], [nFeeLast], [nFeeCur], [dtFillDate], [vcComments], [vcOperName], [vcDeptID] from tbFillFee where 1=2",conCenter,tranCenter);
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
					hsMessage.Add(hsMessage.Count,"更新中心数据：充值信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：营业日志信息...");

					UpdatedCount=0;
					#region 向中心同步本店营业日志
					sd = new SqlDataAdapter();
					sd.SelectCommand = new SqlCommand("select [iSerial], [iAssID], [vcCardID], [vcOperType], [vcOperName], [dtOperDate], [vcComments], [vcDeptID] from tbBusiLog where 1=2",conCenter,tranCenter);
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
					hsMessage.Add(hsMessage.Count,"更新中心数据：营业日志信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：系统错误日志信息...");

					UpdatedCount=0;
					#region 向中心同步本店系统错误日志
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
					hsMessage.Add(hsMessage.Count,"更新中心数据：系统错误日志信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");

					#region  向中心同步ProductionInStorage
					UpdatedCount=Sync(AnchorType.ProductionInStorage,conLocal,conCenter,tranCenter);
					hsMessage.Add(hsMessage.Count,"更新中心数据：生产入库更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					#endregion

					#region  向中心同步SaleCheck
					UpdatedCount=Sync(AnchorType.SaleCheck,conLocal,conCenter,tranCenter);
					hsMessage.Add(hsMessage.Count,"更新中心数据：销售盘点更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
					#endregion

					tranCenter.Commit();

					hsMessage.Add(hsMessage.Count,"--------------------------------");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始转移本地数据至历史表...");
					#region 转移本地数据至历史表
					conLocal.Open();
					sql="insert into tbConsItemHis select * from tbConsItem where dtConsDate<'"+strTransferDate+"' and iSerial not in (select Iserial from tbConsItemHis)";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;					
					cmd.ExecuteNonQuery();

					sql="insert into tbBillHis select * from tbBill where dtConsDate<'"+strTransferDate+"' and iSerial not in (select Iserial from tbBillHis)";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="insert into tbIntegralLogHis select * from tbIntegralLog where dtIgDate<'"+strTransferDate+"' and iSerial not in (select Iserial from tbIntegralLogHis) ";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="insert into tbFillFeeHis select * from tbFillFee where dtFillDate<'"+strTransferDate+"' and iSerial not in (select Iserial from tbFillFeeHis) ";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="insert into tbBusiLogHis select * from tbBusiLog where dtOperDate<'"+strTransferDate+"' and iSerial not in (select Iserial from tbBusiLogHis)";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbConsItem where dtConsDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbBill where dtConsDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbIntegralLog where dtIgDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbFillFee where dtFillDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbBusiLog where dtOperDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();

					sql="delete from tbSysErrorLog where dtErrDate<'"+strTransferDate+"'";
					cmd=new SqlCommand(sql,conLocal);
					cmd.CommandTimeout=600;
					cmd.ExecuteNonQuery();
					conLocal.Close();
					#endregion
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  转移本地数据至历史表成功。");
					hsMessage.Add(hsMessage.Count,"--------------------------------");

					hsMessage.Add(hsMessage.Count,"");
					hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  向中心同步的数据更新成功！");
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
				hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  更新过程中发生意外错误，更新未完全！");
				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
				MessageBox.Show("更新过程中发生意外错误，更新未完全，请重新选择手工更新或重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.sbtnClose.Enabled=true;
				this.pictureBox1.Visible=false;
				this.sbtnUpdate.Enabled=true;
				return;
			}
			conLocal.Close();
			conCenter.Close();
			#endregion

			#region 中心向本本地同步参数等信息
			hsMessage.Add(hsMessage.Count,"--------------------------------");
			hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始加载中心数据库资料...");
			#region 获取中心需要下载的资料，参数信息
			//商品
			sql="select [vcGoodsID],[vcGoodsName],[vcSpell],[nPrice],[nRate],[iIgValue],[cNewFlag],[vcComments],[vcGoodsType] from tbGoods order by vcGoodsID";
			cmd=new SqlCommand(sql,conCenter);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"CentertbGoods");
			//系统参数
			sql="select * from tbCommCode where vcCommSign<>'LOCAL' and vcCommCode<>'CEN00' order by vcCommSign,vcCommCode";
			cmd=new SqlCommand(sql,conCenter);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"CentertbCommCode");
			//中心客户端操作员
            //sql="select * from tbOper where vcDeptID='"+SysInitial.LocalDept+"' or vcDeptID='*' order by vcOperID";
            sql = "select a.UserName as vcOperID,b.FullName as vcOperName,'LM001' as vcLimit,d.Password as vcPwd,c.DeptCode as vcDeptID,'1' as vcActiveFlag,'0' as vcPwdBeginFlag,0 as IsDiscount,d.PasswordSalt as vcPwdSalt from aspnet_Users a left join aspnet_CustomProfile b on a.UserId=b.UserId left join Depts c on b.DeptId=c.DeptId left join aspnet_Membership d on a.UserId=d.UserId where c.DeptCode='" + SysInitial.LocalDept + "' and d.IsApproved=1  and a.UserId in (select UserId from aspnet_UsersInRoles where RoleId in (select RoleId from aspnet_AuthorizationRules where SiteMapKey like '1%') )";
			cmd=new SqlCommand(sql,conCenter);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"CentertbOper");
			//本地客户端操作员
			sql="select * from tbOper order by vcOperID";
			cmd=new SqlCommand(sql,conLocal);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"LocaltbOper");
			//客户端操作员权限
			sql="select * from tbFunc where cnvcFuncType='CS'";
			cmd=new SqlCommand(sql,conCenter);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"CentertbFunc");
			//客户端操作员权限
            sql = "select a.UserName as vcOperID,e.Title as vcFuncName,e.Name as vcFuncAddress from aspnet_Users a left join aspnet_UsersInRoles b on a.UserId=b.UserId left join aspnet_AuthorizationRules c on b.RoleId=c.RoleId left join aspnet_Roles d on c.RoleId=d.RoleId left join aspnet_Sitemaps e on c.SiteMapKey = e.Code left join aspnet_CustomProfile f on a.UserId=f.UserId left join Depts g on f.DeptId=g.DeptId where e.IsClient=1 and g.DeptCode='" + SysInitial.LocalDept + "' group by a.UserName ,e.Title ,e.Name ";
			cmd=new SqlCommand(sql,conCenter);
			cmd.CommandTimeout=600;
			daTmp=new SqlDataAdapter(cmd);
			daTmp.Fill(dstmp,"CentertbOperFunc");
			//通知
			//			sql="select * from tbNotice where vcActiveFlag='2' and dtCreateDate>='"+strBeginDate+"' order by id";
			//			cmd=new SqlCommand(sql,conCenter);
			//			daTmp=new SqlDataAdapter(cmd);
			//			daTmp.Fill(dstmp,"CentertbNotice");
			#endregion
			hsMessage.Add(hsMessage.Count,"加载中心数据库资料成功！");
			hsMessage.Add(hsMessage.Count,"--------------------------------");
			conLocal.Open();
			conCenter.Open();
			try
			{
				using(SqlTransaction tranLocal=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					using(SqlTransaction tranCenter=conCenter.BeginTransaction(IsolationLevel.ReadCommitted))
					{
						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：商品信息...");
						UpdatedCount=0;
						#region 向本地同步中心商品信息
						sqlDeal="";
						for(i=0;i<dstmp.Tables["CentertbGoods"].Rows.Count;i++)
						{
							sqlDeal+="insert into tbGoods values('"+dstmp.Tables["CentertbGoods"].Rows[i]["vcGoodsID"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcGoodsName"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcSpell"].ToString()+"',"+dstmp.Tables["CentertbGoods"].Rows[i]["nPrice"].ToString()+",";
							sqlDeal+=dstmp.Tables["CentertbGoods"].Rows[i]["nRate"].ToString()+","+dstmp.Tables["CentertbGoods"].Rows[i]["iIgValue"].ToString()+",'"+dstmp.Tables["CentertbGoods"].Rows[i]["cNewFlag"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcComments"].ToString()+"','"+dstmp.Tables["CentertbGoods"].Rows[i]["vcGoodsType"].ToString()+"');";
							UpdatedCount++;
						}
						if(sqlDeal!="")
						{
							cmd=new SqlCommand("truncate table tbGoods",conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();

							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();
						}
						#endregion
						hsMessage.Add(hsMessage.Count,"更新本地数据：商品信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
						hsMessage.Add(hsMessage.Count,"--------------------------------");
						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：系统参数信息...");
						UpdatedCount=0;
						#region 向本地同步中心系统参数
						sqlDeal="";
						for(i=0;i<dstmp.Tables["CentertbCommCode"].Rows.Count;i++)
						{
							if(dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommSign"].ToString()!="LOCAL")
							{
								sqlDeal+="insert into tbCommCode values('"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommName"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommCode"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcCommSign"].ToString()+"','"+dstmp.Tables["CentertbCommCode"].Rows[i]["vcComments"].ToString()+"');";
								UpdatedCount++;
							}
						}
						if(sqlDeal!="")
						{
							cmd=new SqlCommand("delete from tbCommCode where vcCommSign<>'LOCAL'",conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();

							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();
						}
						#endregion
						hsMessage.Add(hsMessage.Count,"更新本地数据：系统参数信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
						hsMessage.Add(hsMessage.Count,"--------------------------------");
						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：客户端操作员权限信息...");
						UpdatedCount=0;
						#region 向本地同步客户端操作员权限
						sqlDeal="";
						for(i=0;i<dstmp.Tables["CentertbFunc"].Rows.Count;i++)
						{
							sqlDeal+="insert into tbFunc values('"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncParentName"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"','"+dstmp.Tables["CentertbFunc"].Rows[i]["cnvcFuncType"].ToString()+"');";
							UpdatedCount++;
						}
						if(sqlDeal!="")
						{
							cmd=new SqlCommand("truncate table tbFunc",conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();

							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();
						}

						sqlDeal="";
						for(i=0;i<dstmp.Tables["CentertbOperFunc"].Rows.Count;i++)
						{
							sqlDeal+="insert into tbOperFunc values('"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcOperID"].ToString()+"','"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcFuncName"].ToString()+"','"+dstmp.Tables["CentertbOperFunc"].Rows[i]["vcFuncAddress"].ToString()+"');";
							UpdatedCount++;
						}
						if(sqlDeal!="")
						{
							cmd=new SqlCommand("truncate table tbOperFunc",conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();

							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();
						}
						#endregion
						hsMessage.Add(hsMessage.Count,"更新本地数据：客户端操作员权限信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
						hsMessage.Add(hsMessage.Count,"--------------------------------");
						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：客户端操作员信息...");
						UpdatedCount=0;
						#region 同步客户端操作员
						//将本地密码同步到中心，判断该操作员在中心没有被初始化，并且本地的密码与中心不一样

                        //sqlDeal="";
                        //for(i=0;i<dstmp.Tables["LocaltbOper"].Rows.Count;i++)
                        //{
                        //    for(int j=0;j<dstmp.Tables["CentertbOper"].Rows.Count;j++)
                        //    {
                        //        if(dstmp.Tables["CentertbOper"].Rows[j]["vcPwdBeginFlag"].ToString()=="0"&&dstmp.Tables["CentertbOper"].Rows[j]["vcOperID"].ToString()==dstmp.Tables["LocaltbOper"].Rows[i]["vcOperID"].ToString()&&dstmp.Tables["CentertbOper"].Rows[j]["vcPwd"].ToString()!=dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString())
                        //        {
                        //            sqlDeal += "update tbOper set vcPwd='" + dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString() + "',vcPwdSalt='" + dstmp.Tables["LocaltbOper"].Rows[i]["vcPwdSalt"].ToString() + "' where vcOperID='" + dstmp.Tables["CentertbOper"].Rows[j]["vcOperID"].ToString() + "' and vcDeptID='" + SysInitial.LocalDept + "';";
                        //            dstmp.Tables["CentertbOper"].Rows[j]["vcPwd"]=dstmp.Tables["LocaltbOper"].Rows[i]["vcPwd"].ToString();
                        //        }
                        //    }
                        //}
                        //if(sqlDeal!="")
                        //{
                        //    cmd=new SqlCommand(sqlDeal,conCenter,tranCenter);
                        //    cmd.CommandTimeout=600;
                        //    cmd.ExecuteNonQuery();
                        //}

						//通过上面步骤，本地密码已经更新到中心，根据中心激活的操作员全量同步到本地
                        cmd = new SqlCommand("truncate table tbOper", conLocal, tranLocal);
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
						sqlDeal="";
						for(i=0;i<dstmp.Tables["CentertbOper"].Rows.Count;i++)
						{
							if(dstmp.Tables["CentertbOper"].Rows[i]["vcActiveFlag"].ToString()=="1")
							{
								string strDiscount=dstmp.Tables["CentertbOper"].Rows[i]["IsDiscount"].ToString().ToLower()=="true"?"1":"NULL";
								sqlDeal+="insert into tbOper values('"+dstmp.Tables["CentertbOper"].Rows[i]["vcOperID"].ToString()+"','"
									+dstmp.Tables["CentertbOper"].Rows[i]["vcOperName"].ToString()+"','"+dstmp.Tables["CentertbOper"].Rows[i]["vcLimit"].ToString()+"','"
									+dstmp.Tables["CentertbOper"].Rows[i]["vcPwd"].ToString()+"','"
                                    + SysInitial.LocalDept + "'," + strDiscount + ",'" + dstmp.Tables["CentertbOper"].Rows[i]["vcPwdSalt"].ToString() + "');";
							}
							UpdatedCount++;
						}
						if(sqlDeal!="")
						{
							cmd=new SqlCommand("truncate table tbOper",conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();
	
							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
							cmd.CommandTimeout=600;
							cmd.ExecuteNonQuery();

                            //cmd=new SqlCommand("update tbOper set vcPwdBeginFlag='0' where vcPwdBeginFlag='1' and vcDeptID='"+SysInitial.LocalDept+"'",conCenter,tranCenter);
                            //cmd.CommandTimeout=600;
                            //cmd.ExecuteNonQuery();
						}
						#endregion
						hsMessage.Add(hsMessage.Count,"更新本地数据：客户端操作员信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
						hsMessage.Add(hsMessage.Count,"--------------------------------");
						//						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  开始更新中心数据：通知信息...");
						//						UpdatedCount=0;
						#region 向本地同步中心通知
						//						sqlDeal="";
						//						for(i=0;i<dstmp.Tables["CentertbNotice"].Rows.Count;i++)
						//						{
						//							if(dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()=="all"||dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()==SysInitial.LocalDept)
						//							{
						//								recCount=0;
						//								sql="select count(*) from tbNotice where id="+dstmp.Tables["CentertbNotice"].Rows[i]["id"].ToString();
						//								cmd=new SqlCommand(sql,conLocal,tranLocal);
						//								drr=cmd.ExecuteReader();
						//								drr.Read();
						//								recCount=int.Parse(drr[0].ToString());
						//								drr.Close();
						//
						//								if(recCount==0)
						//								{
						//									sqlDeal+="insert into tbNotice values("+dstmp.Tables["CentertbNotice"].Rows[i]["id"].ToString()+",'"+dstmp.Tables["CentertbNotice"].Rows[i]["vcComments"].ToString()+"','"+dstmp.Tables["CentertbNotice"].Rows[i]["dtCreateDate"].ToString()+"','0','"+dstmp.Tables["CentertbNotice"].Rows[i]["vcDeptFlag"].ToString()+"');";
						//									UpdatedCount++;
						//								}
						//							}
						//						}
						//						if(sqlDeal!="")
						//						{
						//							cmd=new SqlCommand(sqlDeal,conLocal,tranLocal);
						//							cmd.ExecuteNonQuery();
						//						}
						#endregion
						//						hsMessage.Add(hsMessage.Count,"更新本地数据：通知信息更新成功。共更新"+UpdatedCount.ToString()+"条记录.");
						//						hsMessage.Add(hsMessage.Count,"--------------------------------");
						hsMessage.Add(hsMessage.Count,"");
						hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  从中心获取的数据更新成功！");

						tranCenter.Commit();
						tranLocal.Commit();
					}
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
				hsMessage.Add(hsMessage.Count,DateTime.Now.ToLongTimeString()+"  更新过程中发生意外错误，更新未完全！");
				hsMessage.Add(hsMessage.Count,"----------------------------------------------------------------------");
				MessageBox.Show("更新过程中发生意外错误，更新未完全，请重新选择手工更新或重新启动系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				this.sbtnClose.Enabled=true;
				return;
			}
			conLocal.Close();
			conCenter.Close();
			#endregion

			hsMessage.Add(hsMessage.Count,"");
			hsMessage.Add(hsMessage.Count,"所有数据上传成功！");

			Exception err=null;
			SysInitial.CreatDS(out err);
			if(err!=null)
			{
				MessageBox.Show("系统出错，将自动关闭，稍后请重新登录系统！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
                MessageBox.Show("童鞋，同步失败！vpn掉线了或者网速太慢！,请检查vpn连接！");
                return;
            }


            this.sbtnUpdate.Enabled = false;
			threadFin=false;
			threadDown=new Thread(new ThreadStart(UpdateData));
			threadDown.IsBackground = true;
			threadDown.Start();
			this.pictureBox1.Visible=true;
			this.sbtnClose.Enabled=false;
			this.timer1.Start();
		}

		private void sbtnClose_Click(object sender, System.EventArgs e)
		{
			if(threadDown!=null&&threadDown.IsAlive)
			{
				if(DialogResult.Yes != MessageBox.Show(this,"数据同步正在更新，是否关闭？","关闭确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
				{					
					return;			
				}
				threadDown.Abort();
				threadDown = null;		
			}
			this.Close();
		}

		private void frmDataManuUpdate_Load(object sender, System.EventArgs e)
		{
			this.pictureBox1.Visible=false;
			this.dateTimePicker1.Value=DateTime.Today.AddDays(-3);
			this.timer1.Interval=3000;
			this.timer1.Enabled=true;
		}

		private void frmDataManuUpdate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(threadDown!=null&&threadDown.IsAlive)
			{
				if(DialogResult.Yes == MessageBox.Show(this,"数据同步正在更新，是否关闭？","关闭确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
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
