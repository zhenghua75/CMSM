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
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class frmSync : System.Windows.Forms.Form
	{
		#region �������
		private System.ComponentModel.IContainer components;
		//ע���ȼ���api 
		[DllImport("user32")] 
		public static extern bool RegisterHotKey(IntPtr hWnd,int id,uint control,Keys vk);
		//ע���ȼ���api 
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
		private int ClientToCenterCount; //�ͻ����������ͬ���ɹ���¼��
		private int CenterToClientCount; //��������ͻ���ͬ���ɹ���¼��
		private int ClientToCenterZeroCount; //�ͻ����������ͬ�����������Ա��
		private int CenterToClientZeroCount; //��������ͻ���ͬ�����������Ա��
		private bool SyncIsThreading; //ͬ���߳��Ƿ��������б�־
		private int NextRefreshSed; //������һ��ˢ�µ�ʱ�ӣ�������
		private int RefreshTimes; //ˢ��ʱ������������
		private int WaitTimes; //�̴߳�������и������ж�ʱ��
		private string SyncPlaning;
		private System.Windows.Forms.Button btClose; //��ǰͬ���߳�����ͬ��������
		private AutoResetEvent _StopEvent; //�߳���ͣʱ��
		#endregion

		#region ���캯��
		public frmSync()
		{
			//
			// Windows ���������֧���������
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.lblRefreshState.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRefreshState.ForeColor = System.Drawing.Color.DimGray;
			this.lblRefreshState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblRefreshState.Location = new System.Drawing.Point(32, 16);
			this.lblRefreshState.Name = "lblRefreshState";
			this.lblRefreshState.Size = new System.Drawing.Size(256, 56);
			this.lblRefreshState.TabIndex = 1;
			this.lblRefreshState.Text = "��ʱˢ��ʱ��";
			this.lblRefreshState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSyncThreadState
			// 
			this.lblSyncThreadState.BackColor = System.Drawing.SystemColors.Control;
			this.lblSyncThreadState.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSyncThreadState.ForeColor = System.Drawing.Color.DimGray;
			this.lblSyncThreadState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblSyncThreadState.ImageList = this.imageList1;
			this.lblSyncThreadState.Location = new System.Drawing.Point(368, 16);
			this.lblSyncThreadState.Name = "lblSyncThreadState";
			this.lblSyncThreadState.Size = new System.Drawing.Size(240, 56);
			this.lblSyncThreadState.TabIndex = 2;
			this.lblSyncThreadState.Text = "ͬ���߳�״̬";
			this.lblSyncThreadState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSyncPlan
			// 
			this.lblSyncPlan.BackColor = System.Drawing.SystemColors.Control;
			this.lblSyncPlan.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
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
			this.btClose.Text = "����";
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
			this.Text = "��Ա����ʵʱͬ��";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.frmSync_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
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

		#region �����װ
		private void frmSync_Load(object sender, System.EventArgs e)
		{
			this.Hide();
			//ע���ȼ�(������,�ȼ�ID,������,ʵ��)
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

		#region ͬ���̼߳��ˢ��ʱ��
		private void SyncRefreshTimer_Tick(object sender, System.EventArgs e)
		{
			NextRefreshSed=0;
			if(!SyncIsThreading&&SyncThread==null)
			{
				strMessage+="ʵʱͬ���߳�������"+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
				SyncThread=new Thread(new ThreadStart(RealTimeSync));
				SyncThread.IsBackground=true;
				SyncThread.Start();
			}
			else if(!SyncIsThreading&&!SyncThread.IsAlive&&SyncThread.ThreadState!=ThreadState.Running)
			{
				SyncThread=null;
				strMessage+="ʵʱͬ���߳������"+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
			}
			NextRefreshSed=RefreshTimes;
		}
		#endregion

		#region ʵʱͬ������
		private void RealTimeSync()
		{
			//�߳̿�ʼ
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

				#region ��ȡ�����ŵ�ID���ŵ��ʶ
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
					throw new Exception("���ŵ��ʶ������ͬ��");
				}

				if(strLocalDeptSYNCN=="")
				{
					throw new Exception("���ŵ��ʶ������ͬ��");
				}

				dtSyncn=new DataTable();
				strSql="select vcCommName,vcCommCode from tbCommCode where vcCommSign='SYNCN' order by cast(vcCommName as bigint) desc";
				adp=new SqlDataAdapter(strSql,conClient);
				adp.Fill(dtSyncn);
				#endregion

				#region ����������ͬ��
				SyncPlaning="����ͬ��������������������";
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
							//�������ϻ�Ա�Ѵ��ڣ�����и��²�����ֻ����״̬�������֣�����ʱ�䣬�����к�
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
							//�������ϻ�Ա�����ڣ�����в������
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

				#region �����򱾵�ͬ��
				SyncPlaning="����ͬ��������������������";
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
								//�������ϻ�Ա�Ѵ��ڣ�����и��²�����ֻ����״̬�������֣�����ʱ�䣬�����к�
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
								//�������ϻ�Ա�����ڣ�����в������
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

				#region ���������Աͬ��
				SyncPlaning="����ͬ�����������Ա";
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

				#region ��Ա��������Ϣͬ��
				SyncPlaning="����ͬ����Ա��������Ϣ";
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

				//ͬ����ɲ�����־
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

				SyncPlaning="ͬ�����";
				strMessage+="ͬ����ɣ�\n���οͻ����������ͬ���ɹ�����"+ClientToCenterCount.ToString()+"  "+step1time+"\n���η�������ͻ���ͬ���ɹ�����"+CenterToClientCount.ToString()+"  "+step2time+"\n";
				strMessage+="���οͻ����������ͬ��������������"+ClientToCenterZeroCount.ToString()+"  "+step3time+"\n���η�������ͻ���ͬ��������������"+CenterToClientZeroCount.ToString()+"  "+step4time+"\n";
				strMessage+="��Ա��������Ϣͬ����ɡ�"+"  "+step5time+"\n";
				_StopEvent.WaitOne(WaitTimes * 1000,true);

				//�߳̽���
				SyncIsThreading=false;
				SyncPlaning="";
			}
			catch(SqlException sqlex)
			{
				if(sqlex.Class==20)
				{
					SyncIsThreading=false;
					strMessage+="����\n���οͻ����������ͬ���ɹ�����"+ClientToCenterCount.ToString()+"\n���η�������ͻ���ͬ���ɹ�����"+CenterToClientCount.ToString()+"\n";
					strMessage+="ʵʱͬ���߳����ݿ��޷����ӣ�"+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
					strMessage+=sqlex.ToString()+"\n";
				}
				else
				{
					SyncIsThreading=false;
					strMessage+="����\n���οͻ����������ͬ���ɹ�����"+ClientToCenterCount.ToString()+"\n���η�������ͻ���ͬ���ɹ�����"+CenterToClientCount.ToString()+"\n";
					strMessage+="ʵʱͬ���߳����ݿ����"+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
					strMessage+=sqlex.ToString()+"\n";
				}
			}
			catch(Exception er)
			{
				SyncIsThreading=false;
				strMessage+="����\n���οͻ����������ͬ���ɹ�����"+ClientToCenterCount.ToString()+"\n���η�������ͻ���ͬ���ɹ�����"+CenterToClientCount.ToString()+"\n";
				strMessage+="ʵʱͬ���̳߳���"+DateTime.Now.ToShortDateString() +" "+DateTime.Now.ToLongTimeString()+"\n";
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

		#region ������ˢ��ʱ��
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
				this.lblRefreshState.Text="��ʱˢ��ʱ��: "+NextRefreshSed+" ��";
			}
			else
			{
				this.lblRefreshState.Text="��ʱˢ��ʱ��: ˢ��ing......";
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

		#region �����¼�
		private void frmSync_Closed(object sender, EventArgs e)
		{
			//ע���ȼ�(���,�ȼ�ID)
			UnregisterHotKey(this.Handle, 123456);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x0312:    //�����window��Ϣ�����   ע����ȼ���Ϣ 
					if (m.WParam.ToString().Equals("123456"))  //���������ע����Ǹ��ȼ� 
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
