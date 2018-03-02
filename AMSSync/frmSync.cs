using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using cc;
using CMSMData.CMSMDataAccess;

namespace AMSSync
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmSync : System.Windows.Forms.Form
	{
		#region 定义变量
		private System.ComponentModel.IContainer components;
		//注册热键的api 
		[DllImport("user32")] 
		public static extern bool RegisterHotKey(IntPtr hWnd,int id,uint control,Keys vk);
		//注消热键的api 
		[DllImport("user32")] 
		public static extern bool UnregisterHotKey(IntPtr hWnd,int id); 

		private SqlConnection conClient;
        private SqlConnection conCenter;
		private string strDBCenterCon;
		private string strDBClientCon;
		private System.Data.SqlClient.SqlCommand cmd;
		private System.Data.SqlClient.SqlDataReader drr;
		private System.Data.SqlClient.SqlDataAdapter adp;
		private Thread SyncThread;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Timer SyncRefreshTimer;
		private System.Windows.Forms.Timer MainRefreshTimer;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lblRefreshState;
		private System.Windows.Forms.Label lblSyncThreadState;
		private System.Windows.Forms.Label lblSyncPlan; 

		private DataTable dttmp;
		private string strLocalDept;
		private string strLocalDeptSYNCN;
		private string strtmpsql;
		private string strMessage;
		private DataTable dtSyncn;
		private int ClientToCenterCount; //客户端向服务器同步成功记录数
		private int CenterToClientCount; //服务器向客户端同步成功记录数
		private int ClientToCenterZeroCount; //客户端向服务器同步积分清零会员数
		private int CenterToClientZeroCount; //服务器向客户端同步积分清零会员数
		private bool SyncIsThreading; //同步线程是否正在运行标志
		private int NextRefreshSed; //距离下一次刷新的时钟（秒数）
		private int RefreshTimes; //刷新时间间隔（秒数）
		private int WaitTimes; //线程处理过程中各步骤中断时间
		private string SyncPlaning;
		private System.Windows.Forms.Button btClose; //当前同步线程正在同步的内容
		private AutoResetEvent _StopEvent; //线程暂停时件
		#endregion

		#region 构造函数
		public frmSync()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            strDBCenterCon = ConfigAdapter.GetConfigNote("appsettings", "DBCenter");
            strDBClientCon = ConfigAdapter.GetConfigNote("connectionstrings", "DBAMSCM","name","connectionString");
            
			string strdes="";
            string strDesFlag = ConfigAdapter.GetConfigNote("appsettings", "DFLAG");
			if(strDesFlag=="1")
			{		
				DESEncryptor dese=new DESEncryptor();
				dese.InputString=strDBClientCon;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;
				strDBClientCon=strdes;

				dese=new DESEncryptor();
				dese.InputString=strDBCenterCon;
				dese.DecryptKey="cmsmyykx";
				dese.DesDecrypt();
				strdes=dese.OutString;
				dese=null;
				strDBCenterCon=strdes;
			}

            conCenter = new SqlConnection(strDBCenterCon);
            conClient = new SqlConnection(strDBClientCon);


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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSync));
			this.SyncRefreshTimer = new System.Windows.Forms.Timer(this.components);
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.MainRefreshTimer = new System.Windows.Forms.Timer(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblRefreshState = new System.Windows.Forms.Label();
			this.lblSyncThreadState = new System.Windows.Forms.Label();
			this.lblSyncPlan = new System.Windows.Forms.Label();
			this.btClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SyncRefreshTimer
			// 
			this.SyncRefreshTimer.Tick += new System.EventHandler(this.SyncRefreshTimer_Tick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 128);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(688, 280);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// MainRefreshTimer
			// 
			this.MainRefreshTimer.Tick += new System.EventHandler(this.MainRefreshTimer_Tick);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblRefreshState
			// 
			this.lblRefreshState.BackColor = System.Drawing.SystemColors.Control;
			this.lblRefreshState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRefreshState.ForeColor = System.Drawing.Color.DimGray;
			this.lblRefreshState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblRefreshState.Location = new System.Drawing.Point(32, 16);
			this.lblRefreshState.Name = "lblRefreshState";
			this.lblRefreshState.Size = new System.Drawing.Size(256, 56);
			this.lblRefreshState.TabIndex = 1;
			this.lblRefreshState.Text = "定时刷新时钟";
			this.lblRefreshState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSyncThreadState
			// 
			this.lblSyncThreadState.BackColor = System.Drawing.SystemColors.Control;
			this.lblSyncThreadState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSyncThreadState.ForeColor = System.Drawing.Color.DimGray;
			this.lblSyncThreadState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblSyncThreadState.ImageList = this.imageList1;
			this.lblSyncThreadState.Location = new System.Drawing.Point(368, 16);
			this.lblSyncThreadState.Name = "lblSyncThreadState";
			this.lblSyncThreadState.Size = new System.Drawing.Size(240, 56);
			this.lblSyncThreadState.TabIndex = 2;
			this.lblSyncThreadState.Text = "同步线程状态";
			this.lblSyncThreadState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSyncPlan
			// 
			this.lblSyncPlan.BackColor = System.Drawing.SystemColors.Control;
			this.lblSyncPlan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSyncPlan.ForeColor = System.Drawing.Color.Green;
			this.lblSyncPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblSyncPlan.Location = new System.Drawing.Point(24, 88);
			this.lblSyncPlan.Name = "lblSyncPlan";
			this.lblSyncPlan.Size = new System.Drawing.Size(656, 24);
			this.lblSyncPlan.TabIndex = 3;
			this.lblSyncPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(632, 8);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(56, 23);
			this.btClose.TabIndex = 4;
			this.btClose.Text = "隐藏";
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// frmSync
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(704, 410);
			this.ControlBox = false;
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.lblSyncPlan);
			this.Controls.Add(this.lblSyncThreadState);
			this.Controls.Add(this.lblRefreshState);
			this.Controls.Add(this.richTextBox1);
			this.Name = "frmSync";
			this.Text = "会员资料实时同步";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.frmSync_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
            System.Diagnostics.Process[] proSync = System.Diagnostics.Process.GetProcessesByName("AMSSync");
            if (proSync.Length == 1)
            {
                Application.Run(new frmSync());
            }
		}

		#region 窗体加装
		private void frmSync_Load(object sender, System.EventArgs e)
		{
			this.Hide();
			//注册热键(窗体句柄,热键ID,辅助键,实键)
			RegisterHotKey(this.Handle, 123456, 3,Keys.O);

			SyncIsThreading=false;
			NextRefreshSed=0;
#if DEBUG
            RefreshTimes = 5;
#else
            RefreshTimes=60*3;
#endif
			SyncPlaning="";
			WaitTimes=15;
			_StopEvent = new AutoResetEvent(false);
			strMessage="";

			this.MainRefreshTimer.Interval=1000;
			this.MainRefreshTimer.Enabled=true;
			this.MainRefreshTimer.Start();

			this.SyncRefreshTimer.Interval=RefreshTimes*1000;
			this.SyncRefreshTimer.Enabled=true;
			NextRefreshSed=RefreshTimes;
			this.SyncRefreshTimer.Start();
		}
		#endregion

		#region 同步线程监控刷新时钟
		private void SyncRefreshTimer_Tick(object sender, System.EventArgs e)
		{
			NextRefreshSed=0;
			if(!SyncIsThreading&&SyncThread==null)
			{
				strMessage+="实时同步线程启动："+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
				SyncThread=new Thread(new ThreadStart(RealTimeSync));
				SyncThread.IsBackground=true;
				SyncThread.Start();
			}
			else if(!SyncIsThreading&&!SyncThread.IsAlive&&SyncThread.ThreadState!=ThreadState.Running)
			{
				SyncThread=null;
				strMessage+="实时同步线程清除："+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
			}
			NextRefreshSed=RefreshTimes;
		}
		#endregion

		#region 实时同步函数
		private void RealTimeSync()
		{
			//线程开始
			SyncIsThreading=true;
			ClientToCenterCount=0;
			CenterToClientCount=0;
			ClientToCenterZeroCount=0;
			CenterToClientZeroCount=0;
			
			try
			{
				string strSql="";
				string step1time="";
				string step2time="";
				string step3time="";
				string step4time="";
				string step5time="";

				#region 获取本地门店ID和门店标识
				conCenter.Open();
				conClient.Open();
				strSql="select vcCommCode from tbCommCode where vcCommSign='LOCAL'";
				cmd=new SqlCommand(strSql,conClient);
				drr=cmd.ExecuteReader();
				drr.Read();
				strLocalDept=drr[0].ToString();
				drr.Close();

				strSql="select isnull(vcCommName,0) from tbCommCode where vcCommSign='SYNCN' and vcCommCode='"+strLocalDept+"'";
				cmd=new SqlCommand(strSql,conClient);
				drr=cmd.ExecuteReader();
				if(drr.HasRows)
				{
					drr.Read();
					strLocalDeptSYNCN=drr[0].ToString();
					drr.Close();
				}
				else
				{
					throw new Exception("无门店标识，不能同步");
				}

				if(strLocalDeptSYNCN=="")
				{
					throw new Exception("无门店标识，不能同步");
				}

				dtSyncn=new DataTable();
				strSql="select vcCommName,vcCommCode from tbCommCode where vcCommSign='SYNCN' order by cast(vcCommName as bigint) desc";
				adp=new SqlDataAdapter(strSql,conClient);
				adp.Fill(dtSyncn);
				#endregion

				#region 本地向中心同步
				SyncPlaning="正在同步本地数据至数据中心";
				strSql="select * from tbAssociatorSync order by dtOperDate,vcCardID,iSerial";
				adp=new SqlDataAdapter(strSql,conClient);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				if(dttmp.Rows.Count>0)
				{
					foreach(DataRow dr in dttmp.Rows)
					{
						strtmpsql="";
						strtmpsql="'"+dr["vcCardID"].ToString()+"','"+dr["vcAssName"].ToString()+"','"+dr["vcSpell"].ToString()+"','"+dr["vcAssNbr"].ToString()+"','"+dr["vcLinkPhone"].ToString()+"','"+dr["vcLinkAddress"].ToString()+"','";
						strtmpsql+=dr["vcEmail"].ToString()+"','"+dr["vcAssType"].ToString()+"','"+dr["vcAssState"].ToString()+"',"+dr["nCharge"].ToString()+","+dr["iIgValue"].ToString()+",'"+dr["vcCardFlag"].ToString()+"','"+dr["vcComments"].ToString()+"','"+dr["dtCreateDate"].ToString()+"','";
						strtmpsql+=dr["dtOperDate"].ToString()+"','"+dr["vcDeptID"].ToString()+"'";

						strSql="select count(*) from tbAssociator where vcCardID='"+dr["vcCardID"].ToString()+"'";
						cmd=new SqlCommand(strSql,conCenter);
						drr=cmd.ExecuteReader();
						drr.Read();
						if(drr[0].ToString()=="1")
						{
							//服务器上会员已存在，则进行更新操作，只更新状态，余额，积分，操作时间，卡序列号
							drr.Close();
							strSql="update tbAssociator set vcAssName='"+dr["vcAssName"].ToString()+"',vcLinkPhone='"+dr["vcLinkPhone"].ToString()+"',vcLinkAddress='"+dr["vcLinkAddress"].ToString()+"',vcAssType='"+dr["vcAssType"].ToString()+"',vcAssState='"+dr["vcAssState"].ToString()+"',nCharge="+dr["nCharge"].ToString()+",iIgValue="+dr["iIgValue"].ToString()+",dtOperDate='"+dr["dtOperDate"].ToString()+"',vcCardSerial='"+dr["vcCardSerial"].ToString()+"',vcComments='"+dr["vcComments"].ToString()+"' where vcCardID='"+dr["vcCardID"].ToString()+"' and dtCreateDate='"+dr["dtCreateDate"].ToString()+"';";
							strSql+="insert into tbAssociatorSync values("+strtmpsql+",'"+dr["vcCardSerial"].ToString()+"',"+strLocalDeptSYNCN+");";
							strSql+="insert into tbAssociatorLog values(0,"+strtmpsql+",'SYNC','"+strLocalDept+"','"+dr["vcCardSerial"].ToString()+"');";
							cmd=new SqlCommand(strSql,conCenter);
							cmd.ExecuteNonQuery();

							strSql="delete from tbAssociatorSync where vcCardID='"+dr["vcCardID"].ToString()+"' and iSerial="+dr["iSerial"].ToString();
							cmd=new SqlCommand(strSql,conClient);
							cmd.ExecuteNonQuery();
						}
						else
						{
							//服务器上会员不存在，则进行插入操作
							drr.Close();
							strSql="insert into tbAssociator values("+strtmpsql+",'"+dr["vcCardSerial"].ToString()+"');";
							strSql+="insert into tbAssociatorSync values("+strtmpsql+",'"+dr["vcCardSerial"].ToString()+"',"+strLocalDeptSYNCN+");";
							strSql+="insert into tbAssociatorLog values(0,"+strtmpsql+",'SYNC','"+strLocalDept+"','"+dr["vcCardSerial"].ToString()+"');";
							cmd=new SqlCommand(strSql,conCenter);
							cmd.ExecuteNonQuery();

							strSql="delete from tbAssociatorSync where vcCardID='"+dr["vcCardID"].ToString()+"' and iSerial="+dr["iSerial"].ToString();
							cmd=new SqlCommand(strSql,conClient);
							cmd.ExecuteNonQuery();
						}
						ClientToCenterCount++;
					}				
				}
				conClient.Close();
				conCenter.Close();
				step1time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				_StopEvent.WaitOne(WaitTimes * 1000,true);
				#endregion

				#region 中心向本地同步
				SyncPlaning="正在同步数据中心数据至本地";
				conCenter.Open();
				conClient.Open();

				strSql="select * from tbAssociatorSync where iUpdateCount<>"+strLocalDeptSYNCN+" and iUpdateCount<>(select sum(cast(isnull(vcCommName,0) as bigint)) from tbCommCode where vcCommSign='SYNCN') order by vcCardID,iSerial";
				adp=new SqlDataAdapter(strSql,conCenter);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				if(dttmp.Rows.Count>0)
				{
					bool isupdated=false;
					int updateCounttmp=0;
					foreach(DataRow dr in dttmp.Rows)
					{
						updateCounttmp=int.Parse(dr["iUpdateCount"].ToString());
						isupdated=false;
						if(int.Parse(strLocalDeptSYNCN)>updateCounttmp)
						{
							isupdated=false;
						}
						else
						{
							for(int i=0;i<dtSyncn.Rows.Count;i++)
							{
								if(int.Parse(dtSyncn.Rows[i]["vcCommName"].ToString())==updateCounttmp)
								{
									if(dtSyncn.Rows[i]["vcCommCode"].ToString()==strLocalDept)
									{
										isupdated=true;
										break;
									}
									else
									{
										isupdated=false;
										break;
									}
								}
								else if(int.Parse(dtSyncn.Rows[i]["vcCommName"].ToString())<updateCounttmp)
								{
									if(dtSyncn.Rows[i]["vcCommCode"].ToString()==strLocalDept)
									{
										isupdated=true;
										break;
									}
									else
									{
										updateCounttmp=updateCounttmp-int.Parse(dtSyncn.Rows[i]["vcCommName"].ToString());
									}
								}
							}
						}
						if(!isupdated)
						{
							strtmpsql="";
							strtmpsql="'"+dr["vcCardID"].ToString()+"','"+dr["vcAssName"].ToString()+"','"+dr["vcSpell"].ToString()+"','"+dr["vcAssNbr"].ToString()+"','"+dr["vcLinkPhone"].ToString()+"','"+dr["vcLinkAddress"].ToString()+"','";
							strtmpsql+=dr["vcEmail"].ToString()+"','"+dr["vcAssType"].ToString()+"','"+dr["vcAssState"].ToString()+"',"+dr["nCharge"].ToString()+","+dr["iIgValue"].ToString()+",'"+dr["vcCardFlag"].ToString()+"','"+dr["vcComments"].ToString()+"','"+dr["dtCreateDate"].ToString()+"','";
							strtmpsql+=dr["dtOperDate"].ToString()+"','"+dr["vcDeptID"].ToString()+"'";

							strSql="select count(*) from tbAssociator where vcCardID='"+dr["vcCardID"].ToString()+"'";
							cmd=new SqlCommand(strSql,conClient);
							drr=cmd.ExecuteReader();
							drr.Read();
							if(drr[0].ToString()=="1")
							{
								//服务器上会员已存在，则进行更新操作，只更新状态，余额，积分，操作时间，卡序列号
								drr.Close();
								strSql="update tbAssociator set vcAssName='"+dr["vcAssName"].ToString()+"',vcSpell='"+dr["vcSpell"].ToString()+"',vcAssNbr='"+dr["vcAssNbr"].ToString()+"',vcLinkPhone='"+dr["vcLinkPhone"].ToString()+"',vcLinkAddress='"+dr["vcLinkAddress"].ToString()+"',vcEmail='"+dr["vcEmail"].ToString()+"',";
								strSql+="vcAssType='"+dr["vcAssType"].ToString()+"',vcAssState='"+dr["vcAssState"].ToString()+"',nCharge="+dr["nCharge"].ToString()+",iIgValue="+dr["iIgValue"].ToString()+",vcCardFlag='"+dr["vcCardFlag"].ToString()+"',vcComments='"+dr["vcComments"].ToString()+"',";
								strSql+="dtOperDate='"+dr["dtOperDate"].ToString()+"',vcDeptID='"+dr["vcDeptID"].ToString()+"',vcCardSerial='"+dr["vcCardSerial"].ToString()+"' where vcCardID='"+dr["vcCardID"].ToString()+"'";
								cmd=new SqlCommand(strSql,conClient);
								cmd.ExecuteNonQuery();

								strSql="update tbAssociatorSync set iUpdateCount=iUpdateCount+"+strLocalDeptSYNCN+" where vcCardID='"+dr["vcCardID"].ToString()+"' and iSerial="+dr["iSerial"].ToString();
								cmd=new SqlCommand(strSql,conCenter);
								cmd.ExecuteNonQuery();
							}
							else
							{
								//服务器上会员不存在，则进行插入操作
								drr.Close();
								strSql="insert into tbAssociator values("+strtmpsql+",'"+dr["vcCardSerial"].ToString()+"')";
								cmd=new SqlCommand(strSql,conClient);
								cmd.ExecuteNonQuery();

								strSql="update tbAssociatorSync set iUpdateCount=iUpdateCount+"+strLocalDeptSYNCN+" where vcCardID='"+dr["vcCardID"].ToString()+"' and iSerial="+dr["iSerial"].ToString();
								cmd=new SqlCommand(strSql,conCenter);
								cmd.ExecuteNonQuery();
							}
							CenterToClientCount++;
						}
					}
				}
				conClient.Close();
				conCenter.Close();
				step2time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				_StopEvent.WaitOne(WaitTimes * 1000,true);
				#endregion

				#region 积分清零会员同步
				SyncPlaning="正在同步积分清零会员";
				conCenter.Open();
				conClient.Open();

				strSql="select distinct vcCardID from tbSetZero";
				adp=new SqlDataAdapter(strSql,conCenter);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				Hashtable hsZeroCenter=new Hashtable();
				foreach(DataRow drz in dttmp.Rows)
				{
					hsZeroCenter.Add(drz["vcCardID"].ToString(),drz["vcCardID"].ToString());
				}

				strSql="select distinct vcCardID from tbSetZero";
				adp=new SqlDataAdapter(strSql,conClient);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				Hashtable hsZeroLocal=new Hashtable();
				foreach(DataRow drz in dttmp.Rows)
				{
					hsZeroLocal.Add(drz["vcCardID"].ToString(),drz["vcCardID"].ToString());
				}
				
				foreach(object obj in hsZeroLocal.Keys)
				{
					if(!hsZeroCenter.ContainsKey(obj.ToString()))
					{
						strSql="insert into tbSetZero values('"+obj.ToString()+"',getdate())";
						cmd=new SqlCommand(strSql,conCenter);
						cmd.ExecuteNonQuery();
						ClientToCenterZeroCount++;
					}
				}
				step3time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();

				foreach(object obj in hsZeroCenter.Keys)
				{
					if(!hsZeroLocal.ContainsKey(obj.ToString()))
					{
						strSql="insert into tbSetZero values('"+obj.ToString()+"',getdate())";
						cmd=new SqlCommand(strSql,conClient);
						cmd.ExecuteNonQuery();
						CenterToClientZeroCount++;
					}
				}

				conClient.Close();
				conCenter.Close();
				step4time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				_StopEvent.WaitOne(WaitTimes * 1000,true);
				#endregion

				#region 会员补积分信息同步
				SyncPlaning="正在同步会员补积分信息";
				conCenter.Open();
				conClient.Open();

				strSql="select distinct vcCardID from tbAssIgDupMakeUp where iAdded=1";
				adp=new SqlDataAdapter(strSql,conCenter);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				Hashtable hsIgDupCenter=new Hashtable();
				foreach(DataRow drz in dttmp.Rows)
				{
					hsIgDupCenter.Add(drz["vcCardID"].ToString(),drz["vcCardID"].ToString());
				}

				strSql="select distinct vcCardID from tbAssIgDupMakeUp where iAdded=1";
				adp=new SqlDataAdapter(strSql,conClient);
				dttmp=new DataTable();
				adp.Fill(dttmp);
				Hashtable hsIgDupLocal=new Hashtable();
				foreach(DataRow drz in dttmp.Rows)
				{
					hsIgDupLocal.Add(drz["vcCardID"].ToString(),drz["vcCardID"].ToString());
				}
				
				foreach(object obj in hsIgDupLocal.Keys)
				{
					if(!hsIgDupCenter.ContainsKey(obj.ToString()))
					{
						strSql="update tbAssIgDupMakeUp set iAdded=1 where vcCardID='"+obj.ToString()+"' and iAdded=0";
						cmd=new SqlCommand(strSql,conCenter);
						cmd.ExecuteNonQuery();
					}
				}

				foreach(object obj in hsIgDupCenter.Keys)
				{
					if(!hsIgDupLocal.ContainsKey(obj.ToString()))
					{
						strSql="update tbAssIgDupMakeUp set iAdded=1 where vcCardID='"+obj.ToString()+"' and iAdded=0";
						cmd=new SqlCommand(strSql,conClient);
						cmd.ExecuteNonQuery();
					}
				}

				conClient.Close();
				conCenter.Close();
				step5time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				_StopEvent.WaitOne(WaitTimes * 1000,true);
				#endregion

				//同步完成插入日志
				drr.Close();
				conCenter.Open();
				conClient.Open();
				strSql="insert into [tbDataSoftUpdateLog] values ('"+strLocalDept+"','"+ClientToCenterCount.ToString()+"','"+CenterToClientCount.ToString()+"',getDate())";
				cmd=new SqlCommand(strSql,conCenter);
				cmd.ExecuteNonQuery();

				conClient.Close();
				conCenter.Close();
				step2time=DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString();
				_StopEvent.WaitOne(WaitTimes * 1000,true);

				SyncPlaning="同步完成";
				strMessage+="同步完成：\n本次客户端向服务器同步成功数："+ClientToCenterCount.ToString()+"  "+step1time+"\n本次服务器向客户端同步成功数："+CenterToClientCount.ToString()+"  "+step2time+"\n";
				strMessage+="本次客户端向服务器同步积分清零数："+ClientToCenterZeroCount.ToString()+"  "+step3time+"\n本次服务器向客户端同步积分清零数："+CenterToClientZeroCount.ToString()+"  "+step4time+"\n";
				strMessage+="会员补积分信息同步完成。"+"  "+step5time+"\n";
				_StopEvent.WaitOne(WaitTimes * 1000,true);

				//线程结束
				SyncIsThreading=false;
				SyncPlaning="";
			}
			catch(SqlException sqlex)
			{
				if(sqlex.Class==20)
				{
					SyncIsThreading=false;
					strMessage+="出错：\n本次客户端向服务器同步成功数："+ClientToCenterCount.ToString()+"\n本次服务器向客户端同步成功数："+CenterToClientCount.ToString()+"\n";
					strMessage+="实时同步线程数据库无法连接："+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
					strMessage+=sqlex.ToString()+"\n";
				}
				else
				{
					SyncIsThreading=false;
					strMessage+="出错：\n本次客户端向服务器同步成功数："+ClientToCenterCount.ToString()+"\n本次服务器向客户端同步成功数："+CenterToClientCount.ToString()+"\n";
					strMessage+="实时同步线程数据库出错："+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
					strMessage+=sqlex.ToString()+"\n";
				}
			}
			catch(Exception er)
			{
				SyncIsThreading=false;
				strMessage+="出错：\n本次客户端向服务器同步成功数："+ClientToCenterCount.ToString()+"\n本次服务器向客户端同步成功数："+CenterToClientCount.ToString()+"\n";
				strMessage+="实时同步线程出错："+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
				strMessage+=er.ToString()+"\n";
			}
			finally
			{
				SyncPlaning="";
				if(conCenter.State==ConnectionState.Open)
					conCenter.Close();
				if(conClient.State==ConnectionState.Open)
					conClient.Close();
			}
		}
		#endregion

		#region 主进程刷新时钟
		private void MainRefreshTimer_Tick(object sender, System.EventArgs e)
		{
			int meslen=strMessage.Length;
			if(meslen>0)
			{
				this.richTextBox1.Text+=strMessage.Substring(0,meslen);
				this.richTextBox1.Select(this.richTextBox1.Text.Length,0);
				strMessage=strMessage.Substring(meslen,strMessage.Length-meslen);
			}
			if(this.richTextBox1.Text.Length>5000)
			{
				this.richTextBox1.Text=this.richTextBox1.Text.Substring(4000,this.richTextBox1.Text.Length-4000);
				this.richTextBox1.Select(this.richTextBox1.Text.Length,0);
			}

			if(NextRefreshSed>0)
			{
				NextRefreshSed--;
				this.lblRefreshState.Text="定时刷新时钟: "+NextRefreshSed+" 秒";
			}
			else
			{
				this.lblRefreshState.Text="定时刷新时钟: 刷新ing......";
			}
			if(SyncIsThreading)
			{
				this.lblSyncThreadState.ImageIndex=0;
			}
			else if(!SyncIsThreading&&SyncThread==null)
			{
				this.lblSyncThreadState.ImageIndex=2;
			}
			else if(!SyncIsThreading&&!SyncThread.IsAlive&&SyncThread.ThreadState!=ThreadState.Running)
			{
				this.lblSyncThreadState.ImageIndex=1;
			}
			this.lblSyncPlan.Text=SyncPlaning;
		}
		#endregion

		#region 其它事件
		private void frmSync_Closed(object sender, EventArgs e)
		{
			//注消热键(句柄,热键ID)
			UnregisterHotKey(this.Handle, 123456);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x0312:    //这个是window消息定义的   注册的热键消息 
					if (m.WParam.ToString().Equals("123456"))  //如果是我们注册的那个热键 
						this.Show();
					break;
			}
			base.WndProc(ref m);
		}

		private void btClose_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		#endregion
	}
}
