using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using CMSMData;
using CMSMData.CMSMDataAccess;
using System.IO;
using System.Net.NetworkInformation;

namespace CMSM.CMSMApp
{
	/// <summary>
	/// Summary description for frmAfterStartDown.
	/// </summary>
	public class frmAfterStartDown : CMSM.CMSMApp.frmBase
    {
		private System.ComponentModel.IContainer components;
        private System.Windows.Forms.RichTextBox richTextBox1;

		private string strMessage;
		private bool SyncIsThreading; //线程是否正在运行标志
        private System.Windows.Forms.Timer timerMessage;
        private Button sbtnTryAgain;
        private Button sbtnExit;
        private Button sbtnEnter;
		private Thread ParaFuncThread;

		public frmAfterStartDown()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sbtnTryAgain = new System.Windows.Forms.Button();
            this.sbtnExit = new System.Windows.Forms.Button();
            this.sbtnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerMessage
            // 
            this.timerMessage.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(32, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(573, 311);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // sbtnTryAgain
            // 
            this.sbtnTryAgain.Location = new System.Drawing.Point(90, 368);
            this.sbtnTryAgain.Name = "sbtnTryAgain";
            this.sbtnTryAgain.Size = new System.Drawing.Size(75, 23);
            this.sbtnTryAgain.TabIndex = 27;
            this.sbtnTryAgain.Text = "重试";
            this.sbtnTryAgain.UseVisualStyleBackColor = true;
            this.sbtnTryAgain.Click += new System.EventHandler(this.sbtnTryAgain_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Location = new System.Drawing.Point(267, 368);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(75, 23);
            this.sbtnExit.TabIndex = 28;
            this.sbtnExit.Text = "退出系统";
            this.sbtnExit.UseVisualStyleBackColor = true;
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEnter
            // 
            this.sbtnEnter.Location = new System.Drawing.Point(448, 368);
            this.sbtnEnter.Name = "sbtnEnter";
            this.sbtnEnter.Size = new System.Drawing.Size(75, 23);
            this.sbtnEnter.TabIndex = 29;
            this.sbtnEnter.Text = "进入系统";
            this.sbtnEnter.UseVisualStyleBackColor = true;
            this.sbtnEnter.Click += new System.EventHandler(this.sbtnEnter_Click);
            // 
            // frmAfterStartDown
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(634, 408);
            this.ControlBox = false;
            this.Controls.Add(this.sbtnEnter);
            this.Controls.Add(this.sbtnExit);
            this.Controls.Add(this.sbtnTryAgain);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAfterStartDown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刷新数据";
            this.Load += new System.EventHandler(this.frmAfterStartDown_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmAfterStartDown_Load(object sender, System.EventArgs e)
		{
			this.sbtnEnter.Enabled=false;
			this.sbtnExit.Enabled=false;
			this.sbtnTryAgain.Enabled=false;
			this.timerMessage.Interval=3000;
			this.timerMessage.Enabled=true;
			this.timerMessage.Start();
			ParaFuncThread=new Thread(new ThreadStart(SystemStartParaDownLoad));
			ParaFuncThread.IsBackground=true;
			ParaFuncThread.Start();
		}


		#region 下载最新系统参数函数内容
		private void SystemStartParaDownLoad()
		{
			strMessage="正在连接网络，进行系统参数更新，请稍后......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

            Ping ping = new Ping();
            PingReply pr = ping.Send("10.10.10.203");
            if (pr.Status != IPStatus.Success)
            {
                strMessage += "童鞋！vpn掉线了或者网速太慢！,请检查vpn连接！" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\n";
                return;
            }

			SyncIsThreading=true;
			Hashtable htout=new Hashtable();
			DataSet dstmp=new DataSet();
			SqlCommand cmd;
			SqlDataAdapter daTmp;
			bool netopen=false;
			SqlConnection conCenter=new SqlConnection(SysInitial.CenterConString);
			SqlConnection conLocal=new SqlConnection(SysInitial.ConString);
			try
			{
				string sql;
				conCenter.Open();
				strMessage+="连接AS成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
				conLocal.Open();
				strMessage+="连接AC成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
				netopen=true;
				sql="select * from tbCommCode where vcCommSign<>'LOCAL'";
				cmd=new SqlCommand(sql,conCenter);
				cmd.CommandTimeout=120;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"CenCommCode");
				strMessage+="加载基本参数表成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

                sql = "SELECT [cnvcHddSerialNo],[cnvcRegister],[cnvcDeptName],[cnvcOperName],[cndOperDate]  FROM [tbRegister]";
                cmd = new SqlCommand(sql, conCenter);
                cmd.CommandTimeout = 120;
                daTmp = new SqlDataAdapter(cmd);
                daTmp.Fill(dstmp, "CenRegister");

                //中心客户端操作员
                sql = "select a.UserName as vcOperID,b.FullName as vcOperName,'LM001' as vcLimit,d.Password as vcPwd,c.DeptCode as vcDeptID,'1' as vcActiveFlag,'0' as vcPwdBeginFlag,0 as IsDiscount,d.PasswordSalt as vcPwdSalt from aspnet_Users a left join aspnet_CustomProfile b on a.UserId=b.UserId left join Depts c on b.DeptId=c.DeptId left join aspnet_Membership d on a.UserId=d.UserId where c.DeptCode='" + SysInitial.LocalDept + "' and d.IsApproved=1  and a.UserId in (select UserId from aspnet_UsersInRoles where RoleId in (select RoleId from aspnet_AuthorizationRules where SiteMapKey like '1%') )";
                cmd = new SqlCommand(sql, conCenter);
                cmd.CommandTimeout = 600;
                daTmp = new SqlDataAdapter(cmd);
                daTmp.Fill(dstmp, "CentertbOper");

				sql="select * from tbFunc";
				cmd=new SqlCommand(sql,conCenter);
				cmd.CommandTimeout=120;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"CenFunc");
				strMessage+="加载功能列表成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

                //sql="select * from tbOperFunc where vcFuncAddress in(select cnvcFuncAddress from tbFunc where cnvcFuncType='CS')";
                sql = "select a.UserName as vcOperID,e.Title as vcFuncName,e.Name as vcFuncAddress from aspnet_Users a left join aspnet_UsersInRoles b on a.UserId=b.UserId left join aspnet_AuthorizationRules c on b.RoleId=c.RoleId left join aspnet_Roles d on c.RoleId=d.RoleId left join aspnet_Sitemaps e on c.SiteMapKey = e.Code left join aspnet_CustomProfile f on a.UserId=f.UserId left join Depts g on f.DeptId=g.DeptId where e.IsClient=1 and g.DeptCode='" + SysInitial.LocalDept + "' group by a.UserName ,e.Title ,e.Name ";
				cmd=new SqlCommand(sql,conCenter);
				cmd.CommandTimeout=120;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"CenOperFunc");
				strMessage+="加载操作员权限成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

				sql="select * from tbAssIgDupMakeUp";
				cmd=new SqlCommand(sql,conCenter);
				cmd.CommandTimeout=120;
				daTmp=new SqlDataAdapter(cmd);
				daTmp.Fill(dstmp,"CenAssIgDupMakeUp");
                //strMessage+="加载中心会员补积分信息成功......"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
				strMessage+="--------------------------------------------\n";

				string strsql="";
				int i=0;
				#region 更新tbCommCode
				using(SqlTransaction trans=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					strsql="delete from tbCommCode where vcCommSign<>'LOCAL'";
					cmd=new SqlCommand(strsql,conLocal,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenCommCode"].Rows.Count;i++)
					{
						strsql+="insert into tbCommCode values('"+dstmp.Tables["CenCommCode"].Rows[i]["vcCommName"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["vcCommCode"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["vcCommSign"].ToString()+"','"+dstmp.Tables["CenCommCode"].Rows[i]["vcComments"].ToString()+"'); ";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,conLocal,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				strMessage+="基本参数更新成功！"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
                #endregion

                #region 更新tbOper
                using (SqlTransaction trans = conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    strsql = "";
                    strsql = "truncate table tbOper";
                    cmd = new SqlCommand(strsql, conLocal, trans);
                    cmd.ExecuteNonQuery();

                    strsql = "";
                    for (i = 0; i < dstmp.Tables["CentertbOper"].Rows.Count; i++)
                    {
                        strsql += "insert into tbOper values('" + dstmp.Tables["CentertbOper"].Rows[i]["vcOperID"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["vcOperName"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["vcLimit"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["vcPwd"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["vcDeptID"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["isDiscount"].ToString() + "','" + dstmp.Tables["CentertbOper"].Rows[i]["vcPwdSalt"].ToString() + "');";
                    }
                    if (strsql != "")
                    {
                        cmd = new SqlCommand(strsql, conLocal, trans);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                strMessage += "操作员更新成功！" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\n";
                #endregion

                #region 更新tbFunc
                using (SqlTransaction trans=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					strsql="";
					strsql="truncate table tbFunc";
					cmd=new SqlCommand(strsql,conLocal,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenFunc"].Rows.Count;i++)
					{
						strsql+="insert into tbFunc values('"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncName"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncParentName"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncAddress"].ToString()+"','"+dstmp.Tables["CenFunc"].Rows[i]["cnvcFuncType"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,conLocal,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				#endregion

                #region 更新[tbRegister]
                using (SqlTransaction trans = conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    strsql = "";
                    strsql = "truncate table tbRegister";
                    cmd = new SqlCommand(strsql, conLocal, trans);
                    cmd.ExecuteNonQuery();
                    strsql = "";
                    for (i = 0; i < dstmp.Tables["CenRegister"].Rows.Count; i++)
                    {
                        strsql += "insert into tbRegister values('" + dstmp.Tables["CenRegister"].Rows[i]["cnvcHddSerialNo"].ToString() + "','" + dstmp.Tables["CenRegister"].Rows[i]["cnvcRegister"].ToString() + "','" + dstmp.Tables["CenRegister"].Rows[i]["cnvcDeptName"].ToString() + "','" + dstmp.Tables["CenRegister"].Rows[i]["cnvcOperName"].ToString() + "','" + dstmp.Tables["CenRegister"].Rows[i]["cndOperDate"].ToString() + "');";
                    }
                    if (strsql != "")
                    {
                        cmd = new SqlCommand(strsql, conLocal, trans);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                #endregion

				#region 更新tbOperFunc
				using(SqlTransaction trans=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
				{
					strsql="";
					strsql="truncate table tbOperFunc";
					cmd=new SqlCommand(strsql,conLocal,trans);
					cmd.ExecuteNonQuery();

					strsql="";
					for(i=0;i<dstmp.Tables["CenOperFunc"].Rows.Count;i++)
					{
						strsql+="insert into tbOperFunc values('"+dstmp.Tables["CenOperFunc"].Rows[i]["vcOperID"].ToString()+"','"+dstmp.Tables["CenOperFunc"].Rows[i]["vcFuncName"].ToString()+"','"+dstmp.Tables["CenOperFunc"].Rows[i]["vcFuncAddress"].ToString()+"');";
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,conLocal,trans);
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
                strMessage += "操作员权限更新成功！" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\n";
				#endregion

				#region 更新tbAssIgDupMakeUp
				using(SqlTransaction trans=conLocal.BeginTransaction(IsolationLevel.ReadCommitted))
				{

					sql="select * from tbAssIgDupMakeUp";
					cmd=new SqlCommand(sql,conLocal,trans);
					cmd.CommandTimeout=120;
					daTmp=new SqlDataAdapter(cmd);
					daTmp.Fill(dstmp,"LocalAssIgDupMakeUp");

					DataTable dtLA = dstmp.Tables["LocalAssIgDupMakeUp"];

					strsql="";
					for(i=0;i<dstmp.Tables["CenAssIgDupMakeUp"].Rows.Count;i++)
					{
//						string strsqlqu="select count(*) from tbAssIgDupMakeUp where vcCardID='"+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["vcCardID"].ToString()+"'";
//						cmd=new SqlCommand(strsqlqu,conLocal,trans);
//						cmd.CommandTimeout=1200;
//						drr=cmd.ExecuteReader();
//						drr.Read();

						DataRow[] drLAs = dtLA.Select("vcCardID='"+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["vcCardID"].ToString()+"'");
						//if(drr[0].ToString()=="0")
						if(drLAs.Length==0)
						{
							strsql+="insert into tbAssIgDupMakeUp values('"+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["vcCardID"].ToString()+"',"+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["iIgArrival"].ToString()+","+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["iIgGet"].ToString()+","+dstmp.Tables["CenAssIgDupMakeUp"].Rows[i]["iAdded"].ToString()+");";
						}
						//drr.Close();
					}
					if(strsql!="")
					{
						cmd=new SqlCommand(strsql,conLocal,trans);
						cmd.CommandTimeout=1200;
						cmd.ExecuteNonQuery();
					}

					trans.Commit();
				}
				#endregion

                //strMessage+="会员补积分信息更新成功！"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

				strMessage+="--------------------------------------------\n";
				strMessage+="所有必要参数全部更新成功！"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";

				strMessage+="--------------------------------------------\n";
                strMessage += "------------客户QQ：349419637---------- \n";
                strMessage += "--------------------------------------------\n";
                strMessage += "----------昆明道讯科技有限公司---------- \n";

				conLocal.Close();
				conCenter.Close();

				SyncIsThreading=false;

				if(File.Exists(Application.StartupPath+@"\BatchScript.bat"))
				{
					File.Delete(Application.StartupPath+@"\BatchScript.bat");
				}
				if(File.Exists(Application.StartupPath+@"\Script.sql"))
				{
					File.Delete(Application.StartupPath+@"\Script.sql");
				}
			}
			catch(Exception err)
			{
				if(conCenter.State==ConnectionState.Open)
				{
					conCenter.Close();
				}
				if(conLocal.State==ConnectionState.Open)
				{
					conLocal.Close();
				}
				if(!netopen)
				{
					strMessage+="--------------------------------------------\n";
					strMessage+="《vpn》网络不通或其它原因，无法连接服务器！"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
//					strMessage+=err.ToString()+"\n";
					strMessage+="--------------------------------------------\n";
					strMessage+="----------昆明道讯科技有限公司---------- \n";
				}
				else
				{
					strMessage+="--------------------------------------------\n";
					strMessage+="更新系统参数时发生错误！"+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n";
					strMessage+=err.ToString()+"\n";
					strMessage+="--------------------------------------------\n";
					strMessage+="----------昆明道讯科技有限公司---------- \n";
				}
				SyncIsThreading=false;
				return;
			}
		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
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

			if(!SyncIsThreading&&!ParaFuncThread.IsAlive&&ParaFuncThread.ThreadState!=ThreadState.Running)
			{
				this.sbtnTryAgain.Enabled=true;
				this.sbtnEnter.Enabled=true;
				this.sbtnExit.Enabled=true;
			}
		}

        private void sbtnTryAgain_Click(object sender, EventArgs e)
        {
            this.sbtnEnter.Enabled = false;
            this.sbtnExit.Enabled = false;
            this.sbtnTryAgain.Enabled = false;
            ParaFuncThread = new Thread(new ThreadStart(SystemStartParaDownLoad));
            ParaFuncThread.IsBackground = true;
            ParaFuncThread.Start();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            SysInitial.strTmp = "ExitApp";
            this.Close();
        }

        private void sbtnEnter_Click(object sender, EventArgs e)
        {
            SysInitial.strTmp = "EnterSys";
            this.Close();
        }
	}
}
